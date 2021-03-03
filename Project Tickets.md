```markdown
# Implementation of Projects

## Assumptions

1. Users will be able to create, edit and delete their own projects through a new page
2. Each project will consist of a single name field and an array of ids that map towards their respective tasks. 
3. Each project will also have its own generated unique id.

## Implementation
### Frontend(Views)
* We will need to create a new Projects view as depicted in ProjectsTaskList.png. We can reuse the existing Home View for this purpose using template syntaxing.
* We will also need to create a new view to show all current projects, as seen in ProjectsPage.png.
### Frontend(Components)
* We will need to create several new components:
    * Project.vue and ProjectList.vue (similiar to ToDoCard.vue and ToDoItemsList.vue). This should be quite straightforward. 
### Frontend(Routing)
* Update router/index.ts with the new routes. (/projects and /projects/:projectID respectively).

## Ticket - Add an Order button to the Items List page
Allow the user to toggle through different ordering strategies.

Acceptance criteria:
1. Default will be latest first
1. Second option will be oldest first
1. On toggling the option, the query will be re-ran with the API specifying the newest sort order.
1. The loading spinner should be shown while the API interaction is taking place
```