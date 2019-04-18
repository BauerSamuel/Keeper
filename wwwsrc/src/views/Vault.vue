<template>
  <div>
    <div class="row">
      <div class="col-10 text-left">
        <h1>{{theVault.name}}</h1>
      </div>
      <div class="col-2">
        <router-link tag="button" :to="{path: '/dash'}" class="btn btn-primary float-right mt-3 mr-3">
          << &nbsp Back to Dash </router-link> </div> </div> <div class="vault row mx-0">
            <div class="col-3 my-2" v-for="vltkp in vltkps">
              <vaultKeeps :vk="vltkp"></vaultKeeps>
            </div>
      </div>
    </div>
</template>

<script>
  import vaultKeeps from '@/components/vaultKeeps.vue'
  export default {
    name: "vault",
    mounted() {
      this.setVault();

    },
    computed: {
      pubKeeps() {
        return this.$store.state.pubKeeps;
      },
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vaults;
      },
      theVault() {
        return this.$store.state.activeVault;
      },
      vltkps() {
        return this.$store.state.vaultKeeps;
      }
    },
    methods: {

      setVault() {
        let active = this.vaults.find(v => v.id == this.$route.params.vaultId);
        this.$store.dispatch("setActiveVault", active)
      }

    },
    components: {
      vaultKeeps
    }
  };
</script>

<style>
</style>