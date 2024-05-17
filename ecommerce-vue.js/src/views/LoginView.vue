<template>
  <div class="login-container">
    <h1 class="title">E-commerce Site</h1>
    <form class="login-form" @submit.prevent="login">
      <div class="form-group">
        <input type="text" v-model="username" placeholder="Username" required />
      </div>
      <div class="form-group">
        <input
          type="password"
          v-model="password"
          placeholder="Password"
          required
        />
      </div>
      <div class="form-group">
        <button type="submit">Sign In</button>
      </div>
      <nav>
        <router-link to="/Signup">Sign Up</router-link>
      </nav>
      <router-view />
    </form>
  </div>
</template>

<script>
import { ref } from "vue";
import { useRouter } from "vue-router";
import { useUserStore } from "@/stores/userStore";

export default {
  setup() {
    const username = ref("");
    const password = ref("");
    const products = ref([]);
    const router = useRouter();
    const userStore = useUserStore();

    const getProducts = async () => {
      try {
        const response = await fetch("https://localhost:7256/api/Product");
        const data = await response.json();
        products.value = data;
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    };

    const login = async () => {
      try {
        const response = await fetch("https://localhost:7256/api/Users/login", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            username: username.value,
            password: password.value,
          }),
        });
        if (response.ok) {
          const data = await response.json();
          const token = data.TOKEN;

          sessionStorage.setItem("token", token);

          userStore.updateUser(data.CART_ID, data.TOKEN);

          router.push("/main");
          getProducts();
        } else {
          alert("Username or password is incorrect");
        }
      } catch (error) {
        console.error("Error logging in:", error);
      }
    };

    return {
      username,
      password,
      login,
    };
  },
};
</script>

<style scoped>
.login-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background: linear-gradient(135deg, #f8f9fa, #e9ecef);
  padding: 20px;
}

.title {
  font-size: 2.5rem;
  font-weight: 700;
  color: #3e8050;
  margin-bottom: 2rem;
}

.login-form {
  width: 100%;
  max-width: 400px;
  background: #fff;
  padding: 2rem;
  border-radius: 10px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.form-group {
  margin-bottom: 1.5rem;
}

input[type="text"],
input[type="password"] {
  width: 100%;
  padding: 0.75rem;
  font-size: 1rem;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-sizing: border-box;
}

input[type="text"]::placeholder,
input[type="password"]::placeholder {
  color: #999;
}

button {
  width: 100%;
  padding: 0.75rem;
  background-color: #3e8050;
  color: #fff;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 1rem;
  font-weight: 600;
  transition: background-color 0.3s;
}

button:hover {
  background-color: #355c4a;
}

.signup {
  margin-top: 1rem;
  text-align: center;
  color: #555;
}

.signup a {
  color: #3e8050;
  text-decoration: none;
  font-weight: 600;
}

.signup a:hover {
  text-decoration: underline;
}
nav {
  padding: 1px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
