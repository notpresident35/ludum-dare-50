using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    [SerializeField] Rigidbody2D player;
    [SerializeField] private inventory_ui_behavior uiInventory;//inventory code
    private float horizontalAxis;
    private inventory_ui inventory;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        inventory = new inventory_ui();
        uiInventory.Setinventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(horizontalAxis * 5f, player.velocity.y);
    }
}
