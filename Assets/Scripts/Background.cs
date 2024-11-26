using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material; //Unity's mesh renderer?
    }

    void Update() //looping bg
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        material.SetTextureOffset("_MainTex" , new Vector2(offset , 0));
    }
}
