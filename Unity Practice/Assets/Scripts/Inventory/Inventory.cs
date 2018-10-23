using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public static Item selectedItem;
    public int money;
    public GUIStyle style;

    public CharacterHandler handler;

    public Vector2 scr = Vector2.zero;
    public Vector2 scrollPos = Vector2.zero;

    #endregion
    void Start()
    {
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(404));

        handler = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!PauseMenu.paused && !LevelUp.ready)
            {
                ToggleInv();
            }
        }
    }
    public static bool ToggleInv()
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
            Cursor.lockState = CursorLockMode.None;
            return (true);
        }
    }
    private void OnGUI()
    {
        if (!PauseMenu.paused)
        {
            if (showInv)
            {
                LevelUp.ask = false;
                if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
                {
                    scr.x = Screen.width / 16;
                    scr.y = Screen.height / 9;
                }
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory", style);
                for (int i = 0; i < 10; i++)
                {
                    GUI.Box(new Rect(7.45f * scr.x, 2.1f * scr.y + i * (0.65f * scr.y), 1.1f * scr.x, .65f * scr.y), "");
                }
                for (int i = 0; i < inv.Count; i++)
                {

                    if (GUI.Button(new Rect(7.5f * scr.x, 2.15f * scr.y + i * (0.65f * scr.y), 1f * scr.x, .55f * scr.y), inv[i].Name))
                    {

                        selectedItem = inv[i];
                        handler.curHealth += selectedItem.Heal;
                        inv.Remove(selectedItem);

                    }
                }
                #region Non Scroll Inventory


                #endregion
                #region Scroll Inventory

                #endregion
            }
        }
    }
}
