<template>
  <div>
    <Header />
    <div class="container">
      <h1>My Cart</h1>

      <table class="table">
        <thead>
          <tr>
            <th>#</th>
            <th>Item</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Total Price</th>
            <th>Remove</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in cartItems" :key="item.id">
            <td>{{ index + 1 }}</td>
            <td>{{ item.ProductName }}</td>
            <td>{{ item.Price }}</td>
            <td>{{ item.Quantity }}</td>
            <td>{{ item.Price * item.Quantity }}</td>
            <td>
              <button @click="removeItem(item)">Remove</button>
            </td>
          </tr>
        </tbody>
      </table>

      <div class="button-container">
        <button class="button pay" @click="handlePay">
          {{ `Pay ${totalAmount}$` }}
        </button>
      </div>
    </div>
  </div>
  <Footer />
</template>

<script>
import { ref, onMounted } from "vue";
import { useUserStore } from "@/stores/userStore";

export default {
  setup() {
    const cartItems = ref([]);
    const totalAmount = ref(0);
    const userStore = useUserStore();

    const fetchCartItems = async () => {
      try {
        const response = await fetch(
          `https://localhost:7256/api/CartItems/cart/${userStore.$state.cart_id}`
        );
        if (!response.ok) {
          throw new Error("Failed to fetch cart items");
        }
        const data = await response.json();
        cartItems.value = data;
        calculateTotalAmount(data);
      } catch (error) {
        console.error("Error fetching cart items:", error);
        cartItems.value = [];
      }
    };

    const calculateTotalAmount = (items) => {
      totalAmount.value = items.reduce(
        (sum, item) => sum + item.Price * item.Quantity,
        0
      );
    };

    const handlePay = () => {
      console.log("Payment completed!");
    };

    onMounted(fetchCartItems);

    const removeItem = async (item) => {
      try {
        const response = await fetch(
          `https://localhost:7256/api/CartItems/cart/${userStore.$state.cart_id}/${item.ProductId}`,
          {
            method: "DELETE",
          }
        );
        if (!response.ok) {
          throw new Error("Failed to delete cart item");
        }
        await fetchCartItems();
      } catch (error) {
        console.error("Error deleting cart item:", error);
      }
    };

    return {
      cartItems,
      totalAmount,
      handlePay,
      removeItem,
    };
  },
};
</script>

<style scoped>
.container {
  padding: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
  min-height: 100vh;
  background: url("@/assets/bg_image.webp") no-repeat center center;
  background-size: cover;
}

h1 {
  font-size: 2.5rem;
  margin-bottom: 20px;
  color: #3e8050;
  padding-top: 20px;
}

.table {
  width: 100%;
  border-collapse: collapse;
  margin-bottom: 20px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  background-color: #fff;
}

.table th,
.table td {
  border: 1px solid #ddd;
  padding: 12px;
  text-align: left;
  font-size: 1rem;
}

.table th {
  background-color: #f5f5f5;
  color: #333;
}

.table td button {
  padding: 6px 12px;
  background-color: #ff4d4d;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.button-container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
}

.button {
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
  transition: background-color 0.3s;
}

.logout {
  background-color: #3e8050;
  color: #fff;
}

.logout:hover {
  background-color: #369045;
}

.pay {
  background-color: #b345e6;
  color: #fff;
}

.pay:hover {
  background-color: #a139d1;
}
</style>
