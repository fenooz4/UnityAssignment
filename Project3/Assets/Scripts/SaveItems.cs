using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;



public class SaveItems : MonoBehaviour
{
    [Header("Item")] 
    [Tooltip("A unique identifier for the item, for example: Sword")][SerializeField] string _name;
    [Tooltip("Describe what your item does")][TextArea()] [SerializeField] string _description;
    [Tooltip("place the file name of the image you will use here, for example: sword")][SerializeField] string imageName;
    [Tooltip("Cost of the item in the store")][SerializeField] int _buyPrice;
    [Tooltip("Money recieved when sold")][SerializeField] int _sellPrice;

    [Button(nameof(SaveItem))]
    public bool buttonField1;
    [Button(nameof(ClearItems))]
    public bool buttonField2;
    [Serializable]
    public struct itemList
    {
        public List<Item> list;
    }
    itemList items =  new itemList();
    
    public void SaveItem()
    {
        Item newItem = new(_name,_description,imageName,_buyPrice,_sellPrice);
        items.list.Add(newItem);
        string path = Application.persistentDataPath + "/item.json";

        File.WriteAllText(path, JsonUtility.ToJson(items));
        
        
    }
    public void ClearItems()
    {
        items.list.Clear();
    }
}
