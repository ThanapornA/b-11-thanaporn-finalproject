using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Seal : Character
{
    [ SerializeField ] Collider2D collider;

    [ SerializeField ] private Vector2 velocity;
    [ SerializeField ] private Transform[] movePoints;
    [ SerializeField ] Rigidbody2D rb;

    [ SerializeField ] TextMeshProUGUI triggeredText;
    public GameOverScreen GameOverScreen;

    void Start()
    {
        Init( "Seal" , "enemy" );
    }

    void FixedUpdate()
    {
        Behavior();
    }
    
    void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    //game end conditions
    void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.tag == "Player" )
        {
            Debug.Log("you triggered the seal and got eaten!");
            triggeredText.text = "you triggered the seal and got eaten!";
            //set gameover screen active
            GameOverScreen.TriggeredEneScreen();
            GameOverScreen.gameObject.SetActive(true);
        }
    }

    public void Behavior()
    {
        rb.MovePosition( rb.position + velocity * Time.fixedDeltaTime );

        if ( rb.position.x <= movePoints[0].position.x && velocity.x < 0 )
        {
            Flip();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        velocity *= -1;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
