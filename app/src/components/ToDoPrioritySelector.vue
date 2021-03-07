<template>
  <div class = "radio-buttons-container">
      <b-radio v-model= "localDefaultPriority"
               name = "name"
               native-value = "LOW"
               :value = "'LOW'"
               @input="returnSelection">
       Low
      </b-radio>
        <b-radio v-model= "localDefaultPriority"
                 name = "name"
                 native-value = "NORMAL"
                 :value = "'NORMAL'"
                 @input="returnSelection">
       Normal
      </b-radio>
      <b-radio v-model= "localDefaultPriority"
               name = "name"
               native-value = "HIGH"
               :value = "'HIGH'"
               @input="returnSelection">
       High
      </b-radio>
  </div>
</template>

<script lang="ts">

export default
{
    data() 
    {
        return{}
    },
    model:
    {
        prop: 'defaultPriority',
        event: 'buttonSelected'
    },
    props:
    {
        defaultPriority: String
    },
    methods:
    {
        returnSelection(e:any)
        {
            this.$emit("buttonSelected", e)
        }
    },
    computed:
    {
        localDefaultPriority:
        {
            get(): string 
            {
                return this.defaultPriority;
            },
            
            set(): void
            {
                //We don't need to do anything here.
            }
        }
    }
}

</script>

<style lang="scss" scoped>

$medium: 900px;

.radio-buttons-container
{
    margin: 1rem;
    display: flex;
}

.radio-buttons-container .b-radio.radio
{
    margin-right: 1rem;
} 


</style>