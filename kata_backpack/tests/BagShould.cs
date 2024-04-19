using FluentAssertions;
using kata_backpack.solution;
using Xunit;

namespace kata_backpack.tests;

public class BagShould
{
    [Fact]
    public void allow_to_store_items()
    {
        var bag = new Bag();
        var phone = Item.From("Phone", Category.Unknown);
        var laptop = Item.From("Laptop", Category.Unknown);


        bag.Store(phone);
        bag.Store(laptop);

        bag.Items.Should().Contain(phone).And.Contain(laptop);
    }

    [Fact]
    public void allow_to_store_items_with_the_same_category()
    {
        var bag = new Bag(Category.Electronics);
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Electronics);


        bag.Store(phone);
        bag.Store(laptop);

        bag.Items.Should().Contain(phone).And.Contain(laptop);
    }

    [Fact]
    public void not_allow_to_store_items_with_different_category()
    {
        var bag = new Bag(Category.Electronics);
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Unknown);


        bag.Store(phone);
        bag.Store(laptop);

        bag.Items.Should().Contain(phone).And.NotContain(laptop);
    }

    [Fact]
    public void not_allow_to_store_items_above_max_capacity()
    {
        const int maxCapacity = 4;
        var bag = new Bag(Category.Electronics);

        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Electronics);
        var tablet = Item.From("Tablet", Category.Electronics);
        var camera = Item.From("Camera", Category.Electronics);
        var watch = Item.From("Watch", Category.Electronics);

        bag.Store(phone);
        bag.Store(laptop);
        bag.Store(tablet);
        bag.Store(camera);
        bag.Store(watch);


        bag.Items.Should()
            .HaveCount(maxCapacity)
            .And.Contain(phone)
            .And.Contain(laptop)
            .And.Contain(tablet)
            .And.Contain(camera)
            .And.NotContain(watch);
    }
}