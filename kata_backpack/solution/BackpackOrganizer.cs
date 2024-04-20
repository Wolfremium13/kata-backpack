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
        // If backpack does not throw an error, store the item in the backpack if yes raise the error
        var maybeBackpackStored = Backpack.Store(item);
        if (maybeBackpackStored.IsLeft)
        {
            return this;
        }

        var backpack = maybeBackpackStored.ToSeq()[0];
        return new BackpackOrganizer(backpack, Bags);
    }
}

public record CannotSaveTheItem(string Message) : Error(Message);