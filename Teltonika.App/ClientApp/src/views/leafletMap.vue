<template>

    <div style="height: 100%; width: 100%">
        
        <l-map :zoom="zoom"
               :center="center"
               style="height: 100%">
            <l-tile-layer :url="url"
                          :attribution="attribution" />
          <l-marker
                    v-for = "m , index in markers"
                    :lat-lng="m.marker"
                    :icon="m.markerIcon"
                    >

          </l-marker>
            <l-marker :lat-lng="center">
                <l-popup>
                    <div @click="innerClick">
                        I am a popup
                       
                    </div>
                </l-popup>
            </l-marker>

        </l-map>
    </div>
</template>

<script lang="ts">

    import { Action, Getter } from "vuex-class";
    import { Component, Vue } from "vue-property-decorator";
    const namespace: string = 'map';
    import { latLng, LatLng } from "leaflet";
    import { LMap, LTileLayer, LMarker, LPopup, LTooltip, LIcon } from "vue2-leaflet";

    @Component({
        components: {
            LMap,
            LTileLayer,
            LMarker,
            LPopup,
            LTooltip,
            LIcon 
        }
    })
    export default class LeafletMap extends Vue {

        private listOfVehicles!: any[];
        private center: any = [36.7525000,3.0419700 ];
        private zoom: number = 10;
        @Getter('getMarkers', { namespace })
        private markers!: any[];
        private url: string = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
        private attribution: string =
            '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors';
        private innerClick() {

        }

    }
</script>