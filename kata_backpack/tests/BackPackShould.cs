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
    
    [Fact]
    public void not_allow_to_store_items_above_max_capacity()
    {
        const int maxCapacity = 8;
        var backpack = new BackPack();
        var phones = new List<Item>();
        for (var i = 0; i < maxCapacity + 1; i++)
        {
            phones.Add(Item.from("Phone", Category.Unknown));
        }

        foreach (var phone in phones)
        {
            backpack.Store(phone);
        }

        backpack.Items.Should().HaveCount(maxCapacity).And.Contain(phones);
    }
}