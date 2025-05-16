using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //gets player position and is used for movement
    private Rigidbody2D r;
    //access action map -> links wasd to movement
    private Movement controls;
    //this is used for position -> x + y values put in this
    private Vector2 movement;
    //accesses class for check if trigger is happening
    public Interaction interaction;
    //used to contain values gain from interaction class
    private bool b;
    //used to check if both interaction and e key is pressed
    private bool check = false;
    [SerializeField] private dialouge text;
    
    // things the program needs to do before starting -> earlier than start()
    void Awake()
    {
        //access the rigidbody -> gets position
        r = GetComponent<Rigidbody2D>();
        //makes sure to assign controls
        controls = new Movement();

        // Register input event
        controls.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => movement = Vector2.zero;
    }

    void OnEnable()
    {
        //if the player is moving -> start
        controls.Player.Enable();
    }

    void OnDisable()
    {
        //don't do anything if not starting
        controls.Player.Disable();
    }
    
    //this is a function that is being called at all times
    void Update()
    {
        //checks if the player is triggering/in range
        b = interaction.inRange();
        //calls stopMovement to check if key is being pressed as well
        stopMovement();
    }

    void stopMovement()
    {
        if (b && Keyboard.current.eKey.wasPressedThisFrame)
        {
            check = !check;
        }
    }

    public bool continueText()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            return true;
        }

        return false;
    }
    
    //acesses time -> allows for all programs to be ran at the same pace
    void FixedUpdate()
    {
        if (check!=true)
        {
            Vector2 current = r.position;
            Vector2 newPos = current + movement * (5f * Time.fixedDeltaTime);
            r.MovePosition(newPos);
            //text.deleteText();
        }
        else
        {
            Debug.Log("Blocked");
            text.displayText();
        }
    }
}