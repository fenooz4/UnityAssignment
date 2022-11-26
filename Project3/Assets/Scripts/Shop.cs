using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    string itemsPath;
    [SerializeField] [Range(1, 7)] int rows;
    [SerializeField] [Range(1, 14)] int columns;
    RectTransform background;
    int height;
    int width;
    GameObject slot;
    int horizontalOffset;
    int verticalOffset;
    int spacing = 15;




    [SerializeField] Inventory targetInventory;
    ShopSlot[,] storage;
    SaveItems.itemList items;



    int totalCostOfPurchase=0;
    void Start()
    {
        itemsPath = Application.persistentDataPath + "/item.json";
        background = GetComponentInChildren<RectTransform>();
        if (background != null)
        {
            width = 30 * columns + spacing * (columns + 1);
            background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            height = 30 * rows + spacing * (rows + 1);
            background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }
        horizontalOffset = 15 + spacing - width / 2;
        verticalOffset = 15 + spacing - height / 2;
        storage = new ShopSlot[rows, columns];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                slot = (GameObject)Instantiate(Resources.Load("Prefabs/ShopSlot"), transform);
                RectTransform x = slot.GetComponent<RectTransform>();
                x.anchoredPosition = new Vector2(horizontalOffset, verticalOffset);
                horizontalOffset += 30 + spacing;
                storage[r, c] = slot.GetComponent<ShopSlot>();
            }
            horizontalOffset = 15 + spacing - width / 2;
            verticalOffset += 30 + spacing;
        }
        string data = System.IO.File.ReadAllText(itemsPath);
        items=JsonUtility.FromJson<SaveItems.itemList>(data);

        int tempx = 0;
        int tempy = 0;
        
        for (int i =0;i<items.list.Count; i++,tempy++)
        {
            if (tempy < columns)
            {
                storage[tempx, tempy].addItem(items.list[i]);
            }
        }

    }

    public Inventory GetInventory()
    {
        return targetInventory;
    }
    public bool AddItem(Item i, int q)
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (storage[r, c] == null)
                {
                    storage[r, c].addItem(i, q);
                    return true;//return true if item successfully added, otherwise inventory might be full
                }
            }
        }

        return false;
    }
    public void addToTotalCost(int q)
    {
        totalCostOfPurchase += q;
    }

    public void Buy()
    {
        if (targetInventory.GetGold() > totalCostOfPurchase)
        {
            //reduce gold
            //remove items from shop
            //add items to target inventory
        }
    }
}


