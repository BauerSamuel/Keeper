<template>
  <div class="vault-form">
    <h2>Create a vault!</h2>
    <form @submit.prevent="createVault">
      <p>Name: <input type="text" v-model="newVault.Name" required>
        <br>
        Description: <input type="text" v-model="newVault.Description" required></p>
      <button class="btn btn-outline-info">Create</button>
      </p>
    </form>
  </div>
</template>

<script>
  export default {
    name: "keepForm",
    data() {
      return {
        newVault: {
          Name: "",
          Description: ""
        }
      }
    },
    computed: {
    },
    methods: {
      createVault() {
        this.$store.dispatch("createVault", this.newVault);
        this.newVault = {
          Name: "",
          Description: ""
        };
      }
    }
  };
</script>