import { defineStore } from "pinia";

export const useUserStore = defineStore({
  id: "user",
  state: () => ({
    cart_id: "",
    token: "",
  }),
  actions: {
    // Mutation to update user data:
    updateUser(cartId, token) {
      this.cart_id = cartId;
      this.token = token;
    },
    // Mutation to clear user data when logging out:
    clearUser() {
      this.cart_id = "";
      this.token = "";
    },
  },
});
