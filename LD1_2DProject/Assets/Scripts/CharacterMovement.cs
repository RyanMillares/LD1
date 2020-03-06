using UnityEngine;
using System.Collections;
public class CharacterMovement : MonoBehaviour
{

    public float speed = 6f;
    public float sprintSpeed = 8f;
    public float jumpSpeed = Mathf.Sqrt(50);
    public float gravity = 10f;
    private Vector3 moveDirection = Vector3.zero;
    private float previousYVelocity = 0f;
    public bool isJumping = false;
    private float shortJumpMultiplier = 3f;
    private float fallMultiplier = 4f;

    [HideInInspector] public bool isFacingLeft = false;
    public bool isMoving = false;
    public bool isSprinting = false;
    public double previousX;
    public double currentX;
    
	/// SOUNDS
	private AudioSource source;
    public AudioClip jumpSound;
    public AudioClip spawnSound;
    
	// Use this for initialization
	void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(spawnSound);
    }
    
	// Update is called once per frame
	void Update()
    {
        previousX = System.Math.Round(this.gameObject.transform.position.x, 2);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), previousYVelocity, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        
        if (isSprinting)
        {
            moveDirection.x *= sprintSpeed;
        }
        if (!isSprinting)
        {
            moveDirection.x *= speed;
        }

        DBMovement();
        
		if (controller.isGrounded)
        {
            
			isJumping = false;
            moveDirection.y = 0;
            
			if (Input.GetButton("Jump") && !isJumping)
            {
                moveDirection.y = jumpSpeed;
                isJumping = true;
                source.PlayOneShot(jumpSound);
            }
        }
        else
        {
            if (isJumping && Input.GetButton("Jump") && moveDirection.y > 0)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            else if (moveDirection.y < 0)
            {
                moveDirection.y -= gravity * Time.deltaTime * (fallMultiplier);
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime * (shortJumpMultiplier);
            }
        }

        controller.Move(moveDirection * Time.deltaTime);
        currentX = System.Math.Round(this.gameObject.transform.position.x, 2);
        //Check to see if we are currently moving... this is needed for animation purposes...
        if (previousX != currentX)
        {
            isMoving = true;
        }
        else if (previousX == currentX)
        {
            isMoving = false;
        }
        
        previousYVelocity = moveDirection.y;
    }
    
	void DBMovement()
    {
        if (moveDirection.x > 0)
        {
            //Debug.Log ("I moved right!");
            isFacingLeft = false;
        }
        else if (moveDirection.x < 0)
        {
            //Debug.Log ("I moved left!");
            isFacingLeft = true;
        }
    }
}