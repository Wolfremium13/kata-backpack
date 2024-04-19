using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BagShould
{
    [Fact]
    public void allow_to_store_items()
    {
        var bag = new Bag();
        var phone = Item.from("Phone", Category.Unknown);
        var laptop = Item.from("Laptop", Category.Unknown);
        

        bag.Store(phone);
        bag.Store(laptop);

        bag.Items.Should().Contain(phone).And.Contain(laptop);
    }
    
}