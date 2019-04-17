<template>
  <div class="card" style="width: 95%;">
    Stuff Here.
    <img :src="myKeep.img" width="100%" height="auto" alt="A keep from me.">
    <div class="card-body">
      <h5 class="card-title">{{myKeep.name}}</h5>
      <p class="card-text">{{myKeep.description}}</p>
      <p v-if="myKeep.isPrivate">Private</p>
      <p v-else>Public</p>
      <p>keeps: {{myKeep.keeps}}</p>
      <p>shares: {{myKeep.shares}}</p>
      <p>views: {{myKeep.views}}</p>
    </div>
  </div>
</template>

<script>
  export default {
    name: "keeps",
    props: ["myKeep"],
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