<template>
    <v-container fluid>
        <v-slide-y-transition mode="out-in">
            <v-row>
                <v-col>
                   
                    <div>
                        
                    </div>
                    <br />
                    <v-data-table :headers="headers"
                                  :items="vehicles"
                                  hide-default-footer
                                  :loading="loading"
                                  class="elevation-1">
                        <v-progress-linear v-slot:progress color="blue" indeterminate></v-progress-linear>
                        <template v-slot:item.date="{ item }">
                            <td>{{ item.initServiceDate | date }}</td>
                        </template>
                        <template v-slot:item.temperatureC="{ item }">
                            <v-chip :color="getColor(item.vehicleStatus)" dark>{{ item.vehicleStatus }}</v-chip>
                        </template>
                    </v-data-table>
                </v-col>
            </v-row>
        </v-slide-y-transition>

        <v-alert :value="showError" type="error" v-text="errorMessage">
            This is an error alert.
        </v-alert>

        <v-alert :value="showError" type="warning">
            Are you sure you're using ASP.NET Core endpoint? (default at
            <a href="http://localhost:5000/fetch-data">http://localhost:5000</a>)
            <br />
            API call would fail with status code 404 when calling from Vue app
            (default at
            <a href="http://localhost:8080/fetch-data">http://localhost:8080</a>)
            without devServer proxy settings in vue.config.js file.
        </v-alert>
    </v-container>
</template>

<script lang="ts">
    // an example of a Vue Typescript component using Vue.extend
    import Vue from 'vue';
    import { VehicleViewModel } from '../models/VehicleViewModel';
    import axios from 'axios';

    export default Vue.extend({
        data() {
            return {
                loading: true,
                showError: false,
                errorMessage: 'Error while loading  vehicles.',
                vehicles: [] as VehicleViewModel[],
                headers: [
                    { text: 'Name', value: 'vehicleName' },
                    { text: 'VIN', value: 'vin' },
                    { text: 'License plate', value: 'licensePlate' },
                    { text: 'IMEI', value: 'imei' },
                    { text: 'Type', value: 'vehicleType' },
                    { text: 'Entry service date', value: 'initServiceDate' },
                    { text: 'Status', value: 'vehicleStatus' },
                ],
            };
        },
        methods: {
            getColor(vehicleType: string) {

            },
            async fetchVehicles() {
                try {
                    const response = await axios.get<VehicleViewModel[]>('api/Vehicle');
                    this.vehicles = response.data;
                } catch (e) {
                    this.showError = true;
                    this.errorMessage = `Error while loading vehicles: ${e.message}.`;
                }
                this.loading = false;
            },
        },
        async created() {
            await this.fetchVehicles();
        },
    });
</script>
