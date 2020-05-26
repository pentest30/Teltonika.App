import 'core-js/stable';
import 'regenerator-runtime/runtime';
import Vue from 'vue';
import './plugins/axios';
import vuetify from './plugins/vuetify';
import App from './App.vue';
import {router} from './router';
import store from '@/store/index';
import './registerServiceWorker';
import dateFilter from '@/filters/date.filter';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
delete L.Icon.Default.prototype._getIconUrl;
L.Icon.Default.mergeOptions({
    iconRetinaUrl: require('leaflet/dist/images/marker-icon-2x.png'),
    iconUrl: require('leaflet/dist/images/marker-icon.png'),
    shadowUrl: require('leaflet/dist/images/marker-shadow.png')
});
Vue.config.productionTip = false;
Vue.filter('date', dateFilter);
//router.beforeEach((to: { path: string; }, from: any, next: (arg0: string | any) => void) => {
//    // redirect to login page if not logged in and trying to access a restricted page
//    const publicPages = ['/login'];
//    const authRequired = !publicPages.includes(to.path);
//    const loggedIn = localStorage.getItem('user');

//    if (authRequired && !loggedIn) {
//        return next('/login');
//    }

//    next('');
//});
new Vue({
  vuetify,
  router,
  store,
    render: (h) => h(App)
  
}).$mount('#app');
