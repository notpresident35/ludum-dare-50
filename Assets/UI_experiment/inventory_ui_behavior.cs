using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_ui_behavior : MonoBehaviour
{
    private inventory_ui inventory;
    private Transform Bucket_background;
    private Transform Bucket_slot;

    private void Awake()
    {
        Bucket_background = transform.Find("Bucket_background");
        Bucket_slot = transform.Find("Bucket_slot");

    }

    public void Setinventory(inventory_ui inventory)
    {
        this.inventory = inventory;
    }
}
