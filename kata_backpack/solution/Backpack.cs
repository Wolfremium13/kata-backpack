using kata_backpack.solution.common;
using LanguageExt;

namespace kata_backpack.solution;

public record Backpack
{
    private List<Item> Items { get; init; } = [];

    public Either<Error, Backpack> Store(Item item)
    {
        const int maxCapacity = 8;
        if (Items.Count == maxCapacity)
        {
            return new BackPackIsFullError("Backpack is full");
        }
        return this with { Items = Items.Append(item).ToList() };
    }
    public IEnumerable<Item> RetrieveAll() => Items;
}

public record BackPackIsFullError(string Message) : Error(Message);