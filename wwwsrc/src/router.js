import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dash from './views/Dash.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
//@ts-ignore
import ViewKeep from './views/ViewKeep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/home',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/dash',
      name: 'dash',
      component: Dash
    },
    {
      path: '/vault/:vaultId',
      name: 'vault',
      component: Vault
    },
    {
      path: '/keep/:keepId',
      name: 'ViewKeep',
      component: ViewKeep

    }
  ]
})
