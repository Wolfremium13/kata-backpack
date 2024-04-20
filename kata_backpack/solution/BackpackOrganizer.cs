using kata_backpack.solution.common;
using LanguageExt;
using Void = LanguageExt.Pipes.Void;

namespace kata_backpack.solution;

public class BackpackOrganizer(Backpack backpack, List<Bag> bags)
{
    public readonly Backpack Backpack = backpack;
    public readonly List<Bag> Bags = bags;

    public Either<Error, BackpackOrganizer> Store(Item item)
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

        var backpack = maybeBackpackStored.ToSeq()[0];
        return new BackpackOrganizer(backpack, Bags);
    }
}

public record CannotSaveTheItem(string Message) : Error(Message);