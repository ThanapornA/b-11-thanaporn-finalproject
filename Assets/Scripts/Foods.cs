using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Foods : MonoBehaviour //ABSTRACT Class
{
    [ SerializeField ] private int foodPoints;
    public int FoodPoints { get{ return foodPoints; } set{ foodPoints = value; }}

    [ SerializeField ] public float foodSpeed;

    protected string _name = "food";

    public Transform Trans;

    public void Init( string newName , float newFoodspeed)
    {
        name = newName;
        foodSpeed = newFoodspeed;
    }

    public abstract void Print(); //after foods are collected >> there will be announcement in console

    public void Update()
    {
        //each food will have different falling speed up to their points
        Trans.position += Vector3.down * foodSpeed * Time.deltaTime;
    }
}
