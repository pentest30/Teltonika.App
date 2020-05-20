import { ActionTree } from 'vuex';
import axios from 'axios';
import { MapState } from './types';
import { RootState } from '../types';

export const actions: ActionTree<MapState, RootState> = {
    pushTrackingVehicle({ commit}, payload : any): any {
        commit('pushTrackingVehicle', payload);
    },
};
