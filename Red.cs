using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Red : enemybehavior
{
    protected override void OnTriggerEnter2D()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * redSpeed; 
            Debug.Log("player near at" + Pos.pos + ".");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
