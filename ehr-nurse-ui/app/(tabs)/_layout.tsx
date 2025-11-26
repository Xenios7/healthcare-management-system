import { Tabs } from "expo-router";
import React from "react";
import { theme } from "../../styles/theme";

export default function TabsLayout() {
  return (
    <Tabs
      screenOptions={{
        headerShown: false,
        tabBarStyle: { display: "none" },
        tabBarActiveTintColor: theme.colors.primary,
        tabBarInactiveTintColor: theme.colors.mutedText,
      }}
    >
      <Tabs.Screen name="index" />
      <Tabs.Screen
        name="qrcode"
        options={{ href: null }}
      />
      <Tabs.Screen name="Appointments" />
      <Tabs.Screen name="medication" />
      <Tabs.Screen name="nutrition" />
    </Tabs>
  );
}
