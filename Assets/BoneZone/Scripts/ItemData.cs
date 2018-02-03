using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Item item;
    public int amount;
    public int slot;
    private Inventory inv;

    void Start()
    {
        inv = GameObject.Find("GameMaster").GetComponent<Inventory>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.SetParent(inv.slots[slot].transform);
        this.transform.position = inv.slots[slot].transform.position;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
