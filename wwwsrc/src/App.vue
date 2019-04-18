<template>
  <div id="app" class="container-fluid">
    <nav class="navbar navbar-dark bg-dark">
      <img class="logo" src="@/assets/Keeprlogo.png" height="300px" alt="the logo">
      <span v-if="this.$store.state.user.id">
        <span v-if="!atDash">
          <button class="float-right btn btn-outline-danger rounded-circle" @click="logout">
            Logout</button>
          <button class="mr-3 float-right btn btn-outline-light rounded-circle" @click="goDash">Dashboard</button>
        </span>
        <span v-else-if="!atHome">
          <button class="float-right btn btn-outline-danger rounded-circle" @click="logout">
            Logout</button>
          <button class="mr-3 float-right btn btn-outline-light rounded-circle" @click="goHome">Home</button>
        </span>
      </span>

      <button v-else-if="!this.$store.state.user.id && atLogin" class="float-right btn btn-outline-info rounded-circle"
        @click="goBrowse">Browse</button>
      <button v-else class="float-right btn btn-outline-success rounded-circle" @click="goLogin">Login</button>

    </nav>
    <router-view />
  </div>
</template>

<script>
  export default {
    name: 'App',
    mounted() {
      this.$store.dispatch("authenticate")
      this.$store.dispatch('getPublicKeeps')
    },
    data() {
      return {
        atHome: false,
        atLogin: false,
        atDash: false
      }
    },
    methods: {
      logout() {
        this.atHome = false;
        this.atDash = false;
        this.atLogin = true;
        this.$store.dispatch("logout");
      },
      goBrowse() {
        this.atLogin = false;
        this.atDash = false;
        this.atHome = true;
        this.$router.push({ name: 'home' })
      },
      goLogin() {
        this.atHome = false;
        this.atDash = false;
        this.atLogin = true;
        this.$store.dispatch("logout");
      },
      goHome() {
        this.atDash = false;
        this.atLogin = false;
        this.atHome = true;
        this.$router.push({ name: 'home' })
      },
      goDash() {
        this.atLogin = false;
        this.atHome = false;
        this.atDash = true;
        this.$router.push({ name: 'dash' })
      }
    }
  }

</script>


<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 0px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  #app {
    background-color: #fbffb5;
    height: 100%;
    padding: 0;
  }

  .logo {
    margin-top: -75px;
    margin-bottom: -75px;
    margin-left: -50px;
  }
</style>