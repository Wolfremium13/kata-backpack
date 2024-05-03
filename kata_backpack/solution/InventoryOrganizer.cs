using kata_backpack.solution.common;
using LanguageExt;

namespace kata_backpack.solution;

public class InventoryOrganizer(Backpack backpack, List<Bag> bags)
{
    public readonly Backpack Backpack = backpack;
    public readonly List<Bag> Bags = bags;

    public Either<Error, InventoryOrganizer> Store(Item item)
    {
        return Backpack.Store(item)
            .Match<Either<Error, InventoryOrganizer>>(
                _ =>
                {
                    var maybeBagStored = Bags.Find(bag => bag.Store(item).IsRight);
                    return maybeBagStored is null
                        ? new CannotSaveTheItem("Cannot save the item")
                        : new InventoryOrganizer(Backpack, Bags);
                },
                backpack => new InventoryOrganizer(backpack, Bags)
            );
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