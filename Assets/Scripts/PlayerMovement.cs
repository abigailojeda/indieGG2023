using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float right, left;
    private bool onFloor = true;
    public float jumpForce = 300f;
    SpriteRenderer spriteRenderer;
    bool isFacingRight = true;
    public bool IsFacingRight() => isFacingRight;

    bool _gameIsOn = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        right = transform.localScale.x;
        left = -transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameIsOn)
        {
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(right, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + 5f * Time.deltaTime, transform.position.y, 0);
               
                GetComponent<Animator>().SetBool("moving", true);
            }
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(left, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - 5f * Time.deltaTime, transform.position.y, 0);
              
                GetComponent<Animator>().SetBool("moving", true);

            }
            if (onFloor && (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W)))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpForce, 0));
                onFloor = false;
            }

            if ((!Input.GetKey("left") && !Input.GetKey(KeyCode.A)) &&
                (!Input.GetKey("right") && !Input.GetKey(KeyCode.D)))
            {
                GetComponent<Animator>().SetBool("moving", false);
            }

            if(GetComponent<Rigidbody2D>().velocity.y != 0)
            {
                GetComponent<Animator>().SetBool("jumping", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("jumping", false);

            }

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")  && _gameIsOn)
        {
            onFloor = true;
        }

        if (collision.gameObject.CompareTag("MovingFloor"))
        {
            onFloor = true;
            transform.parent = collision.transform;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("MovingFloor"))
        {
            onFloor = true;
            transform.parent = null;
        }
    }

    private void FaceToRight()
    {
        if(isFacingRight) return;
        spriteRenderer.flipX = false;
        isFacingRight = true;
    }
    private void FaceToLeft()
    {
        if(!isFacingRight) return;
        spriteRenderer.flipX = true;
        isFacingRight = false;
    }
    
    public void StartRecordingPlayerMovement() => _gameIsOn = true;
    public void StopRecordingPlayerMovement() => _gameIsOn = false;

   
}
