<template>
    <div>
        <v-container fluid>
            <h1>List of vehicles</h1>
            <VehiclePopup />
            <Vehicle></Vehicle>
            </v-container>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Vehicle from '@/components/Vehicle.vue';
    import VehiclePopup from '@/components/VehiclePopup.vue';
@Component({
    components: { Vehicle, VehiclePopup},
})
export default class VehiclesView extends Vue {}
</script>


