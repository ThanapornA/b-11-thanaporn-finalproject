using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : Foods , ICollectable //INHERITANCE
{
    [ SerializeField ] private int point;
    private bool hasTriggered;

    public void Start()
    {
        Init("Toasty" , 3f);
        Print();
    }

    public override void Print()
    {
        Debug.Log($"{name} is a food jaa");
    }

    public void Collect() //edit**********
    {
        /* if ( collide.CompareTag("Player") && hasTriggered )
        {
            hasTriggered = true;
            Destroy( GameObject );
        } */
    }
}
