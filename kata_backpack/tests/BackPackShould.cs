using FluentAssertions;
using kata_backpack.solution;
using kata_backpack.solution.common;
using LanguageExt;
using Xunit;

namespace kata_backpack.tests;

public class BackPackShould
{
    private readonly Backpack _backpack = new();

    [Fact]
    public void allow_to_store_items()
    {
        var phone = Item.From("Phone");

        _backpack.Store(phone).Match(
            error => error.Should().BeNull(),
            backpack => backpack.RetrieveAll().Should().Contain(phone)
        );
    }

    [Fact]
    public void not_allow_to_store_items_above_max_capacity()
    {
        var item = Item.From("Irrelevant");

        var extraPhone = Item.From("Extra phone");
        _backpack
            .Store(item)
            .Bind(b => b.Store(item))
            .Bind(b => b.Store(item))
            .Bind(b => b.Store(item))
            .Bind(b => b.Store(item))
            .Bind(b => b.Store(item))
            .Bind(b => b.Store(item))
            .Bind(b => b.Store(item))
            .Bind(b => b.Store(extraPhone))
            .Match(
                error => error.Should().BeOfType<BackPackIsFullError>(),
                backpack => backpack.RetrieveAll().Should().NotContain(extraPhone)
            );
    }
}
