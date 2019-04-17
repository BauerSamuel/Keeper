<template>
  <div class="keep-form">
    <h2>Create a Keep!</h2>
    <form @submit.prevent="createKeep">
      <p>Image URL: <input type="text" v-model="newKeep.Img" required>
        <br>
        Name: <input type="text" v-model="newKeep.Name" required>
        <br>
        Description: <input type="text" v-model="newKeep.Description" required>
        <br>
        Private? (only you can see your private posts) <input type="checkbox" v-model="newKeep.isPrivate">
        <br>
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
        newKeep: {
          Img: "",
          Name: "",
          Description: "",
          isPrivate: false
        }
      }
    },
    computed: {
    },
    methods: {
      createKeep() {
        this.$store.dispatch("createKeep", this.newKeep);
        this.newKeep = {
          Img: "",
          Name: "",
          Description: "",
          isPrivate: false
        }
      }
    }
  };
</script>