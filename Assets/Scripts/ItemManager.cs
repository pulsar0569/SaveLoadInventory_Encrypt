using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;

[System.Serializable]
public class Item
{
    public enum Rarity {
        Common,
        Uncommon,
        Rare,
        Legendary
    }
    [SerializeField] public Rarity rarity;
    [SerializeField] public string displayName;
    [SerializeField] public string description;
    [SerializeField] public int quantity;
    //[SerializeField] public Sprite icon;

}

public class ItemManager : MonoBehaviour
{
    public TMP_Text displayText;
    public static List<Item> items;

    public void Start()
    {
        items = new List<Item>();
        InventoryAddItem(Item.Rarity.Uncommon, "Copper Sword", "Just a basic copper sword", 1);
        InventoryAddItem(Item.Rarity.Legendary, "Flame Sword", "The Flame of Swords", 1);

        InventoryAddItem(Item.Rarity.Common, "Gold Coin", "Currency used by all", UnityEngine.Random.Range(34, 159));
    }

    public void Update()
    {
        displayText.text = "";
        int counter = 0;
        foreach (Item item in items)
        {
            counter++;
            displayText.text += counter + ") " + item.rarity + "     " + item.displayName + "     " + item.description + "   " + item.quantity + "\n";
        }
    }

    public void InventoryAddItem(Item.Rarity rarity, string itemName, string itemDescription, int quantity)
    {
        Item item = new Item();

        item.rarity = rarity;
        item.displayName = itemName;
        item.description = itemDescription;
        item.quantity = quantity;

        items.Add(item);

        return;
    }

    public void RemoveFirstItem()
    {
        if (items.Count > 0)
        {
            items.RemoveAt(0);
        }

        return;
    }

    public List<Item> ReturnInventory()
    {
        return items;
    }
}