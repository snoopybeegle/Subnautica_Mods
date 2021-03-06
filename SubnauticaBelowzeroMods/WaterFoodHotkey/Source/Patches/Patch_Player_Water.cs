﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterFoodHotkeyBZ.Patches
{
    public static class PlayerWater_Patch
    {
        public static void Patch_Player_Water()
        {
            //int[] TechTypes = new int[] { 4500, 808, 4501, 4516 };
            /*bool consoleOpened = (bool)typeof(DevConsole).GetField("state", BindingFlags.NonPublic |
            BindingFlags.Instance).GetValue(typeof(DevConsole).GetField("instance", BindingFlags.NonPublic |
            BindingFlags.Static).GetValue(null));*/

            Inventory pInventory = Inventory.main;

            IList<InventoryItem> filteredWater = pInventory.container.GetItems(TechType.FilteredWater);
            IList<InventoryItem> stillSuitWater = pInventory.container.GetItems(TechType.StillsuitWater);
            IList<InventoryItem> disinfectedWater = pInventory.container.GetItems(TechType.DisinfectedWater);
            IList<InventoryItem> bigfilteredWater = pInventory.container.GetItems(TechType.BigFilteredWater);
            IList<InventoryItem> cOffee = pInventory.container.GetItems(TechType.Coffee);

            if (Input.GetKeyDown(Config.WaterHotKey) && Config.ToggleWaterHotKey == false && !MainPatch.EditNameCheck)
            {
                if (Config.TextValue == 0)
                {
                    ErrorMessage.AddWarning("You have Disabled The Water Hotkey");
                }
                else if (Config.TextValue == 1)
                {
                    Subtitles.Add("You Have Disabled The Water Hotkey");
                }
            }
            else if (Input.GetKeyDown(Config.WaterHotKey) && Config.ToggleWaterHotKey == true && !MainPatch.EditNameCheck)
            {
                if (Player.main.GetComponent<Survival>().water <= Config.WaterPercentage)
                {
                    
                    if (filteredWater != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, filteredWater.First());
                    }
                    else if (stillSuitWater != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, stillSuitWater.First());
                    }
                    else if (disinfectedWater != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, disinfectedWater.First());
                    }
                    else if (bigfilteredWater != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, bigfilteredWater.First());
                    }
                    else if (cOffee != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cOffee.First());
                    }
                    else
                    {
                        if (Config.TextValue == 0)
                        {
                            ErrorMessage.AddWarning("You Do Not Have Any Drinkable Items In your Inventory");
                        }
                        else if (Config.TextValue == 1)
                        {
                            Subtitles.Add("You Do Not Have Any Drinkable Items In your Inventory");
                        }
                    }
                }
                else
                {
                    if (Config.TextValue == 0)
                    {
                        ErrorMessage.AddWarning("You Do Not Need A Drink, You're Not Thirsty");
                    }
                    else if (Config.TextValue == 1)
                    {
                        Subtitles.Add("You Do Not Need A Drink, You're Not Thirsty");
                    }
                }
            }
        }
    }
}
