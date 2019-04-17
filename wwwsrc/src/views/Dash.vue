<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col">
        <form @submit.prevent="createKeep">
          <!-- description, name, image,isprivate -->
          <p>form here to post keep</p>
        </form>
      </div>
    </div>
    <div class="dash row mt-4">
      <div class="select col-6">
        <button class="btn btn-block btn-outline-info" @click="vb = true; kb=false;">My Vaults</button>
      </div>
      <div class="select col-6">
        <button class="btn btn-block btn-outline-info" @click="kb = true; vb=false;">My Keeps</button>
      </div>
    </div>
    <div class="row">
      <div v-if="vb" class="col-4 flex my-2" v-for="vault in vaults">
        <vaults :vault="vault"></vaults>
      </div>
      <div v-else class="col-4 flex my-2" v-for="vault in vaults">
        <myKeeps :myKeep="myKeep"></myKeeps>
      </div>
    </div>
  </div>
</template>

<script>
  import vaults from '@/components/vaults.vue'
  export default {
    name: 'Dash',
    mounted() {
      this.getUser();
      // this.$store.dispatch("authenticate")
    },
    data() {
      return {
        vb: false,
        kb: false
      }
    },
    methods: {
      getUser() {
        this.$store.dispatch('getVaults')
      },
      vaultBool() {
        this.vb = true;
        this.kb = false;
      },
      keepBool() {
        this.vb = false;
        this.kb = true;
      },
      createKeep() {

      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults;
      },
      myKeeps() {
        return this.$store.state.myKeeps;
      },
      user() {
        return this.$store.state.user
      }
    },
    components: {
      vaults
    }
  }
</script>

<style>
</style>