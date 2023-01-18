using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KAKI : MonoBehaviour
{
    KAKI player;
    Enemy enemy;
    GameObject gop;
    public float gravity = -100;
    public Vector2 velocity;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float distance = 0;
    public float jumpVelocity = 20;
    public float maxVelocity = 100;
    public float groundHeight = 2;
    public bool isGrounded = false;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.15f;
    public float holdJumpTimer = 0.0f;
    public float jumpGroundThreshold = 1;
    public int health = 2;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("KAKI").GetComponent<KAKI>();                
        animator = GetComponent<Animator>();
        gop = GameObject.Find("GameOverPanel");
        gop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 post = transform.position;
        float groundDistance = Mathf.Abs(post.y - groundHeight);
        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;
            } 
            if (Input.touchCount > 0) {
                Touch first = Input.GetTouch(0);
                if(first.phase == TouchPhase.Stationary)
                {
                    isGrounded = false;
                    velocity.y = jumpVelocity;
                    isHoldingJump = true;
                    holdJumpTimer = 0;
                } else {
                    isHoldingJump = false;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            isHoldingJump = false;
        }
    }    

    void OnCollisionEnter2D(Collision2D Coll)
    {
        if(Coll.gameObject.tag == "Respawn")
        {
            health--;
            if (health == 1) {
                velocity.x = velocity.x * (20 / 100);
                animator.Play("Contaminate");
            } else if (health == 0) {                
                //Game Over
                Time.timeScale = 0;
                gop.SetActive(true);
            }            
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if(holdJumpTimer >= maxHoldJumpTime) 
                {
                    isHoldingJump = false;
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump) {
                velocity.y += gravity * Time.fixedDeltaTime;
            }            

            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;                
            }
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            float velocityRation = velocity.x / maxVelocity;
            acceleration = maxAcceleration * (1 - velocityRation);

            velocity.x += acceleration * Time.fixedDeltaTime;
            if (velocity.x >= maxVelocity)
            {
                velocity.x = maxVelocity;
            }
        }

        transform.position = pos;

    }
}
