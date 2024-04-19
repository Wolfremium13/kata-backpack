namespace kata_backpack.solution;

public record BackPack
{
    public List<Item> Items { get; } = [];

    public void Store(Item item)
    {
        Items.Add(item);
    }
}