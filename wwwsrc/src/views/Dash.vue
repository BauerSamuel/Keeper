<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col">
        <vaultForm v-if="vb"></vaultForm>
        <keepForm v-else></keepForm>
      </div>
    </div>
    <div class="dash row mt-4">
      <div class="select col-6">
        <button class="btn btn-block btn-outline-info mb-5" @click="vb = true; kb=false;">My Vaults</button>
      </div>
      <div class="select col-6">
        <button class="btn btn-block btn-outline-info mb-5" @click="kb = true; vb=false;">My Keeps</button>
      </div>
    </div>
    <div class="row">
      <div v-if="vb" class="col-4 flex my-2" v-for="vault in vaults">
        <vaults :vault="vault"></vaults>
      </div>
      <div v-else class="col-4 flex my-2" v-for="myKeep in myKeeps">
        <myKeeps :myKeep="myKeep"></myKeeps>
      </div>
    </div>
  </div>
</template>

<script>
  import vaults from '@/components/vaults.vue'
  import myKeeps from '@/components/myKeeps.vue'
  import vaultForm from '@/components/vaultForm.vue'
  import keepForm from '@/components/keepForm.vue'

  export default {
    name: 'Dash',
    mounted() {
      this.getStuff();
      // this.$store.dispatch("authenticate")
    },
    data() {
      return {
        vb: false,
        kb: false
      }
    },
    methods: {
      getStuff() {
        debugger;
        this.$store.dispatch('getMyKeeps', this.user.id)
        this.$store.dispatch('getVaults')
      },
      vaultBool() {
        this.vb = true;
        this.kb = false;
      },
      keepBool() {
        this.vb = false;
        this.kb = true;
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
      vaults,
      myKeeps,
      keepForm,
      vaultForm
    }
  }
</script>

<style>
</style>