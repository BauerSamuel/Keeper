<template>
  <div class="viewkeep">


    <div class="row">
      <div class="col-10 text-left">
        <!-- <h1>{{theVault.name}}</h1> -->
      </div>
      <div class="col-2">
        <router-link tag="button" :to="{path: '/home'}" class="btn btn-primary float-right mt-3 mr-3">
          &lt&lt &nbsp Back to Home </router-link>
      </div>
    </div>
    <div class="keep row mx-0">
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