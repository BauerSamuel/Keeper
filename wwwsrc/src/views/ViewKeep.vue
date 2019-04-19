<template>
  <div class="viewkeep">
    <div class="row">

      <div class="col-2 offset-10">
        <router-link tag="button" :to="{path: '/home'}" class="btn btn-primary float-right mt-3 mr-3">
          &lt&lt &nbsp Back to Home </router-link>
      </div>
    </div>
    <div class="keep row mx-0 flex justify-content-center">
      <bigKeep></bigKeep>
    </div>
  </div>
</template>
<script>
  import bigKeep from '@/components/bigKeep.vue'
  export default {
    name: 'ViewKeep',
    mounted() {

    },
    data() {
      return {

      }
    },
    computed: {
      activeKeep() {
        return this.$store.state.$store.activeKeep
      }
    },
    methods: {

    },
    components: {
      bigKeep
    }
  }
</script>

<style>

</style>