using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public ItemType type;

    public int amount;

    public int value;
    public int power;
}

public enum ItemType
{
    Bone,
    Potion,
    PageFragment
}
