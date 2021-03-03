using System;
using HotChocolate;
using ToDoApi.Data;

namespace ToDoApi.ToDoItems
{
    public record DeleteToDoItemInput(
        Guid Id
    );
}