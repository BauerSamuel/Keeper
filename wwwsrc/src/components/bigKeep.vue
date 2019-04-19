<template>
  <div class="card">
    <img :src="activeKeep.img" width="100%" height="auto" alt="A keep from a user.">
    <div class="card-body">
      <h5 class="card-title">{{activeKeep.name}}</h5>
      <p class="card-text">{{activeKeep.description}}</p>
      <p>keeps: {{activeKeepKeeps}}</p>
      <p>shares: {{activeKeep.shares}}</p>
      <p>views: {{activeKeep.views + 1}}</p>
      <p>
        <div v-show="vaults.length > 0" class="dropdown">
          <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Add to Vault
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <li v-for="vault in vaults" class="dropdown-item" @click="addToVault(vault.id, activeKeep)">{{vault.name}}
            </li>
          </div>
        </div>
      </p>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'bigKeep',
    mounted() {

    },
    data() {
      return {

      }
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      activeKeepKeeps() {
        return this.$store.state.activeKeep.keeps
      },
      vaults() {
        return this.$store.state.vaults
      },
      keeps() {
        return this.$store.state.vaults
      }
    },
    methods: {
      addToVault(vaultId, addedKeep) {
        let vk = {
          VaultId: vaultId,
          KeepId: addedKeep.id
        }
        let sendIt = {
          KeepId: addedKeep.id,
          to: 'k'
        }
        this.$store.dispatch("addToVault", vk)
        this.$store.dispatch("updateKeepNums", sendIt)
        this.$store.dispatch("setActiveKeep", this.activeKeep)
      },
    }
  }

</script>

<style>

</style>