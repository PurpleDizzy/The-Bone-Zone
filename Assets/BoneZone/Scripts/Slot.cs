using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public int id;
    public Inventory inv;


    void Start()
    {
        inv = GameObject.Find("GameMaster").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        Debug.Log(inv);
        if (inv.items[id].ID == -1)
        {
            inv.items[droppedItem.slot] = new Item();
            inv.items[id] = droppedItem.item;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;
            droppedItem.slot = id;
        }
        else
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(inv.slots[droppedItem.slot].transform);
            item.transform.position = inv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }
    }
}

