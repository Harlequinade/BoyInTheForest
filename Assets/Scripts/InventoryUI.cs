using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;
    InventorySlot[] slots;

	void Start () {
        Inventory.instance.OnItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = !Cursor.visible;
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }


    void UpdateUI () {
		for(int i=0; i<slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
            {
                slots[i].AddItem(Inventory.instance.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
	}
}
