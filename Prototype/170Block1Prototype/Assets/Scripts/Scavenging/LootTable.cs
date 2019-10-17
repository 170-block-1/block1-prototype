using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLootTable", menuName = "Scavenging/LootTable")]
public class LootTable : ScriptableObject
{
    public List<float> rarityWeighting = new List<float> { 5, 3, 1 };
    public List<Part> itemsCommon = new List<Part>();
    public List<float> itemsCommonWeights = new List<float>();
    public List<Part> itemsUncommon = new List<Part>();
    public List<float> itemsUncommonWeights = new List<float>();
    public List<Part> itemsRare = new List<Part>();
    public List<float> itemsRareWeights = new List<float>();
}
