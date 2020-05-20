import { GetterTree } from 'vuex';
import { MapState } from './types';
import { RootState } from '../types';
import { TrackingVehicleViewModel } from '../../models/TrackingVehicleViewModel';
import { latLng, icon } from "leaflet";
export const getters: GetterTree<MapState, RootState> = {
    getMarkers(state: any): TrackingVehicleViewModel[] {
        state.vehicles.forEach((v: any) => {
            
            var markers = [...state.markers];
            for (var i = 0; i < markers.length; i++) {
                if (markers[i].imei == v.imei) {
                    state.markers.splice(i, 1);
                    break;
                }
            }
            markers = [];
            state.markers.push({
                imei: v.imei, marker: [v.lat,v.long ], position: { lat: v.lat, lng: v.long }, icon: {
                url: require("../../assets/vehicles/LightVehicleMoving.png")
                }, markerIcon :icon({
                    iconUrl: require("../../assets/vehicles/LightVehicleMoving.png")
        })
            });
        });
        return state.markers;
    },
};
