<template>
  <div class="done">
    <ToDoItemsList :filters="{ status: { in: ['DONE'] } }"
    @list_deletedItem = "handleDeletedItem" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import ToDoItemsList from "@/components/ToDoItemsList.vue";
import ToDoCard from '@/components/ToDoCard.vue';

@Component({
  components: {
    ToDoItemsList
  }
})
export default class Done extends Vue {

  handleDeletedItem(e:ToDoCard)
  {
    //Just in case, let's test if e is undefined first.
    if( e !== undefined)
    {
      this.$router.go(0);
    }
  }
}

</script>

<style lang="scss" scoped>
</style>
