using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   
    void Start()
    {

    }

    void Update()
    {

        //destroys after some time

        Destroy(this.gameObject, 8f);
    }

}

