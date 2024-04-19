namespace kata_backpack.solution;

public record Backpack
{
    public List<Item> Items { get; } = [];
    public bool IsFull => Items.Count == MaxCapacity;

    private const int MaxCapacity = 8;

    public void Store(Item item)
    {
        if (Items.Count < MaxCapacity)
            Items.Add(item);
    }
}