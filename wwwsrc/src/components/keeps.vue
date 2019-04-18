<template>
  <div class="card" style="width: 95%;">
    <img :src="pubKeep.img" width="100%" height="auto" alt="A keep from a user.">
    <div class="card-body">
      <h5 class="card-title">{{pubKeep.name}}</h5>
      <p class="card-text">{{pubKeep.description}}</p>
      <p class="mb-0 mt-0"><button class="btn btn-primary py-0 px-1"><i class="far fa-save keepIcon"></i>

          {{pubKeep.keeps}}</button>

        <button class="btn btn-secondary py-0 px-1" height="20px"><i class="far fa-share-square shareIcon"></i>
          {{pubKeep.shares}}</button>


        <button class="btn btn-warning py-0 px-1" height="20px"><i class="fas fa-search viewIcon"></i>
          {{pubKeep.views}}</button></p>
      <br>
      <p>
        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Dropdown button
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <li class="dropdown-item">Add to Vault</li>
            <li v-for="vault in vaults" class="dropdown-item" @click="addToVault(vault.id, pubKeep)">{{vault.name}}
            </li>
          </div>
        </div>
      </p>
    </div>
  </div>
</template>

<script>
  export default {
    name: "keeps",
    props: ["pubKeep"],
    mounted() {

    },
    data() {
      return {
        toVault: {

        }
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults;
      }
    },
    methods: {
      addToVault(vaultId, addedKeep) {
        let vk = {
          VaultId: vaultId,
          KeepId: addedKeep.id
        }
        this.$store.dispatch("addToVault", vaultId, vk)
      }
    }
  };
</script>
<style>
  .red {
    color: red;
  }

  .btn-primary,
  .btn-primary:hover,
  .btn-primary:active,
  .btn-primary:visited {
    background-color: #04004a !important;
  }

  .btn-secondary,
  .btn-secondary:hover,
  .btn-secondary:active,
  .btn-secondary:visited {
    background-color: blue !important;
  }

  .btn-warning,
  .btn-warning:hover,
  .btn-warning:active,
  .btn-warning:visited {
    background-color: skyblue !important;
  }

  .card {
    background-color: grey !important;
  }

  .keepIcon {
    color: white;
  }

  .shareIcon {
    color: lightgrey;
  }

  .viewIcon {}
</style>