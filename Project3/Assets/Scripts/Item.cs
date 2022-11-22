using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    //public static string[] Types = { "consumable", "tool", "weapon" };
    private ItemType type;
    private string name;
    private string description;
    //private string prefabName; //utilize as seen below
    
    private int buyPrice;
    private int sellPrice;
    #region accessors
    public ItemType getType()
    {
        return type;
    }
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
