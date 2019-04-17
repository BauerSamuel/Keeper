<template>
  <div class="card" style="width: 95%;">
    stuff here.
    <div class="card-body">
      <h5 class="card-title">{{vault.name}}</h5>
      <p class="card-text">{{vault.description}}</p>
      <p>Images in vault: {{vaults.length}}</p>
    </div>
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
      addToVault(vaultId, pubKeep) {
        this.$store.dispatch("addToVault", pubKeep)
      }
    }
  };
</script>