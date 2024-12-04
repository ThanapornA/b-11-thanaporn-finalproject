using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : Character
{
    private float satietyPoints = 0f;
    public float SatietyPoints => satietyPoints; //readOnly property

    //speed variables
    [ SerializeField ] private float speed; //no this will be veryyyyy slow
    public float Speed { get{ return speed; } set{ speed = value; } } //ENCAPSULATION

    private float originalSpeed;
    private float speedBoostDuration = 0.0f;
    private float speedBoostTimer = 0.0f;
    private bool isSpeedBoostActive = false;

    [ SerializeField ] private Rigidbody2D rb;
    [ SerializeField ] private Animator anim;
    public Transform Trans;
    private float dragSpeed = 10.0f;

    //jump variables
    [ SerializeField ] private int jumpPower;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    //ui
    [ SerializeField ] SatietyBar SatietyBar;
    [ SerializeField ] TextMeshProUGUI currentSpeed , currentJumpPower;

    void Start()
    {
        Debug.Log($"Hello {Name}! Hey look! let's collect foods until you are full!"); //start text
        originalSpeed = speed;
        UpdateCurrentSpeed();
        UpdateCurrentJumpPower();

        Init( "Penguin" , "player" );
    }

    void Update() //check what player press
    {
        SatietyBar.UpdateBar( SatietyPoints );
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
        isGrounded = Physics2D.OverlapCircle(feetPos.position , checkRadius , whatIsGround); //check if player hits the ground
        if ( isGrounded == true && Input.GetKey(KeyCode.UpArrow)  )
        {
            rb.velocity = new Vector2( rb.velocity.x , jumpPower );
        }

        //animator parameter
        anim.SetBool("Run" , horizontalInput != 0);

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
                UpdateCurrentSpeed();
                isSpeedBoostActive = false;
                Debug.Log("... speed boost ended ...");
            }
        }
    }

    //POLYMORPHISM(overload)
    public void ClassifyingFood( int foodPoints , float speedUp , float duration ) //SPEED special food : blueberry milk
    {
        satietyPoints += foodPoints;
        Debug.Log($"you have now {SatietyPoints}% full!!"); //text update score

        if( !isSpeedBoostActive )
        {
            Debug.Log($"your speed is +{speedUp} for {duration} seconds.");
            speed += speedUp;
            isSpeedBoostActive = true;
            speedBoostDuration = duration;
            speedBoostTimer = 0.0f;
            UpdateCurrentSpeed();
        }
    }

    public void ClassifyingFood( int foodPoints , int increaseJump ) //JUMP special food : pancake
    {
        satietyPoints += foodPoints;
        Debug.Log($"you are now {SatietyPoints}% hungry!!");

        jumpPower += increaseJump;

        if ( jumpPower <= 15 )
        {
            UpdateCurrentJumpPower();
            Debug.Log($"your jump power is +{increaseJump}.");
        }
        else
        {
            jumpPower = 15;
            UpdateCurrentJumpPower();
            Debug.Log($"your jump power is max at 15.");
        }
    }
    
    public void ClassifyingFood( int foodPoints ) //normal food
    {
        satietyPoints += foodPoints;
        Debug.Log($"you are now {SatietyPoints}% hungry!!");
    }

    public void ClassifyingFood( float foodPoints , string foodType ) //bad food
    {
        satietyPoints -= foodPoints;
        Debug.Log($"Oh no! you are now {SatietyPoints}% hungry...");
    }

    //Texts
    private void UpdateCurrentSpeed()
    {
        currentSpeed.text = $"Speed: {Speed}";
    }

    private void UpdateCurrentJumpPower()
    {
        currentJumpPower.text = $"Jump Power : {jumpPower}";

        if ( jumpPower == 15 )
        {
            currentJumpPower.text = $"your jump power is max at 15.";
        }
    }
}