<template>
  <div class="items-list">
    <div v-if="items.length">
      <div v-for="item in items" :key="item.id">
        <ToDoCard :item="item" 
                  :onStatusToggle="loadItems"
                  @deletedItem = "deletedItem" />
      </div>
    </div>
    <p v-else-if="!isLoading">No items found!</p>
    <BLoading :is-full-page="true" :active.sync="isLoading" />
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";
import ToDoCard from "@/components/ToDoCard.vue";
import gql from "graphql-tag";

@Component({
  components: {
    ToDoCard
  }
})
export default class ToDoItemsList extends Vue {
  @Prop({ required: true }) filters: any;

  items = [];
  isLoading = false;

  mounted() {
    this.loadItems();
  }

  deletedItem(e: ToDoCard)
  {
    this.$emit('handleDeletedItem', e);
  }


  //reload()
  //{
   // this.$forceUpdate();
  //}

  loadItems() {
    this.isLoading = true;
    this.$apollo
      .query({
        query: gql`
          query($filters: ToDoItemFilterInput) {
            toDoItems(
              order: [{priority:ASC}, {createdDate:DESC}]
              where: $filters
            ) {
              nodes {
                content
                createdDate
                id
                status
                priority
              }
            }
          }
        `,
        variables: {
          filters: this.filters
        },
        fetchPolicy: "network-only"
      })
      .then(
        ({
          data: {
            toDoItems: { nodes: items }
          }
        }) => {
          this.items = items;
        }
      )
      .finally(() => (this.isLoading = false));
  }
}
</script>
