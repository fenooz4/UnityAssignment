using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField] [Range(1 , 7)] int rows;
    [SerializeField] [Range(1 , 14)] int columns;
    RectTransform background;
    int height;
    int width;
    GameObject slot;
    int horizontalOffset;
    int verticalOffset;
    int spacing = 15;
    InventorySlot[,] storage;


    int gold = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
        background = GetComponentInChildren<RectTransform>();
        if (background != null)
        {
            width = 30 * columns + spacing * (columns + 1);
            background.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            height = 30 * rows + spacing * (rows + 1);
            background.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }
        horizontalOffset =15+ spacing - width / 2;
        verticalOffset =15+ spacing - height / 2;
        storage = new InventorySlot[rows, columns];
        
        for (int r = 0;r<rows ;r++)
        {
            for(int c = 0;c<columns; c++)
            {
                slot = (GameObject)Instantiate(Resources.Load("Prefabs/Slot"), transform);
                RectTransform x = slot.GetComponent<RectTransform>();
                x.anchoredPosition = new Vector2(horizontalOffset,verticalOffset);
                horizontalOffset += 30+spacing;
                storage[r, c] = slot.GetComponent<InventorySlot>();
            }
            horizontalOffset =15+ spacing - width / 2;
            verticalOffset += 30+spacing;
        }



        Item money = new("Gold", "Use this to make purchases", "gold", 1, 1);
        storage[0, 0].addItem(money,30);
        gold = 30;
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
                    return true;
                }
            }
        }

                return false;
    }

    public int GetGold()
    {
        return gold;
    }

    public void reduceGold(int q)
    {
        if (q <= gold)
        {
            gold -= q;
        }
        else
        {
            gold = 0;
        }
    }

}
