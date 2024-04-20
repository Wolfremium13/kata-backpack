using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BackPackOrganizerShould
{
    private readonly BackpackOrganizer _backpackOrganizer = new(new Backpack(),
        [
            new Bag(Category.Electronics),
            new Bag(Category.Clothes),
            new Bag(Category.Food),
            new Bag()
        ]
    );

    [Fact]
    public void fill_backpack_first_if_it_has_capacity()
    {
        var phone = Item.From("Phone");

        _backpackOrganizer.Store(phone).Match(
            error => error.Should().BeNull(),
            organizer => organizer.Backpack.RetrieveAll().Should().Contain(phone));
    }
}