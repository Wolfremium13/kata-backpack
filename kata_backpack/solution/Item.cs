namespace kata_backpack.solution;

public class Item
{
    public string Name { get; }
    public Category Category { get; }

    private Item(string name, Category category)
    {
        Name = name;
        Category = category;
    }

    public static Item From(string name, Category category = Category.Unknown) => new(name, category);
}