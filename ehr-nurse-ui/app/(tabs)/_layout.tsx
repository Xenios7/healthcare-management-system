import { Tabs } from "expo-router";
import React from "react";
import { MaterialCommunityIcons, Ionicons } from "@expo/vector-icons";
import { theme } from "../../styles/theme";

export default function TabsLayout() {
  return (
    <Tabs
      screenOptions={{
        headerShown: false,
        tabBarStyle: { display: 'none' },
        tabBarActiveTintColor: theme.colors.primary,
        tabBarInactiveTintColor: theme.colors.mutedText,
        tabBarStyle: {
          flexDirection: "row",
          alignItems: "center",
          justifyContent: "space-around",
          borderTopWidth: 1,
          borderTopColor: theme.colors.border,
          paddingVertical: theme.spacing.sm,
          height: 60,
          backgroundColor: theme.colors.card,
        },
      }}
    >
      <Tabs.Screen name="index" />
      <Tabs.Screen
        name="qrcode"
        options={{ href: null }}
      />
      <Tabs.Screen name="Appointments" />
    </Tabs>
  );
}
