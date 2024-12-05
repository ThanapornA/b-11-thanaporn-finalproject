using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour //this script used to define each character and their type whether it's an enemy or player
{ 
    private string name = "animal name";
    public string Name
    {
        get{ return name; } 
        set{ name = value; }
    }

    private string characterType = "animal";
    public string CharacterType
    {
        get{ return characterType; } 
        set{ characterType = value; }
    }

    public void Init( string newName , string newCharacterType )
    {
        name = newName;
        characterType = newCharacterType;

        Debug.Log($"<color=white>{name} is a {characterType}</color>");
    }
}