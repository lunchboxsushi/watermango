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
      <v-layout row wrap>
        <span>Visual alert at:</span>
        <div>{{entity.AlertWatering != null ? entity.AlertWatering : "Unknown"}}</div>
      </v-layout>
      <v-layout row wrap>
        <span>Count down to finish watering:</span>
        <div></div>
      </v-layout>
    </v-card>
    <div v-if="entity.IsWatering">Watering in process...</div>
    <div v-else>
      <v-checkbox v-if="!watering" label="Select for watering" v-model="entity.isSelected"></v-checkbox>
    </div>
  </v-container>
</template>

<script>
export default {
  props: {
    watering: {
      required: true,
      type: Boolean
    },
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
