using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterController : MonoBehaviour
{
    private bool _canMove = true;
    private float dir;
    private Rigidbody2D _rb;
    [Header("Movement Speed")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 6f;
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
        //call the SimpleMovement function
        SimpleMovement();
    }

    private void SimpleMovement()
    {
        dir = 0;
        //check if the player can move befor allowing movement
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
        //Check if a circle on the groundCheck GameObject is overlapping with a groundLayer
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
        }
    }
}