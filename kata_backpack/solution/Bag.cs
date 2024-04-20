using kata_backpack.solution.common;
using LanguageExt;

namespace kata_backpack.solution;

public record Bag(Category Category = Category.Unknown)
{
    private List<Item> Items { get; } = [];

    public Either<Error, Bag> Store(Item item)
    {
        const int maxCapacity = 4;
        if (Items.Count == maxCapacity)
        {
            return new BagIsFullError("Bag is full");
        }

        var notHaveAnAllowedCategory = item.Category != Category && item.Category != Category.Unknown;
        if (notHaveAnAllowedCategory)
        {
            return new DifferentCategoryItemError("Item category is different from bag category");
        }

        Items.Add(item);
        return this;
    }

    public IEnumerable<Item> RetrieveAll()
    {
        return Items.ToList();
    }
}

public record BagIsFullError(string Message) : Error(Message);
public record DifferentCategoryItemError(string Message) : Error(Message);