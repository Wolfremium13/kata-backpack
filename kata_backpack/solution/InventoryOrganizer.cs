using kata_backpack.solution.common;
using LanguageExt;

namespace kata_backpack.solution;

public class InventoryOrganizer(Backpack backpack, List<Bag> bags)
{
    public readonly Backpack Backpack = backpack;
    public readonly List<Bag> Bags = bags;

    public Either<Error, InventoryOrganizer> Store(Item item)
    {
        var maybeBackpackStored = Backpack.Store(item);
        if (maybeBackpackStored.IsLeft)
        {
            var maybeBagStored = Bags.Find(bag => bag.Store(item).IsRight);
            if (maybeBagStored is null)
            {
                return new CannotSaveTheItem("Cannot save the item");
            }

            return this;
        }

        var newBackpack = maybeBackpackStored.ToSeq()[0];
        return new InventoryOrganizer(newBackpack, Bags);
    }

    public InventoryOrganizer Organize()
    {
        var newBackpack = new Backpack();
        foreach (var item in Backpack.RetrieveAll())
        {
            var couldBeStoredInAnyBag = Bags.Find(bag => bag.Store(item).IsRight);
            if (couldBeStoredInAnyBag is null)
            {
                newBackpack = newBackpack.Store(item).ToSeq()[0];
            }
        }

        return new InventoryOrganizer(newBackpack, Bags);
    }
}

public record CannotSaveTheItem(string Message) : Error(Message);