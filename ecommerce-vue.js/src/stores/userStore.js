import { defineStore } from "pinia";

export const useUserStore = defineStore({
  id: "user",
  state: () => ({
    cart_id: "",
    token: "",
    firstname: "",
    lastname: "",
  }),
  actions: {
    // Mutation to update user data:
    updateUser(cartId, token, firstName, lastName) {
      this.cart_id = cartId;
      this.token = token;
      this.firstname = firstName;
      this.lastname = lastName;
    },
    // Mutation to clear user data when logging out:
    clearUser() {
      this.cart_id = "";
      this.token = "";
      this.firstname = "";
      this.lastname = "";
    },
  },
});
