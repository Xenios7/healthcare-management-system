import React, { useEffect, useState, useMemo, JSX } from "react";
import {
  View,
  Text,
  StyleSheet,
  Image,
  ScrollView,
  TouchableOpacity,
  LayoutChangeEvent,
} from "react-native";
import {
  MaterialIcons,
  MaterialCommunityIcons,
  FontAwesome,
} from "@expo/vector-icons";
import { SafeAreaView } from "react-native-safe-area-context";
import { router, useLocalSearchParams, usePathname } from "expo-router";

import { theme } from "../../styles/theme";
import { API_BASE_URL } from "./Api_Base_Url";

import { TabsContainer } from "@/components/ui/tabsContainer";
import { DaysContainer } from "@/components/ui/daysContainer";

type PatientCard = {
  id: number;
  name: string;
  age: number | null;
  ward: string;
  bed: string;
  daysInWard: number;
};

const chartBars = [
  { label: "09:00", value: 40 },
  { label: "10:00", value: 80 },
  { label: "11:00", value: 65 },
  { label: "12:00", value: 50 },
  { label: "13:00", value: 90 },
  { label: "14:00", value: 70 },
];

const arterialRow = {
  dateTime: "2015-04-22 12:09 pm",
  pH: "213",
  hco3: "123",
  paco2: "123",
  pao2: "231",
  sao2: "321",
};

const arterialRow2 = {
  dateTime: "2015-04-22 12:09 pm",
  pH: "220",
  hco3: "128",
  paco2: "123",
  pao2: "237",
  sao2: "319",
};

const CHART_HEIGHT = 220;
const CHART_TOP_PADDING = 10;
const CHART_BOTTOM_PADDING = 26;

function getStr(value: any, fallback: string): string {
  if (Array.isArray(value)) return value[0] ?? fallback;
  if (typeof value === "string") return value;
  return fallback;
}

type DayDef = { day: string; date: string; month: string };

function buildDays(): DayDef[] {
  const today = new Date();
  today.setHours(0, 0, 0, 0);

  const start = new Date(today);
  start.setDate(start.getDate() - 30); // 30 μέρες ΠΙΣΩ

  const totalDays = 61; // 30 πίσω + σήμερα + 30 μπροστά
  const days: DayDef[] = [];

  for (let i = 0; i < totalDays; i++) {
    const d = new Date(start);
    d.setDate(start.getDate() + i);

    days.push({
      day: d.toLocaleDateString(undefined, { weekday: "short" }),
      date: d.getDate().toString().padStart(2, "0"),
      month: d.toLocaleDateString(undefined, { month: "short" }),
    });
  }

  return days;
}

export default function Inpatient2Screen() {
  const params = useLocalSearchParams();
  const pathname = usePathname();

  const [lastSynced, setLastSynced] = useState("");
  const [selectedDay, setSelectedDay] = useState(
    () => new Date().getDate().toString().padStart(2, "0")
  );
  const [patient, setPatient] = useState<PatientCard | null>(null);
  const [chartWidth, setChartWidth] = useState(0);

  const tabs = [
    "Daily monitoring",
    "Medication",
    "Nutrition Intake",
    "Appointments",
  ];

  const days = useMemo(buildDays, []);

  useEffect(() => {
    const now = new Date();
    setLastSynced(
      `${now.toLocaleDateString()} , ${now.toLocaleTimeString([], {
        hour: "2-digit",
        minute: "2-digit",
      })}`
    );
  }, []);

  const paramPatient: PatientCard = (() => {
    try {
      const p: any = params;

      const idStr = getStr(p.patientId ?? p.id, "1");
      const name = getStr(p.name, "Test Patient2");
      const ageStr = getStr(p.age, "");
      const ward = getStr(p.ward, "WARD - 1");
      const bed = getStr(p.bed, "101");
      const daysStr = getStr(p.daysInWard, "88");

      return {
        id: Number(idStr) || 1,
        name,
        age: ageStr ? Number(ageStr) : 66,
        ward,
        bed,
        daysInWard: Number(daysStr) || 88,
      };
    } catch (e) {
      return {
        id: 1,
        name: "Test Patient2",
        age: 66,
        ward: "WARD - 1",
        bed: "101",
        daysInWard: 88,
      };
    }
  })();

  useEffect(() => {
    const loadPatient = async () => {
      try {
        setPatient(paramPatient);

        const url = `${API_BASE_URL}/api/Patients/${paramPatient.id}`;
        const res = await fetch(url);

        if (!res.ok) {
          return;
        }

        const data = (await res.json()) as PatientCard;
        setPatient(data);
      } catch (e) {}
    };

    loadPatient();
  }, [paramPatient.id]);

  const effectivePatient = patient ?? paramPatient;

  const navParams = {
    patientId: String(effectivePatient.id),
    name: effectivePatient.name,
    age: effectivePatient.age != null ? String(effectivePatient.age) : "",
    ward: effectivePatient.ward,
    bed: effectivePatient.bed,
    daysInWard: String(effectivePatient.daysInWard),
  };

  const selectedTab = useMemo(() => {
    if (pathname.startsWith("/inpatient2")) return "Daily monitoring";
    if (pathname.startsWith("/inpatient3")) return "Medication";
    if (pathname.startsWith("/inpatient4")) return "Nutrition Intake";
    if (pathname.startsWith("/inpatient5")) return "Appointments";
    return "Daily monitoring";
  }, [pathname]);

  const handleSelectTab = (tab: string) => {
    if (!navParams) return;

    switch (tab) {
      case "Daily monitoring":
        router.push({
          pathname: "/inpatient2",
          params: navParams,
        });
        break;
      case "Medication":
        router.push({
          pathname: "/inpatient3",
          params: navParams,
        });
        break;
      case "Nutrition Intake":
        router.push({
          pathname: "/inpatient4",
          params: navParams,
        });
        break;
      case "Appointments":
        router.push({
          pathname: "/inpatient5",
          params: navParams,
        });
        break;
    }
  };

  const maxBarValue = Math.max(...chartBars.map((bar) => bar.value));
  const usableHeight =
    CHART_HEIGHT - CHART_TOP_PADDING - CHART_BOTTOM_PADDING;

  const handleChartLayout = (event: LayoutChangeEvent) => {
    setChartWidth(event.nativeEvent.layout.width);
  };

  let lineSegments: JSX.Element[] = [];
  if (chartWidth > 0 && chartBars.length > 1) {
    const xStep = chartWidth / chartBars.length;

    const points = chartBars.map((bar, index) => {
      const normalizedHeight =
        (bar.value / maxBarValue) *
        (usableHeight <= 0 ? 1 : usableHeight);
      const x = xStep * index + xStep / 2;
      const y =
        CHART_HEIGHT - CHART_BOTTOM_PADDING - (normalizedHeight || 0);
      return { x, y };
    });

    for (let i = 0; i < points.length - 1; i++) {
      const p1 = points[i];
      const p2 = points[i + 1];
      const dx = p2.x - p1.x;
      const dy = p2.y - p1.y;
      const distance = Math.sqrt(dx * dx + dy * dy) || 1;
      const angle = Math.atan2(dy, dx);
      const cx = (p1.x + p2.x) / 2;
      const cy = (p1.y + p2.y) / 2;

      lineSegments.push(
        <View
          key={`seg-${i}`}
          style={{
            position: "absolute",
            left: cx - distance / 2,
            top: cy - 1,
            width: distance,
            height: 2,
            backgroundColor: "#8EC9FF",
            transform: [{ rotate: `${angle}rad` }],
            borderRadius: 2,
          }}
        />
      );
    }
  }

  return (
    <SafeAreaView
      style={styles.safeContainer}
      edges={["top", "left", "right"]}
    >
      <View style={styles.inner}>
        {/* HEADER + PATIENT INFO (όπως στο PatientsScreen) */}
        <View style={styles.header}>
          <TouchableOpacity onPress={() => router.replace("../patients")}>
            <MaterialIcons
              name="arrow-back-ios"
              size={20}
              color={theme.colors.text}
            />
          </TouchableOpacity>
          <Text style={styles.headerTitle}>Patient Details</Text>
        </View>

        <Text style={styles.syncedText}>Last synced: {lastSynced}</Text>

        <View style={styles.patientInfo}>
          <Image
            source={require("../../assets/images/user.png")}
            style={styles.userIcon}
          />

          <View style={{ flex: 1 }}>
            <Text style={styles.name}>
              {effectivePatient.name} ({effectivePatient.age ?? "?"}yo)
            </Text>

            <View style={{ flexDirection: "row", alignItems: "center" }}>
              <MaterialCommunityIcons
                name="doctor"
                size={18}
                color="#B0B0B0"
              />
              <Text style={[styles.subText, { marginLeft: 6 }]}>
                George Adamides
              </Text>
            </View>

            <View style={{ flexDirection: "row", alignItems: "center" }}>
              <FontAwesome name="bed" size={18} color="#B0B0B0" />
              <Text style={[styles.subText, { marginLeft: 6 }]}>
                {effectivePatient.ward ?? "Ward - 1"} |{" "}
                {effectivePatient.bed ?? "101"} |{" "}
                {effectivePatient.daysInWard ?? 0} days
              </Text>
            </View>
          </View>
        </View>

        <TabsContainer
          tabs={tabs}
          selectedTab={selectedTab}
          onSelect={handleSelectTab}
        />

        <DaysContainer
          days={days}
          selectedDay={selectedDay}
          onSelect={setSelectedDay}
        />

        {/* CONTENT ΣΕ SCROLLVIEW, όπως τα cards στη λίστα */}
        <ScrollView
          style={{ flex: 1 }}
          contentContainerStyle={{ paddingBottom: 120 }}
          showsVerticalScrollIndicator={false}
        >
          <Text style={styles.sectionTitle}>Nursing care schedule</Text>

          <View style={styles.chartCard}>
            <View style={styles.chartHeader}>
              <View style={{ flexDirection: "row", alignItems: "center" }}>
                <MaterialCommunityIcons
                  name="chart-bar"
                  size={18}
                  color={theme.colors.mutedText}
                />
                <Text style={styles.chartHeaderText}>
                  Vital signs overview
                </Text>
              </View>

              <TouchableOpacity style={styles.chartIconButton}>
                <MaterialIcons
                  name="fullscreen"
                  size={18}
                  color={theme.colors.mutedText}
                />
              </TouchableOpacity>
            </View>

            <View style={styles.chartBody} onLayout={handleChartLayout}>
              <View style={styles.chartGrid}>
                {Array.from({ length: 4 }).map((_, index) => (
                  <View key={index} style={styles.chartGridLine} />
                ))}
              </View>

              {chartBars.map((bar) => {
                const normalizedHeight =
                  (bar.value / maxBarValue) *
                  (usableHeight <= 0 ? 1 : usableHeight);

                return (
                  <View key={bar.label} style={styles.chartBarContainer}>
                    <View
                      style={[
                        styles.chartBar,
                        { height: normalizedHeight || 1 },
                      ]}
                    />
                    <Text style={styles.chartBarLabel}>{bar.label}</Text>
                  </View>
                );
              })}

              {chartWidth > 0 && (
                <View
                  pointerEvents="none"
                  style={[
                    styles.chartLineOverlay,
                    { width: chartWidth, height: CHART_HEIGHT },
                  ]}
                >
                  {lineSegments}
                </View>
              )}
            </View>
          </View>

          <View style={styles.arterialCard}>
            <View style={styles.arterialHeader}>
              <Text style={styles.arterialTitle}>Arterial Blood Gas</Text>
              <TouchableOpacity>
                <MaterialIcons
                  name="info-outline"
                  size={18}
                  color={theme.colors.mutedText}
                />
              </TouchableOpacity>
            </View>

            <View style={styles.arterialBody}>
              <View style={styles.arterialRow}>
                <Text style={[styles.arterialHeaderCell, { flex: 2 }]}>
                  Date &amp; Time
                </Text>
                <Text style={styles.arterialHeaderCell}>pH</Text>
                <Text style={styles.arterialHeaderCell}>HCO3</Text>
                <Text style={styles.arterialHeaderCell}>PaCO2</Text>
                <Text style={styles.arterialHeaderCell}>PaO2</Text>
                <Text style={styles.arterialHeaderCell}>SaO2</Text>
              </View>

              <View style={styles.arterialRow}>
                <Text style={[styles.arterialCell, { flex: 2 }]}>
                  {arterialRow.dateTime}
                </Text>
                <Text style={styles.arterialValue}>{arterialRow.pH}</Text>
                <Text style={styles.arterialValue}>{arterialRow.hco3}</Text>
                <Text style={styles.arterialValue}>{arterialRow.paco2}</Text>
                <Text style={styles.arterialValue}>{arterialRow.pao2}</Text>
                <Text style={styles.arterialValue}>{arterialRow.sao2}</Text>
              </View>

              <View style={styles.arterialRow}>
                <Text style={[styles.arterialCell, { flex: 2 }]}>
                  {arterialRow.dateTime}
                </Text>
                <Text style={styles.arterialValue}>{arterialRow2.pH}</Text>
                <Text style={styles.arterialValue}>{arterialRow2.hco3}</Text>
                <Text style={styles.arterialValue}>{arterialRow2.paco2}</Text>
                <Text style={styles.arterialValue}>{arterialRow2.pao2}</Text>
                <Text style={styles.arterialValue}>{arterialRow2.sao2}</Text>
              </View>
            </View>
          </View>
        </ScrollView>
      </View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  safeContainer: {
    flex: 1,
    backgroundColor: "#F4F6F8",
  },
  inner: {
    flex: 1,
    paddingTop: 8,
    paddingHorizontal: 16,
    maxWidth: 600,
    alignSelf: "center",
    width: "100%",
  },
  header: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 4,
  },
  headerTitle: {
    fontSize: 22,
    fontWeight: "700",
    marginLeft: 8,
    color: theme.colors.text,
  },
  syncedText: {
    fontSize: 11,
    color: theme.colors.mutedText,
    marginBottom: 12,
  },
  patientInfo: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: theme.spacing.lg,
  },
  userIcon: {
    width: 60,
    height: 60,
    marginRight: theme.spacing.md,
  },
  name: {
    fontSize: theme.font.md,
    fontWeight: "700",
    color: theme.colors.text,
    marginBottom: 3,
  },
  subText: {
    fontSize: theme.font.sm,
    color: theme.colors.mutedText,
    marginLeft: 6,
  },
  sectionTitle: {
    fontSize: theme.font.md,
    fontWeight: "600",
    marginBottom: theme.spacing.md,
  },
  chartCard: {
    backgroundColor: "#FFF",
    borderRadius: 16,
    padding: 12,
    marginBottom: 18,
    shadowColor: "#000",
    shadowOpacity: 0.05,
    shadowRadius: 4,
    elevation: 3,
  },
  chartHeader: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "center",
    marginBottom: 8,
  },
  chartHeaderText: {
    fontSize: theme.font.sm,
    color: theme.colors.mutedText,
    marginLeft: 6,
  },
  chartIconButton: {
    padding: 4,
    borderRadius: 14,
    borderWidth: 1,
    borderColor: theme.colors.border,
  },
  chartBody: {
    height: CHART_HEIGHT,
    flexDirection: "row",
    alignItems: "flex-end",
    justifyContent: "space-between",
    paddingHorizontal: 4,
    position: "relative",
  },
  chartGrid: {
    position: "absolute",
    left: 0,
    right: 0,
    top: 0,
    bottom: CHART_BOTTOM_PADDING,
    justifyContent: "space-between",
  },
  chartGridLine: {
    height: 1,
    backgroundColor: theme.colors.border,
  },
  chartBarContainer: {
    flex: 1,
    alignItems: "center",
  },
  chartBar: {
    width: 14,
    borderRadius: 6,
    backgroundColor: theme.colors.primary,
    marginBottom: 6,
  },
  chartBarLabel: {
    fontSize: 10,
    color: theme.colors.mutedText,
  },
  chartLineOverlay: {
    position: "absolute",
    left: 0,
    top: 0,
  },
  arterialCard: {
    borderRadius: 16,
    backgroundColor: "#FFF",
    overflow: "hidden",
    borderWidth: 1,
    borderColor: theme.colors.border,
    marginBottom: 24,
  },
  arterialHeader: {
    backgroundColor: "#E6F4F1",
    paddingVertical: 10,
    paddingHorizontal: 14,
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
  },
  arterialTitle: {
    fontSize: theme.font.sm,
    fontWeight: "600",
    color: theme.colors.text,
  },
  arterialBody: {
    paddingHorizontal: 14,
    paddingVertical: 12,
  },
  arterialRow: {
    flexDirection: "row",
    marginBottom: 6,
  },
  arterialHeaderCell: {
    flex: 1,
    fontSize: 11,
    color: theme.colors.mutedText,
    textAlign: "center",
  },
  arterialCell: {
    flex: 1,
    fontSize: 11,
    color: theme.colors.text,
  },
  arterialValue: {
    flex: 1,
    fontSize: 11,
    color: "#E53935",
    fontWeight: "600",
    textAlign: "center",
  },
});
