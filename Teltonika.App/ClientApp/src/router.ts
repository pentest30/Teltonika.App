import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';
Vue.use(Router);

export const  router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
        {
          path: '/',
          name: 'home',
          component: Home,
          meta: {
              requiresAuth: true
          }
        }
      ,
      {
          path: '/login',
          name: 'login',
          component: () => import('./views/Login.vue'),
          meta: {
              guest: true
          }
      }
      ,
      {
          path: '/vehicles',
          name: 'vehicles',
          component: () => import('./views/Vehicles.vue'),
          meta: {
              requiresAuth: true
          }
      },
      {
          path: '/vehicles/add',
          name: 'addVehicle',
          component: () => import('./views/Vehicles.vue'),
          meta: {
              requiresAuth: true
          }
      }
      ,
      {
          path: '/leaflet-map',
          name: 'leaflet-map',
          component: () => import('./views/leafletMap.vue'),
          meta: {
              requiresAuth: true
          }
      }
     ],
  
});
router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
        if (localStorage.getItem('jwt') == null) {
            next({
                path: '/login',
                params: { nextUrl: to.fullPath }
            })
        } else {
            let user = JSON.parse(localStorage.getItem('user'))
            if (to.matched.some(record => record.meta.is_admin)) {
                if (user.is_admin == 1) {
                    next()
                }
                else {
                    next({ name: 'home' })
                }
            } else {
                next()
            }
        }
    } else if (to.matched.some(record => record.meta.guest)) {
        if (localStorage.getItem('jwt') == null) {
            next()
        }
        else {
            next({ name: 'home' })
        }
    } else {
        next()
    }
})