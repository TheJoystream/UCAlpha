using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Inventory : MonoBehaviour
    
{
    public static Inventory instance;
    //This list stores all items in player's inventory

    public List<Item> items = new List<Item>();
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    
    }

    public void AddItem(Item itemToAdd)
    {
        //Item does exist in inventory, increase the count
        bool itemExists = false;

        foreach (Item item in items)
        {
            if (item.name == itemToAdd.name)
            {
                item.count += itemToAdd.count;
                itemExists = true;
                break;
            }
        }
        //Item does not exist, add to inventory 
        if (!itemExists)
        {
            items.Add(itemToAdd);
        }
        Debug.Log(itemToAdd.count + "" + itemToAdd.name + "added to inventory.");
    }
}
