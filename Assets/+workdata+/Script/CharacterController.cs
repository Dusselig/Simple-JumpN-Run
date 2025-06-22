using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterController : MonoBehaviour
{
    private bool _canMove = true;
    private float dir;
    private Rigidbody2D _rb;
    [SerializeField] private CountersAndTimer counterAndTimer;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private AudioManager audioManager;
    [Header("Movement Speed")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 8f;
    [Header("Ground Check")]
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool _isGrounded;
    
    void Start()
    {
        //set the variable _rb to the rigidbody of the GameObject
        _rb = GetComponent<Rigidbody2D>();
    }
    
    
    void Update()
    {
        //call the SimpleMovement function every frame
        SimpleMovement();
    }

    private void SimpleMovement()
    {
        //stop movement of the character if the player is not active moving
        dir = 0;
        //check if the player can move before allowing movement
        if (_canMove)
        {
            dir = 0;
            //check if "D" is pressed
            if (Keyboard.current.dKey.isPressed)
            {
                //move right
                dir = 1;
            }
            //check if "A" is pressed
            if (Keyboard.current.aKey.isPressed)
            {
                //move left
                dir = -1;
            }
            //check if "Space" is pressed
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                //call the Jump function
                Jump();
                
            }
            //change the Position of the GameObeject in a diraction with a set speed
            _rb.linearVelocity = new Vector2(dir * speed, _rb.linearVelocity.y);
        }


    }

    private void Jump()
    {
        //Check if a circle on the groundCheck GameObject is overlapping with a groundLayer and if they overlap set _isGrounded to true
        if (Physics2D.OverlapCircle(groundCheck.transform.position, .25f, groundLayer))
        {
            _isGrounded = true;
        }
        //Check if the Variable _isGrounded is true
        if (_isGrounded)
        {
            //jump and set the _isGrounded variable to false
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpforce);
            _isGrounded = false;
            audioManager.PlayJumpSound();
        }
    }
    //check if player collides with any other Collider with a trigger active
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if the collided game object has the "Coin" tag
        if (other.gameObject.CompareTag("Coin"))
        {
            //destroy the coin and activate the AddCoin function
            Destroy(other.gameObject);
            counterAndTimer.AddCoin();
            audioManager.PlayCoinSound();
        }//check if the collided game object has the "Crystal" tag
        else if (other.gameObject.CompareTag("Crystal"))
        {
            //destroy the Crystal and activate the AddCry function
            Destroy(other.gameObject);
            counterAndTimer.AddCry();
        }//check if the collided game object has the "death" tag
        
    }
    //check if player collides with any other Collider
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("death"))
        {
            //stops the game time (movement and timers)
            uiManager.ActiveDeathPanel();
        }
    }
    
}