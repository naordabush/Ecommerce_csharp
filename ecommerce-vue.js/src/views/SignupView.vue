<template>
  <div class="signup-container">
    <h1 class="title">Sign Up</h1>
    <form class="signup-form" @submit.prevent="signup">
      <div class="form-group">
        <input
          type="text"
          v-model="USER_USERNAME"
          placeholder="Username"
          required
        />
      </div>
      <div class="form-group">
        <input
          type="text"
          v-model="USER_FIRSTNAME"
          placeholder="First Name"
          required
        />
      </div>
      <div class="form-group">
        <input
          type="text"
          v-model="USER_LASTNAME"
          placeholder="Last Name"
          required
        />
      </div>
      <div class="form-group">
        <input type="email" v-model="USER_EMAIL" placeholder="Email" required />
      </div>
      <div class="form-group">
        <input
          type="password"
          v-model="USER_PASSWORD"
          placeholder="Password"
          required
        />
      </div>
      <div class="form-group">
        <button type="submit">Sign Up</button>
      </div>
      <nav><router-link to="/">Sign In</router-link></nav>
      <router-view />
    </form>
  </div>
  <Footer />
</template>

<script>
import { ref } from "vue";
import { useRouter } from "vue-router";

export default {
  setup() {
    const USER_USERNAME = ref("");
    const USER_FIRSTNAME = ref("");
    const USER_LASTNAME = ref("");
    const USER_EMAIL = ref("");
    const USER_PASSWORD = ref("");
    const router = useRouter();

    const signup = async () => {
      try {
        const response = await fetch("https://localhost:7256/api/Users", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            USER_USERNAME: USER_USERNAME.value,
            USER_FIRSTNAME: USER_FIRSTNAME.value,
            USER_LASTNAME: USER_LASTNAME.value,
            USER_EMAIL: USER_EMAIL.value,
            USER_PASSWORD: USER_PASSWORD.value,
          }),
        });

        if (response.ok) {
          console.log("User signed up successfully");
          router.push("/");
        } else {
          const errorMessage = await response.text();
          console.error("Signup failed:", errorMessage);
        }
      } catch (error) {
        console.error("Error signing up:", error);
      }
    };

    return {
      USER_USERNAME,
      USER_FIRSTNAME,
      USER_LASTNAME,
      USER_EMAIL,
      USER_PASSWORD,
      signup,
    };
  },
};
</script>

<style scoped>
.signup-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  padding: 20px;
  background: url("@/assets/bg_image.webp") no-repeat center center;
  background-size: cover;
}

.title {
  font-size: 2.5rem;
  font-weight: 700;
  color: #3e8050;
  margin-bottom: 2rem;
}

.signup-form {
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
input[type="email"],
input[type="password"] {
  width: 100%;
  padding: 0.75rem;
  font-size: 1rem;
  border: 1px solid #ccc;
  border-radius: 5px;
  box-sizing: border-box;
}

input[type="text"]::placeholder,
input[type="email"]::placeholder,
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
