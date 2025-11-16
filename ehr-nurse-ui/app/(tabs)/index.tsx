import React, { useState, useEffect } from "react";
import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  SafeAreaView,
  Pressable,
} from "react-native";
import { Ionicons, MaterialCommunityIcons } from "@expo/vector-icons";
import { theme } from "../../styles/theme";

const USER_NAME = "TEAM13";

export default function HomeScreen() {
  const [activeShift, setActiveShift] = useState(false);
  const [duration, setDuration] = useState(0);

  useEffect(() => {
    let timer: any = null;
    if (activeShift) {
      timer = setInterval(() => {
        setDuration((d) => d + 1);
      }, 1000);
    }
    return () => clearInterval(timer);
  }, [activeShift]);

  const formatDuration = (seconds: number) => {
    const mins = Math.floor(seconds / 60)
      .toString()
      .padStart(2, "0");
    const secs = (seconds % 60).toString().padStart(2, "0");
    return `${mins}:${secs}`;
  };

  return (
    <SafeAreaView style={styles.screen}>
      <ScrollView style={styles.panel} contentContainerStyle={{ paddingBottom: 40 }}>
        <Text style={styles.greeting} allowFontScaling={false}>
          Hello {USER_NAME}
        </Text>

        <Text style={styles.sectionTitle} allowFontScaling={false}>
          Today's Overview
        </Text>

        <View style={styles.overviewRow}>
          {overviewItem(0, 15, "Given", "pill", "#e53935", "warning")}
          {overviewItem(3, 15, "Given", "silverware-fork-knife", "#fb8c00", "warning")}
          {overviewItem(15, 15, "Checked", "clipboard-text-outline", theme.colors.primaryDark, "check")}
          {overviewItem(15, 15, "Appointments", "calendar-month-outline", theme.colors.primaryDark, "check")}
        </View>

        <Text style={[styles.sectionTitle, { marginTop: theme.spacing.lg }]} allowFontScaling={false}>
          Quick Actions
        </Text>

        <View style={styles.quickActionsRow}>
          <View style={styles.quickActionCard}>
            <View style={styles.quickIconWrapper}>
              <Ionicons name="qr-code-outline" size={32} color={theme.colors.primaryDark} />
            </View>
            <Text style={styles.quickActionText} allowFontScaling={false}>
              Scan patient
            </Text>
          </View>
          <View style={{ flex: 1 }} />
        </View>

        <Text style={[styles.sectionTitle, { marginTop: theme.spacing.lg }]} allowFontScaling={false}>
          Alerts
        </Text>

        <View style={styles.alertsContainer}>
          {alertItem("Patient #102 missed Paracetamol", "warning")}
          {alertItem("Patient #104 has 3 days since last eaten", "warning")}
          {alertItem("Patient #3278 has missed meds", "warning")}
          {alertItem("Patient #105 is admitted for the last 725 days", "warning")}
          {alertItem("Admin has added a new meeting for you", "info")}
          {alertItem("Nurse Maria is on sick leave. You are replacing Maria for the rest of the week", "info")}
          {alertItem("Doctor Kostakis is sick. Doctor Yiannakis is replacing Kostakis for today", "info")}
        </View>

        <Text style={[styles.sectionTitle, { marginTop: theme.spacing.lg }]} allowFontScaling={false}>
          Shift Management
        </Text>

        {!activeShift && (
          <View style={styles.shiftCard}>
            <View style={styles.shiftLeft}>
              <Ionicons name="time-outline" size={34} color={theme.colors.primaryDark} />
              <Text style={styles.shiftStatus}>Ready to Start?</Text>
              <Text style={styles.shiftSubText}>Begin your shift now</Text>
            </View>

            <Pressable style={styles.clockInBtn} onPress={() => setActiveShift(true)}>
              <Ionicons name="log-in-outline" size={20} color="#fff" />
              <Text style={styles.clockInText}>Clock In</Text>
            </Pressable>
          </View>
        )}

        {activeShift && (
          <View style={styles.shiftCard}>
            <View style={styles.shiftLeft}>
              <Ionicons name="time" size={34} color={theme.colors.primary} />
              <Text style={styles.shiftStatus}>Active Shift</Text>
              <Text style={styles.shiftSubText}>Duration: {formatDuration(duration)}</Text>
            </View>

            <Pressable
              style={styles.clockOutBtn}
              onPress={() => {
                setActiveShift(false);
                setDuration(0);
              }}
            >
              <Ionicons name="log-out-outline" size={20} color="#fff" />
              <Text style={styles.clockOutText}>Clock Out</Text>
            </Pressable>
          </View>
        )}
      </ScrollView>
    </SafeAreaView>
  );
}

type OverviewStatus = "warning" | "check";

function overviewItem(
  current: number,
  total: number,
  label: string,
  icon: keyof typeof MaterialCommunityIcons.glyphMap,
  highlightColor: string,
  status: OverviewStatus
) {
  return (
    <View style={styles.overviewCard}>
      <View style={styles.overviewLeft}>
        <View style={styles.overviewIconCircle}>
          <MaterialCommunityIcons name={icon} size={20} color="#fff" />
        </View>

        <View style={styles.overviewTextBlock}>
          <View style={styles.overviewCountRow}>
            <Text style={[styles.overviewCountMain, { color: highlightColor }]} allowFontScaling={false}>
              {current}
            </Text>
            <Text style={styles.overviewCountSlash} allowFontScaling={false}>
              /{total}
            </Text>
          </View>

          <Text style={styles.overviewLabel} allowFontScaling={false}>
            {label}
          </Text>
        </View>
      </View>

      <View style={styles.overviewRight}>
        {status === "warning" && <Ionicons name="warning" size={18} color="#fbbf24" />}
        {status === "check" && (
          <Ionicons name="checkmark-circle-outline" size={18} color={theme.colors.primary} />
        )}
      </View>
    </View>
  );
}

function alertItem(message: string, type: "warning" | "info") {
  const iconName = type === "warning" ? "alert" : "information-outline";
  const iconColor = type === "warning" ? "#fbbf24" : theme.colors.primary;

  return (
    <View style={styles.alertItem}>
      <MaterialCommunityIcons
        name={iconName}
        size={18}
        color={iconColor}
        style={{ marginRight: theme.spacing.sm }}
      />
      <Text style={styles.alertText} allowFontScaling={false}>
        {message}
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  screen: {
    flex: 1,
    backgroundColor: theme.colors.inputBg,
  },
  panel: {
    backgroundColor: theme.colors.card,
    marginHorizontal: theme.spacing.lg,
    marginVertical: theme.spacing.lg,
    padding: theme.spacing.lg,
    borderRadius: theme.radii.lg,
    ...theme.shadow.card,
  },
  greeting: {
    fontSize: theme.font.lg,
    fontWeight: "700",
    color: theme.colors.text,
    marginBottom: theme.spacing.xs,
  },
  sectionTitle: {
    fontSize: theme.font.lg,
    fontWeight: "800",
    marginBottom: theme.spacing.sm,
    color: "rgba(15, 23, 42, 0.85)",
  },
  overviewRow: {
    flexDirection: "row",
    flexWrap: "wrap",
    justifyContent: "space-between",
    marginBottom: theme.spacing.md,
  },
  overviewCard: {
    width: "48%",
    marginBottom: theme.spacing.sm,
    flexDirection: "row",
    alignItems: "center",
    borderRadius: theme.radii.md,
    borderWidth: 1,
    borderColor: theme.colors.border,
    backgroundColor: theme.colors.inputBg,
    paddingVertical: theme.spacing.xs,
    paddingHorizontal: theme.spacing.sm,
  },
  overviewLeft: {
    flexDirection: "row",
    alignItems: "center",
    flex: 1,
  },
  overviewRight: {
    width: 26,
    alignItems: "center",
    justifyContent: "center",
  },
  overviewIconCircle: {
    width: 30,
    height: 30,
    borderRadius: 15,
    backgroundColor: theme.colors.primary,
    alignItems: "center",
    justifyContent: "center",
    marginRight: theme.spacing.sm,
  },
  overviewTextBlock: {
    flex: 1,
  },
  overviewCountRow: {
    flexDirection: "row",
    alignItems: "baseline",
  },
  overviewCountMain: {
    fontSize: theme.font.sm,
    fontWeight: "800",
  },
  overviewCountSlash: {
    fontSize: theme.font.sm,
    fontWeight: "700",
    marginLeft: 2,
    color: theme.colors.text,
  },
  overviewLabel: {
    fontSize: 11,
    lineHeight: 14,
    color: theme.colors.mutedText,
  },
  quickActionsRow: {
    flexDirection: "row",
    marginTop: theme.spacing.xs,
  },
  quickActionCard: {
    flex: 1,
    borderRadius: theme.radii.md,
    borderWidth: 1,
    borderColor: theme.colors.border,
    backgroundColor: theme.colors.card,
    paddingHorizontal: theme.spacing.md,
    paddingVertical: theme.spacing.sm,
    minHeight: 100,
  },
  quickIconWrapper: {
    width: 36,
    height: 36,
    borderRadius: theme.radii.sm,
    backgroundColor: theme.colors.primary + "22",
    alignItems: "center",
    justifyContent: "center",
    marginBottom: theme.spacing.xs,
  },
  quickActionText: {
    fontSize: theme.font.sm,
    fontWeight: "500",
    color: theme.colors.text,
  },
  alertsContainer: {
    marginTop: theme.spacing.sm,
  },
  alertItem: {
    flexDirection: "row",
    alignItems: "center",
    paddingVertical: 4,
  },
  alertText: {
    flex: 1,
    fontSize: theme.font.sm,
    color: theme.colors.text,
  },

  shiftCard: {
    marginTop: theme.spacing.sm,
    borderRadius: theme.radii.md,
    borderWidth: 1,
    borderColor: theme.colors.border,
    backgroundColor: theme.colors.card,
    padding: theme.spacing.lg,
    ...theme.shadow.card,
  },
  shiftLeft: {
    marginBottom: theme.spacing.md,
  },
  shiftStatus: {
    fontSize: theme.font.md,
    fontWeight: "700",
    color: theme.colors.text,
    marginTop: theme.spacing.xs,
  },
  shiftSubText: {
    color: theme.colors.mutedText,
    marginTop: 2,
  },
  clockInBtn: {
    backgroundColor: theme.colors.primary,
    paddingVertical: 12,
    borderRadius: theme.radii.md,
    alignItems: "center",
    flexDirection: "row",
    justifyContent: "center",
    gap: 6,
  },
  clockInText: {
    color: "#fff",
    fontWeight: "700",
  },
  clockOutBtn: {
    backgroundColor: "#ef4444",
    paddingVertical: 12,
    borderRadius: theme.radii.md,
    alignItems: "center",
    flexDirection: "row",
    justifyContent: "center",
    gap: 6,
  },
  clockOutText: {
    color: "#fff",
    fontWeight: "700",
  },
});
