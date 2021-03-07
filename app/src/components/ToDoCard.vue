<template>
  <div class="item-card">
    <div class="columns">
      <div class="column is-three-quarters has-text-left">
        <div class = "icon-holder">
          <vue-fontawesome
          icon="circle"
          size="1x"
          v-bind:style="{color:priorityIconColor, visibility:displayPriorityIcon}"
          class = "fs-priority-icon">
          </vue-fontawesome>
        </div>
        <BField class="checkbox-field">
            <BCheckbox v-model="done" @input="toggleDone" class = "content-checkbox">{{
            content
          }}</BCheckbox>
        </BField>
      </div>
      <div>
        <BButton outlined @click="editItem">Edit</BButton>
      </div>
      <div>
        <BButton outlined @click="deleteItem">Delete</BButton>
      </div>
  </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";
import gql from "graphql-tag";

@Component
export default class ToDoCard extends Vue {
  @Prop({ required: true }) item: any;
  @Prop({ default: () => () => ({}) }) onStatusToggle: Function;

  get content() {
    return this.item.content;
  }

  get createdDate() {
    return this.item.createdDate;
  }

  get priorityIconColor(){
    switch(this.item.priority)
    {
      case "HIGH":
       return "Red"
      case "LOW":
        return "Green"
      default:
        return "Black"
    }
  }

  get displayPriorityIcon()
  {
    if( this.item.priority === "LOW" || this.item.priority === "HIGH" )
    {
      return "visible";
    }
    else
    {
      return "hidden";
    }
   }

  get createdDateDisplay() {
    return new Date(this.item.createdDate).toUTCString();
  }

  get done() {
    return this.item.status == "DONE";
  }

  set done(val: boolean) {
    this.item.status = val ? "DONE" : "PENDING";
  }

  editItem()
  {
    this.$router.push({
      name: 'edit',
      params: {
        item: this.item
      }
    })
  }

  deleteItem()
  {
    this.$apollo
    .mutate({
      mutation: gql`
        mutation($input: DeleteToDoItemInput!) {
          deleteToDoItemPayload(input: $input) {
            toDoItem {
                  content
                  createdDate
                  id
                  status
            }
          }
        }
      `,
      variables: {
        input:
        {
          id: this.item.id
        }
      }
  }).then(() => this.$emit("deletedItem", this.item));

  }

  toggleDone(){
    this.$apollo
      .mutate({
        mutation: gql`
          mutation($input: UpdateToDoItemInput!) {
            updateToDoItem(input: $input) {
              toDoItem {
                content
                createdDate
                id
                status
              }
            }
          }
        `,
        variables: {
          input: {
            id: this.item.id,
            status: this.item.status
          }
        }
      })
      .then(() => this.onStatusToggle());
  }
}
</script>
<style lang="scss" scoped>
$medium: 900px;

.has-text-left
{
  padding: 0px;
  padding-bottom: 30px;
}

.checkbox-field 
{
  line-height: 2.5rem;
  margin-left: 2rem;
}

.icon-holder
{
  height: 0;
}

.fs-priority-icon
{
  margin-right: 1rem;
  position: relative;
  left: 0;
  top: 3px;
  @media screen and (max-width: $medium)
  {
    margin: 0;
    position: relative;
  }
}


button
{
  margin-right: 1rem;
  @media screen and (max-width: $medium)
  {
    margin-bottom: 1rem;
  }
}

.control-label
{
  word-wrap: normal;
}


</style>
