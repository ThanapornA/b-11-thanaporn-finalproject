using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : Foods , ICollectable //INHERITANCE
{
    public void Start()
    {
        Init("Crispy Toast" , 100f , 5 );
        Print();
    }

    public override void Print()
    {
        //Debug.Log($"{FoodPoints} is spawned!"); //info name points + boosts
    }

    public void Collect(PlayerController player) //when player collect 
    {
        if ( hasTriggered == true ) 
        {
            player.ClassifyingFood( FoodPoints );
        }
    }
}
