import React, { useMemo, useState, useEffect } from "react";
import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  Pressable,
  SafeAreaView,
} from "react-native";
import { Ionicons, MaterialCommunityIcons } from "@expo/vector-icons";
import { theme } from "../styles/theme";
import { router } from "expo-router";

/* ---------------------------------------------------
   TYPES
--------------------------------------------------- */

type FilterType = "All" | "Not Given" | "Given";

type DayInfo = {
  key: string;
  label: string;
  dayNumber: number;
  isToday: boolean;
};

type MealCard = {
  id: string;
  patientName: string;
  age: number;
  ward: string;
  room: string;
  bed: string;
  daysAdmitted: number;
  medName: string;
  doseText: string;
  instructions: string;
  endDate: string;
  isGiven: boolean;
  hasReminder: boolean;
};

/* ---------------------------------------------------
   DUMMY DATA (10 entries)
--------------------------------------------------- */

const INITIAL_MEALS: MealCard[] = [
  {
    id: "1",
    patientName: "Test Patient2",
    age: 66,
    ward: "1",
    room: "101",
    bed: "1",
    daysAdmitted: 88,
    medName: "CHICKEN WITH RICE",
    doseText: "LUNCH",
    instructions: "Put them in the mixer. Serve cold.",
    endDate: "n/a",
    isGiven: true,
    hasReminder: false,
  },
  {
    id: "2",
    patientName: "Test Patient3",
    age: 72,
    ward: "2",
    room: "203",
    bed: "2",
    daysAdmitted: 12,
    medName: "VEGETABLE SOUP",
    doseText: "DINNER",
    instructions: "Serve warm.",
    endDate: "20/11/2024",
    isGiven: false,
    hasReminder: true,
  },
  {
    id: "3",
    patientName: "Test Patient4",
    age: 81,
    ward: "1",
    room: "115",
    bed: "3",
    daysAdmitted: 3,
    medName: "CHICKEN WITH RICE",
    doseText: "LUNCH",
    instructions: "Cut in small pieces.",
    endDate: "n/a",
    isGiven: false,
    hasReminder: false,
  },
  {
    id: "4",
    patientName: "Test Patient5",
    age: 59,
    ward: "3",
    room: "305",
    bed: "1",
    daysAdmitted: 45,
    medName: "FISH WITH POTATOES",
    doseText: "DINNER",
    instructions: "Serve cold with lemon.",
    endDate: "01/12/2024",
    isGiven: true,
    hasReminder: true,
  },
  {
    id: "5",
    patientName: "Test Patient6",
    age: 70,
    ward: "2",
    room: "210",
    bed: "2",
    daysAdmitted: 5,
    medName: "CHICKEN WITH RICE",
    doseText: "LUNCH",
    instructions: "Serve warm.",
    endDate: "n/a",
    isGiven: false,
    hasReminder: false,
  },
  {
    id: "6",
    patientName: "Test Patient7",
    age: 77,
    ward: "2",
    room: "122",
    bed: "1",
    daysAdmitted: 18,
    medName: "PASTA",
    doseText: "DINNER",
    instructions: "Serve hot.",
    endDate: "n/a",
    isGiven: false,
    hasReminder: true,
  }
];

/* ---------------------------------------------------
   CREATE DAYS FOR CALENDAR
--------------------------------------------------- */

function buildDaysAroundToday(): DayInfo[] {
  const today = new Date();
  const days: DayInfo[] = [];

  for (let offset = -2; offset <= 3; offset++) {
    const d = new Date(today);
    d.setDate(today.getDate() + offset);

    const label = d.toLocaleDateString(undefined, { weekday: "short" });
    const dayNumber = d.getDate();
    const key = d.toISOString().substring(0, 10);
    const isToday = offset === 0;

    days.push({ key, label, dayNumber, isToday });
  }

  return days;
}

/* ---------------------------------------------------
   MAIN COMPONENT
--------------------------------------------------- */

export default function NutritionScreen() {
  const [lastSynced, setLastSynced] = useState(new Date());

useEffect(() => {
  const timer = setInterval(() => {
    setLastSynced(new Date());
  }, 1000);

  return () => clearInterval(timer);
}, []);
    
  const [selectedFilter, setSelectedFilter] = useState<FilterType>("All");
  const days = useMemo(() => buildDaysAroundToday(), []);
  const initialDay = days.find((d) => d.isToday)?.key ?? days[0]?.key ?? "";
  const [selectedDayKey, setSelectedDayKey] = useState(initialDay);
  const [meals, setMeals] = useState(INITIAL_MEALS);

  const toggleGiven = (id: string) => {
    setMeals((prev) =>
      prev.map((m) => (m.id === id ? { ...m, isGiven: !m.isGiven } : m))
    );
  };

  const toggleReminder = (id: string) => {
    setMeals((prev) =>
      prev.map((m) =>
        m.id === id ? { ...m, hasReminder: !m.hasReminder } : m
      )
    );
  };

  const filteredMeals = meals.filter((m) => {
    if (selectedFilter === "Given") return m.isGiven;
    if (selectedFilter === "Not Given") return !m.isGiven;
    return true;
  });

  return (
    <SafeAreaView style={styles.screen}>
      <View style={styles.panel}>
        <ScrollView style={{ flex: 1 }} contentContainerStyle={styles.scrollContent}>
          {/* HEADER */}
<View style={styles.headerRow}>
  <Pressable
    style={styles.headerIconLeft}
    onPress={() => router.replace("/home")}
  >
    <Ionicons name="chevron-back" size={24} color={theme.colors.text} />
  </Pressable>

  <View style={styles.headerTitleBlock}>
    <Text style={styles.headerTitle}>Today&apos;s Nutrition Intake</Text>
    <Text style={styles.headerSubtitle}>
      Last synced: {lastSynced.toLocaleDateString()} , {lastSynced.toLocaleTimeString()}
    </Text>
  </View>

  {/* NEW RIGHT ICONS */}
  <View style={{ flexDirection: "row", alignItems: "center" }}>
    <Pressable style={{ paddingHorizontal: 10 }}>
      <Ionicons
        name="search-outline"
        size={24}
        color={theme.colors.text}
      />
    </Pressable>

    <Pressable style={{ paddingLeft: 4 }}>
      <MaterialCommunityIcons
        name="qrcode-scan"
        size={26}
        color={theme.colors.text}
      />
    </Pressable>
  </View>
</View>


          {/* FILTER TABS */}
          <View style={styles.filterRow}>
            {(["All", "Not Given", "Given"] as FilterType[]).map((f) => {
              const active = f === selectedFilter;
              return (
                <Pressable
                  key={f}
                  style={[styles.filterTab, active && styles.filterTabActive]}
                  onPress={() => setSelectedFilter(f)}
                >
                  <Text
                    style={[styles.filterTabText, active && styles.filterTabTextActive]}
                  >
                    {f}
                  </Text>
                </Pressable>
              );
            })}
          </View>

          {/* CALENDAR */}
          <View style={{ marginTop: theme.spacing.md, width: "100%" }}>
            <ScrollView
              horizontal
              showsHorizontalScrollIndicator={false}
              contentContainerStyle={styles.dateRowContent}
            >
              {days.map((d) => {
                const active = d.key === selectedDayKey;
                return (
                  <Pressable
                    key={d.key}
                    onPress={() => setSelectedDayKey(d.key)}
                    style={[styles.dateCard, active && styles.dateCardActive]}
                  >
                    <Text style={[styles.dateLabel, active && styles.dateLabelActive]}>
                      {d.label}
                    </Text>
                    <Text
                      style={[styles.dateNumber, active && styles.dateNumberActive]}
                    >
                      {d.dayNumber}
                    </Text>
                  </Pressable>
                );
              })}
            </ScrollView>
          </View>

          {/* MEAL LIST */}
          <View style={styles.mealList}>
            {filteredMeals.map((meal) => (
              <View key={meal.id} style={styles.mealCard}>
                <View style={styles.mealTopRow}>
                  {/* Avatar */}
                  <View style={styles.avatarCircle}>
                    <Text style={styles.avatarInitial}>
                      {meal.patientName.charAt(0)}
                    </Text>
                  </View>

                  {/* RIGHT SIDE */}
                  <View style={{ flex: 1 }}>
                    {/* LINE 1 — Name + Chevron */}
                    <View
                      style={{
                        flexDirection: "row",
                        justifyContent: "space-between",
                        alignItems: "center",
                      }}
                    >
                      <Text
                        style={styles.mealPatientName}
                        numberOfLines={1}
                        ellipsizeMode="tail"
                        allowFontScaling={false}
                      >
                        {meal.patientName} ({meal.age}yo)
                      </Text>

                      <Ionicons
                        name="chevron-forward"
                        size={20}
                        color={theme.colors.mutedText}
                      />
                    </View>

                    {/* LINE 2 — Ward + Room */}
                    <View style={styles.mealMetaRow}>
                      <MaterialCommunityIcons
                        name="hospital-building"
                        size={14}
                        color={theme.colors.mutedText}
                        style={styles.mealMetaIcon}
                      />
                      <Text style={styles.mealMetaText}
                      allowFontScaling={false}
                      >WARD – {meal.ward}</Text>

                      <Text
                        style={{
                          marginHorizontal: 6,
                          color: theme.colors.mutedText,
                        }}
                      >
                        |
                      </Text>

                      <MaterialCommunityIcons
                        name="bed-outline"
                        size={14}
                        color={theme.colors.mutedText}
                        style={styles.mealMetaIcon}
                      />
                      <Text style={styles.mealMetaText}
                      allowFontScaling={false}
                      >{meal.room}</Text>
                    </View>

                    {/* LINE 3 — DAYS ALWAYS SEPARATE */}
                    <View
                      style={{
                        flexDirection: "row",
                        alignItems: "center",
                        marginTop: 2,
                      }}
                    >
                      <MaterialCommunityIcons
                        name="calendar-range"
                        size={14}
                        color={theme.colors.mutedText}
                        style={styles.mealMetaIcon}
                      />
                      <Text style={styles.mealMetaText}
                      allowFontScaling={false}
                      >{meal.daysAdmitted}</Text>
                    </View>
                  </View>
                </View>

                <View style={styles.topSeparator} />

                {/* MED INFO */}
                <View style={styles.medInfoBlock}>
                  <View style={styles.medNameRow}>
                    <MaterialCommunityIcons
                      name="silverware-fork-knife"
                      size={18}
                      color={theme.colors.primaryDark}
                      style={{ marginRight: 6 }}
                    />
                    <Text style={styles.medName}>{meal.medName}</Text>
                  </View>

                  <Text style={styles.doseText}>{meal.doseText}</Text>
                </View>

                {/* NOTES */}
                <View style={styles.mealNotes}>
                  <Text style={styles.mealNotesText}>
                    - Instructions: {meal.instructions}
                  </Text>
                  <Text style={styles.mealNotesText}>
                    - End Date: {meal.endDate}
                  </Text>
                </View>

                {/* BOTTOM ROW */}
                <View style={styles.mealBottomRow}>
                  <Pressable
                    style={styles.addReminderWrapper}
                    onPress={() => toggleReminder(meal.id)}
                  >
                    <Ionicons
                      name={
                        meal.hasReminder ? "notifications" : "notifications-outline"
                      }
                      size={18}
                      color={theme.colors.primaryDark}
                      style={{ marginRight: 4 }}
                    />
                    <Text
                      style={[
                        styles.addReminderText,
                        meal.hasReminder && styles.addReminderTextActive,
                      ]}
                    >
                      {meal.hasReminder ? "Remove reminder" : "Add reminder"}
                    </Text>
                  </Pressable>

                  <Pressable
                    style={[
                      styles.checkButton,
                      meal.isGiven && styles.checkButtonActive,
                    ]}
                    onPress={() => toggleGiven(meal.id)}
                  >
                    {meal.isGiven && (
                      <Ionicons
                        name="checkmark"
                        size={18}
                        color={theme.colors.primaryDark}
                      />
                    )}
                  </Pressable>
                </View>
              </View>
            ))}
          </View>
        </ScrollView>
      </View>
    </SafeAreaView>
  );
}

/* ---------------------------------------------------
   STYLES
--------------------------------------------------- */

const styles = StyleSheet.create({
  screen: {
    flex: 1,
    backgroundColor: theme.colors.inputBg,
  },

  panel: {
    flex: 1,
    marginHorizontal: theme.spacing.lg,
    marginVertical: theme.spacing.lg,
    borderRadius: theme.radii.lg,
    backgroundColor: theme.colors.card,
    padding: theme.spacing.lg,
    ...theme.shadow.card,
  },

  scrollContent: {
    paddingBottom: theme.spacing.lg,
  },

  headerRow: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: theme.spacing.md,
  },

  headerIconLeft: {
    paddingRight: theme.spacing.sm,
  },

  headerTitleBlock: {
    flex: 1,
  },

  headerTitle: {
    fontSize: theme.font.lg,
    fontWeight: "800",
    color: theme.colors.text,
  },

  headerSubtitle: {
    marginTop: 2,
    fontSize: theme.font.sm - 2,
    color: theme.colors.mutedText,
  },

  /* FILTER TABS */
  filterRow: {
    flexDirection: "row",
    borderRadius: theme.radii.md,
    overflow: "hidden",
    backgroundColor: theme.colors.inputBg,
    marginBottom: theme.spacing.sm,
  },

  filterTab: {
    flex: 1,
    paddingVertical: 10,
    alignItems: "center",
    justifyContent: "center",
  },

  filterTabActive: {
    backgroundColor: theme.colors.primary,
  },

  filterTabText: {
    fontSize: theme.font.sm,
    fontWeight: "600",
    color: theme.colors.mutedText,
  },

  filterTabTextActive: {
    color: "#ffffff",
  },

  /* CALENDAR */
  dateRowContent: {
    paddingTop: theme.spacing.sm,
    paddingRight: theme.spacing.sm,
  },

  dateCard: {
    minWidth: 64,
    paddingHorizontal: theme.spacing.md,
    height: 76,
    borderRadius: theme.radii.md,
    borderWidth: 1,
    borderColor: theme.colors.border,
    backgroundColor: theme.colors.card,
    marginRight: theme.spacing.sm,
    alignItems: "center",
    justifyContent: "center",
  },

  dateCardActive: {
    backgroundColor: theme.colors.primary,
  },

  dateLabel: {
    fontSize: theme.font.sm - 2,
    color: theme.colors.mutedText,
  },

  dateLabelActive: {
    color: "#ffffff",
  },

  dateNumber: {
    marginTop: 4,
    fontSize: theme.font.md,
    fontWeight: "700",
    color: theme.colors.text,
  },

  dateNumberActive: {
    color: "#ffffff",
  },

  /* MEAL LIST */
  mealList: {
    marginTop: theme.spacing.sm,
  },

  mealCard: {
    borderRadius: theme.radii.md,
    borderWidth: 1,
    borderColor: theme.colors.border,
    backgroundColor: theme.colors.card,
    paddingHorizontal: theme.spacing.md,
    paddingVertical: theme.spacing.md,
    marginBottom: theme.spacing.sm,
  },

  /* CARD TOP */
  mealTopRow: {
    flexDirection: "row",
    alignItems: "flex-start",
  },

  avatarCircle: {
    width: 40,
    height: 40,
    borderRadius: 20,
    backgroundColor: theme.colors.inputBg,
    alignItems: "center",
    justifyContent: "center",
    marginRight: theme.spacing.sm,
  },

  avatarInitial: {
    fontSize: theme.font.md,
    fontWeight: "700",
    color: theme.colors.text,
  },

  mealPatientName: {
    fontSize: theme.font.sm,
    fontWeight: "700",
    color: theme.colors.text,
    flexShrink: 1,
  },

  mealMetaRow: {
    flexDirection: "row",
    alignItems: "center",
    marginTop: 2,
    flexWrap: "wrap",
    width: "100%",
  },

  mealMetaIcon: {
    marginLeft: 4,
    marginRight: 2,
  },

  mealMetaText: {
    fontSize: theme.font.sm - 2,
    color: theme.colors.mutedText,
    flexShrink: 1,
  },

  topSeparator: {
    height: 1,
    backgroundColor: theme.colors.border,
    marginVertical: theme.spacing.sm,
  },

  /* MED INFO */
  medInfoBlock: {
    marginBottom: theme.spacing.sm,
  },

  medNameRow: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 4,
  },

  medName: {
    fontSize: theme.font.md,
    fontWeight: "700",
    color: theme.colors.text,
  },

  doseText: {
    fontSize: theme.font.sm - 1,
    color: theme.colors.primaryDark,
  },

  mealNotes: {
    marginBottom: theme.spacing.sm,
  },

  mealNotesText: {
    fontSize: theme.font.sm - 2,
    color: theme.colors.mutedText,
  },

  mealBottomRow: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    borderTopWidth: 1,
    borderTopColor: theme.colors.border,
    paddingTop: theme.spacing.sm,
  },

  addReminderWrapper: {
    flex: 1,
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
  },

  addReminderText: {
    fontSize: theme.font.sm,
    color: theme.colors.primaryDark,
  },

  addReminderTextActive: {
    fontWeight: "700",
  },

  checkButton: {
    width: 28,
    height: 28,
    borderRadius: 6,
    borderWidth: 2,
    borderColor: theme.colors.primary,
    backgroundColor: "#ffffff",
    alignItems: "center",
    justifyContent: "center",
  },

  checkButtonActive: {
    backgroundColor: "#e5f4f1",
  },
});
