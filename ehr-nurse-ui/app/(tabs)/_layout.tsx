import { Tabs } from 'expo-router';
import { MaterialIcons } from '@expo/vector-icons';
import { theme } from '../../styles/theme';
import React from 'react';

export default function TabsLayout() {
  return (
    <Tabs
      screenOptions={{
        headerShown: false,
        tabBarActiveTintColor: theme.colors.primary,
        tabBarInactiveTintColor: theme.colors.mutedText,
      }}
    >
      {/* Home Screen */}
      <Tabs.Screen
        name="index"
        options={{
          title: 'Home',
          tabBarIcon: ({ color, size }) => (
            <MaterialIcons name="home" color={color} size={size} />
          ),
        }}
      />

      {/* QR Code Scanner Screen  */}
      <Tabs.Screen
        name="qrcode"
        options={{
          href: null,                     
          tabBarStyle: { display: "none" },  
        }}
      />
      {/* Appointments Screen */}
      <Tabs.Screen
        name="Appointments"
        options={{ title: 'Appointments' }}
      />
    </Tabs>
  );
}
