using System.Linq;
using HotChocolate.Types;
using ToDoApi.Extensions;
using ToDoApi.Data;
using HotChocolate;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace ToDoApi.ToDoItems
{
    [ExtendObjectType(Name = "Mutation")]
    public class ToDoItemMutations
    {
        [UseApplicationDbContext]
        public async Task<CreateToDoItemPayload> CreateToDoItemAsync(
            CreateToDoItemInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var item = new ToDoItem
            {
                Content = input.Content,
                CreatedDate = DateTimeOffset.UtcNow,
                Status = input.Status.HasValue ? input.Status.Value : ToDoItemStatus.PENDING
            };

            context.ToDoItems.Add(item);

            await context.SaveChangesAsync(cancellationToken);

            return new CreateToDoItemPayload(item);
        }

        [UseApplicationDbContext]
        public async Task<UpdateToDoItemPayload> UpdateToDoItemAsync(
            UpdateToDoItemInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var item = await context.ToDoItems.FindAsync(new object[] { input.Id }, cancellationToken);

            item.Content = input.Content.HasValue ? input.Content.Value : item.Content;
            item.Status = input.Status.HasValue ? (input.Status.Value ?? item.Status) : item.Status;

            await context.SaveChangesAsync(cancellationToken);

            return new UpdateToDoItemPayload(item);
        }

        [UseApplicationDbContext]
        public async Task<DeleteToDoItemPayload> DeleteToDoItemPayloadAsync(
            DeleteToDoItemInput input,
            [ScopedService] ApplicationDbContext context,
            CancellationToken cancellationToken
        )
        {
            // Find the item to delete
            var item_to_delete = await context.ToDoItems.FindAsync(new object[] { input.Id }, cancellationToken);
            // Call remove to delete the item from the DB
            context.Remove( item_to_delete );
            // Commit/Save changes to the DB
            await context.SaveChangesAsync(cancellationToken);

            return new DeleteToDoItemPayload(item_to_delete);
        }
    }
}
