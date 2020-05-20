<template>
  <v-container fluid>
    <v-layout column align-center>
      <img src="@/assets/logo.png" alt="Vuetify.js" class="mb-5">
      <HelloWorld quote="Welcome to Teltonika platforme App" author="brought to you by Software Ateliers" />
    </v-layout>
    <v-slide-y-transition mode="out-in">
      <v-row>        
        
      </v-row>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src

@Component({
  components: {
    HelloWorld,
  },
})
export default class Home extends Vue {}
</script>
