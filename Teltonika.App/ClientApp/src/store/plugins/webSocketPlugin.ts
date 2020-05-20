import * as signalR from "@microsoft/signalr";
import { TrackingVehicleViewModel } from '../../models/TrackingVehicleViewModel';
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

connection.start().catch(err => console.log(err));

function webSocketPlugin() {
    return (store: any) => {
        connection.on("trackingVehicle", (trackObject: TrackingVehicleViewModel) => {
            //console.log(trackObject)
            store.commit("map/pushTrackingVehicle", trackObject, { root: true });
        });
    }
    
}
export {webSocketPlugin}