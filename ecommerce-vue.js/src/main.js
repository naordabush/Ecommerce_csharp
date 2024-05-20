import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";
import { createPinia } from "pinia";
import axios from "axios";
import "@fortawesome/fontawesome-free/css/all.css";

const pinia = createPinia();
const app = createApp(App);

app.use(pinia);
app.use(router);
app.component("Header", Header);
app.component("Footer", Footer);
// Set the base URL for Axios
axios.defaults.baseURL = "https://api.example.com"; // Replace with your API base URL

// Optionally, you can set up interceptors, headers, etc.
// axios.interceptors.request.use(config => {
//   // Add any headers or modify the request config as needed
//   return config;
// });

// axios.interceptors.response.use(response => {
//   // Handle responses or errors globally
//   return response;
// });

// Make Axios available globally on the app instance
app.config.globalProperties.$http = axios;

app.mount("#app");
