*Note 1: this document is stil being finalized*

*Note 2: this document is for design and development, none of this information is imperative, and all information is subject to change through the course of development*

*Note 3: these are the core development principals of the terrain generation. Thy may not affect the final product*
# Terrain Generation

The terrain generation is handled by three noise images (maps) that are all generated with independed seeds set by the server host.

One map is dedicated to height.

One map is dedicated to biome generation.

One map is dedicated to resource type.

## Height map

Height values are organized into 4 levels; High, Medium, Low, and Water. The height map is normalized to be 0-3. Level 0 is Water, level 1 is Low, level 2 is Medium, level 3 is High.

## Resource map

If resource map pixel is greater than height map pixel, there will be a chance that it will spawn a resource node to spawn resource node.

When resource cluster is verified to exist, it has a chance to be plentiful depending on the height (higher = higher chance.)

The resource type is dependent on the biome.

## Biome map

Values on the biome map are normalized in the same way that the values on the height map are.

The biome of a chosen area is chosen by the value of that area on the biome map.

# Networking and Terrain

The terrain generation is done clientside. When the client connects to the server the server send loss-less packets containing the generation seeds.

It is **very important** that these arrive in order and are not lost/spoofed because that would create terrain de-sync betwen clients and would result in false anti-cheat flagging and unintentional bans.
