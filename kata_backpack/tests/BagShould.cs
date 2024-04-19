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
        var item = Item.from("Phone", Category.Unknown);

        bag.Store(item);

        bag.Items.Should().Contain(item);
    }
}