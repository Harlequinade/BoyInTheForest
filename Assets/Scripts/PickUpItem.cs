using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable {


    public Item item;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("player");
    }


    public override void Interaction()
    {
        base.Interaction();
        if (Inventory.instance.Add(item) == true)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(player.transform.position, transform.position) <= 20f)
        {
            Interaction();
        }
    }
}
