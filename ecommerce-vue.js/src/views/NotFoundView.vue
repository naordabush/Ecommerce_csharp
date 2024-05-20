<template>
  <div class="not-found-container">
    <h1>404 - Page Not Found</h1>
    <p>The page you are looking for does not exist.</p>
  </div>
</template>

<script>
export default {
  name: "NotFoundView",
};
</script>

<style scoped>
.not-found-container {
  text-align: center;
  padding-top: 150px;
  min-height: 100vh;
  background: url("@/assets/bg_image.webp") no-repeat center center;
  background-size: cover;
}
</style>
