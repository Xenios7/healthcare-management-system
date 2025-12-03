import React, { useState, useEffect, useMemo } from "react";
import {
    View,
    Text,
    StyleSheet,
    Image,
    ScrollView,
    TouchableOpacity,
} from "react-native";

import {
    MaterialIcons,
    MaterialCommunityIcons,
    FontAwesome,
} from "@expo/vector-icons";

import { theme } from "../../styles/theme";
import { SafeAreaView } from "react-native-safe-area-context";
import { TabsContainer } from "@/components/ui/tabsContainer";
import { DaysContainer } from "@/components/ui/daysContainer";
import { router, useLocalSearchParams, usePathname } from "expo-router";

type PatientCard = {
    id: number;
    name: string;
    age: number | null;
    ward: string;
    bed: string;
    daysInWard: number;
};

function getStr(value: any, fallback: string): string {
    if (Array.isArray(value)) return value[0] ?? fallback;
    if (typeof value === "string") return value;
    return fallback;
}

export default function Inpatient5Screen() {
    const params = useLocalSearchParams();
    const pathname = usePathname();

    const selectedTab = useMemo(() => {
        if (pathname.startsWith("/inpatient2")) return "Daily monitoring";
        if (pathname.startsWith("/inpatient3")) return "Medication";
        if (pathname.startsWith("/inpatient4")) return "Nutrition Intake";
        if (pathname.startsWith("/inpatient5")) return "Appointments";
        return "Daily monitoring";
    }, [pathname]);

    const [selectedDay, setSelectedDay] = useState("01");
    const [lastSynced, setLastSynced] = useState("");

    const tabs = [
        "Daily monitoring",
        "Medication",
        "Nutrition Intake",
        "Appointments",
    ];

    const days = [
        { day: "Mon", date: "01" },
        { day: "Tue", date: "02" },
        { day: "Wed", date: "03" },
        { day: "Thu", date: "04" },
        { day: "Fri", date: "05" },
        { day: "Sat", date: "06" },
    ];

    const appointments = [
        {
            name: "Dr Melissa Addam",
            roles: ["Speech Therapist"],
            status: "Confirmed",
            date: "07/10/2024",
            time: "2:00 PM",
            location: "Nicosia General Hospital",
            notes: "Bring patient without the wheelchair",
        },
        {
            name: "Dr Chivas,  Dr Melissa Addam",
            roles: ["Psychologist", "Speech Therapist"],
            status: "Confirmed",
            date: "07/10/2024",
            time: "2:00 PM",
            location: "Nicosia General Hospital",
            notes: "Bring patient without the wheelchair",
        },
    ];

    useEffect(() => {
        const now = new Date();
        setLastSynced(
            `${now.toLocaleDateString()} , ${now.toLocaleTimeString([], {
                hour: "2-digit",
                minute: "2-digit",
            })}`
        );
    }, []);

    const patient: PatientCard | null = useMemo(() => {
        try {
            const idStr = getStr(
                (params as any).patientId ?? (params as any).id,
                "101"
            );
            const name = getStr((params as any).name, "Test Patient2");
            const ageStr = getStr((params as any).age, "");
            const ward = getStr((params as any).ward, "WARD - 1");
            const bed = getStr((params as any).bed, "101");
            const daysStr = getStr((params as any).daysInWard, "88");

            return {
                id: Number(idStr),
                name,
                age: Number(ageStr),
                ward,
                bed,
                daysInWard: Number(daysStr),
            };
        } catch (e) {
            return {
                id: 1,
                name: "Test Patient2",
                age: 66,
                ward: "WARD - 1",
                bed: "101",
                daysInWard: 88,
            };
        }
    }, [
        params.patientId,
        params.id,
        params.name,
        params.age,
        params.ward,
        params.bed,
        params.daysInWard,
    ]);

    const navParams =
        patient && {
            patientId: String(patient.id),
            name: patient.name,
            age: patient.age != null ? String(patient.age) : "",
            ward: patient.ward,
            bed: patient.bed,
            daysInWard: String(patient.daysInWard),
        };

    const handleSelectTab = (tab: string) => {
        if (!navParams) return;

        switch (tab) {
            case "Daily monitoring":
                router.push({
                    pathname: "/inpatient2",
                    params: navParams,
                });
                break;

            case "Medication":
                router.push({
                    pathname: "/inpatient3",
                    params: navParams,
                });
                break;

            case "Nutrition Intake":
                router.push({
                    pathname: "/inpatient4",
                    params: navParams,
                });
                break;

            case "Appointments":
                router.push({
                    pathname: "/inpatient5",
                    params: navParams,
                });
                break;
        }
    };

    return (
        <SafeAreaView
            style={styles.safeContainer}
            edges={["top", "left", "right"]}
        >
            <View style={styles.inner}>
                <ScrollView
                    style={styles.container}
                    contentContainerStyle={{ paddingBottom: 120 }}
                >

                    <View style={styles.header}>
                        <TouchableOpacity onPress={() => router.replace("../patients")}>
                            <MaterialIcons
                                name="arrow-back-ios"
                                size={20}
                                color={theme.colors.text}
                            />
                        </TouchableOpacity>
                        <Text style={styles.headerTitle}>Patient Details</Text>
                    </View>

                    <Text style={styles.syncedText}>
                        Last synced: {lastSynced}
                    </Text>

                    <View style={styles.patientInfo}>
                        <Image
                            source={require("../../assets/images/user.png")}
                            style={styles.userIcon}
                        />

                        <View style={{ flex: 1 }}>
                            <Text style={styles.name}>
                                {patient?.name ?? "John Smith"} ({patient?.age ?? "?"}yo)
                            </Text>

                            <View style={{ flexDirection: "row", alignItems: "center" }}>
                                <MaterialCommunityIcons name="doctor" size={18} color="#B0B0B0" />
                                <Text style={[styles.subText, { marginLeft: 6 }]}>
                                    George Adamides
                                </Text>
                            </View>

                            <View style={{ flexDirection: "row", alignItems: "center" }}>
                                <FontAwesome name="bed" size={18} color="#B0B0B0" />
                                <Text style={[styles.subText, { marginLeft: 6 }]}>
                                    {patient?.ward ?? "Ward - 1"} | {patient?.bed ?? "101"} |{" "}
                                    {patient?.daysInWard ?? 0} days
                                </Text>
                            </View>
                        </View>
                    </View>

                    <TabsContainer
                        tabs={tabs}
                        selectedTab={selectedTab}
                        onSelect={handleSelectTab}
                    />

                    <DaysContainer
                        days={days}
                        selectedDay={selectedDay}
                        onSelect={setSelectedDay}
                    />

                    <Text style={styles.sectionTitle}>Patient appointment Schedule</Text>

                    {appointments.map((appt, i) => (
                        <View key={i} style={styles.appointmentCard}>

                            <View style={styles.userWrapper}>
                                {appt.roles.length > 1 ? (
                                    <View style={{ flexDirection: "row" }}>
                                        <Image
                                            source={require("../../assets/images/doctor_male.png")}
                                            style={[styles.user, { marginRight: 6 }]}
                                        />
                                        <Image
                                            source={require("../../assets/images/doctor_female.png")}
                                            style={styles.user}
                                        />
                                    </View>
                                ) : (
                                    <Image
                                        source={require("../../assets/images/doctor_female.png")}
                                        style={styles.user}
                                    />
                                )}
                            </View>

                            <Text style={styles.doctorName}> {appt.name}</Text>

                            <View style={styles.row}>
                                <MaterialCommunityIcons
                                    name="doctor"
                                    size={18}
                                    color="#B0B0B0"
                                />
                                <Text style={styles.subText}>
                                    {appt.roles.join(", ")}
                                </Text>

                                <MaterialCommunityIcons style={styles.checkCirclePadding}
                                    name="check-circle"
                                    size={18}
                                    color="#41B06E"

                                />
                                <Text style={[styles.subText, { color: "#41B06E" }]}>
                                    {appt.status}
                                </Text>
                            </View>

                            <View style={styles.row}>
                                <MaterialIcons name="event" size={20} color="#B0B0B0" />
                                <Text style={styles.subText}>{appt.date}</Text>
                            </View>

                            <View style={styles.row}>
                                <MaterialIcons name="access-time" size={20} color="#B0B0B0" />
                                <Text style={styles.subText}>{appt.time}</Text>
                            </View>

                            <View style={styles.row}>
                                <MaterialIcons name="place" size={20} color="#B0B0B0" />
                                <Text style={styles.subText}>{appt.location}</Text>
                            </View>

                            <View style={styles.line}></View>
                            <Text style={styles.notes}>• {appt.notes}</Text>

                            <View style={styles.buttonRow}>
                                <TouchableOpacity style={[styles.btnNotAttend, styles.btnSpacing]}>
                                    <Text style={styles.btnText}>Did not attend</Text>
                                </TouchableOpacity>

                                <TouchableOpacity style={[styles.btnPostponed, styles.btnSpacing]}>
                                    <Text style={styles.btnText}>Postponed</Text>
                                </TouchableOpacity>

                                <TouchableOpacity style={[styles.btnCompleted, styles.btnSpacing]}>
                                    <Text style={styles.btnText}>Completed</Text>
                                </TouchableOpacity>
                            </View>
                        </View>
                    ))}

                </ScrollView>
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
        paddingTop: 8,
        paddingHorizontal: 16,
        maxWidth: 600,
        alignSelf: "center",
        width: "100%",
    },

    container: {
        flex: 1,
        backgroundColor: theme.colors.bg,
        padding: theme.spacing.md,
    },

    header: {
        flexDirection: "row",
        alignItems: "center",
        marginBottom: theme.spacing.xs,
    },

    headerTitle: {
        fontSize: theme.font.lg,
        fontWeight: "700",
        marginLeft: theme.spacing.xs,
        color: theme.colors.text,
    },

    syncedText: {
        fontSize: theme.font.sm,
        color: theme.colors.mutedText,
        marginBottom: theme.spacing.md,
    },

    patientInfo: {
        flexDirection: "row",
        alignItems: "center",
        marginBottom: theme.spacing.lg,
    },

    userIcon: {
        width: 60,
        height: 60,
        marginRight: theme.spacing.md,
    },

    name: {
        fontSize: theme.font.md,
        fontWeight: "700",
        color: theme.colors.text,
        marginBottom: 3,
    },

    subText: {
        fontSize: theme.font.sm,
        color: theme.colors.mutedText,
        marginLeft: 6,
    },

    sectionTitle: {
        fontSize: theme.font.md,
        fontWeight: "600",
        marginBottom: theme.spacing.md,
    },

    row: {
        flexDirection: "row",
        alignItems: "center",
        marginTop: 3,
    },

    appointmentCard: {
        backgroundColor: "#FFF",
        padding: 18,
        borderRadius: 16,
        marginBottom: 18,
        shadowColor: "#000",
        shadowOpacity: 0.08,
        shadowRadius: 5,
        elevation: 4,
        position: "relative",
    },

    userWrapper: {
        position: "absolute",
        top: 16,
        right: 16,
    },

    user: {
        width: 40,
        height: 40,
        borderRadius: 20,
    },

    doctorName: {
        fontSize: 16,
        fontWeight: "700",
        color: theme.colors.text,
        marginBottom: 6,
        marginTop: 10,
    },

    checkCirclePadding: {
        paddingLeft: 6,
    },

    line: {
        height: 1,
        backgroundColor: theme.colors.border,
        marginTop: 10
    },

    notes: {
        fontSize: 12,
        color: theme.colors.mutedText,
        marginTop: 10,
    },

    buttonRow: {
        flexDirection: "row",
        marginTop: 16,
    },

    btnSpacing: {
        marginRight: 8,
    },

    btnNotAttend: {
        backgroundColor: "#FF8A8A",
        paddingVertical: 8,
        paddingHorizontal: 14,
        borderRadius: 8,
    },
    btnPostponed: {
        backgroundColor: "#FFC46B",
        paddingVertical: 8,
        paddingHorizontal: 14,
        borderRadius: 8,
    },
    btnCompleted: {
        backgroundColor: theme.colors.primary,
        paddingVertical: 8,
        paddingHorizontal: 14,
        borderRadius: 8,
    },

    btnText: {
        color: "#FFF",
        fontWeight: "600",
    },


    bottomNav: {
        position: "absolute",
        bottom: 0,
        left: 0,
        right: 0,
        flexDirection: "row",
        justifyContent: "space-around",
        alignItems: "center",
        paddingVertical: theme.spacing.lg,
        backgroundColor: "#FFF",
        shadowColor: "#000",
        shadowOpacity: 0.08,
        shadowRadius: 6,
        shadowOffset: { width: 0, height: -2 },
        elevation: 12,
    },
});
