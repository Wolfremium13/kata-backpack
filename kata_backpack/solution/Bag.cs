namespace kata_backpack.solution;

public record Bag(Category Category = Category.Unknown)
{
    public List<Item> Items { get; } = [];
    public bool IsFull => Items.Count == MaxCapacity;

    private const int MaxCapacity = 4;

    public void Store(Item item)
    {
        if (item.Category == Category && Items.Count < MaxCapacity)
        {
            Items.Add(item);
        }
    }
}