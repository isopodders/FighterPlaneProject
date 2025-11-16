using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Getting the coinCounterVariable from Game manager
    
   
    void Start()
    {

    }

    void Update()
    {


        Destroy(this.gameObject, 8f);
    }

}

