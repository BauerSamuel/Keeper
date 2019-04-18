<template>
  <div class="card" style="width: 95%;">
    {{myKeep.id}} <i class="far fa-times-circle red float-right" @click="deleteKeep(myKeep.id)"></i>
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
      myKeeps() {
        return this.$store.state.myKeeps;
      }
    },
    methods: {
      addToVault(vaultId, myKeep) {
        this.$store.dispatch("addToVault", myKeep)
      },
      deleteKeep(keepId) {
        this.$store.dispatch("deleteKeep", keepId)
      }
    }
  };
</script>