import { MutationTree } from 'vuex';
import { MapState } from './types';

export const mutations: MutationTree<MapState> = {
    pushTrackingVehicle(state, payload) {
        //console.log(payload);
        state.vehicles.push(payload);
    },
};
