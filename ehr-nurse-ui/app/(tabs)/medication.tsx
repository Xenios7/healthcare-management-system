import React, { useEffect, useState, useCallback } from "react";
import {
  View,
  Text,
  FlatList,
  TouchableOpacity,
  ActivityIndicator,
  StyleSheet,
  TextInput,
  RefreshControl,
  useWindowDimensions,
  SafeAreaView,
} from "react-native";

import Animated, {
  useSharedValue,
  useAnimatedStyle,
  withTiming,
  SharedValue,
} from "react-native-reanimated";

import FeatherIcon from "react-native-vector-icons/Feather";
import { Ionicons, MaterialCommunityIcons } from "@expo/vector-icons";
import { Link, router } from "expo-router";
import { theme } from "../../styles/theme";
import { Platform } from "react-native";

const API_BASE_URL = Platform.select({
  web: "http://localhost:5164",
  default: "http://172.22.240.1:5164",
});

type FilterType = "all" | "not_given" | "given";

type MedCard = {
  MedicationId: number;
  PatientId: number;
  PatientName: string;
  PatientAge: number | null;
  Ward: string;
  Bed: string;
  DaysInWard: number;
  ProductName: string;
  Form: string | null;
  Quantity: number;
  QuantityUnit: string;
  FrequencyAmount: number;
  FrequencyUnit: string;
  DurationAmount: number;
  DurationUnit: string;
  Route: string | null;
  InstructionPatient: string | null;
  EndDate: string | null;
  Status: string;
  HasReminder: boolean;
};

const PAST_DAYS = 30;
const FUTURE_DAYS = 120;

function buildCalendarDays(): Date[] {
  const today = new Date();
  const days: Date[] = [];

  for (let i = PAST_DAYS; i > 0; i--) {
    const d = new Date(today);
    d.setDate(today.getDate() - i);
    days.push(d);
  }

  for (let i = 0; i <= FUTURE_DAYS; i++) {
    const d = new Date(today);
    d.setDate(today.getDate() + i);
    days.push(d);
  }

  return days;
}

function isSameDay(a: Date, b: Date) {
  return (
    a.getFullYear() === b.getFullYear() &&
    a.getMonth() === b.getMonth() &&
    a.getDate() === b.getDate()
  );
}

function formatDateKey(d: Date) {
  return d.toISOString().substring(0, 10);
}

function getFilterLabel(f: FilterType) {
  if (f === "all") return "All";
  if (f === "not_given") return "Not Given";
  if (f === "given") return "Given";
  return f;
}

type DayItemAnimatedProps = {
  date: Date;
  isActive: boolean;
  onSelect: () => void;
  selectedScale: SharedValue<number>;
  width: number;
};

const DayItemAnimated: React.FC<DayItemAnimatedProps> = ({
  date,
  isActive,
  onSelect,
  selectedScale,
  width,
}) => {
  const animatedStyle = useAnimatedStyle(() => ({
    transform: [{ scale: isActive ? selectedScale.value : 1 }],
    opacity: isActive ? selectedScale.value : 0.85,
  }));

  const monthStr = date.toLocaleDateString(undefined, { month: "short" });

  return (
    <Animated.View style={[animatedStyle, { width }]}>
      <TouchableOpacity
        style={[styles.dayItem, isActive && styles.dayItemActive]}
        onPress={onSelect}
      >
        <Text style={[styles.dayName, isActive && styles.dayNameActive]}>
          {date.toLocaleDateString(undefined, { weekday: "short" })}
        </Text>

        <Text style={[styles.dayNumber, isActive && styles.dayNumberActive]}>
          {date.getDate()}
        </Text>

        <Text style={[styles.monthName, isActive && styles.monthNameActive]}>
          {monthStr}
        </Text>
      </TouchableOpacity>
    </Animated.View>
  );
};

export default function MedicationScreen() {
  const { width: windowWidth } = useWindowDimensions();
  const dayWidth = Math.min(82, (windowWidth - 32) / 4.5);

  const [filter, setFilter] = useState<FilterType>("all");
  const [meds, setMeds] = useState<MedCard[]>([]);
  const [loading, setLoading] = useState(false);
  const [refreshing, setRefreshing] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const [days] = useState<Date[]>(() => buildCalendarDays());
  const [selectedDate, setSelectedDate] = useState<Date | null>(null);

  const [isSearching, setIsSearching] = useState(false);
  const [searchQuery, setSearchQuery] = useState("");

  const selectedScale = useSharedValue(1);
  const [lastSynced] = useState(new Date());

  const loadMeds = useCallback(
    async (isRefresh = false) => {
      if (!selectedDate) return;

      try {
        setError(null);
        if (!isRefresh) setLoading(true);

        const statusParam = filter;
        const dateKey = formatDateKey(selectedDate);

        const url =
          `${API_BASE_URL}/api/Medications/schedule` +
          `?status=${encodeURIComponent(statusParam)}` +
          `&date=${encodeURIComponent(dateKey)}` +
          `&search=${encodeURIComponent(searchQuery)}`;

        const res = await fetch(url);
        const data = (await res.json()) as MedCard[];
        setMeds(data);
      } catch (e: any) {
        console.log("Error loading meds", e);
        setError(e?.message ?? "Failed to load medications");
        setMeds([]);
      } finally {
        if (!isRefresh) setLoading(false);
      }
    },
    [filter, selectedDate, searchQuery]
  );

  useEffect(() => {
    if (!selectedDate && days.length > 0) {
      setSelectedDate(days[PAST_DAYS]);
    }
  }, [selectedDate, days]);

  useEffect(() => {
    if (selectedDate) {
      loadMeds();
    }
  }, [selectedDate, filter, searchQuery, loadMeds]);

  const onRefresh = useCallback(async () => {
    try {
      setRefreshing(true);
      await loadMeds(true);
    } finally {
      setRefreshing(false);
    }
  }, [loadMeds]);

  const handleSearchPress = () => {
    setIsSearching(true);
  };

  const cancelSearch = () => {
    setIsSearching(false);
    setSearchQuery("");
  };

  const onSelectDate = (d: Date) => {
    setSelectedDate(d);
    selectedScale.value = 0.8;
    selectedScale.value = withTiming(1, { duration: 160 });
  };

  const renderFilterButtons = () => (
    <View style={styles.segmentContainer}>
      {(["all", "not_given", "given"] as FilterType[]).map((f) => {
        const active = filter === f;
        const label = getFilterLabel(f);

        return (
          <TouchableOpacity
            key={f}
            style={[styles.segmentItem, active && styles.segmentItemActive]}
            onPress={() => {
              setFilter(f);
              setIsSearching(false);
              setSearchQuery("");
            }}
          >
            <Text style={[styles.segmentText, active && styles.segmentTextActive]}>
              {label}
            </Text>
          </TouchableOpacity>
        );
      })}
    </View>
  );

  const renderDayStrip = () => (
    <View style={styles.dayStripContainer}>
      <FlatList
        horizontal
        data={days}
        keyExtractor={(item) => item.toISOString()}
        showsHorizontalScrollIndicator={false}
        initialScrollIndex={PAST_DAYS}
        getItemLayout={(_, index) => ({
          length: dayWidth,
          offset: dayWidth * index,
          index,
        })}
        onScrollToIndexFailed={(info) => {
          setTimeout(() => {
            (info as any).flatListRef?.scrollToIndex({
              index: info.index,
              animated: true,
            });
          }, 50);
        }}
        contentContainerStyle={{ paddingRight: 12 }}
        renderItem={({ item: d }) => {
          const active = selectedDate && isSameDay(d, selectedDate);
          return (
            <DayItemAnimated
              date={d}
              isActive={!!active}
              onSelect={() => onSelectDate(d)}
              selectedScale={selectedScale}
              width={dayWidth}
            />
          );
        }}
      />
    </View>
  );

  const renderMedItem = ({ item: med }: { item: MedCard }) => {
    return (
      <View style={styles.medCard}>
        <View style={styles.medTopRow}>
          <View style={styles.avatarCircle}>
            <Text style={styles.avatarInitial}>{med.PatientName.charAt(0)}</Text>
          </View>

          <View style={{ flex: 1 }}>
            <View
              style={{
                flexDirection: "row",
                justifyContent: "space-between",
                alignItems: "center",
              }}
            >
              <Text style={styles.patientName} numberOfLines={1}>
                {med.PatientName} ({med.PatientAge ?? "?"}yo)
              </Text>

              <Ionicons
                name="chevron-forward"
                size={20}
                color={theme.colors.mutedText}
              />
            </View>

            <View style={styles.patientMetaRow}>
              <MaterialCommunityIcons
                name="hospital-building"
                size={14}
                color={theme.colors.mutedText}
              />
              <Text style={styles.patientMetaText}>WARD – {med.Ward}</Text>

              <Text style={{ marginHorizontal: 6, color: theme.colors.mutedText }}>
                |
              </Text>

              <MaterialCommunityIcons
                name="bed-outline"
                size={14}
                color={theme.colors.mutedText}
              />
              <Text style={styles.patientMetaText}>{med.Bed}</Text>
            </View>

            <View style={{ flexDirection: "row", alignItems: "center", marginTop: 2 }}>
              <Ionicons
                name="calendar-outline"
                size={14}
                color={theme.colors.mutedText}
              />
              <Text style={styles.patientMetaText}>{med.DaysInWard} days</Text>
            </View>
          </View>
        </View>

        <View style={styles.topSeparator} />

        <View style={styles.medInfoBlock}>
          <View style={styles.medNameRow}>
            <MaterialCommunityIcons
              name="pill"
              size={18}
              color={theme.colors.primaryDark}
              style={{ marginRight: 6 }}
            />
            <Text style={styles.medName}>{med.ProductName}</Text>
          </View>
          <Text style={styles.doseText}>
            {med.Quantity} {med.QuantityUnit} • {med.FrequencyAmount}{" "}
            {med.FrequencyUnit}
          </Text>
        </View>

        <View style={styles.medNotes}>
          <Text style={styles.medNotesText}>
            - Instructions: {med.InstructionPatient ?? "None"}
          </Text>
          <Text style={styles.medNotesText}>
            - End Date: {med.EndDate ? med.EndDate.toString().slice(0, 10) : "n/a"}
          </Text>
        </View>

        <View style={styles.medBottomRow}>
          <TouchableOpacity style={styles.addReminderWrapper}>
            <Ionicons
              name={med.HasReminder ? "notifications" : "notifications-outline"}
              size={18}
              color={theme.colors.primaryDark}
              style={{ marginRight: 4 }}
            />
            <Text
              style={[
                styles.addReminderText,
                med.HasReminder && styles.addReminderTextActive,
              ]}
            >
              {med.HasReminder ? "Remove reminder" : "Add reminder"}
            </Text>
          </TouchableOpacity>

          <View style={styles.checkButton} />
        </View>
      </View>
    );
  };

  const placeholderText = `Search ${getFilterLabel(filter).toLowerCase()} medications`;
  const visibleMeds = meds;

  return (
    <SafeAreaView style={styles.safeContainer}>
      <View style={styles.inner}>
        <View style={styles.header}>
          <View style={{ flexDirection: "row", alignItems: "center" }}>
            <TouchableOpacity
              style={{ marginRight: 8 }}
              onPress={() => router.replace("/home")}
            >
              <Ionicons name="chevron-back" size={22} color="#111827" />
            </TouchableOpacity>

            <View>
              <Text style={styles.headerTitle}>Medication</Text>
              <Text style={styles.headerSubtitle}>
                Last synced: {lastSynced.toLocaleDateString()} ,{" "}
                {lastSynced.toLocaleTimeString()}
              </Text>
            </View>
          </View>

          <View style={styles.headerIcons}>
            <TouchableOpacity style={styles.headerIcon} onPress={handleSearchPress}>
              <FeatherIcon name="search" size={18} color="#111827" />
            </TouchableOpacity>
          </View>
        </View>

        {renderFilterButtons()}

        {isSearching && (
          <View style={styles.searchRow}>
            <TextInput
              style={styles.searchInput}
              placeholder={placeholderText}
              value={searchQuery}
              onChangeText={setSearchQuery}
            />
            <TouchableOpacity style={styles.searchCancel} onPress={cancelSearch}>
              <Text style={styles.searchCancelText}>Cancel</Text>
            </TouchableOpacity>
          </View>
        )}

        {renderDayStrip()}

        {loading && !refreshing ? (
          <View style={styles.center}>
            <ActivityIndicator />
          </View>
        ) : (
          <FlatList
            data={visibleMeds}
            keyExtractor={(item) => item.MedicationId.toString()}
            renderItem={renderMedItem}
            contentContainerStyle={
              visibleMeds.length === 0
                ? styles.emptyContainer
                : styles.listContent
            }
            refreshControl={
              <RefreshControl refreshing={refreshing} onRefresh={onRefresh} />
            }
            ListEmptyComponent={
              !loading ? (
                <Text style={styles.emptyText}>
                  No medications found for this date.
                </Text>
              ) : null
            }
          />
        )}

        {error && (
          <View style={styles.errorBar}>
            <Text style={styles.errorText}>{error}</Text>
          </View>
        )}

        <View style={styles.bottomNav}>
          <Link href="/home" asChild>
            <TouchableOpacity style={styles.bottomItem}>
              <Ionicons name="home" size={26} color={theme.colors.mutedText} />
            </TouchableOpacity>
          </Link>

          <TouchableOpacity style={styles.bottomItem}>
            <MaterialCommunityIcons
              name="clipboard-text-outline"
              size={26}
              color={theme.colors.mutedText}
            />
          </TouchableOpacity>

          <TouchableOpacity style={styles.bottomItem}>
            <MaterialCommunityIcons
              name="pill"
              size={26}
              color={theme.colors.primary}
            />
          </TouchableOpacity>

          <TouchableOpacity style={styles.bottomItem}>
            <MaterialCommunityIcons
              name="silverware-fork-knife"
              size={26}
              color={theme.colors.mutedText}
            />
          </TouchableOpacity>

          <TouchableOpacity style={styles.bottomItem}>
            <Ionicons
              name="calendar-outline"
              size={26}
              color={theme.colors.mutedText}
            />
          </TouchableOpacity>
        </View>
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
    paddingTop: 24,
    paddingHorizontal: 16,
    maxWidth: 600,
    alignSelf: "center",
    width: "100%",
  },
  container: {
    flex: 1,
  },
  center: { flex: 1, justifyContent: "center", alignItems: "center" },

  header: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    marginBottom: 16,
  },
  headerTitle: {
    fontSize: 22,
    fontWeight: "700",
    color: "#111827",
  },
  headerSubtitle: {
    marginTop: 4,
    fontSize: 11,
    color: "#6B7280",
  },
  headerIcons: {
    flexDirection: "row",
    alignItems: "center",
  },
  headerIcon: {
    width: 32,
    height: 32,
    borderRadius: 10,
    borderWidth: 1,
    borderColor: "#D1D5DB",
    marginLeft: 8,
    alignItems: "center",
    justifyContent: "center",
    backgroundColor: "#FFFFFF",
  },

  segmentContainer: {
    flexDirection: "row",
    alignSelf: "center",
    backgroundColor: "#E5E7EB",
    borderRadius: 24,
    padding: 2,
    marginBottom: 16,
  },
  segmentItem: {
    paddingHorizontal: 18,
    paddingVertical: 6,
    borderRadius: 20,
    justifyContent: "center",
    alignItems: "center",
  },
  segmentItemActive: {
    backgroundColor: "#0EAD9A",
  },
  segmentText: {
    fontSize: 12,
    color: "#4B5563",
    fontWeight: "500",
  },
  segmentTextActive: {
    color: "#FFFFFF",
  },

  searchRow: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 8,
  },
  searchInput: {
    flex: 1,
    backgroundColor: "#FFFFFF",
    borderRadius: 12,
    paddingHorizontal: 12,
    paddingVertical: 8,
    fontSize: 14,
    borderWidth: 1,
    borderColor: "#E5E7EB",
  },
  searchCancel: {
    marginLeft: 8,
  },
  searchCancelText: {
    fontSize: 14,
    color: "#0EAD9A",
    fontWeight: "500",
  },

  dayStripContainer: {
    marginBottom: 16,
  },
  dayItem: {
    paddingVertical: 8,
    marginRight: 8,
    borderRadius: 16,
    backgroundColor: "#FFFFFF",
    justifyContent: "center",
    alignItems: "center",
  },
  dayItemActive: {
    backgroundColor: "#0EAD9A",
  },
  dayName: {
    fontSize: 11,
    color: "#6B7280",
  },
  dayNameActive: {
    color: "#FFFFFF",
  },
  dayNumber: {
    fontSize: 16,
    fontWeight: "700",
    color: "#111827",
  },
  dayNumberActive: {
    color: "#FFFFFF",
  },
  monthName: {
    fontSize: 11,
    color: "#6B7280",
  },
  monthNameActive: {
    color: "#FFFFFF",
  },

  listContent: {
    paddingBottom: 120,
  },
  emptyContainer: {
    flexGrow: 1,
    justifyContent: "center",
    alignItems: "center",
    paddingBottom: 120,
  },
  emptyText: {
    color: "#6B7280",
  },

  medCard: {
    backgroundColor: "#FFFFFF",
    borderRadius: 16,
    padding: 14,
    marginBottom: 12,
    shadowColor: "#000",
    shadowOpacity: 0.06,
    shadowRadius: 6,
    shadowOffset: { width: 0, height: 2 },
    elevation: 2,
  },
  medTopRow: {
    flexDirection: "row",
    alignItems: "flex-start",
  },
  avatarCircle: {
    width: 40,
    height: 40,
    borderRadius: 20,
    backgroundColor: "#E5E7EB",
    alignItems: "center",
    justifyContent: "center",
    marginRight: 10,
  },
  avatarInitial: {
    fontSize: 16,
    fontWeight: "700",
    color: "#111827",
  },
  patientName: {
    fontSize: 15,
    fontWeight: "700",
    color: "#111827",
  },
  patientMetaRow: {
    flexDirection: "row",
    alignItems: "center",
    marginTop: 2,
  },
  patientMetaText: {
    fontSize: 11,
    color: "#6B7280",
    marginLeft: 4,
  },
  topSeparator: {
    height: 1,
    backgroundColor: "#E5E7EB",
    marginVertical: 10,
  },
  medInfoBlock: {
    marginBottom: 8,
  },
  medNameRow: {
    flexDirection: "row",
    alignItems: "center",
  },
  medName: {
    fontSize: 15,
    fontWeight: "700",
    color: "#111827",
  },
  doseText: {
    marginTop: 2,
    fontSize: 12,
    color: "#0EAD9A",
  },
  medNotes: {
    marginBottom: 8,
  },
  medNotesText: {
    fontSize: 11,
    color: "#6B7280",
  },
  medBottomRow: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderTopWidth: 1,
    borderTopColor: "#E5E7EB",
    paddingTop: 8,
    alignItems: "center",
  },
  addReminderWrapper: {
    flexDirection: "row",
    alignItems: "center",
  },
  addReminderText: {
    fontSize: 12,
    color: theme.colors.primaryDark,
  },
  addReminderTextActive: {
    fontWeight: "800",
  },
  checkButton: {
    width: 28,
    height: 28,
    borderRadius: 6,
    borderWidth: 2,
    borderColor: theme.colors.primary,
    alignItems: "center",
    justifyContent: "center",
  },

  errorBar: {
    backgroundColor: "#EF4444",
    padding: 8,
  },
  errorText: {
    color: "white",
    textAlign: "center",
    fontSize: 12,
  },

  bottomNav: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-around",
    borderTopWidth: 1,
    borderTopColor: theme.colors.border,
    marginTop: 8,
    paddingVertical: theme.spacing.sm,
    backgroundColor: theme.colors.card,
  },
  bottomItem: {
    flex: 1,
    alignItems: "center",
  },
});
