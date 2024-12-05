using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Foods : MonoBehaviour //ABSTRACT Class
{
    private int foodPoints;
    public int FoodPoints { get{ return foodPoints; } set{ foodPoints = value; }}

    public float foodSpeed;

    protected string _name = "food";

    public bool hasTriggered = false;

    [ SerializeField ] private Collider2D collider;
    public Transform Trans;
    public Spawner Spawner;

    public void Init( string newName , int pointWillGet )
    {
        _name = newName;
        foodPoints = pointWillGet;
    }

    public abstract void Print();

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
