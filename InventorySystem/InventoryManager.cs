using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField]
    private Item[] _inventoryItems = new Item[0];
    private static List<Item> inventoryItems;
    [SerializeField]
    private DebugAndTest test = new DebugAndTest ();


    void Start () {

        inventoryItems = new List<Item> (_inventoryItems);
    }

    void Update () {

        _inventoryItems = inventoryItems.ToArray ();
        TestPart ();
    }


    private void OnValidate () {
        inventoryItems = new List<Item> (_inventoryItems);
    }
    private void TestPart () {
        if (test.addItem) {
            test.addItem = false;
            AddItem (test.itemObj);
        }
        if (test.addItemMultiple) {
            test.addItemMultiple = false;
            AddItem (test.itemObj, test.number);
        }
        if (test.removeItem) {
            test.removeItem = false;
            RemoveItem (test.itemObj);
        }
        if (test.removeItemMultiple) {
            test.removeItemMultiple = false;
            RemoveItem (test.itemObj, test.number);
        }
    }

    [Serializable]
    private class DebugAndTest {
        public bool addItem = false;
        public bool addItemMultiple = false;
        public bool removeItem = false;
        public bool removeItemMultiple = false;
        public GameObject itemObj = null;
        public int number = 0;

    }

    [Serializable]
    private class Item {

        public GameObject prefab;
        public int number = 1;

        public Item (GameObject obj) {
            prefab = obj;
        }
        public Item (GameObject obj, int num) {
            prefab = obj;
            number = num;
        }

    }
    public static void AddItem (GameObject obj) {

        GameObject itemPrefab = obj.GetComponent<ItemAttribute> ().itemPrefab;
        Item findItem = inventoryItems.Find (x => x.prefab == itemPrefab);


        if (obj.GetComponent<ItemAttribute> ().stackable & findItem != null) {
            findItem.number += 1;
        } else {
            inventoryItems.Add (new Item (itemPrefab));
        }

    }
    public static void AddItem (GameObject obj, int number) {

        GameObject itemPrefab = obj.GetComponent<ItemAttribute> ().itemPrefab;
        Item findItem = inventoryItems.Find (x => x.prefab == itemPrefab);


        if (obj.GetComponent<ItemAttribute> ().stackable) {
            if (findItem != null) {
                findItem.number += number;
            } else {
                inventoryItems.Add (new Item (itemPrefab, number));
            }

        } else {
            for (int i = 0; i < number; i++) {
                inventoryItems.Add (new Item (itemPrefab));
            }

        }

    }


    public static void RemoveItem (GameObject obj) {
        GameObject itemPrefab = obj.GetComponent<ItemAttribute> ().itemPrefab;
        Item findItem = inventoryItems.Find (x => x.prefab == itemPrefab);
        if (findItem != null) {
            if (obj.GetComponent<ItemAttribute> ().stackable) {
                if (findItem.number == 1) inventoryItems.Remove (findItem);
                else findItem.number -= 1;

            } else {
                inventoryItems.Remove (findItem);
            }
        }
    }
    public static void RemoveItem (GameObject obj, int number) {
        GameObject itemPrefab = obj.GetComponent<ItemAttribute> ().itemPrefab;
        Item findItem = inventoryItems.Find (x => x.prefab == itemPrefab);

        if (findItem != null) {
            if (obj.GetComponent<ItemAttribute> ().stackable) {
                if (findItem.number > number) inventoryItems.Remove (findItem);
                else findItem.number -= number;

            } else {
                for (int i = 0; i < number; i++) {
                    inventoryItems.Remove (inventoryItems.Find (x => x.prefab == itemPrefab));
                }


            }
        }
    }

}
