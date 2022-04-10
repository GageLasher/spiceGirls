<template>
  <div class="container-fluid">
    <div class="row">
      <div
        class="col-md-4 mt-4 hoverable"
        v-for="r in recipes"
        :key="r.id"
        @click="goTo(r.id)"
      >
        <Recipe :recipe="r" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, watchEffect } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { recipesService } from '../services/RecipesService'
import { AppState } from '../AppState'
export default {
  setup() {
    watchEffect(async () => {
      try {
        await recipesService.getAll()
      } catch (error) {
        logger.log(error)
        Pop.toast(error.message)
      }
    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>


<style lang="scss" scoped>
</style>