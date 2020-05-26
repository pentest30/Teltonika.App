<template>
     <v-app>
        <v-card width="400" class="mx-auto mt-5">
            <v-card-title class="pb-0">
                <h3>Login</h3>
            </v-card-title>
            <v-card-text>
                <v-form ref="form">
                    <v-text-field label="Username" 
                                  v-model="username"
                                  :rules="userRules"
                                  prepend-icon="mdi-account-circle" />
                    <v-text-field :type="showPassword ? 'text' : 'password'"
                                  label="Password"
                                  v-model="password"
                                  prepend-icon="mdi-lock"
                                  :rules="passwordRules"
                                  append-icon="mdi-eye-off"
                                  @click:append="showPassword = !showPassword" />
                </v-form>
            </v-card-text>
            <v-divider></v-divider>
            <v-card-actions>
                <v-btn  color="success">Register</v-btn>
                <v-btn @click="submit" color="info">Login</v-btn>
            </v-card-actions>
        </v-card>
    </v-app>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    @Component
    export default class Login extends Vue {
        private valid: boolean = false;
        e1: boolean = false;
        password: string = '';
        showPassword: boolean = false;
        passwordRules: any = [(v: string) => !!v || 'Password is required'];
        username: string = '';
        userRules: any = [(v: string) => !!v || 'Username is required'];
        submit() {
            console.log("here ... ")
            if (this.$refs.form.validate()) {
                var user = {
                    username: this.username,
                    password: this.password
                };
                this.$store.dispatch("auth/login", user);
            }
          
        }
        clear() {
            //this.$refs.form.reset()
        }
    }
</script>
