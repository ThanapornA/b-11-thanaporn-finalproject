using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Foods : MonoBehaviour //ABSTRACT Class
{
    [ SerializeField ] private int foodPoints;
    public int FoodPoints { get{ return foodPoints; } set{ foodPoints = value; }}

    [ SerializeField ] public float foodSpeed;

    protected string _name = "food";

    public bool hasTriggered = false;

    [ SerializeField ] private Collider2D collider; //private Rigidbody2D rb;
    public Transform Trans;

    public void Init( string newName , float newFoodspeed , int pointWillGet )
    {
        _name = newName;
        //foodSpeed = newFoodspeed;
        foodPoints = pointWillGet;
    }

    public abstract void Print();

    public void Update()
    {

    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if ( other.CompareTag("Player") )
        {
            hasTriggered = true;
            Debug.Log($"-- you ate {_name} --"); //after foods are collected >> there will be announce in console
            PlayerController player = other.GetComponent<PlayerController>();
            ICollectable collect = GetComponent<ICollectable>();
            
            if ( collect != null && player != null )
            {
                collect.Collect(player);
                this.gameObject.SetActive(false);
            }
        }
    }
}
