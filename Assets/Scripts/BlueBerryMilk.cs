using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBerryMilk : Foods , ICollectable
{
    public void Start()
    {
        Init("Blue Berry Milk" , 100f , 10 );
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
            player.ClassifyingFood( FoodPoints , 15.0f , 5.0f );
        }
    }
}
