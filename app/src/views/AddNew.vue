<template>
  <div class="add-new">
    <ValidationObserver v-slot="{ handleSubmit }">
      <form @submit.prevent="handleSubmit(createItem)">
        <ValidationProvider
          v-slot="{ errors }"
          name="To Do"
          :rules="'min:3|max:255'"
          slim
        >
          <BField
            :type="{ 'is-danger': errors[0] }"
            :message="errors"
            :expanded="true"
          >
            <BInput v-model="content" placeholder="To Do" :expanded="true" />
          </BField>
        </ValidationProvider>
        <section>
            <div class="buttons are-medium">
              <BButton native-type="submit" type="is-primary" class="control">
                Save
              </BButton>
              <BButton @click = "$router.back()">
                Cancel
              </BButton>
            </div>
        </section>
        <ToDoPrioritySelector defaultPriority = "NORMAL" v-on:buttonSelected = "buttonSelected" ></ToDoPrioritySelector>
      </form>
    </ValidationObserver>
    <BLoading :is-full-page="false" :active.sync="isLoading" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ValidationProvider, ValidationObserver } from "vee-validate";
import gql from "graphql-tag";
import ToDoPrioritySelector from '@/components/ToDoPrioritySelector.vue';

@Component({
  components: {
    ValidationProvider,
    ValidationObserver,
    ToDoPrioritySelector
  }
})
export default class AddNew extends Vue {
  isLoading = false;
  content = "";
  priority = "NORMAL";

  buttonSelected(e:string)
  {
    this.priority = e;
  }

  createItem() {
    this.isLoading = true;
    this.$apollo
      .mutate({
        mutation: gql`
          mutation($input: CreateToDoItemInput!) {
            createToDoItem(input: $input) {
              toDoItem {
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
          input: {
            content: this.content,
            priority: this.priority
          },
        }
      })
      .then(() => this.$router.push({ name: "default" }))
      .finally(() => (this.isLoading = false));
  }

  close()
  {
    this.$router.push({
      name:'default'
    });
  }
}
</script>
