<template>
  <v-container>
    <h1>Plant Management</h1>
    <div class="pspacing">
      <p>1. select plants you want to water</p>
      <p>2. select start watering, you can stop watering anytime or it will default after 10 seconds</p>
      <p>3. you cannot water the same plant for 30 seconds</p>
    </div>

    <!-- iterate over plants to show all-->
    <v-progress-circular :indeterminate="true" v-if="loading"></v-progress-circular>
    <div v-else>
      <v-layout row wrap>
        <div md3 lg3 v-for="plant in plants" :key="plant.Id">
          <Plant :entity="plant"/>
        </div>
      </v-layout>
    </div>
    <v-btn v-if="watering" @click="stopWatering">Stop Watering</v-btn>
    <v-btn v-else @click="startWatering">Start Watering</v-btn>
  </v-container>
</template>

<script>
import PlantApi from "@/api/PlantApi";
import Plant from "@/components/Plant";

export default {
  components: { Plant },
  data() {
    return {
      plants: [],
      selectedPlants: [],
      loading: true,
      watering: false
    };
  },
  methods: {
    startWatering() {
      // set all selected plants to watering status
      this.selectedPlants = this.plants.filter(p => p.isSelected);

      this.plants.forEach(p => {
        if (this.selectedPlants.find(s => s.Id === p.Id)) {
          p.isWatering = true;
        }
      });
      this.watering = true;
      // await PlantApi.startWatering(selectedPlants);
    },
    stopWatering() {
      this.plants.forEach(p => (p.isWatering = false));
      this.watering = false;
    }
  },
  async mounted() {
    try {
      // Fetch all plants on page load
      var results = await PlantApi.getPlants();
      if (results) {
        results.forEach(r => (r.isSelected = false));
      }
      this.$set(this, "plants", results);
    } finally {
      this.loading = false;
    }
  }
};
</script>

<style>
.pspacing {
  margin-top: 15px;
}
</style>
