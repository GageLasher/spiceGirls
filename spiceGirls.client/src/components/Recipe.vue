<template>
  <div class="bg-white shadow rounded">
    <div class="row">
      <div class="col-12">
        <h3>{{ recipe.category }}</h3>
      </div>
      <div class="col-12">
        <h3>{{ recipe.title }}</h3>
        <p>{{ recipe.subTitle }}</p>
      </div>
      <div class="col-12">
        <img :src="recipe.picture" alt="" class="img-fluid" />
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
</style>