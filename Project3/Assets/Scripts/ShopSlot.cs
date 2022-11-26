using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    Item item;
    int quantity;
    public ShopSlot()
    {
        quantity = 0;
    }
    public void addItem(Item newItem, int q=1)//returns the amount of the item if it was switched
    {
        if (item!=null && item.getName().Equals(newItem.getName()))
        {
            quantity += q;
            
        }
        else
        {
            
            item = newItem;
            quantity = q;
            Image img = GetComponent<Image>();
            Debug.Log("Images/" + item.image);
            img.overrideSprite = Resources.Load<Sprite>("Images/"+item.image);
        }

    }
    public Item getItem()
    {
        return item;
    }

    public void purchaseAmount(int q)
    {
        int totalCost;
        if (item != null)
        {
            if (q >= quantity)
            {
                totalCost = quantity * item.getBuyPrice();
                quantity = 0;
            }
            else
            {
                totalCost = q * item.getBuyPrice();
                quantity -= q;
            }
        }
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(item);
        //set as selected or deselected
    }





}
