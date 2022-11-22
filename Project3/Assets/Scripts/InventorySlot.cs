using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    Item item;
    int quantity;
    public InventorySlot()
    {
        quantity = 0;
    }
    public int addItem(Item newItem, int q)//returns the amount of the item if it was switched
    {
        if (item.getName().Equals(newItem.getName()))
        {
            quantity += q;
            return 0;
        }
        else
        {
            int ret = quantity;
            item = newItem;
            quantity = q;
            return ret;
        }
        
    }
    public Item getItem()
    {
        return item;
    }
}
