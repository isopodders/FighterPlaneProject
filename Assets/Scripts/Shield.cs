using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    
   
    void Start()
    {

    }

    void Update()
    {
        //destroys after some time

        Destroy(this.gameObject, 3f);
    }

}

