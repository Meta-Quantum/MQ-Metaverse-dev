﻿/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.InventorySystem;
using CodeMonkey.CraftingSystem;
using UnityEngine.Serialization;

public class Testing_CraftingSystem : MonoBehaviour {

    [FormerlySerializedAs("player")] [SerializeField] private MonkeyPlayer monkeyPlayer = null;
    [SerializeField] private UI_Inventory uiInventory = null;

    [SerializeField] private UI_CharacterEquipment uiCharacterEquipment = null;
    [SerializeField] private CharacterEquipment characterEquipment = null;

    [SerializeField] private UI_CraftingSystem uiCraftingSystem = null;

    private void Start() {
        uiInventory.SetPlayer(monkeyPlayer);
        uiInventory.SetInventory(monkeyPlayer.GetInventory());

        uiCharacterEquipment.SetCharacterEquipment(characterEquipment);

        CraftingSystem craftingSystem = new CraftingSystem(null);

        //Item item = new Item { itemType = Item.ItemType.Diamond, amount = 1 };
        //craftingSystem.SetItem(item, 0, 0);
        //Debug.Log(craftingSystem.GetItem(0, 0));

        uiCraftingSystem.SetCraftingSystem(craftingSystem);
    }

}
