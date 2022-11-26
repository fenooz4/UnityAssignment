using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
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
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
    }





}
