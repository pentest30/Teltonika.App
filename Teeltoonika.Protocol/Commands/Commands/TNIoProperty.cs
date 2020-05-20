namespace Teeltoonika.Protocol.Commands.Commands
{
    public enum TNIoProperty
    {
        /// <summary>
        /// Aucun évènnement
        /// </summary>
        //[JsonProperty(PropertyName = "no")]
        No_Event = 0,
        /// <summary>
        /// Digital Input Status 1 (Logic: 0 / 1)
        /// </summary>
        //[JsonProperty(PropertyName = "dis1")]
        Digital_Input_Status_1 = 1,
        /// <summary>
        /// Digital Input Status 2 (Logic: 0 / 1)
        /// </summary>
        //[JsonProperty(PropertyName = "dis2")]
        Digital_Input_Status_2 = 2,
        /// <summary>
        /// Digital Input Status 3 (Logic: 0 / 1)
        /// </summary>
        //[JsonProperty(PropertyName = "dis3")]
        Digital_Input_Status_3 = 3,
        /// <summary>
        /// Digital Input Status 4 (Logic: 0 / 1)
        /// </summary>
        //[JsonProperty(PropertyName = "dis4")]
        Digital_Input_Status_4 = 4,
        /// <summary>
        /// Dallas Temperature 5 (10 * Degrees ( °C ), -55 - +115, if 3000 – Dallas error)
        /// </summary>
        Dallas_Temperature_5 = 5,
        /// <summary>
        /// Dallas Temperature ID5 (ID of Dallas Temperature Sensor 5)
        /// </summary>
        Dallas_Temperature_ID5 = 6,
        /// <summary>
        /// Dallas Temperature 6 (10 * Degrees ( °C ), -55 - +115, if 3000 – Dallas error)
        /// </summary>
        Dallas_Temperature_6 = 7,
        /// <summary>
        /// Dallas Temperature ID6 (ID of Dallas Temperature Sensor 6)
        /// </summary>
        Dallas_Temperature_ID6 = 8,
        /// <summary>
        /// Analog Input 1 (Voltage: mV, 0 – 30 V)
        /// </summary>
        //[JsonProperty(PropertyName = "ani1")]
        Analog_Input_1 = 9,
        /// <summary>
        /// Analog Input 2 (Voltage: mV, 0 – 30 V)
        /// </summary>
        //[JsonProperty(PropertyName = "ani2")]
        Analog_Input_2 = 10,
        /// <summary>
        /// Analog Input 3 (Voltage: mV, 0 – 30 V)
        /// </summary>
        //[JsonProperty(PropertyName = "ani3")]
        Analog_Input_3 = 11,
        /// <summary>
        /// LVCAN Program Number (LVCAN Program Number)
        /// </summary>
        LVCAN_Program_Number = 12,
        /// <summary>
        /// LVCAN ModuleID (Module ID)
        /// </summary>
        LVCAN_ModuleID = 13,
        /// <summary>
        /// Analog Input 4 (Voltage: mV, 0 – 30 V)
        /// </summary>
        //[JsonProperty(PropertyName = "ani4")]
        Analog_Input_4 = 19,
        /// <summary>
        /// GSM signal level (Value in scale 1 – 5)
        /// </summary>
        //[JsonProperty(PropertyName = "sig")]
        GSM_signal_level = 21,
        /// <summary>
        /// Actual profile (Value in scale 1 – 4)
        /// </summary>
        Actual_profile = 22,
        /// <summary>
        /// Speedometer (Value in km/h, 0 – xxx km/h)
        /// </summary>
        Speedometer = 24,
        /// <summary>
        /// LVCAN Speed (Value in km/h)
        /// </summary>
        LVCAN_Speed = 30,
        /// <summary>
        /// LVCAN Acc Pedal (Value in persentages, %)
        /// </summary>
        LVCAN_Acc_Pedal = 31,
        /// <summary>
        /// LVCAN Fuel Consumed (Value in liters, L)
        /// </summary>
        LVCAN_Fuel_Consumed = 33,
        /// <summary>
        /// LVCAN Fuel Level (liters) (Value in liters, L)
        /// </summary>
        LVCAN_Fuel_Level_Liters = 34,
        /// <summary>
        /// LVCAN Engine RPM (Value in rounds per minute, rpm)
        /// </summary>
        LVCAN_Engine_RPM = 35,
        /// <summary>
        /// LVCAN Total Mileage (Value in meters, m)
        /// </summary>
        LVCAN_Total_Mileage = 36,
        /// <summary>
        /// LVCAN Fuel Level (percents) (Value in percentages, %)
        /// </summary>
        LVCAN_Fuel_Level_Percents = 37,
        /// <summary>
        /// Digital Output 3 (Logic: 0 / 1)
        /// </summary>
        Digital_Output_3 = 50,
        /// <summary>
        /// Digital Output 4 (Logic: 0 / 1)
        /// </summary>
        Digital_Output_4 = 51,
        /// <summary>
        /// Dallas Temperature ID1 (ID of Dallas Temperature Sensor 1)
        /// </summary>
        Dallas_Temperature_ID1 = 62,
        /// <summary>
        /// Dallas Temperature ID2 (ID of Dallas Temperature Sensor 2)
        /// </summary>
        Dallas_Temperature_ID2 = 63,
        /// <summary>
        /// Dallas Temperature ID3 (ID of Dallas Temperature Sensor 3)
        /// </summary>
        Dallas_Temperature_ID3 = 64,
        /// <summary>
        /// Dallas Temperature ID4 (ID of Dallas Temperature Sensor 4)
        /// </summary>
        Dallas_Temperature_ID4 = 65,
        /// <summary>
        /// External Power Voltage (Voltage: mV, 0 – 30 V)
        /// </summary>
        //[JsonProperty(PropertyName = "epv")]
        External_Power_Voltage = 66,
        /// <summary>
        /// Internal Battery Voltage (Voltage: mV)
        /// </summary>
        //[JsonProperty(PropertyName = "ibv")]
        Internal_Battery_Voltage = 67,
        /// <summary>
        /// Internal Battery Current (Voltage: mA)
        /// </summary>
        //[JsonProperty(PropertyName = "ibc")]
        Internal_Battery_Current = 68,
        /// <summary>
        /// PCB Temperature (10 * Degrees ( °C ))
        /// </summary>
        //[JsonProperty(PropertyName = "pcb")]
        PCB_Temperature = 70,
        /// <summary>
        /// GNSS status (0-off/ 1-no antenna (only when using NAVYS)/ 2- no fix/ 3-got fix/ 4-sleep/ 5-over current)
        /// </summary>
        GNSS_status = 71,
        /// <summary>
        /// Dallas Temperature 1 (10 * Degrees ( °C ), -55 - +115, if 3000 – Dallas error)
        /// </summary>
        Dallas_Temperature_1 = 72,
        /// <summary>
        /// Dallas Temperature2 (10 * Degrees ( °C ), -55 - +115, if 3000 – Dallas error)
        /// </summary>
        Dallas_Temperature_2 = 73,
        /// <summary>
        /// Dallas Temperature 3 (10 * Degrees ( °C ), -55 - +115, if 3000 – Dallas error)
        /// </summary>
        Dallas_Temperature_3 = 74,
        /// <summary>
        /// Dallas Temperature 4 (10 * Degrees ( °C ), -55 - +115, if 3000 – Dallas error)
        /// </summary>
        Dallas_Temperature_4 = 75,
        /// <summary>
        /// Fuel Counter (Difference of generated impulses on two signal lines)
        /// </summary>
        Fuel_Counter = 76,
        /// <summary>
        /// iButton ID (iButton ID number)
        /// </summary>
        //[JsonProperty(PropertyName = "ibu")]
        iButton_ID = 78,
        /// <summary>
        /// Brake switch (0 – pedal released; 1 – pedal depressed)
        /// </summary>
        //[JsonProperty(PropertyName = "brs")]
        Brake_switch = 79,
        /// <summary>
        /// Wheel based speed (0-65536 (km/h)*)
        /// </summary>
        //[JsonProperty(PropertyName = "wbs")]
        Wheel_based_speed = 80,
        /// <summary>
        /// Cruise control active (0 = switched off ; 1 = switched on)
        /// </summary>
        //[JsonProperty(PropertyName = "cru")]
        Cruise_control_active = 81,
        /// <summary>
        /// Slutch switch (0 = pedal released; 1 = pedal depressed)
        /// </summary>
        //[JsonProperty(PropertyName = "slu")]
        Slutch_switch = 82,
        /// <summary>
        /// PTO state (0 = off/disabled; 1 = Set; 2 = not available)
        /// </summary>
        //[JsonProperty(PropertyName = "pto")]
        PTO_state = 83,
        /// <summary>
        /// Accelerator pedal position 1 (0-102 (%)*)
        /// </summary>
        //[JsonProperty(PropertyName = "acc")]
        Accelerator_pedal_position_1 = 84,
        /// <summary>
        /// Engine Percent Load At Current Speed (0-125 (%)*)
        /// </summary>
        //[JsonProperty(PropertyName = "enp")]
        Engine_Percent_Load_At_Current_Speed = 85,
        /// <summary>
        /// Engine total fuel used (0 – 2105540607,5 (Liters)*)
        /// </summary>
        //[JsonProperty(PropertyName = "fus")]
        Engine_total_fuel_used = 86,
        /// <summary>
        /// Fuel level 1 X (1-102 (%)*)
        /// </summary>
        //[JsonProperty(PropertyName = "fle")]
        Fuel_level_1_X = 87,
        /// <summary>
        /// Engine speed X (0 – 8031,875 (rpm)*)
        /// </summary>
        //[JsonProperty(PropertyName = "ens")]
        Engine_speed_X = 88,
        /// <summary>
        /// Axle_weight_1 (32766 (kg)*)
        /// </summary>
        Axle_weight_1 = 89,
        /// <summary>
        /// Axle_weight_2 (32766 (kg)*)
        /// </summary>
        Axle_weight_2 = 90,
        /// <summary>
        /// Axle_weight_3 (32766 (kg)*)
        /// </summary>
        Axle_weight_3 = 91,
        /// <summary>
        /// Axle_weight_4 (32766 (kg)*)
        /// </summary>
        Axle_weight_4 = 92,
        /// <summary>
        /// Axle_weight_5 (32766 (kg)*)
        /// </summary>
        Axle_weight_5 = 93,
        /// <summary>
        /// Axle_weight_6 (32766 (kg)*)
        /// </summary>
        Axle_weight_6 = 94,
        /// <summary>
        /// Axle_weight_7 (32766 (kg)*)
        /// </summary>
        Axle_weight_7 = 95,
        /// <summary>
        /// Axle_weight_8 (32766 (kg)*)
        /// </summary>
        Axle_weight_8 = 96,
        /// <summary>
        /// Axle_weight_9 (32766 (kg)*)
        /// </summary>
        Axle_weight_9 = 97,
        /// <summary>
        /// Axle_weight_10 (32766 (kg)*)
        /// </summary>
        Axle_weight_10 = 98,
        /// <summary>
        /// Axle_weight_11 (32766 (kg)*)
        /// </summary>
        Axle_weight_11 = 99,
        /// <summary>
        /// Axle_weight_12 (32766 (kg)*)
        /// </summary>
        Axle_weight_12 = 100,
        /// <summary>
        /// Axle_weight_13 (32766 (kg)*)
        /// </summary>
        Axle_weight_13 = 101,
        /// <summary>
        /// Axle_weight_14 (32766 (kg)*)
        /// </summary>
        Axle_weight_14 = 102,
        /// <summary>
        /// Axle_weight_15 (32766 (kg)*)
        /// </summary>
        Axle_weight_15 = 103,
        /// <summary>
        /// Engine total hours of Operation X (0 – 214748364 (Hours)*)
        /// </summary>
        Engine_total_hours_of_Operation_X = 104,
        /// <summary>
        /// vehicle identification number X part 1 (Max 24 ASCII bytes ???)
        /// </summary>
        //[JsonProperty(PropertyName = "vin1")]
        vehicle_identification_number_X_part1 = 105,
        /// <summary>
        /// vehicle identification number X part 2 (Max 24 ASCII bytes ???)
        /// </summary>
        //[JsonProperty(PropertyName = "vin2")]
        vehicle_identification_number_X_part2 = 106,
        /// <summary>
        /// vehicle identification number X part 3 (Max 24 ASCII bytes ???)
        /// </summary>
        //[JsonProperty(PropertyName = "vin3")]
        vehicle_identification_number_X_part3 = 107,
        /// <summary>
        /// vehicle identification number X part 4 (Max 24 ASCII bytes ???)
        /// </summary>
        //[JsonProperty(PropertyName = "vin4")]
        vehicle_identification_number_X_part4 = 108,
        /// <summary>
        /// SW-version supported X (4 ASCII bytes (Version format – ab.cd))
        /// </summary>
        SW_version_supported_X = 109,
        /// <summary>
        /// Diagnostics supported X (0 = diagnostics is not supported; 1 = diagnostics is supported;2 = reserved; 3 = don´t care)
        /// </summary>
        Diagnostics_supported_X = 110,
        /// <summary>
        /// Requests supported X (0 = request is not supported; 1= request is supported;2 = reserved; 3 = don´t care;)
        /// </summary>
        Requests_supported_X = 111,
        /// <summary>
        /// High resolution total vehicle distance X (0 - 21055406 km*)
        /// </summary>
        //[JsonProperty(PropertyName = "mil")]
        High_resolution_total_vehicle_distance_X = 112,
        /// <summary>
        /// Service distance (-160 635 – 167040 km*)
        /// </summary>
        Service_distance = 113,
        /// <summary>
        /// Vehicle motion X (0 – Motion Not Detected; 1 – Motion Detected)
        /// </summary>
        //[JsonProperty(PropertyName = "vmo")]
        Vehicle_motion_X = 114,
        /// <summary>
        /// driver 2 working state X (0 – Rest; 1 – Driver Available; 2 – Work; 3 – Drive;4 – Error; 5 – not available;)
        /// </summary>
        //[JsonProperty(PropertyName = "asl2")]
        driver_2_working_state_X = 115,
        /// <summary>
        /// driver 1 working state X (0 – Rest; 1 – Driver Available; 2 – Work; 3 – Drive;4 – Error; 5 – not available;)
        /// </summary>
        //[JsonProperty(PropertyName = "asl1")]
        driver_1_working_state_X = 116,
        /// <summary>
        /// Vehicle overspeed (0 – No Overspeed; 1 – Overspeed)
        /// </summary>
        //[JsonProperty(PropertyName = "ove")]
        Vehicle_overspeed = 117,
        /// <summary>
        /// Driver 1 time rel. states (0 – Normal; 1 – 15min bef. 4,5h; 2 – 4,5h reached;3 – 15min bef. 9h; 4 – 9h reached; 
        /// 5 – 15min bef. 16h;6 – 16h reached; 7 – Error; 8 – not available;)
        /// </summary>
        //[JsonProperty(PropertyName = "tsl1")]
        Driver_1_time_rel_states = 118,
        /// <summary>
        /// Driver 2 time rel. states (0 – Normal; 1 – 15min bef. 4,5h; 2 – 4,5h reached;3 – 15min bef. 9h; 4 – 9h reached; 
        /// 5 – 15min bef. 16h;6 – 16h reached; 7 – Error; 8 – not available;)
        /// </summary>
        //[JsonProperty(PropertyName = "tsl2")]
        Driver_2_time_rel_states = 119,
        /// <summary>
        /// Driver 1 card X (0 – Card Not Present; 1 – Card Present)
        /// </summary>
        //[JsonProperty(PropertyName = "csl1")]
        Driver_1_card_X = 120,
        /// <summary>
        /// Driver 2 card X (0 – Card Not Present; 1 – Card Present)
        /// </summary>
        //[JsonProperty(PropertyName = "csl2")]
        Driver_2_card_X = 121,
        /// <summary>
        /// Direction indicator (0 – Forward; 1 – Reverse;)
        /// </summary>
        Direction_indicator = 122,
        /// <summary>
        /// Tachograph performance X (0 – Normal perfomance; 1 – Performance analysis)
        /// </summary>
        Tachograph_performance_X = 123,
        /// <summary>
        ///  Handling information X (0 – No Handling information; 1 – Handling information)
        /// </summary>
        Handling_information_X = 124,
        /// <summary>
        /// System event X (0 – No Tacho Event; 1 – Tacho Event)
        /// </summary>
        System_event_X = 125,
        /// <summary>
        /// Tachograph vehicle speed X ([0 – 65000] – Tacho Vehicle Speed km/h*)
        /// </summary>
        //[JsonProperty(PropertyName = "tsp")]
        Tachograph_vehicle_speed_X = 126,
        /// <summary>
        /// engine coolant temperature X ([-40 – 210] oC– Engine Cooilant Temperature*)
        /// </summary>
        engine_coolant_temperature_X = 127,
        /// <summary>
        /// Ambient Air Temperature X ([-273 – 1770]oC – Ambient Air Temperature*)
        /// </summary>
        Ambient_Air_Temperature_X = 128,
        /// <summary>
        /// Driver 1 Identification part 1 (24 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "d11")]
        Driver_1_Identification_part1 = 129,
        /// <summary>
        /// Driver 1 Identification part 2 (24 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "d12")]
        Driver_1_Identification_part2 = 130,
        /// <summary>
        /// Driver 1 Identification part 3 (24 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "d13")]
        Driver_1_Identification_part3 = 131,
        /// <summary>
        /// Driver 2 Identification part 1 (24 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "d21")]
        Driver_2_Identification_part1 = 132,
        /// <summary>
        /// Driver 2 Identification part 2 (24 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "d22")]
        Driver_2_Identification_part2 = 133,
        /// <summary>
        /// Driver 2 Identification part 3 (24 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "d23")]
        Driver_2_Identification_part3 = 134,
        /// <summary>
        /// Fuel rate X ([0 – 3212,75] litres/h*)
        /// </summary>
        Fuel_rate_X = 135,
        /// <summary>
        /// Instantaneous Fuel Economy ([0 – 125.5 km/litre ]*)
        /// </summary>
        Instantaneous_Fuel_Economy_X = 136,
        /// <summary>
        /// At least one PTO engaged (0 – No PTO Drive is Engaged; 1 – At least one PTO drive is engaged; 2 – Error; 
        /// 3 – not available;)
        /// </summary>
        At_least_one_PTO_engaged = 137,
        /// <summary>
        /// High resolution engine total fuel used ([0 - 4211081,215] litres*)
        /// </summary>
        High_resolution_engine_total_fuel_used = 138,
        /// <summary>
        /// Gross Combinaison Weight ??????
        /// </summary>
        //[JsonProperty(PropertyName = "gcw")]
        Gross_Combinaison_Weight = 139,
        /// <summary>
        /// Manual CAN1 0 (ID Specific data)
        /// </summary>
        CAN_0 = 145,
        /// <summary>
        /// Manual CAN1 1 (ID Specific data)
        /// </summary>
        CAN_1 = 146,
        /// <summary>
        /// Manual CAN1 2 (ID Specific data)
        /// </summary>
        CAN_2 = 147,
        /// <summary>
        /// Manual CAN1 3 (ID Specific data)
        /// </summary>
        CAN_3 = 148,
        /// <summary>
        /// Manual CAN1 4 (ID Specific data)
        /// </summary>
        CAN_4 = 149,
        /// <summary>
        /// Manual CAN1 5 (ID Specific data)
        /// </summary>
        CAN_5 = 150,
        /// <summary>
        /// Manual CAN1 6 (ID Specific data)
        /// </summary>
        CAN_6 = 151,
        /// <summary>
        /// Manual CAN1 7 (ID Specific data)
        /// </summary>
        CAN_7 = 152,
        /// <summary>
        /// Manual CAN1 8 (ID Specific data)
        /// </summary>
        CAN_8 = 153,
        /// <summary>
        /// Manual CAN1 9 (ID Specific data)
        /// </summary>
        CAN_9 = 154,
        /// <summary>
        /// Geofence zone 01 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_01 = 155,
        /// <summary>
        /// Geofence zone 02 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_02 = 156,
        /// <summary>
        /// Geofence zone 03 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_03 = 157,
        /// <summary>
        /// Geofence zone 04 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_04 = 158,
        /// <summary>
        /// Geofence zone 05 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_05 = 159,
        /// <summary>
        /// Geofence zone 06 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_06 = 160,
        /// <summary>
        /// Geofence zone 07 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_07 = 161,
        /// <summary>
        /// Geofence zone 08 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_08 = 162,
        /// <summary>
        /// Geofence zone 09 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_09 = 163,
        /// <summary>
        /// Geofence zone 10 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_10 = 164,
        /// <summary>
        /// Geofence zone 11 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_11 = 165,
        /// <summary>
        /// Geofence zone 12 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_12 = 166,
        /// <summary>
        /// Geofence zone 13 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_13 = 167,
        /// <summary>
        /// Geofence zone 14 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_14 = 168,
        /// <summary>
        /// Geofence zone 15 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_15 = 169,
        /// <summary>
        /// Geofence zone 16 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_16 = 170,
        /// <summary>
        /// Geofence zone 17 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_17 = 171,
        /// <summary>
        /// Geofence zone 18 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_18 = 172,
        /// <summary>
        /// Geofence zone 19 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_19 = 173,
        /// <summary>
        /// Geofence zone 20 (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Geofence_zone_20 = 174,
        /// <summary>
        /// Auto Geofence (Event: 0 – target left zone, 1 – target entered zone)
        /// </summary>
        Auto_Geofence = 175,
        /// <summary>
        /// Network Type (0 – 3 G; 1 – 2G)
        /// </summary>
        Network_Type = 178,
        /// <summary>
        /// Digital Output 1 (Logic: 0 / 1)
        /// </summary>
        Digital_Output_1 = 179,
        /// <summary>
        /// Digital Output 2 (Logic: 0 / 1)
        /// </summary>
        Digital_Output_2 = 180,
        /// <summary>
        /// GPS PDOP (Probability * 10; 0-500)
        /// </summary>
        GPS_PDOP = 181,
        /// <summary>
        /// GPS HDOP (Probability * 10; 0-500)
        /// </summary>
        GPS_HDOP = 182,
        /// <summary>
        /// KLN Vehicle Motion (0 – Motion Not Detected; 1 – Motion Detected)
        /// </summary>
        //[JsonProperty(PropertyName = "kmo")]
        KLN_Vehicle_Motion = 183,
        /// <summary>
        /// KLN driver 1 working state (0 – Rest; 1 – Driver Available; 2 – Work; 3 – Drive;4 – Error; 5 – not available;6 – Error; 7 – not available;)
        /// </summary>
        //[JsonProperty(PropertyName = "ka1")]
        KLN_driver_1_working_state = 184,
        /// <summary>
        /// KLN driver 2 working state (0 – Rest; 1 – Driver Available; 2 – Work; 3 – Drive;4 – Error; 5 – not available;6 – Error; 7 – not available;)
        /// </summary>
        //[JsonProperty(PropertyName = "ka2")]
        KLN_driver_2_working_state = 185,
        /// <summary>
        /// KLN Vehicle overspeed (0 – No Overspeed; 1 – Overspeed)
        /// </summary>
        //[JsonProperty(PropertyName = "kov")]
        KLN_Vehicle_overspeed = 186,
        /// <summary>
        /// KLN Driver 1 card (0 – Card Not Present; 1 – Card Present)
        /// </summary>
        //[JsonProperty(PropertyName = "kc1")]
        KLN_Driver_1_card = 187,
        /// <summary>
        /// KLN Driver 2 card (0 – Card Not Present; 1 – Card Present)
        /// </summary>
        //[JsonProperty(PropertyName = "kc2")]
        KLN_Driver_2_card = 188,
        /// <summary>
        /// KLN Driver 1 time rel. states (0 – Normal; 1 – 15min bef. 4,5h; 2 – 4,5h reached;3 – 15min bef. 9h; 4 – 9h reached; 
        /// 5 – 15min bef. 16h;6 – 16h reached; 7 – Error; 8 – not available; 14 – Error; 15 – not available;)
        /// </summary>
        KLN_Driver_1_time_rel_states = 189,
        /// <summary>
        /// KLN Driver 2 time rel. states (0 – Normal; 1 – 15min bef. 4,5h; 2 – 4,5h reached;3 – 15min bef. 9h; 4 – 9h reached; 
        /// 5 – 15min bef. 16h;6 – 16h reached; 7 – Error; 8 – not available; 14 – Error; 15 – not available;)
        /// </summary>
        KLN_Driver_2_time_rel_states = 190,
        /// <summary>
        /// KLN Tachograph vehicle speed ([0 – 65000] – Tacho Vehicle Speed km/h*)
        /// </summary>
        //[JsonProperty(PropertyName = "kse")]
        KLN_Tachograph_vehicle_speed = 191,
        /// <summary>
        /// KLN Tachograph odometer (total vehicle distance en mètres)
        /// </summary>
        //[JsonProperty(PropertyName = "kod")]
        KLN_Tachograph_odometer = 192,
        /// <summary>
        /// KLN Tachograph distance of current journey (??)
        /// </summary>
        KLN_Tachograph_distance_of_current_journey = 193,
        /// <summary>
        /// KLN Tachograph_timestamp (Seconds since 1 jan 1970 00:00:00)
        /// </summary>
        //[JsonProperty(PropertyName = "kts")]
        KLN_Tachograph_timestamp = 194,
        /// <summary>
        /// KLN Driver 1 Identification part 1 (16 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "k11")]
        KLN_Driver_1_Identification_part1 = 195,
        /// <summary>
        /// KLN Driver 1 Identification part 2 (16 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "k12")]
        KLN_Driver_1_Identification_part2 = 196,
        /// <summary>
        /// KLN Driver 2 Identification part 1 (16 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "k21")]
        KLN_Driver_2_Identification_part1 = 197,
        /// <summary>
        /// KLN Driver 2 Identification part 2 (16 ASCII Bytes per Driver ID)
        /// </summary>
        //[JsonProperty(PropertyName = "k22")]
        KLN_Driver_2_Identification_part2 = 198,
        /// <summary>
        /// Odometer (Distance between two records: m)
        /// </summary>
        //[JsonProperty(PropertyName = "odo")]
        Odometer = 199,
        /// <summary>
        /// Deep Sleep (0 – not deep sleep mode, 1 – deep sleep mode)
        /// </summary>
        //[JsonProperty(PropertyName = "dee")]
        Deep_Sleep = 200,
        /// <summary>
        /// Fuel level meter 1 (Fuel level, measured by LLS sensor on COM1/COM or RS485, in kvants or liters.)
        /// </summary>
        Fuel_level_meter_1 = 201,
        /// <summary>
        /// Fuel temperature 1 (Fuel temperature, measured by LLS sensor on COM1/COM2 or RS485, in degrees Celsius.)
        /// </summary>
        Fuel_temperature_1 = 202,
        /// <summary>
        /// Fuel level meter 2 (Fuel level, measured by LLS sensor on COM1/COM2 or RS485, in kvants or liters.)
        /// </summary>
        Fuel_level_meter_2 = 203,
        /// <summary>
        /// Fuel temperature 2 (Fuel temperature, measured by LLS sensor on COM1/COM2 or RS485, in degrees Celsius.)
        /// </summary>
        Fuel_temperature_2 = 204,
        /// <summary>
        /// Cell ID (Base station ID. Valid CID ranges are from 0 to 65535 on GSM and CDMA networks and from 0 to 268435455 on UMTS and LTE networks.)
        /// </summary>
        Cell_ID = 205,
        /// <summary>
        /// Area Code (Location Area code (LAC), it depends on GSM operator. It provides unique number which assigned to a 
        /// set of base GSM stations. Max value: 65536)
        /// </summary>
        Area_Code = 206,
        /// <summary>
        /// RFID ID (Read RFID value, depending on RFID mode, values can be: for RFID mode in hexadecimal format, RFID M7 mode 
        /// in decimal format.)
        /// </summary>
        RFID_ID = 207,
        /// <summary>
        /// Acceleration (In mG /10. Acceleration change on X axis)
        /// </summary>
        Acceleration = 208,
        /// <summary>
        /// Deceleration (In mG /10. Acceleration change on X axis)
        /// </summary>
        Deceleration = 209,
        /// <summary>
        /// Fuel level meter 3 (Fuel level, measured by LLS sensor on RS485, in kvants or liters.)
        /// </summary>
        Fuel_level_meter_3 = 210,
        /// <summary>
        /// Fuel temperature 3 (Fuel temperature, measured by LLS sensor on RS485 interface)
        /// </summary>
        Fuel_temperature_3 = 211,
        /// <summary>
        /// Fuel level meter 4 (Fuel level, measured by LLS sensor on RS485, in kvants or liters.)
        /// </summary>
        Fuel_level_meter_4 = 212,
        /// <summary>
        /// Fuel temperature 4 (Fuel temperature, measured by LLS sensor on RS485 interface)
        /// </summary>
        Fuel_temperature_4 = 213,
        /// <summary>
        /// Fuel level meter 5 (Fuel level, measured by LLS sensor on RS485, in kvants or liters.)
        /// </summary>
        Fuel_level_meter_5 = 214,
        /// <summary>
        /// Fuel temperature 5 (Fuel temperature, measured by LLS sensor on RS485 interface)
        /// </summary>
        Fuel_temperature_6 = 215,
        /// <summary>
        /// Manual CAN2 0 (ID Specific data)
        /// </summary>
        CAN2_0 = 216,
        /// <summary>
        /// Manual CAN2 1 (ID Specific data)
        /// </summary>
        CAN2_1 = 217,
        /// <summary>
        /// Manual CAN2 2 (ID Specific data)
        /// </summary>
        CAN2_2 = 218,
        /// <summary>
        /// Manual CAN2 3 (ID Specific data)
        /// </summary>
        CAN2_3 = 219,
        /// <summary>
        /// Manual CAN2 4 (ID Specific data)
        /// </summary>
        CAN2_4 = 220,
        /// <summary>
        /// Manual CAN2 5 (ID Specific data)
        /// </summary>
        CAN2_5 = 221,
        /// <summary>
        /// Manual CAN2 6 (ID Specific data)
        /// </summary>
        CAN2_6 = 222,
        /// <summary>
        /// Manual CAN2 7 (ID Specific data)
        /// </summary>
        CAN2_7 = 223,
        /// <summary>
        /// Manual CAN2 8 (ID Specific data)
        /// </summary>
        CAN2_8 = 224,
        /// <summary>
        /// Manual CAN2 9 (ID Specific data)
        /// </summary>
        CAN2_9 = 225,
        /// <summary>
        /// Ignition (Logic: 0 / 1)
        /// </summary>
        Ignition = 239,
        /// <summary>
        /// Movement Sensor (Logic: 0 / 1, 0 – not moving, 1 – moving.)
        /// </summary>
        //[JsonProperty(PropertyName = "mov")]
        Movement = 240,
        /// <summary>
        /// Current Operator Code (Currently used GSM Operator code)
        /// </summary>
        Current_Operator_Code = 241,
        /// <summary>
        /// Data limit reached (Send When GPRS data limit was reached)
        /// </summary>
        Data_limit_reached = 242,
        /// <summary>
        /// Excessive Idling (Send When Idling with Ignition ON 1- Idling; 0 – Idling End)
        /// </summary>
        Excessive_Idling = 243,
        /// <summary>
        /// Jamming (1 – jamming start, 0 – jamming stop)
        /// </summary>
        Jamming = 249,
        /// <summary>
        /// Trip (1 – trip start, 0 – trip stop)
        /// </summary>
        //[JsonProperty(PropertyName = "tri")]
        Trip = 250,
        /// <summary>
        /// Immobilizer (1 – iButton connected)
        /// </summary>
        Immobilizer = 251,
        /// <summary>
        /// Authorized driving (1 – authorized iButton connected)
        /// </summary>
        //[JsonProperty(PropertyName = "aut")]
        Authorized_driving = 252,
        /// <summary>
        /// ECO driving type (1 – harsh acceleration, 2 – harsh braking, 3 - harsh cornering)
        /// </summary>
        ECO_driving_type = 253,
        /// <summary>
        /// ECO driving value (Depending on eco driving type: if harsh acceleration, braking and cornering – g*10 m/s2)
        /// </summary>
        ECO_driving_value = 254,
        /// <summary>
        /// Over Speeding (At over speeding start km/h, at over speeding end km/h)
        /// </summary>
        Over_Speeding = 255,
        /// <summary>
        /// KLN vehicle identification number part 1
        /// </summary>
        //[JsonProperty(PropertyName = "kvin1")]
        KLN_vehicle_identification_number_part1 = 233,
        /// <summary>
        /// KLN vehicle identification number part 2
        /// </summary>
        //[JsonProperty(PropertyName = "kvin2")]
        KLN_vehicle_identification_number_part2 = 234,
        /// <summary>
        /// KLN vehicle identification number part 3
        /// </summary>
        //[JsonProperty(PropertyName = "kvin3")]
        KLN_vehicle_identification_number_part3 = 235,
        /// <summary>
        /// KLN vehicle license plate part 1
        /// </summary>
        //[JsonProperty(PropertyName = "klsp1")]
        KLN_vehicle_license_plate_part1 = 231,
        /// <summary>
        /// KLN vehicle license plate part 2
        /// </summary>
        //[JsonProperty(PropertyName = "klsp2")]
        KLN_vehicle_license_plate_part2 = 232,
    }
}