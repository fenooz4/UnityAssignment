using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Item
{
    //public static string[] Types = { "consumable", "tool", "weapon" };
    //private ItemType type;
    
    public string name;
    public string description;
    public string image;//icon for shop and inventory
                            

    public int buyPrice;
    public int sellPrice;
    
    

    public Item(string itemName="Default",string itemDesc = "Default Description", string itemImage ="default.jpg", int itemBuy=5, int itemSell=5)
    {
        name = itemName;
        description = itemDesc;
        image = itemImage;
        buyPrice = itemBuy;
        sellPrice = itemSell;
    }

    public override string ToString()
    {
        string str = "";
        str += name+"\n";
        str += description + "\n";
        str += image + "\n";
        str += buyPrice + "\n";
        str += sellPrice + "\n";

        return str;
    }

    #region accessors
    
    public string getName()
    {
        return name;
    }
    public string getDescription()
    {
        return description;
    }
    
    public int getBuyPrice()
    {
        return buyPrice;
    }
    public int getSellPrice()
    {
        return sellPrice;
    }
    public void setBuyPrice(int x)
    {
        buyPrice = x;
    }
    public void setSellPrice(int x)
    {
        sellPrice = x;
    }
    #endregion
}
