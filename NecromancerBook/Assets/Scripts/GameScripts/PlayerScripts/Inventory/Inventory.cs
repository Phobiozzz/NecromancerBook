using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> itemList;

    public void Start()
    {
        itemList = new List<Item>();

    }
    
    public void AddItem(Item _item)
    {
        itemList.Add(_item);
    }
}


