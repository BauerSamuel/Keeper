<template>
  <div class="home row mx-0">
    <div class="col-3 flex my-2" v-for="pubKeep in pubKeeps">
      <keeps :pubKeep="pubKeep"></keeps>
    </div>
  </div>
</template>

<script>
  import keeps from '@/components/keeps.vue'
  export default {
    name: "home",
    mounted() { },
    computed: {
      pubKeeps() {
        return this.$store.state.pubKeeps;
      },
      user() {
        return this.$store.state.user;
      }
    },
    methods: {

    },
    components: {
      keeps
    }
  };
</script>

<style>
</style>