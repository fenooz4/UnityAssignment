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
    // Start is called before the first frame update
    void Start()
    {
        
        background = GetComponent<RectTransform>();
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
                slot = (GameObject)Instantiate(Resources.Load("Prefabs/Slot"), background.transform);
                RectTransform x = slot.GetComponent<RectTransform>();
                x.anchoredPosition = new Vector2(horizontalOffset,verticalOffset);
                horizontalOffset += 30+spacing;
                storage[r, c] = slot.GetComponent<InventorySlot>();
            }
            horizontalOffset =15+ spacing - width / 2;
            verticalOffset += 30+spacing;
        }
    }
    
}
