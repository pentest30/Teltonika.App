export class VehicleViewModel {
    constructor(
        public vehicleName: string,
        public vin: string,
        public licensePlate : string,
        public creationDate: Date,
        public initServiceDate: Date,
        public id: string,
        public customer: string,
        public imei: string,
        public vehicleType: string,
        public vehicleStatus: string,
        public model: string,
        public brand : string

        ) { }
}