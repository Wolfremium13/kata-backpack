namespace kata_backpack.solution;

public record Bag
{
    public List<Item> Items { get; } = [];
    public void Store(Item item)
    {
        Items.Add(item);
    }
}