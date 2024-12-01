using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [ SerializeField ] private string name = "player";
    public string Name => name;//readOnly property

    private float hungyPoints = 0f;
    public float HungyPoints => hungyPoints;

    //speed variables
    [ SerializeField ] private float speed; //no this will be veryyyyy slow
    public float Speed { get{ return speed; } set{ speed = value; } } //ENCAPSULATION

    private float originalSpeed;
    private float speedBoostDuration = 0.0f;
    private float speedBoostTimer = 0.0f;
    private bool isSpeedBoostActive = false;

    [ SerializeField ] private Rigidbody2D rb;
    public Transform Trans;
    private float dragSpeed = 10.0f;

    //jump variables
    [ SerializeField ] private int jumpPower;
    public bool isJumping;

    void Start()
    {
        Debug.Log($"Hello {Name}! Hey look! let's collect foods until you are full!"); //start text
        originalSpeed = speed;
    }

    void Update() //check what player press
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //put value in float first so we can use in Flip()
        
        rb.AddForce(new Vector2(-dragSpeed, 0), ForceMode2D.Force); //this one is for dragging player to left side
        //note : rb.AddForce(Trans.position * dragSpeed); << try to write on my own but not works;-; it drags (x,y)

        rb.velocity = new Vector2( horizontalInput * speed , rb.velocity.y ); //player press left = -1 and if press right will = 1 , y-axis = no changes
        
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
        if ( Input.GetKey(KeyCode.UpArrow)  ) //Jump && isJumping == false
        {
            //rb.AddForce(new Vector2(rb.velocity.x , jumpPower));
            rb.velocity = new Vector2( rb.velocity.x , jumpPower );
        }

        UpdateSpeedBoostTimer();
    }

    //speed boost
    private void UpdateSpeedBoostTimer()
    {
        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;

            if ( speedBoostTimer >= speedBoostDuration )
            {
                speed = originalSpeed;
                isSpeedBoostActive = false;
                Debug.Log("... speed boost ended ...");
            }
        }
    }

    //POLYMORPHISM(overload)
    public void ClassifyingFood( int foodPoints , float speedUp , float duration ) //special food : blueberry milk
    {
        hungyPoints += foodPoints;
        Debug.Log($"you have now {HungyPoints}% hungry!!"); //text update score

        if( !isSpeedBoostActive )
        {
            Debug.Log($"your speed is +{speedUp} for {duration} seconds.");
            speed += speedUp;
            isSpeedBoostActive = true;
            speedBoostDuration = duration;
            speedBoostTimer = 0.0f;
        }
    }

    public void ClassifyingFood( int foodPoints , int increaseJump ) //special food : pancake
    {
        hungyPoints += foodPoints;
        Debug.Log($"you are now {HungyPoints}% hungry!!");

        if ( jumpPower <= 15 )
        {
            jumpPower += increaseJump;
            Debug.Log($"your jump power is +{increaseJump}.");
        }
        else
        {
            Debug.Log($"your jump power is max at 15.");
        }
    }
    
    public void ClassifyingFood( int foodPoints ) //normal food
    {
        hungyPoints += foodPoints;
        Debug.Log($"you are now {HungyPoints}% hungry!!");
    }

    public void ClassifyingFood( float foodPoints , string foodType ) //bad food
    {
        hungyPoints -= foodPoints;
        Debug.Log($"Oh no! you are now {HungyPoints}% hungry...");
    }
}










/*
    //jump only when collide with floor
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.CompareTag("floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if ( other.gameObject.CompareTag("floor"))
        {
            isJumping = true;
        }
    }*/