// app/index.tsx
import React, { useEffect, useState } from 'react';
import { ActivityIndicator, View, StyleSheet } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { theme } from '../../styles/theme';
import { useRouter } from 'expo-router';

export default function Index() {
  const [isReady, setIsReady] = useState(false);
  const [isAuthed, setIsAuthed] = useState(false);
  const router = useRouter();

  useEffect(() => {
    
    const checkAuth = async () => {
      await AsyncStorage.removeItem('auth_token');
      try {
        const token = await AsyncStorage.getItem('auth_token');
        setIsAuthed(!!token);
      } catch (err) {
        console.warn('Error reading auth token', err);
      } finally {
        setIsReady(true);
      }
    };

    checkAuth();
  }, []);

  useEffect(() => {
    if (!isReady) return;

    
    if (isAuthed) {
      router.replace('/home');
    } else {
      router.replace('/login');
    }
  }, [isReady, isAuthed, router]);

  if (!isReady) {
    return (
      <View style={styles.loaderContainer}>
        <ActivityIndicator size="large" color={theme.colors.primary} />
      </View>
    );
  }

  // We already navigated away from this screen
  return null;
}

const styles = StyleSheet.create({
  loaderContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: theme.colors.bg,
  },
});
