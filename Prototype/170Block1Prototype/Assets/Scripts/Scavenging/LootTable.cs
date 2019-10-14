using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLootTable", menuName = "Scavenging/LootTable")]
public class LootTable : ScriptableObject
{
    public List<float> rarityWeighting = new List<float> { 5, 3, 1 };
    public List<TempItem> itemsCommon = new List<TempItem>();
    public List<float> itemsCommonWeights = new List<float>();
    public List<TempItem> itemsUncommon = new List<TempItem>();
    public List<float> itemsUncommonWeights = new List<float>();
    public List<TempItem> itemsRare = new List<TempItem>();
    public List<float> itemsRareWeights = new List<float>();
}
