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
    
}