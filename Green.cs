using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : enemybehavior
{

    protected override void OnTriggerEnter2D()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * redSpeed;
            Debug.Log("player near");
        }
    }
            void Update()
    {
        
    }
}
