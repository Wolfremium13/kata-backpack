using kata_backpack.solution.common;
using LanguageExt;
using Void = LanguageExt.Pipes.Void;

namespace kata_backpack.solution;

public class BackpackOrganizer
{
    public readonly Backpack Backpack = new();
    public readonly List<Bag> Bags;

    public BackpackOrganizer(List<Bag> bags)
    {
        Bags = bags;
    }


    public Either<Error, BackpackOrganizer> Store(Item item)
    {
        if (!Backpack.IsFull)
        {
            Backpack.Store(item);
            return this;
        }
        var availableBag = Bags.FirstOrDefault(bag => bag.Category == item.Category);
        if (availableBag == null)
        {
            return new CannotStoreItem("No available bag to store the item");
        }
        availableBag.Store(item);
        return this;
    }
    
}
public record CannotStoreItem(string Message): Error(Message);
