<template>
  <div class="main-page">
    <h1 class="page-title">Products</h1>
    <div class="product-cards">
      <div
        v-for="product in products"
        :key="product.PRODUCT_ID"
        class="product-card"
      >
        <img
          :src="product.PRODUCT_IMAGE"
          alt="Product Image"
          class="product-image"
        />
        <div class="product-details">
          <h2>{{ product.PRODUCT_NAME }}</h2>
          <p>{{ product.PRODUCT_DESCRIPTION }}</p>
          <p>Price: ${{ product.PRODUCT_PRICE }}</p>
          <div class="quantity-control">
            <button @click="decrementQuantity(product)">-</button>
            <span>{{ product.quantity }}</span>
            <button @click="incrementQuantity(product)">+</button>
          </div>
          <button @click="addToCart(product, product.quantity)">
            Add to Cart
          </button>
        </div>
      </div>
    </div>
    <button class="cart-button" @click="goToCart">
      Cart
      <i class="fa fa-shopping-cart"></i>
    </button>
    <button class="logout-button" @click="logout">
      Logout
      <i class="fa fa-sign-out"></i>
    </button>
    <button class="back-to-top" @click="scrollToTop">
      <i class="fas fa-arrow-up"></i>
    </button>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import { useRouter } from "vue-router";
import { useUserStore } from "@/stores/userStore";

export default {
  setup() {
    const products = ref([]);
    const router = useRouter();
    const userStore = useUserStore();

    const getProducts = async () => {
      try {
        const response = await fetch("https://localhost:7256/api/Product");
        const data = await response.json();
        products.value = data.map((product) => ({ ...product, quantity: 1 }));
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };

    const addToCart = async (product) => {
      try {
        const url = `https://localhost:7256/api/CartItems?cartId=${userStore.$state.cart_id}&productId=${product.PRODUCT_ID}&quantity=${product.quantity}`;
        const response = await fetch(url, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${sessionStorage.getItem("token")}`,
          },
        });
        if (response.ok) {
          console.log("Product added to cart successfully:", product);
        } else {
          console.error("Failed to add product to cart:", response.statusText);
        }
      } catch (error) {
        console.error("Error adding product to cart:", error);
      }
    };

    const decrementQuantity = (product) => {
      if (product.quantity > 1) {
        product.quantity--;
      }
    };

    const incrementQuantity = (product) => {
      product.quantity++;
    };

    const logout = () => {
      sessionStorage.removeItem("token");
      userStore.clearUser();
      console.log("Logging out...");
      router.push("/");
    };

    const goToCart = () => {
      console.log("Navigating to cart page...");
      router.push("/cart");
    };

    const scrollToTop = () => {
      console.log("Scroll To Top");
      window.scrollTo({ top: 0, behavior: "smooth" });
    };

    onMounted(getProducts);

    return {
      products,
      addToCart,
      logout,
      goToCart,
      scrollToTop,
      decrementQuantity,
      incrementQuantity,
    };
  },
};
</script>

<style scoped>
.main-page {
  padding: 20px;
  background: linear-gradient(135deg, #f8f9fa, #e9ecef);
  min-height: 100vh;
}

.page-title {
  font-size: 2.5rem;
  font-weight: 700;
  color: #3e8050;
  text-align: center;
  margin-bottom: 30px;
}

.product-cards {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 20px;
}

.product-card {
  background: #fff;
  border: 1px solid #ccc;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
  align-items: center;
  transition: transform 0.2s;
}

.product-card:hover {
  transform: translateY(-5px);
}

.product-image {
  width: 100%;
  height: auto;
  max-height: 200px;
  object-fit: cover;
  margin-bottom: 10px;
}

.product-details h2 {
  font-size: 1.5rem;
  font-weight: 600;
  color: #333;
  margin-bottom: 10px;
}

.product-details p {
  font-size: 1rem;
  color: #666;
  margin: 5px 0;
}

.quantity-control {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 10px;
}

.quantity-control button {
  padding: 5px 10px;
  margin: 0 5px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f0f0f0;
  cursor: pointer;
  transition: background-color 0.3s;
}

.quantity-control button:hover {
  background-color: #e0e0e0;
}

.quantity-control span {
  font-size: 1.2rem;
  font-weight: 600;
}

button {
  padding: 10px 20px;
  margin: 10px 0;
  border: none;
  border-radius: 5px;
  background-color: #3e8050;
  color: #fff;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 600;
  transition: background-color 0.3s;
}

button:hover {
  background-color: #355c4a;
}

.cart-button,
.logout-button {
  position: fixed;
  top: 20px;
  padding: 10px;
  border: none;
  border-radius: 5px;
  background-color: #3e8050;
  color: #fff;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 600;
  transition: background-color 0.3s;
  display: flex;
  align-items: center;
  justify-content: center;
}

.cart-button:hover,
.logout-button:hover {
  background-color: #355c4a;
}

.cart-button {
  right: 120px;
  margin-right: 5px;
}

.logout-button {
  right: 20px;
  margin-left: 5px;
}

.back-to-top {
  position: fixed;
  bottom: 20px;
  right: 20px;
  width: 50px;
  height: 50px;
  border-radius: 50%;
  background-color: #3e8050;
  color: #fff;
  border: none;
  cursor: pointer;
  display: flex;
  justify-content: center;
  align-items: center;
  transition: background-color 0.3s;
  padding-left: 11px;
}

.back-to-top:hover {
  background-color: #355c4a;
}

.fa,
.fas {
  margin-left: 10px;
}
</style>
