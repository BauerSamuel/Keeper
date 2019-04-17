<template>
  <div class="card" style="width: 95%;">
    <img :src="pubKeep.img" width="100%" height="auto" alt="A keep from a user.">
    <div class="card-body">
      <h5 class="card-title">{{pubKeep.name}}</h5>
      <p class="card-text">{{pubKeep.description}}</p>
      <p>keeps: {{pubKeep.keeps}}</p>
      <p>shares: {{pubKeep.shares}}</p>
      <p>views: {{pubKeep.views}}</p>
      <select v-if="vaults.length > 0">
        <option v-for="vault in vaults" @click="addToVault(vault.Id, pubKeep)">{{vault.Name}}</option>
      </select>
    </div>
  </div>
</template>

<script>
  export default {
    name: "keeps",
    props: ["pubKeep"],
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