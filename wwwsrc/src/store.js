import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    pubKeeps: [],
    myKeeps: [],
    vaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPubKeeps(state, keeps) {
      state.pubKeeps = keeps
    },
    setMyKeeps(state, myKeeps) {
      state.myKeeps = myKeeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    }
  },
  actions: {
    //#region --Auth Stuff
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('Login', creds)
        .then(res => {
          commit('setUser', res.data)
          dispatch('getPublicKeeps')
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      commit('setUser', {})
      router.push({ name: 'login' })
    },
    //#endregion


    //still need create keep, delete keep
    //#region --Keep Stuff
    getPublicKeeps({ commit, dispatch }) {
      api.get("keeps")
        .then(res => {
          commit('setPubKeeps', res.data)
          router.push({ name: 'home' })
        })
        .catch(err => {
          console.log("Error is: " + err)
        })
    },
    getMyKeeps({ commit, dispatch }, userId) {
      debugger;
      api.get(`keeps/${userId}`)
        .then(res => {
          commit('setMyKeeps', res.data)
        })
        .catch(err => {
          console.log("Error is: " + err)
        })
    },
    createKeep({ commit, dispatch }, payload) {
      api.post('keeps', payload)
        .then(res => {
          dispatch('getPublicKeeps')
        })
        .catch(err => {
          console.log("Error is: " + err)
        })
    },
    addToVault({ commit, dispatch }, payload) {
      api.post(`vaultKeeps`, payload)
    },
    //#endregion

    //need get vaults, get single vault, create vault, delete vault
    getVaults({ commit, dispatch }) {
      api.get(`vaults`)
        .then(res => {
          commit('setVaults', res.data)
        })
        .catch(err => {
          console.log("Error is: " + err)
        })
    },
    createVault({ commit, dispatch }, payload) {
      api.post(`vaults`, payload)
        .then(res => {
          dispatch('getVaults')
        })
        .catch(err => {
          console.log("error is: " + err)
        })
    }
  }
})
