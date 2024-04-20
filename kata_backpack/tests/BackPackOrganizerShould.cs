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
        var emptyOrganizer = new BackpackOrganizer(new Backpack(), [new Bag()]);
        var aItem = Item.From("Irrelevant");
        var aBagItem = Item.From("Bag item");

        emptyOrganizer.Store(aItem)
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
    public void not_allow_to_store_items_if_there_are_no_capacity_left()
    {
        var emptyOrganizer = new BackpackOrganizer(new Backpack(), [new Bag(Category.Clothes)]);
        var aItem = Item.From("Irrelevant");
        var phone = Item.From("Phone", Category.Electronics);

        emptyOrganizer.Store(aItem)
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

    [Fact]
    public void organize_items_in_bags_with_same_category()
    {
        var emptyOrganizer = new BackpackOrganizer(new Backpack(), [new Bag(Category.Electronics)]);
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Electronics);
        var tablet = Item.From("Tablet", Category.Electronics);
        var camera = Item.From("Camera", Category.Electronics);
        var cup = Item.From("Cup", Category.Clothes);
        var backpackOrganizer = emptyOrganizer.Store(phone)
            .Bind(organizer => organizer.Store(laptop))
            .Bind(organizer => organizer.Store(tablet))
            .Bind(organizer => organizer.Store(camera))
            .Bind(organizer => organizer.Store(cup))
            .ToSeq()[0];

        var organizedItems = backpackOrganizer.Organize();

        organizedItems.Backpack.RetrieveAll()
            .Should()
            .HaveCount(1)
            .And
            .Contain(cup);
        organizedItems.Bags[0].RetrieveAll()
            .Should()
            .Contain(phone)
            .And.Contain(laptop)
            .And.Contain(tablet)
            .And.Contain(camera);
    }

    [Fact]
    public void organize_items_in_bags_with_different_categories()
    {
        var emptyOrganizer =
            new BackpackOrganizer(new Backpack(), [new Bag(Category.Electronics), new Bag(Category.Clothes)]);
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Electronics);
        var tablet = Item.From("Tablet", Category.Electronics);
        var camera = Item.From("Camera", Category.Electronics);
        var cup = Item.From("Cup", Category.Clothes);
        var backpackOrganizer = emptyOrganizer.Store(phone)
            .Bind(organizer => organizer.Store(laptop))
            .Bind(organizer => organizer.Store(tablet))
            .Bind(organizer => organizer.Store(camera))
            .Bind(organizer => organizer.Store(cup))
            .ToSeq()[0];

        var organizedItems = backpackOrganizer.Organize();

        organizedItems.Backpack.RetrieveAll()
            .Should()
            .HaveCount(0);
        organizedItems.Bags[0].RetrieveAll()
            .Should()
            .Contain(phone)
            .And.Contain(laptop)
            .And.Contain(tablet)
            .And.Contain(camera);
        organizedItems.Bags[1].RetrieveAll()
            .Should()
            .Contain(cup);
    }
}