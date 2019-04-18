<template>
  <div class="card" style="width: 95%;">
    <i class="far fa-times-circle red float-right" @click="deleteVault(vault.id)"></i>
    <router-link :to="{name: 'vault' , params: {vaultId: vault.id}}">
      <div class="card-body">
        <h5 class="card-title">{{vault.name}}</h5>
        <p class="card-text">{{vault.description}}</p>
      </div>
    </router-link>
  </div>
</template>

<script>
  export default {
    name: "vaults",
    props: ["vault"],
    mounted() {

    },
    computed: {
      vaults() {
        return this.$store.state.vaults;
      }
    },
    methods: {
      deleteVault(vaultId) {
        this.$store.dispatch("deleteVault", vaultId)
      }
    }
  }
</script>

<style>
  .card-body {
    color: black;
  }
</style>