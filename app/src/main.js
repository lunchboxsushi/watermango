import Vue from 'vue'
import Vuetify from 'vuetify'
import VueRouter from 'vue-router'
import App from './App.vue'
import routes from './routes'

// vuetify css needs to be included
import 'vuetify/dist/vuetify.min.css'

Vue.config.productionTip = false

// global register vuetify components
Vue.use(Vuetify);
Vue.use(VueRouter);

const router = new VueRouter({
  routes
});

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')