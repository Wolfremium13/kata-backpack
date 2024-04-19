namespace kata_backpack.solution;

public record Bag(Category Category = Category.Unknown)
{
    public List<Item> Items { get; } = [];

    public void Store(Item item)
    {
        if (item.Category == Category)
        {
            Items.Add(item);
        }
    }
}