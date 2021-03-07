<template>
  <div class="home">
    <ToDoItemsList 
      :filters="{ status: { in: ['PENDING', 'DOING'] } }" 
      @handleDeletedItem = "handleDeletedItem" />
    <FloatingButton text="+ Add" :on-click="addNew" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import ToDoItemsList from "@/components/ToDoItemsList.vue";
import FloatingButton from "@/components/FloatingButton.vue";
import ToDoCard from '@/components/ToDoCard.vue';

@Component({
  components: {
    ToDoItemsList,
    FloatingButton
  }
})
export default class Home extends Vue {
  addNew() {
    this.$router.push({ name: "new" });
  }

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
