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
        return this;
    }
    
}
public record CannotStoreItem(string Message): Error(Message);
