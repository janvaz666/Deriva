/*!

=========================================================
* Vue Now UI Dashboard PRO - v1.2.0
=========================================================

* Product Page: http://www.creative-tim.com/product/vue-now-ui-dashboard-pro
* Copyright 2019 Creative Tim (http://www.creative-tim.com)

* Designed by www.invisionapp.com Coded by www.creative-tim.com

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 */

import Vue from "vue";
import VueRouter from "vue-router";
import DashboardPlugin from "./dashboard-plugin";

// Plugins
import App from "./App.vue";

// router setup
import routes from "./routes/routes";

// plugin setup
Vue.use(VueRouter);
Vue.use(DashboardPlugin);

// configure router
const router = new VueRouter({
  routes, // short for routes: routes
  linkActiveClass: "active"
});

/* eslint-disable no-new */
new Vue({
  el: "#app",
  render: h => h(App),
  router
});
