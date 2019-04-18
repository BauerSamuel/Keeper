<template>
  <div class="card" style="width: 95%;">
    <i class="far fa-times-circle red float-right" @click="deleteVK(vk)"></i>
    <img :src="vk.img" width="100%" height="auto" alt="A keep from a user.">
    <div class="card-body">
      <h5 class="card-title">{{vk.name}}</h5>
      <p class="card-text">{{vk.description}}</p>
      <p class="mb-0 mt-0"><button class="btn btn-primary py-0 px-1"><i class="far fa-save keepIcon"></i>

          {{vk.keeps}}</button>

        <a href="https://www.facebook.com/sharer/sharer.php?s=100&p[url]=http://www.example.com&p[images][0]=&p[title]=Title%20Goes%20Here&p[summary]=Description%20goes%20here!"
          target="_blank"
          onclick="window.open(this.href,'targetWindow','toolbar=no,location=0,status=no,menubar=no,scrollbars=yes,resizable=yes,width=600,height=250'); return false"><button
            class="btn btn-secondary py-0 px-1" height="20px"><i class="far fa-share-square shareIcon"></i>
            {{vk.shares}}</button></a>


        <button class="btn btn-warning py-0 px-1" height="20px"><i class="fas fa-search viewIcon"></i>
          {{vk.views}}</button></p>
      <br>
      <p>
        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Add to Vault
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <li v-for="vault in vaults" class="dropdown-item" @click="addToVault(vault.id, vk)">{{vault.name}}
            </li>
          </div>
        </div>
      </p>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaultkeeps',
    props: ['vk'],
    mounted() {

    },
    data() {
      return {

      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteVK(vk) {
        vk.vaultId = this.$route.params.vaultId
        this.$store.dispatch("deleteVK", vk)
      }
    }
  }

</script>

<style>

</style>