using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takingdamage : MonoBehaviour
{

    public health Health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Health.Damaged(1);
        }
    }
}
