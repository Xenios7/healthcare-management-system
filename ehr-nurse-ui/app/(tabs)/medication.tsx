import React, { useMemo, useState } from "react";
import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  TextInput,
  Pressable,
  SafeAreaView,
} from "react-native";
import { Ionicons, MaterialCommunityIcons } from "@expo/vector-icons";
import { theme } from "../../styles/theme";
import { router } from "expo-router";

type FilterType = "All" | "Not Given" | "Given";

type DayInfo = {
  key: string;
  label: string;
  dayNumber: number;
  isToday: boolean;
};

type MedCard = {
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

const INITIAL_MEDS: MedCard[] = [
  {
    id: "1",
    patientName: "John Smith",
    age: 66,
    ward: "1",
    room: "101",
    bed: "1",
    daysAdmitted: 88,
    medName: "Paracetamol",
    doseText: "500mg – 1 tablet",
    instructions: "Take with water.",
    endDate: "n/a",
    isGiven: true,
    hasReminder: false,
  },
  {
    id: "2",
    patientName: "Maria Pap",
    age: 72,
    ward: "2",
    room: "203",
    bed: "2",
    daysAdmitted: 12,
    medName: "Aspirin",
    doseText: "75mg",
    instructions: "Take after food.",
    endDate: "20/11/2024",
    isGiven: false,
    hasReminder: true,
  },
  {
    id: "3",
    patientName: "Andreas Ioannou",
    age: 81,
    ward: "1",
    room: "115",
    bed: "3",
    daysAdmitted: 3,
    medName: "Paracetamol",
    doseText: "20mg",
    instructions: "Morning only.",
    endDate: "n/a",
    isGiven: false,
    hasReminder: false,
  },
];

function buildDaysAround(date: Date): DayInfo[] {
  const days: DayInfo[] = [];

  for (let offset = -2; offset <= 3; offset++) {
    const d = new Date(date);
    d.setDate(date.getDate() + offset);

    days.push({
      key: d.toISOString().substring(0, 10),
      label: d.toLocaleDateString(undefined, { weekday: "short" }),
      dayNumber: d.getDate(),
      isToday: offset === 0,
    });
  }

  return days;
}

export default function MedicationScreen() {
  const [lastSynced] = useState(new Date());
  const [selectedFilter, setSelectedFilter] = useState<FilterType>("All");

  const [currentBaseDate, setCurrentBaseDate] = useState(new Date());
  const days = useMemo(() => buildDaysAround(currentBaseDate), [currentBaseDate]);
  const initialDay = days.find((d) => d.isToday)?.key ?? days[0].key;
  const [selectedDayKey, setSelectedDayKey] = useState(initialDay);

  const [meds, setMeds] = useState(INITIAL_MEDS);

  const [searchOpen, setSearchOpen] = useState(false);
  const [search, setSearch] = useState("");

  const toggleGiven = (id: string) => {
    setMeds((prev) =>
      prev.map((m) => (m.id === id ? { ...m, isGiven: !m.isGiven } : m))
    );
  };

  const toggleReminder = (id: string) => {
    setMeds((prev) =>
      prev.map((m) =>
        m.id === id ? { ...m, hasReminder: !m.hasReminder } : m
      )
    );
  };

  const filteredMeds = meds
    .filter((m) =>
      m.patientName.toLowerCase().includes(search.toLowerCase())
    )
    .filter((m) => {
      if (selectedFilter === "Given") return m.isGiven;
      if (selectedFilter === "Not Given") return !m.isGiven;
      return true;
    });

  return (
    <SafeAreaView style={styles.screen}>
      <View style={styles.panel}>
        <ScrollView style={{ flex: 1 }} contentContainerStyle={styles.scrollContent}>

          <View style={styles.headerRow}>
            <Pressable onPress={() => router.replace("/(tabs)")}>
              <Ionicons name="chevron-back" size={24} color={theme.colors.text} />
            </Pressable>

            {!searchOpen && (
              <View style={styles.headerTitleBlock}>
                <Text style={styles.headerTitle}>Medication</Text>
                <Text style={styles.headerSubtitle}>
                  Last synced: {lastSynced.toLocaleDateString()} ,{" "}
                  {lastSynced.toLocaleTimeString()}
                </Text>
              </View>
            )}

            {!searchOpen && (
              <View style={styles.headerRight}>
                <Pressable onPress={() => setSearchOpen(true)}>
                  <Ionicons name="search-outline" size={24} color={theme.colors.text} />
                </Pressable>

                <Pressable style={{ marginLeft: 12 }}>
                  <MaterialCommunityIcons name="qrcode-scan" size={26} color={theme.colors.text} />
                </Pressable>
              </View>
            )}

            {searchOpen && (
              <View style={styles.searchBar}>
                <Ionicons name="search" size={18} color={theme.colors.mutedText} />
                <TextInput
                  style={styles.searchInput}
                  placeholder="Search patients..."
                  placeholderTextColor={theme.colors.mutedText}
                  value={search}
                  onChangeText={setSearch}
                  autoFocus
                />
                <Pressable
                  onPress={() => {
                    setSearch("");
                    setSearchOpen(false);
                  }}
                >
                  <Ionicons name="close" size={20} color={theme.colors.mutedText} />
                </Pressable>
              </View>
            )}
          </View>

          <View style={styles.filterRow}>
            {(["All", "Not Given", "Given"] as FilterType[]).map((f) => {
              const active = f === selectedFilter;
              return (
                <Pressable
                  key={f}
                  style={[styles.filterTab, active && styles.filterTabActive]}
                  onPress={() => setSelectedFilter(f)}
                >
                  <Text style={[styles.filterTabText, active && styles.filterTabTextActive]}>
                    {f}
                  </Text>
                </Pressable>
              );
            })}
          </View>

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
                    onPress={() => {
                      setSelectedDayKey(d.key);
                      setCurrentBaseDate(new Date(d.key));
                    }}
                    style={[styles.dateCard, active && styles.dateCardActive]}
                  >
                    <Text style={[styles.dateLabel, active && styles.dateLabelActive]}>
                      {d.label}
                    </Text>
                    <Text style={[styles.dateNumber, active && styles.dateNumberActive]}>
                      {d.dayNumber}
                    </Text>
                  </Pressable>
                );
              })}
            </ScrollView>
          </View>

          <View style={styles.mealList}>
            {filteredMeds.map((med) => (
              <View key={med.id} style={styles.mealCard}>

                <View style={styles.mealTopRow}>
                  <View style={styles.avatarCircle}>
                    <Text style={styles.avatarInitial}>
                      {med.patientName.charAt(0)}
                    </Text>
                  </View>

                  <View style={{ flex: 1 }}>
                    <View style={{ flexDirection: "row", justifyContent: "space-between", alignItems: "center" }}>
                      <Text style={styles.mealPatientName} numberOfLines={1}>
                        {med.patientName} ({med.age}yo)
                      </Text>

                      <Ionicons name="chevron-forward" size={20} color={theme.colors.mutedText} />
                    </View>

                    <View style={styles.mealMetaRow}>
                      <MaterialCommunityIcons name="hospital-building" size={14} color={theme.colors.mutedText} />
                      <Text style={styles.mealMetaText}>WARD – {med.ward}</Text>

                      <Text style={{ marginHorizontal: 6, color: theme.colors.mutedText }}>|</Text>

                      <MaterialCommunityIcons name="bed-outline" size={14} color={theme.colors.mutedText} />
                      <Text style={styles.mealMetaText}>{med.room}</Text>
                    </View>

                    <View style={{ flexDirection: "row", alignItems: "center", marginTop: 2 }}>
                      <Ionicons name="calendar-outline" size={14} color={theme.colors.mutedText} />
                      <Text style={styles.mealMetaText}>{med.daysAdmitted}</Text>
                    </View>
                  </View>
                </View>

                <View style={styles.topSeparator} />

                <View style={styles.medInfoBlock}>
                  <View style={styles.medNameRow}>
                    <MaterialCommunityIcons name="pill" size={18} color={theme.colors.primaryDark} style={{ marginRight: 6 }} />
                    <Text style={styles.medName}>{med.medName}</Text>
                  </View>
                  <Text style={styles.doseText}>{med.doseText}</Text>
                </View>

                <View style={styles.mealNotes}>
                  <Text style={styles.mealNotesText}>- Instructions: {med.instructions}</Text>
                  <Text style={styles.mealNotesText}>- End Date: {med.endDate}</Text>
                </View>

                <View style={styles.mealBottomRow}>
                  <Pressable style={styles.addReminderWrapper} onPress={() => toggleReminder(med.id)}>
                    <Ionicons
                      name={med.hasReminder ? "notifications" : "notifications-outline"}
                      size={18}
                      color={theme.colors.primaryDark}
                      style={{ marginRight: 4 }}
                    />
                    <Text style={[styles.addReminderText, med.hasReminder && styles.addReminderTextActive]}>
                      {med.hasReminder ? "Remove reminder" : "Add reminder"}
                    </Text>
                  </Pressable>

                  <Pressable
                    style={[styles.checkButton, med.isGiven && styles.checkButtonActive]}
                    onPress={() => toggleGiven(med.id)}
                  >
                    {med.isGiven && (
                      <Ionicons name="checkmark" size={18} color={theme.colors.primaryDark} />
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
  headerTitleBlock: {
    flex: 1,
    marginLeft: theme.spacing.sm,
  },
  headerTitle: {
    fontSize: theme.font.lg,
    fontWeight: "800",
    color: theme.colors.text,
  },
  headerSubtitle: {
    fontSize: theme.font.sm - 2,
    color: theme.colors.mutedText,
  },
  headerRight: {
    flexDirection: "row",
    alignItems: "center",
  },
  searchBar: {
    flexDirection: "row",
    backgroundColor: theme.colors.inputBg,
    borderRadius: theme.radii.md,
    paddingHorizontal: 10,
    paddingVertical: 6,
    borderWidth: 1,
    borderColor: theme.colors.border,
    alignItems: "center",
    flex: 1,
    marginLeft: theme.spacing.sm,
  },
  searchInput: {
    flex: 1,
    marginLeft: 6,
    color: theme.colors.text,
    fontSize: theme.font.md,
  },
  filterRow: {
    flexDirection: "row",
    borderRadius: theme.radii.md,
    backgroundColor: theme.colors.inputBg,
    marginBottom: theme.spacing.sm,
    overflow: "hidden",
  },
  filterTab: {
    flex: 1,
    paddingVertical: 10,
    alignItems: "center",
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
    color: "#fff",
  },
  dateRowContent: {
    paddingTop: theme.spacing.sm,
    paddingRight: theme.spacing.sm,
  },
  dateCard: {
    minWidth: 64,
    height: 76,
    paddingHorizontal: theme.spacing.md,
    borderRadius: theme.radii.md,
    borderWidth: 1,
    borderColor: theme.colors.border,
    backgroundColor: theme.colors.card,
    justifyContent: "center",
    alignItems: "center",
    marginRight: theme.spacing.sm,
  },
  dateCardActive: {
    backgroundColor: theme.colors.primary,
  },
  dateLabel: {
    fontSize: theme.font.sm - 2,
    color: theme.colors.mutedText,
  },
  dateLabelActive: {
    color: "#fff",
  },
  dateNumber: {
    fontSize: theme.font.md,
    fontWeight: "700",
    marginTop: 4,
    color: theme.colors.text,
  },
  dateNumberActive: {
    color: "#fff",
  },
  mealList: {
    marginTop: theme.spacing.sm,
  },
  mealCard: {
    borderRadius: theme.radii.md,
    borderWidth: 1,
    borderColor: theme.colors.border,
    padding: theme.spacing.md,
    marginBottom: theme.spacing.sm,
    backgroundColor: theme.colors.card,
  },
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
  },
  mealMetaRow: {
    flexDirection: "row",
    alignItems: "center",
    marginTop: 2,
  },
  mealMetaText: {
    fontSize: theme.font.sm - 2,
    color: theme.colors.mutedText,
  },
  mealMetaIcon: {
    marginLeft: 4,
    marginRight: 2,
  },
  topSeparator: {
    height: 1,
    backgroundColor: theme.colors.border,
    marginVertical: theme.spacing.sm,
  },
  medInfoBlock: {
    marginBottom: theme.spacing.sm,
  },
  medNameRow: {
    flexDirection: "row",
    alignItems: "center",
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
    justifyContent: "space-between",
    borderTopWidth: 1,
    borderTopColor: theme.colors.border,
    paddingTop: theme.spacing.sm,
  },
  addReminderWrapper: {
    flexDirection: "row",
    alignItems: "center",
  },
  addReminderText: {
    fontSize: theme.font.sm,
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
  checkButtonActive: {
    backgroundColor: "#e5f4f1",
  },
});
