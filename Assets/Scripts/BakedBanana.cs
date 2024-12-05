using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakedBanana : Foods , ICollectable //INHERITANCE
{
    public bool hasPrinted = false;

    public void Start()
    {
        Init("Baked Banana" , 3 );
        Print();
    }

    public override void Print()
    {
        if (!hasPrinted)
        {
            Debug.Log($"<color=red>bad food</color> : {_name} is spawned! It's lose you 3%");
            hasPrinted = true;
        }
    }

    public void Collect(PlayerController player) //when player collect 
    {
        if ( hasTriggered == true ) 
        {
            Debug.Log($"{_name} reduce your appetite for {FoodPoints}%");
            player.ClassifyingFood( FoodPoints , "BakedBanana" );
        }
    }
}