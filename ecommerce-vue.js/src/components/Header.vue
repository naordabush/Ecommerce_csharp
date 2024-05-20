<template>
  <header class="app-header">
    <div class="left">
      <span>{{ userName }}</span>
    </div>
    <div class="right">
      <button v-if="showBackButton" @click="goBack">
        <i class="fa-solid fa-angles-left"></i> Back
      </button>
      <button v-else @click="cart">
        <i class="fa fa-shopping-cart"></i> Cart
      </button>

      <button @click="logout">
        Logout <i class="fa-solid fa-right-from-bracket"></i>
      </button>
    </div>
  </header>
</template>

<script>
import { computed } from "vue";
import { useRouter } from "vue-router";
import { useUserStore } from "@/stores/userStore";

export default {
  name: "Header",
  setup() {
    const router = useRouter();
    const userStore = useUserStore();
    const userName = computed(
      () => `${userStore.$state.firstname} ${userStore.$state.lastname}`
    );

    const showBackButton = computed(
      () => router.currentRoute.value.path === "/cart"
    );

    const goBack = () => {
      router.push("/main");
    };
    const cart = () => {
      router.push("/cart");
    };

    const logout = () => {
      sessionStorage.removeItem("token");
      userStore.clearUser();
      console.clear();
      console.log("Logging out...");
      router.push("/");
    };

    return {
      userName,
      showBackButton,
      goBack,
      logout,
      cart,
    };
  },
};
</script>

<style scoped>
.app-header {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  padding: 10px 20px;
  background-color: #3e8050;
  color: #fff;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.app-header .left {
  flex: 1;
}

.app-header .right {
  flex: 1;
  text-align: right;
}

.app-header button {
  padding: 8px 16px;
  margin-left: 10px;
  margin-right: 30px;
  border: none;
  border-radius: 4px;
  background-color: transparent;
  color: #fff;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 600;
  transition: background-color 0.3s;
  background-color: rgba(255, 255, 255, 0.1);
}

.app-header button:hover {
  background-color: rgba(255, 255, 255, 0.1);
}
</style>
