namespace kata_backpack.solution;

public class BackpackOrganizer
{
    public readonly Backpack Backpack = new();
    public void Store(Item item)
    {
        Backpack.Store(item);
    }
}