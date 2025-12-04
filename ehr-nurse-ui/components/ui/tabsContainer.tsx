import React from "react";
import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  TouchableOpacity,
  useWindowDimensions,
} from "react-native";
import { theme } from "../../styles/theme";

type TabsContainerProps = {
  tabs: string[];
  selectedTab: string;
  onSelect: (tab: string) => void;
};

export const TabsContainer: React.FC<TabsContainerProps> = ({
  tabs,
  selectedTab,
  onSelect,
}) => {
  const { width } = useWindowDimensions();

  const tabMinWidth = Math.min(width / 3 - 16, 160);

  return (
    <View style={styles.container}>
      <ScrollView
        horizontal
        showsHorizontalScrollIndicator={false}
        contentContainerStyle={styles.scrollContent}
      >
        {tabs.map((tab) => {
          const isActive = tab === selectedTab;

          return (
            <TouchableOpacity
              key={tab}
              onPress={() => onSelect(tab)}
              style={[
                styles.tab,
                { minWidth: tabMinWidth },
                isActive && styles.tabActive,
              ]}
            >
              <Text
                numberOfLines={1}
                style={[styles.tabText, isActive && styles.tabTextActive]}
              >
                {tab}
              </Text>
            </TouchableOpacity>
          );
        })}
      </ScrollView>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginBottom: 12,
  },
  scrollContent: {
    paddingHorizontal: 4,
    alignItems: "center",
  },
  tab: {
    paddingHorizontal: 14,
    paddingVertical: 8,
    borderRadius: 999,
    marginHorizontal: 4,
    backgroundColor: "#FFFFFF",
    borderWidth: 1,
    borderColor: theme.colors.border,
    justifyContent: "center",
    alignItems: "center",
  },
  tabActive: {
    backgroundColor: theme.colors.primary,
    borderColor: theme.colors.primary,
    shadowColor: "#000",
    shadowOpacity: 0.12,
    shadowRadius: 4,
    shadowOffset: { width: 0, height: 2 },
    elevation: 3,
  },
  tabText: {
    fontSize: 13,
    fontWeight: "500",
    color: theme.colors.mutedText,
  },
  tabTextActive: {
    color: "#FFFFFF",
  },
});
