<template>
  <div class="dash row">
    <div class="col-2 flex my-2" v-for="vault in vaults">
      <vaults :vault="vault"></vaults>
    </div>
  </div>
  </div>
</template>

<script>
  import vaults from '@/components/vaults.vue'
  export default {
    name: "Dash",
    mounted() {
      this.getUser();
    },
    computed: {
      vaults() {
        return this.$store.state.vaults;
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      getUser() {
        this.$store.dispatch('getVaults')
      }
    },
    components: {
      vaults
    }
  }
</script>