namespace kata_backpack.solution;

public class Item
{
    public string Name { get; }
    public Category Category { get; }

    private Item(string name, Category category = Category.Unknown)
    {
        Name = name;
        Category = category;
    }

    public static Item from(string name, Category category) => new(name, category);
}