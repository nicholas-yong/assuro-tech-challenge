```markdown
# Implementation of Projects Functionality

## Assumptions

1. Users will be able to create new projects using the new ProjectsList.vue view.
2. When viewing an individual project inside the new Projects.vue view, clicking on +Add will add a ToDoItem to that project.
3. A ToDoItem can only be associated with one project at once.

## Implementation

### Back End

#### Ticket - Create new table inside DB.
1. Create a new table titled Project inside the DB with the following fields:
    * Name VARCHAR(100) NOT NULL
    * ProjectID TEXT NOT NULL CONSTRAINT "PK_Project" PRIMARY KEY
    * createdDate DATETIME DEFAULT CURRENT_TIMESTAMP
2. Add a foreign key to the ToDoItem table titled ProjectID. 

Acceptance Criteria:
1. To Do Items should be able to be associated with Projects with a many to one relationship.

#### Ticket - Create Definition for ToDoProject.cs and alter definition for ToDoItem.cs
1. Create a namespace definition for a Project, similiar to ToDoItem.cs. Each project should have the following fields:
    * Name
    * ProjectID
2. Add a GUID Field for ProjectID to ToDoItem.cs

#### Ticket - Create new Project Mutations
1. Create a new mutation for creating projects along with the respective input/payload files inside a new folder under the ToDoApi folder.

Acceptance Criteria:
1. The create mutation function should return an Input Exception if a project with the same name already exists. (using the FindAsync() Function to check for existing projects).

#### Ticket - Modify Startup.cs
1. Modify Startup.cs to work with the newly created mutation.

### Front End

#### Ticket - Create Project Component
1. Create a component for displaying an individual project similar to ToDoCard.vue, basing the design of the items inside ProjectsTaskList.png. 

Acceptance Criteria:
1. The component should follow the design details shown inside ProjectsTaskList.png
2. This includes things such as a button that routes the user to the Projects.vue view as well as a label that displays how many ToDoItems are currently associated with that Project.

#### Ticket - Create Project List Component
1. Create a component for displaying a list of Project componenets similar to how ToDoItemsList.vue displays a list of ToDoItem components.

Acceptance Criteria:
1. The component should follow the design details shown inside ProjectsTaskList.png
2. We can order the projects by name or by createdDate.
3. This should have a mounted() function that uses a query mutation to query all projects inside the Projects table.

Potential Ideas:
1. Use a loading animation prior to the project being loaded (control this with a this.loading field) if the loading takes too long.

#### Ticket - Create NewProject View
1. Create a view that is similar to the current AddNew.vue view but insteads creates a new project when the save button is clicked.

Acceptance Criteria:
1. Clicking Save/Cancel should bring the user back to the new ProjectLists.vue view.
2. If an input errors occurs when clicking on Save due to an existing project with same name already existing, the user should be alerted to this fact through some method. (Alert, HTML Element, etc)

#### Ticket - Create ProjectList View
1. Create a view for displaying all projects inside the projects table.
2. This view will simply hold the Project List component.

Acceptance Criteria:
1. The design of this view should conform to ProjectTaskList.png.
2. Clicking on the +Add Button should route the user to the NewProject View.

#### Ticket - Create Project View
1. Create a view for displaying all ToDoItems inside a project, using the existing ToDoItemsList component for populating the ToDoItems that belong to that project.

Acceptance Criteria:
1. The design of this view should conform to ProjectsPage.png, with the exception of the addition of the priority indicators.
2. Clicking on the +Add Button should route the user to the AddNew.vue View along with passing the displayed project's GUID as a prop value.

#### Ticket - Modify AddNew.vue
1. Add a prop to the view class that holds a project's GUID. Modify Home.vue to pass undefined for this prop.

#### Ticket - Alter current mutations
1. Alter all current mutations to include the ProjectID as a field.

#### Ticket - Implement new Routes
1. Implement the following new routes and their associated props:
    * '/projects'
    * '/projects/edit', props: this.project
    * '/projects/new'