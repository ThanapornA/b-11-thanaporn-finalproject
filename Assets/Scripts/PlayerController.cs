using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [ SerializeField ] private float speed; //no this will be veryyyyy slow
    public float Speed { get{ return speed; } set{ speed = value; } } //ENCAPSULATION

    [ SerializeField ] private Rigidbody2D rb;
    public Transform Trans;
    private float dragSpeed = 5f;

    void Update() //check what player press
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //put value in float first so we can use in Flip()
        
        rb.AddForce(new Vector2(-dragSpeed, 0), ForceMode2D.Force); //this one is for dragging player to left side
        //note : rb.AddForce(Trans.position * dragSpeed); << try to write on my own but not works;-; it drags (x,y)

        rb.velocity = new Vector2( horizontalInput * Speed , rb.velocity.y ); //player press left = -1 and if press right will = 1 , y-axis = no changes
        
        //Flip
        if ( horizontalInput > 0.01f)
        {
            Trans.localScale = Vector3.one; //note : Vector3.one == Vector3(1,1,1) < same but just shorter
        }
        else if ( horizontalInput > -0.01f)
        {
            Trans.localScale = new Vector3( -1 , 1 , 1 );
        }

        //Jump
        if ( Input.GetKey(KeyCode.UpArrow) ) //Jump
        {
            rb.velocity = new Vector2( rb.velocity.x , Speed );
        }
    }

}
