<template>
  <v-container grid-list-xs>
    <v-card>
      <v-layout row wrap>
        <span>id:</span>
        <div>{{entity.Id}}</div>
      </v-layout>
      <v-layout row wrap>
        <span>is watering:</span>
        <div>{{entity.IsWatering}}</div>
      </v-layout>
      <v-layout row wrap>
        <span>Last watered:</span>
        <div>{{entity.LastWatered != null ? entity.LastWatered : "Unknown"}}</div>
      </v-layout>
    </v-card>
    <div v-if="entity.isWatering">Watering in process...</div>
    <v-checkbox v-else label="Select for watering" v-model="entity.isSelected"></v-checkbox>
  </v-container>
</template>

<script>
export default {
  props: {
    entity: {
      required: true,
      type: Object
    }
  },
  methods: {
    toggleSelection() {
      this.entity.isSelected = !this.entity.isSelected;
    }
  }
};
</script>
