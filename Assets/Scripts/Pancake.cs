using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pancake : Foods , ICollectable
{
    public bool hasPrinted = false;

    public void Start()
    {
        Init("Pancake" , 10 );
        Print();
    }

    public override void Print()
    {
        if (!hasPrinted)
        {
            Debug.Log($"<color=green>special food</color> : {_name} is spawned! It's feed you 10%");
            hasPrinted = true;
        }
    }

    public void Collect(PlayerController player) //when player collect 
    {
        if ( hasTriggered == true ) 
        {
            player.ClassifyingFood( FoodPoints , 3 ); //20.0f , 5.0f
        }
    }
}
