using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakedBanana : Foods , ICollectable //INHERITANCE
{
    public void Start()
    {
        Init("Baked Banana" , 100f , 3 );
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
            Debug.Log($"{_name} reduce your appetite for {FoodPoints}%");
            player.ClassifyingFood( FoodPoints , "BakedBanana" );
        }
    }
}