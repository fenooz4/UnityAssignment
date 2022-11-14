using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public static string[] Types = { "consumable", "tool", "weapon" };
    private string type;
    private string name;
    private string description;
    private string prefabName; //utilize as seen below
    
    private int buyPrice;
    private int sellPrice;
    #region accessors
    public string getType()
    {
        return type;
    }
    public string getName()
    {
        return name;
    }
    public string getDescription()
    {
        return type;
    }
    public string getPrefabName()
    {
        return prefabName;
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
    public void equip(Vector3 position, Quaternion rotation)//load the prefab into the scene
    {
       GameObject obj = Resources.Load("Prefabs/"+prefabName) as GameObject;
       GameObject.Instantiate(obj,position, rotation);
    }
    public void unequip(GameObject obj)
    {
        Resources.UnloadAsset(obj);
    }
}
