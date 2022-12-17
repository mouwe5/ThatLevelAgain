using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;//need to add f in the end
    public float jumpSpeed = 5f;//need to add f in the end
    private float movement = 0f;//need to add f in the end
    private Rigidbody2D rigidBody; // object information
    public Transform groundCheckPointR; //  check if the character on the ground with the legs RIGHT
    public Transform groundCheckPointL; //  check if the character on the ground with the legs LEFT
    public float groundCheckRadius; // radius of the jump
    public LayerMask groundLayer; // All the layer where the player can jump
    private bool isTouchingGround; // if yes , the character Jumpable
    private Animator playerAnimation;
    public Vector3 respawnPoint; // the place of the respawn
    private Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); //get the information from the other project
        playerAnimation = GetComponent<Animator>(); // get the information from the Project
        playerCollider = GetComponent<Collider2D>();// get the information from the Project
        respawnPoint = transform.position;
 


    }

    // Update is called once per frame
    void Update()
    {
        //Movement Controll
      //  isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);// put a bool value - check if any object on groundlayer, that in the radius from that specific point
       if(Physics2D.OverlapCircle(groundCheckPointR.position, groundCheckRadius, groundLayer)|| Physics2D.OverlapCircle(groundCheckPointL.position, groundCheckRadius, groundLayer))
        {
            isTouchingGround = true;
        }
        else { isTouchingGround = false; }

      
        movement = Input.GetAxis("Horizontal"); // 0->1 move right, 0->-1 move left, 0 stand - get the value and put on movement

        if (movement > 0f) // those ifs makes the character move even if something not press
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); // add velocity to any side, make the character move - right
            transform.localScale = new Vector2(1f, 1f);//make the character look right

        }
        else if (movement < 0f) //left
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); // add velocity to any side, make the character move
            transform.localScale = new Vector2(-1f, 1f);//make the character look left

        }
        else  // if any button not pressed, the character stand
        {
            rigidBody.velocity = new Vector2(0,rigidBody.velocity.y);


        }
        if(Input.GetButtonDown("Jump") && (isTouchingGround)) // of someone click jump key = space
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed); //nothing change on X value only on in Y Value

        }
        //Animation
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x)); //set the information on "Speed" catagory from velocity.x ((Mathf.Abs - any negative to postitive for left move))
        playerAnimation.SetBool("OnGround", isTouchingGround); //set the information on "OnGround" catagory from isTouchingGround

    }


}
