using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BackPackShould
{
    [Fact]
    public void allow_to_store_items()
    {
        var backpack = new BackPack();
        var phone = Item.from("Phone", Category.Unknown);
        var laptop = Item.from("Laptop", Category.Unknown);

        backpack.Store(phone);
        backpack.Store(laptop);

        backpack.Items.Should().Contain(phone).And.Contain(laptop);
    }
}