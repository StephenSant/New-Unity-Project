using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public int money;

    public Vector2 scr = Vector2.zero;
    public Vector2 scrollPos = Vector2.zero;
    #endregion
    void Start()
    {
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(404));

        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }
    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            return (false);
        }
        else
        {
            showInv = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            return (true);
        }
    }
    private void OnGUI()
    {
        if (!PauseMenu.paused)
        {
            if (showInv)
            {
                if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
                {
                    scr.x = Screen.width / 16;
                    scr.y = Screen.height / 9;
                }
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
                #region Non Scroll Inventory
                if (inv.Count <= 35)
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                }
                #endregion
                #region Scroll Inventory

                #endregion
            }
        }
    }
}
