using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Rooms;
using Orangotango.Reservations.Domain.Rooms.Entities;

namespace Orangotango.Reservations.Application.Services;

internal sealed class CategoryEventProcessor(ILoggerService logger,
    IUnitOfWork _unitOfWork,
    ICategoryRepository _categoryRepository) : EventProcessorBase(logger), ICategoryEventProcessor
{

    public async Task Upsert(CategoryUpsertedEvent @event)
    {
        var category = await _categoryRepository.GetById(@event.AggregateId);
        Upsert(category, @event);

        await _unitOfWork.Commit();
        LogInfoEventProcessedSuccessfully(@event);
    }

    public async Task Remove(CategoryRemovedEvent @event)
    {
        var category = await _categoryRepository.GetById(@event.AggregateId);
        if (category is null)
        {
            return;
        }

        _categoryRepository.SoftDelete(category);
        await _unitOfWork.Commit();
        LogInfoEventProcessedSuccessfully(@event);
    }

    private void Upsert(Category category, CategoryUpsertedEvent @event)
    {
        if (category == null)
        {
            InsertCategory(@event);
            return;
        }

        UpdateCategory(category, @event);
    }

    private void InsertCategory(CategoryUpsertedEvent @event)
    {
        var category = new Category(@event.AggregateId,
            @event.Name);

        _categoryRepository.Add(category);
    }

    private void UpdateCategory(Category category, CategoryUpsertedEvent @event)
    {
        category.SetName(@event.Name);
        _categoryRepository.Update(category);
    }
}
