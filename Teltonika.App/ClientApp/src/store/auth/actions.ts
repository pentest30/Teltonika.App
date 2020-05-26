import { ActionTree } from 'vuex';
import { AuthState } from './types';
import { RootState } from '../types';
import AuthService from "../../services/authentication/authService ";
export const actions: ActionTree<AuthState, RootState> = {
    login({ commit }, user) {
        return AuthService.login(user).then(
          user => {
                commit('loginSuccess', user);
                this.$router.push('Home');
                return Promise.resolve(user);

          },
          error => {
            commit('loginFailure');
            return Promise.reject(error);
          }
        );
      },
      logout({ commit }) {
        AuthService.logout();
        commit('logout');
      },
      register({ commit }, user) {
        return AuthService.register(user).then(
          response => {
            commit('registerSuccess');
            return Promise.resolve(response.data);
          },
          error => {
            commit('registerFailure');
            return Promise.reject(error);
          }
        );
      }
    }
