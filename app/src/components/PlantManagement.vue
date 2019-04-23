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
          <Plant :entity="plant" :watering="watering"/>
        </div>
      </v-layout>
      <v-btn v-if="watering" @click="stopWatering">Stop Watering</v-btn>
      <v-btn v-else @click="startWatering">Start Watering</v-btn>
    </div>
  </v-container>
</template>

<script>
import PlantApi from "@/api/PlantApi";
import Plant from "@/components/Plant";
import { setTimeout, clearTimeout } from "timers";
import { error } from "util";

export default {
  components: { Plant },
  data() {
    return {
      plants: [],
      selectedPlants: [],
      wateringTimeout: null,
      loading: true,
      watering: false
    };
  },
  methods: {
    startWatering() {
      // let components know watering in progress
      this.watering = true;
      try {
        this.selectedPlants = this.plants.filter(p => p.isSelected);
        this.plants.forEach(p => {
          if (this.selectedPlants.find(s => s.Id === p.Id)) {
            p.IsWatering = true;
          }
        });

        PlantApi.startWatering(this.selectedPlants);
      } catch (exception) {
        this.plants.forEach(p => {
          p.IsWatering = false;
        });
        this.watering = false;
        throw error(exception);
      }
      // call stop watering after certain time unless it's manually triggered ?
      this.wateringTimeout = this.handleWaterTimeout();
    },
    stopWatering() {
      // stop timeout from being called since manual intervention
      clearTimeout(this.wateringTimeout);

      this.plants.forEach(p => (p.IsWatering = false));
      this.watering = false;

      PlantApi.stopWatering(this.selectedPlants);
      this.plants = this.fetchPlants();
    },
    handleWaterTimeout() {
      return setTimeout(this.stopWatering, 10 * 1000);
    },
    async fetchPlants() {
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
  },
  async mounted() {
    await this.fetchPlants();
  }
};
</script>

<style>
.pspacing {
  margin-top: 15px;
}
</style>
