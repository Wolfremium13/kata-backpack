using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BackPackShould
{
    private readonly Backpack _backpack = new();

    [Fact]
    public void allow_to_store_items()
    {
        var phone = Item.From("Phone", Category.Unknown);
        var laptop = Item.From("Laptop", Category.Unknown);

        _backpack.Store(phone);
        _backpack.Store(laptop);

        _backpack.Items.Should().Contain(phone).And.Contain(laptop);
    }

    [Fact]
    public void not_allow_to_store_items_above_max_capacity()
    {
        const int maxCapacity = 8;
        var phones = Repeat(Item.From("Phone", Category.Unknown), maxCapacity + 1);

        foreach (var phone in phones)
        {
            _backpack.Store(phone);
        }

        _backpack.Items.Should()
            .HaveCount(maxCapacity)
            .And.OnlyContain(item => phones.Contains(item));
    }

    private static List<Item> Repeat(Item item, int count)
    {
        var items = new List<Item>();
        for (var i = 0; i < count; i++)
        {
            items.Add(item);
        }

        return items;
    }
}