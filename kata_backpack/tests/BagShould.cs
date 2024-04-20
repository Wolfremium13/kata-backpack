using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BagShould
{
    private readonly Bag _bag = new(Category.Electronics);

    [Fact]
    public void allow_to_store_items()
    {
        var phone = Item.From("Phone");

        _bag.Store(phone).Match(
            error => error.Should().BeNull(),
            bag => bag.RetrieveAll().Should().Contain(phone)
        );
    }

    [Fact]
    public void allow_to_store_items_with_the_same_category()
    {
        var phone = Item.From("Phone", Category.Electronics);

        _bag.Store(phone).Match(
            error => error.Should().BeNull(),
            bag => bag.RetrieveAll().Should().Contain(phone)
        );
    }

    [Fact]
    public void not_allow_to_store_items_with_different_category()
    {
        const Category differentCategory = Category.Clothes;
        var laptop = Item.From("Laptop", differentCategory);

        _bag.Store(laptop).Match(
            error => error.Should().BeOfType<DifferentCategoryItemError>(),
            bag => bag.RetrieveAll().Should().NotContain(laptop)
        );
    }

    [Fact]
    public void not_allow_to_store_items_above_max_capacity()
    {
        const int maxCapacity = 4;
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Electronics);
        var tablet = Item.From("Tablet", Category.Electronics);
        var camera = Item.From("Camera", Category.Electronics);
        var watch = Item.From("Watch", Category.Electronics);

        _bag.Store(phone)
            .Bind(bag => bag.Store(laptop))
            .Bind(bag => bag.Store(tablet))
            .Bind(bag => bag.Store(camera))
            .Bind(bag => bag.Store(watch))
            .Match(
                error => error.Should().BeOfType<BagIsFullError>(),
                bag => bag.RetrieveAll().Should()
                    .HaveCount(maxCapacity)
                    .And.Contain(phone)
                    .And.Contain(laptop)
                    .And.Contain(tablet)
                    .And.Contain(camera)
                    .And.NotContain(watch)
            );


        _bag.RetrieveAll().Should()
            .HaveCount(maxCapacity)
            .And.Contain(phone)
            .And.Contain(laptop)
            .And.Contain(tablet)
            .And.Contain(camera)
            .And.NotContain(watch);
    }
}