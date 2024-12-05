using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnedToast : Foods , ICollectable //INHERITANCE
{
    public bool hasPrinted = false;

    public void Start()
    {
        Init("Burned Toast" , 5 );
        Print();
    }

    public override void Print()
    {
        if (!hasPrinted)
        {
            Debug.Log($"<color=red>bad food</color> : {_name} is spawned! It's lose you 5%");
            hasPrinted = true;
        }
    }

    public void Collect(PlayerController player) //when player collect 
    {
        if ( hasTriggered == true ) 
        {
            Debug.Log($"{_name} reduce your appetite for {FoodPoints}%");
            player.ClassifyingFood( FoodPoints , "Burned Toast" );
        }
    }
}