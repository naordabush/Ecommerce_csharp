<template>
  <footer class="app-footer">
    <div class="rights">
      <span> © All Rights Reserved to Naor Dabush {{ currentYear }}</span>
    </div>
  </footer>
</template>

<script>
export default {
  name: "Footer",
  setup() {
    const currentYear = new Date().getFullYear();
    return { currentYear };
  },
};
</script>

<style scoped>
.app-footer {
  width: 100%;
  height: px;
  padding: 10px 20px;
  background-color: #3e8050;
  color: #fff;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
