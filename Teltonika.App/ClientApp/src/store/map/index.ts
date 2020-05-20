import { Module } from 'vuex';
import { getters } from './getters';
import { actions } from './actions';
import { mutations } from './mutations';
import { MapState } from './types';
import { RootState } from '../types';
import { TrackingVehicleViewModel } from '../../models/TrackingVehicleViewModel';
export const state: MapState = {
    vehicles: [] as TrackingVehicleViewModel[],
    markers : [] as any[]
};

const namespaced: boolean = true;

export const map: Module<MapState, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations,
};
