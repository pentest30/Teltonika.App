<template>
  <div>
      <v-dialog v-model="dialog"
                width="500">
          <template v-slot:activator="{ on }">
              <v-btn color="green lighten-2"
                     dark
                     v-on="on">
                  Add new vehicle
              </v-btn>
          </template>

          <v-card>
              <v-card-title class="headline grey lighten-2"
                            primary-title>
                  Privacy Policy
              </v-card-title>



              <v-divider></v-divider>

              <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="primary"
                         text
                         @click="dialog = false">
                      I accept
                  </v-btn>
              </v-card-actions>
          </v-card>
      </v-dialog>
  </div>
</template>

<script>
export default {
  name: 'VehiclePopup',
  
};
</script>
