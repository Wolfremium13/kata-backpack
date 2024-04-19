## Kata Backpack

Story:
When Durance left his home to start his adventures, all he brought was a backpack. He eventually found more smaller bags to stash his items.

After enchanting his weapons and looking for ingredients and materials for a long time, Durance noticed his bags were really disorganized, maybe we can code a spell for him to organize them?

Requirements
Create an application that helps Durance organize the items in his bags. Each bag can have either a category or not, the backpack has no category.

Items are always added to the backpack, if it happens to be full, the item is added to the next available bag.

After organizing the items, each bag should have the items belonging to its category, sorted alphabetically. If the bag happens to be full, the rest of the items are stored in the backpack or successive bags, following the previous sort.

Rules
Durance has 1 backpack and 4 extra bags
Each bag has a capacity of 4 items, the backpack has a capacity of 8 items
Each bag can have a category, the backpack doesn't have one
Items are sorted alphabetically after organizing the bags

Example
Let's say that Durance has 8 items in his backpack and 1 empty extra bag, which has a category for `Metals`:

backpack = ['Leather', 'Iron', 'Copper', 'Marigold', 'Wool', 'Gold',      'Silk', 'Copper']
bag_with_metals_category = []
bag_with_no_category = []
bag_with_weapons_category = []
bag_with_no_category = []

he finds 2 new items, which are stored in the next available bag, since the backpack is already full:

backpack = ['Leather', 'Iron', 'Copper', 'Marigold', 'Wool', 'Gold',      'Silk', 'Copper']
bag_with_metals_category = ['Copper', 'Cherry Blossom']
bag_with_no_category = []
bag_with_weapons_category = []
bag_with_no_category = []

he now casts the organizing spell:

backpack = ['Cherry Blossom', 'Iron', 'Leather', 'Marigold', 'Silk',   'Wool']
bag_with_metals_category = ['Copper', 'Copper', 'Copper', 'Gold']
bag_with_no_category = []
bag_with_weapons_category = []
bag_with_no_category = []


Items
{
"clothes": ["Leather", "Linen", "Silk", "Wool"],
"herbs": ["Cherry Blossom", "Marigold", "Rose", "Seaweed"],
"metals": ["Copper", "Gold", "Iron", "Silver"],
"weapons": ["Axe", "Dagger", "Mace", "Sword"]
}

