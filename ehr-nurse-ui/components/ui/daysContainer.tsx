import React, { useEffect, useRef } from "react";
import {
  View,
  Text,
  StyleSheet,
  FlatList,
  TouchableOpacity,
  useWindowDimensions,
  FlatListProps,
} from "react-native";
import { theme } from "../../styles/theme";

type DayItem = {
  day: string;
  date: string;
  month: string;
};

type DaysContainerProps = {
  days: DayItem[];
  selectedDay: string;
  onSelect: (date: string) => void;
};

export const DaysContainer: React.FC<DaysContainerProps> = ({
  days,
  selectedDay,
  onSelect,
}) => {
  const { width } = useWindowDimensions();
  const dayWidth = Math.min(82, width / 4.5);
  const listRef = useRef<FlatList<DayItem> | null>(null);

  // auto-scroll στη σημερινή μέρα
  useEffect(() => {
    if (!days.length || !listRef.current) return;

    const today = new Date();
    const todayDate = today.getDate().toString().padStart(2, "0");
    const todayMonth = today.toLocaleDateString(undefined, {
      month: "short",
    });

    const todayIndex = days.findIndex(
      (d) => d.date === todayDate && d.month === todayMonth
    );

    if (todayIndex > 0) {
      listRef.current.scrollToIndex({
        index: todayIndex,
        animated: true,
      });
    }
  }, [days]);

  const getItemLayout: FlatListProps<DayItem>["getItemLayout"] = (
    _data,
    index
  ) => ({
    length: dayWidth + 8,
    offset: (dayWidth + 8) * index,
    index,
  });

  return (
    <View style={styles.container}>
      <FlatList
        ref={listRef}
        horizontal
        data={days}
        keyExtractor={(_, index) => index.toString()}
        showsHorizontalScrollIndicator={false}
        contentContainerStyle={styles.listContent}
        getItemLayout={getItemLayout}
        snapToInterval={dayWidth + 8}
        decelerationRate="fast"
        renderItem={({ item }) => {
          const isActive = item.date === selectedDay;

          return (
            <TouchableOpacity
              style={[
                styles.dayItem,
                { width: dayWidth },
                isActive && styles.dayItemActive,
              ]}
              onPress={() => onSelect(item.date)}
            >
              <Text style={[styles.dayName, isActive && styles.dayNameActive]}>
                {item.day}
              </Text>
              <Text
                style={[styles.dayNumber, isActive && styles.dayNumberActive]}
              >
                {item.date}
              </Text>
              <Text
                style={[styles.monthName, isActive && styles.monthNameActive]}
              >
                {item.month}
              </Text>
            </TouchableOpacity>
          );
        }}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: { marginBottom: 16 },
  listContent: { paddingHorizontal: 4 },
  dayItem: {
    marginHorizontal: 4,
    paddingVertical: 6,
    borderRadius: 16,
    backgroundColor: "#FFFFFF" ,
    alignItems: "center",
  },
  dayItemActive: {
    backgroundColor: theme.colors.primary,
  },
  dayName: {
    fontSize: 11,
    color: theme.colors.mutedText,
  },
  dayNameActive: {
    color: "#FFFFFF",
  },
  dayNumber: {
    fontSize: 18,
    fontWeight: "700",
    color: theme.colors.text,
    marginVertical: 2,
  },
  dayNumberActive: {
    color: "#FFFFFF",
  },
  monthName: {
    fontSize: 11,
    color: theme.colors.mutedText,
  },
  monthNameActive: {
    color: "#FFFFFF",
  },
});
