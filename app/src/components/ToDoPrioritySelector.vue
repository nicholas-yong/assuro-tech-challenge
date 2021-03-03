<template>
  <div class = "radio-buttons-container">
      <b-radio v-model= "selected"
               name = "name"
               native-value = "Low"
               :value = "'Low'"
               @input="returnSelection">
       Low
      </b-radio>
        <b-radio v-model= "selected"
                 name = "name"
                 native-value = "Medium"
                 :value = "'Medium'"
                 @input="returnSelection">
       Medium
      </b-radio>
      <b-radio v-model= "selected"
               name = "name"
               native-value = "High"
               :value = "'High'"
               @input="returnSelection">
       High
      </b-radio>
  </div>
</template>

<script lang="ts">

export default
{
    name: 'ToDoPrioritySelector',
    data()
    {
        return{
            selected: "Low"
        };
    },
    methods:
     {
        returnSelection(event)
        {
            this.$emit("priorityItemSelected", event)
        }
     }
}

</script>

<style lang="scss" scoped>

$medium: 900px;

.radio-buttons-container
{
    margin-top: 1rem;
    display: flex;
}

.radio-buttons-container .b-radio.radio
{
    margin-right: 1rem;
} 


</style>