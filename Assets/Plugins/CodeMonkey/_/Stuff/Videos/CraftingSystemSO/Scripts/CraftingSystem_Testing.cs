/* 
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
using UnityEngine.Serialization;

namespace CodeMonkey.CraftingSystem {

    public class CraftingSystem_Testing : MonoBehaviour {

        [FormerlySerializedAs("player")] [SerializeField] private MonkeyPlayer monkeyPlayer = null;
        [SerializeField] private UI_Inventory uiInventory = null;

        [SerializeField] private UI_CharacterEquipment uiCharacterEquipment = null;
        [SerializeField] private CharacterEquipment characterEquipment = null;

        [SerializeField] private UI_CraftingSystem uiCraftingSystem = null;

        [SerializeField] private StartingItem[] startingItemArray = null;
        [SerializeField] private List<RecipeScriptableObject> recipeScriptableObjectList = null;

        [System.Serializable]
        public struct StartingItem {
            public InventoryItemScriptableObject itemScriptableObject;
            public int amount;
        }

        private void Start() {
            uiInventory.SetPlayer(monkeyPlayer);
            uiInventory.SetInventory(monkeyPlayer.GetInventory());

            Inventory playerInventory = monkeyPlayer.GetInventory();

            foreach (StartingItem startingItem in startingItemArray) {
                playerInventory.AddItem(
                    new Item {
                        itemScriptableObject = startingItem.itemScriptableObject,
                        amount = startingItem.amount
                    }
                );
            }

            uiCharacterEquipment.SetCharacterEquipment(characterEquipment);

            CraftingSystem craftingSystem = new CraftingSystem(recipeScriptableObjectList);
            uiCraftingSystem.SetCraftingSystem(craftingSystem);
        }

    }
}