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
        var phone = Item.from("Phone", Category.Unknown);
        var laptop = Item.from("Laptop", Category.Unknown);


        bag.Store(phone);
        bag.Store(laptop);

        bag.Items.Should().Contain(phone).And.Contain(laptop);
    }

    [Fact]
    public void allow_to_store_items_with_the_same_category()
    {
        var bag = new Bag(Category.Electronics);
        var phone = Item.from("Phone", Category.Electronics);
        var laptop = Item.from("Laptop", Category.Electronics);


        bag.Store(phone);
        bag.Store(laptop);

        bag.Items.Should().Contain(phone).And.Contain(laptop);
    }

    [Fact]
    public void not_allow_to_store_items_with_different_category()
    {
        var bag = new Bag(Category.Electronics);
        var phone = Item.from("Phone", Category.Electronics);
        var laptop = Item.from("Laptop", Category.Unknown);


        bag.Store(phone);
        bag.Store(laptop);

        bag.Items.Should().Contain(phone).And.NotContain(laptop);
    }

    [Fact]
    public void not_allow_to_store_items_above_max_capacity()
    {
        const int maxCapacity = 4;
        var bag = new Bag(Category.Electronics);

        var phone = Item.from("Phone", Category.Electronics);
        var laptop = Item.from("Laptop", Category.Electronics);
        var tablet = Item.from("Tablet", Category.Electronics);
        var camera = Item.from("Camera", Category.Electronics);
        var watch = Item.from("Watch", Category.Electronics);

        bag.Store(phone);
        bag.Store(laptop);
        bag.Store(tablet);
        bag.Store(camera);
        bag.Store(watch);


        bag.Items.Should()
            .Contain(phone)
            .And.Contain(laptop)
            .And.Contain(tablet)
            .And.Contain(camera)
            .And.NotContain(watch);
    }
}