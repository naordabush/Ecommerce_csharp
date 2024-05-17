import { createRouter, createWebHistory } from "vue-router";
import LoginView from "../views/LoginView.vue";
import MainView from "../views/MainView.vue";
import CartView from "../views/CartView.vue";
import SignupView from "../views/SignupView.vue";
import NotFoundView from "../views/NotFoundView.vue";

const routes = [
  {
    path: "/",
    name: "login",
    component: LoginView,
  },
  {
    path: "/main",
    name: "main",
    component: MainView,
  },
  {
    path: "/Signup",
    name: "Signup",
    component: SignupView,
  },
  {
    path: "/cart",
    name: "cart",
    component: CartView,
  },
  {
    path: "/:catchAll(.*)",
    component: NotFoundView,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
