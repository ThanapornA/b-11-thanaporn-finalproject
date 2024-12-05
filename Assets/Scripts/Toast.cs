using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : Foods , ICollectable //INHERITANCE
{
    public bool hasPrinted = false;

    public void Start()
    {
        Init("Crispy Toast" , 5 );
        Print();
    }

    public override void Print()
    {
        if (!hasPrinted)
        {
            Debug.Log($"<color=green>normal food</color> : {_name} is spawned! It's feed you 5%"); //info name&points
            hasPrinted = true;
        }
    }

    public void Collect(PlayerController player) //when player collect 
    {
        if ( hasTriggered == true ) 
        {
            player.ClassifyingFood( FoodPoints );
        }
    }
}
