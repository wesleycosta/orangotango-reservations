using Orangotango.Core.Abstractions;
using Orangotango.Core.Enums;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Domain.Rooms.Aggregates;
using Orangotango.Rooms.Domain.Categories;

namespace Orangotango.Reservations.Application.Services;

internal class CategoryEventProcessor(IUnitOfWork _unitOfWork,
    ILoggerService _logger,
    ICategoryRepository _categoryRepository) : ICategoryEventProcessor
{
    public async Task Upsert(CategoryUpsertedEvent @event)
    {
        var category = await _categoryRepository.GetById(@event.AggregateId);
        Upsert(category, @event);
        await _unitOfWork.Commit();

        _logger.Information(nameof(OperationLogs.EventProcessedSuccessfully), $"Evento processado com sucesso", @event.TranceId);
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
