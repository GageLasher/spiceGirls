<template>
  <form
    @submit.prevent="createRecipe"
    class="row bg-dark darken-20 justify-content-center elevation-3 p-2 m-5"
  >
    <div class="col-md-4 mb-2">
      <label for="" class="form-label">Recipe Title</label>
      <input
        v-model="state.editable.title"
        required
        type="text"
        class="form-control"
        aria-describedby="helpId"
      />
    </div>

    <div class="col-md-8 mb-2">
      <label for="" class="form-label">Subtitle</label>
      <input
        v-model="state.editable.subTitle"
        required
        type="text"
        class="form-control"
        aria-describedby="helpId"
      />
    </div>

    <div class="col-12 mb-2">
      <label for="" class="form-label">Picture</label>
      <textarea
        v-model="state.editable.picture"
        required
        type="text"
        class="form-control"
        placeholder=""
        aria-describedby="helpId"
      />
    </div>
    <div class="col-12 mb-2">
      <label for="" class="form-label">Category</label>
      <textarea
        v-model="state.editable.category"
        required
        type="text"
        class="form-control"
        placeholder=""
        aria-describedby="helpId"
      />
    </div>

    <div class="col-12 d-flex justify-content-end">
      <button class="btn btn-primary">create</button>
    </div>
  </form>
</template>


<script>
import { AppState } from "../AppState";
import { computed, reactive, onMounted } from "vue";
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";

import { recipesService } from '../services/RecipesService';
export default {
  setup() {
    const state = reactive({
      editable: {},
    });
    return {
      state,
      async createRecipe() {
        try {


          await recipesService.create(state.editable);
          state.editable = {};
        } catch (error) {
          logger.error(error);
          Pop.toast(error.message, "error");
        }
      },
    };
  },
};
</script>


<style scoped>
input,
textarea {
  background: rgb(242, 236, 236);
  color: var(--bs-light);
}
</style>