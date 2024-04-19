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
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Electronics);


        _bag.Store(phone);
        _bag.Store(laptop);

        _bag.Items.Should().Contain(phone).And.Contain(laptop);
    }

    [Fact]
    public void allow_to_store_items_with_the_same_category()
    {     
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Electronics);


        _bag.Store(phone);
        _bag.Store(laptop);

        _bag.Items.Should().Contain(phone).And.Contain(laptop);
    }

    [Fact]
    public void not_allow_to_store_items_with_different_category()
    {     
        var phone = Item.From("Phone", Category.Electronics);
        var laptop = Item.From("Laptop", Category.Unknown);


        _bag.Store(phone);
        _bag.Store(laptop);

        _bag.Items.Should().Contain(phone).And.NotContain(laptop);
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

        _bag.Store(phone);
        _bag.Store(laptop);
        _bag.Store(tablet);
        _bag.Store(camera);
        _bag.Store(watch);


        _bag.Items.Should()
            .HaveCount(maxCapacity)
            .And.Contain(phone)
            .And.Contain(laptop)
            .And.Contain(tablet)
            .And.Contain(camera)
            .And.NotContain(watch);
    }
}