using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RandomUtils;


public class Scavenger : MonoBehaviour
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
    }

    /// <summary>
    /// Simulates a round of scavenging and returns a list of scavenged items.
    /// items currently represented by the Part class;
    /// </summary>
    public Part Scavenge(LootTable table)
    {
        // Decide which rarity to choose from
        var rarityWeighted = new WeightedSet<Rarity>(EnumUtils.GetValues<Rarity>(), table.rarityWeighting);
        var rarity = RandomU.instance.Choice(rarityWeighted);
        // Initialize the drops to the items and weights from the correct rarity
        // Would be a dictionry if I had the time to write a good GUI for it
        WeightedSet<Part> drops;
        switch (rarity)
        {
            case Rarity.Common:
                drops = new WeightedSet<Part>(table.itemsCommon, table.itemsCommonWeights);
                break;
            case Rarity.Uncommon:
                drops = new WeightedSet<Part>(table.itemsUncommon, table.itemsUncommonWeights);
                break;
            case Rarity.Rare:
                drops = new WeightedSet<Part>(table.itemsRare, table.itemsRareWeights);
                break;
            default:
                return null;
        }
        //// Make parts you already have less likely
        //drops.ApplyMetric((p) => Player.instance.inventory.Contains(p) ? 0 : 1);
        // Return a random sample from the drops table
        return RandomU.instance.Choice(drops);
    }
}
