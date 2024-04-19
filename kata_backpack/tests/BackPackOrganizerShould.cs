using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BackPackOrganizerShould
{
    private readonly BackpackOrganizer _backpackOrganizer = new(
    [
        new Bag(Category.Electronics),
        new Bag(Category.Clothes),
        new Bag(Category.Food),
        new Bag()
    ]);

    [Fact]
    public void fill_backpack_first_if_it_has_capacity()
    {
        var phone = Item.From("Phone");

        _backpackOrganizer.Store(phone).Match(
            error => error.Should().BeNull(),
            organizer =>
            {
                var backpack = new Backpack();
                backpack.Store(phone);
                organizer.Backpack.Should().BeEquivalentTo(backpack);
            }
        );
    }

    [Fact]
    public void fill_bag_if_backpack_is_full()
    {
        GivenAFullCapacityBackpack();
        var tablet = Item.From("Tablet");

        _backpackOrganizer.Store(tablet).Match(
            error => error.Should().BeNull(),
            organizer =>
            {
                var bag = organizer.Bags.FirstOrDefault(bag => bag.Category == Category.Unknown);
                bag.Items.Should().Contain(tablet);
            }
        );
    }

    private void GivenAFullCapacityBackpack()
    {
        const int backpackCapacity = 8;
        var phones = Repeat(Item.From("Irrelevant"), backpackCapacity);
        foreach (var phone in phones)
        {
            _backpackOrganizer.Store(phone);
        }
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