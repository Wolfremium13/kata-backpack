using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BackPackOrganizerShould
{
    [Fact]
    public void fill_backpack_first_if_it_has_capacity()
    {
        var backpackOrganizer = new BackpackOrganizer(new Backpack(), []);
        var phone = Item.From("Phone");

        backpackOrganizer.Store(phone).Match(
            error => error.Should().BeNull(),
            organizer => organizer.Backpack.RetrieveAll().Should().Contain(phone)
        );
    }

    [Fact]
    public void fill_next_bag_if_backpack_is_full()
    {
        var backpackOrganizer = new BackpackOrganizer(new Backpack(), [new Bag()]);
        var aItem = Item.From("Irrelevant");
        var aBagItem = Item.From("Bag item");

        backpackOrganizer.Store(aItem)
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aBagItem))
            .Match(
                error => error.Should().BeNull(),
                organizer => organizer.Bags[0].RetrieveAll().Should().Contain(aBagItem).And.HaveCount(1)
            );
    }
    
    [Fact]
    public void not_allow_to_store_items_if_no_bag_can_store_it()
    {
        var backpackOrganizer = new BackpackOrganizer(new Backpack(), [new Bag(Category.Clothes)]);
        var aItem = Item.From("Irrelevant");
        var phone = Item.From("Phone", Category.Electronics);

        backpackOrganizer.Store(aItem)
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(aItem))
            .Bind(organizer => organizer.Store(phone))
            .Match(
            error => error.Should().BeOfType<CannotSaveTheItem>(),
            organizer => organizer.Backpack.RetrieveAll().Should().NotContain(phone)
        );
    }
}