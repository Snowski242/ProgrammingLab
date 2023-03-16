using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getanduse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       get myObj = new get();
        myObj.Name = "Tre";
        Debug.Log(myObj.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
