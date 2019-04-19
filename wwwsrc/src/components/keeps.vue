<template>
  <div class="card" style="width: 95%;">
    <img :src="pubKeep.img" @click="keepView(pubKeep)" width="100%" height="auto" alt="A keep from a user.">
    <div class="card-body">
      <h5 class="card-title">{{pubKeep.name}}</h5>
      <p class="card-text">{{pubKeep.description}}</p>
      <p class="mb-0 mt-0"><button class="btn btn-primary py-0 px-1"><i class="far fa-save keepIcon"></i>
          {{pubKeep.keeps}}</button>
        <a href="https://www.facebook.com/sharer/sharer.php?s=100&p[url]=http://www.example.com&p[images][0]=&p[title]=Title%20Goes%20Here&p[summary]=Description%20goes%20here!"
          target="_blank"
          onclick="window.open(this.href,'targetWindow','toolbar=no,location=0,status=no,menubar=no,scrollbars=yes,resizable=yes,width=600,height=250'); return false"><button
            class="btn btn-secondary py-0 px-1" @click=" incShares(pubKeep.id)" height="20px"><i
              class="far fa-share-square shareIcon"></i>
            {{pubKeep.shares}}</button></a>
        <button class="btn btn-warning py-0 px-1" @click="keepView(pubKeep)" height="20px"><i
            class="fas fa-search viewIcon"></i>
          {{pubKeep.views}}</button></p>
      <br>
      <p>
        <div v-show="vaults.length > 0" class="dropdown">
          <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Add to Vault
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
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
        let sendIt = {
          KeepId: addedKeep.id,
          to: 'k'
        }
        this.$store.dispatch("addToVault", vk)
        this.$store.dispatch("updateKeepNums", sendIt)
      },
      incShares(keepId) {
        let sendIt = {
          KeepId: keepId,
          to: 's'
        }
        this.$store.dispatch("updateKeepNums", sendIt)
      },
      keepView(keep) {
        let activeKeep = keep
        let keepId = keep.id
        let sendIt = {
          KeepId: keep.id,
          to: 'v'
        }
        this.$store.dispatch("updateKeepNums", sendIt)
        this.$store.dispatch("setActiveKeep", activeKeep)
        this.$router.push({ name: 'ViewKeep', params: { keepId: keepId } })
      }
    }
  };
</script>
<style>
  .red {
    color: red;
  }

  img:hover {
    cursor: pointer;
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

  .viewIcon {
    color: black;
  }
</style>