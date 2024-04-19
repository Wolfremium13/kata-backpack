using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BackPackOrganizerShould
{
    private readonly BackpackOrganizer _backpackOrganizer = new();
    
    [Fact]
    public void fill_backpack_first_if_it_has_capacity()
    {
        var phone = Item.From("Phone");
        _backpackOrganizer.Store(phone);

        var backpack = new Backpack();
        backpack.Store(phone);
        _backpackOrganizer.Backpack.Should().BeEquivalentTo(backpack);
    }
}