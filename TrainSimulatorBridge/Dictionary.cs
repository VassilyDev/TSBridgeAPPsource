using System;

namespace TrainSimulatorBridge
{
    class Dictionary
    {
        // DATI VALIDI PER LOCOMOTIVE NON IN ELENCO
        public static String[] thrNames = { "Regulator", "ThrottleAndBrake", "VirtualThrottle", "SimpleThrottle" };
        public static String[] brkNames = { "TrainBrakeControl", "VirtualBrake" };
        public static String[] revNames = { "UserVirtualReverser", "VirtualReverser", "Reverser" };
        // GENERIC
        public static String[] hornNames = { "Horn" };
        public static String[] wipNames = { "Wipers", "VirtualWipers" };
        public static String[] speedNames = { "SpeedometerKPH", "SpeedometerMPH" };
        public static String[] sandNames = { "Sander" };
        public static String[] ampNames = { "Ammeter" };
        public static String[] pantNames = { "PantographControl" };
        public static String[] strtNames = { "Startup" };
        public static String[] lightsNames = { "Headlights", "VirtualHeadlights" };
        public static String[] emergencyNames = { "EmergencyBrake" };
        public static String[] doorRNames = { "DoorsOpenCloseRight", "DoorsOpenClose" };
        public static String[] doorLNames = { "DoorsOpenCloseLeft", "DoorsOpenClose" };
        // VIGIL
        public static String[] vigilENNames = { "VigilEnable" };
        public static String[] vigilALNames = { "VigilAlarm" };
        public static String[] vigilRENames = { "VigilReset" };
        // AWS
        public static String[] AWSNames = { "AWS" };
        public static String[] AWSResetNames = { "AWSReset" };
        // PZB
        public static String[] PZB40Names = { "PZB40", };
        public static String[] PZB55Names = { "PZB55", "PZB_55" };
        public static String[] PZB70Names = { "PZB70", "PZB_70" };
        public static String[] PZB85Names = { "PZB85", "PZB_85" };
        public static String[] PZB500Names = { "PZB_500hz_Control", "PZB500", "PZB_500" };
        public static String[] PZB1000Names = { "PZB_1000hz_Control", "PZB1000", "PZB_1000" };
        public static String[] PZBWarnNames = { "PZBWarn" };
        public static String[] CMD40Names = { "Cmd_40" };
        public static String[] CMDFreeNames = { "Cmd_Free" };
        public static String[] CMDWNames = { };
    }
}
