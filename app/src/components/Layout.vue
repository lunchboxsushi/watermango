<template>
  <div>
    <v-toolbar :app="true" :dark="true">
      <v-toolbar-title>WaterMango</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items class="hidden-sm-and-down">
        <v-btn flat to="welcome">Home</v-btn>
        <v-btn flat to="plantManagement">Plant Management</v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <router-view></router-view>
  </div>
</template>

<script>
export default {};
</script>

<style>
</style>

