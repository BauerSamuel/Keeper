<template>
  <div class="card" style="width: 95%;">
    <div class="card-body">
      <h5 class="card-title">{{vault.name}}</h5>
      <p class="card-text">{{vault.description}}</p>
    </div>
  </div>
</template>

<!--Vault has id, userId, name, description. -->

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