export class TrackingVehicleViewModel {
    constructor(
        public Altitude: number,
        public Direction: number,
        public Lat: number,
        public Long: number,
        public  Speed : number,
        public Timestamp: Date,
        public  Status : string,
        public  StopFlag : boolean,
        public IsStop: boolean,
        public  Alarm :string,
        public  Mileage : number,
        public  Temprature : number,
        public Address: string,
        public Imei : string
    ) { }
    

}