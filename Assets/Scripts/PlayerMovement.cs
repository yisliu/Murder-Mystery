using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //gets player position and is used for movement
    private Rigidbody2D r;
    //access action map -> links wasd to movement
    private Movement controls;
    //this is used for position -> x + y values put in this
    private Vector2 movement;
    public static PlayerMovement instance;
    //accesses class for check if trigger is happening
    
    //public Interaction interaction;
    
    //used to contain values gain from interaction class
    private bool b;
    //used to check if both interaction and e key is pressed
    private bool check = false;
    [SerializeField] interrogate interogateOn;
    [SerializeField] private dialouge text;
    public static GameObject player;
    public bool finished;

    
    // things the program needs to do before starting -> earlier than start()
    void Awake()
    {
        controls = new Movement();
        controls.Enable();
        //access the rigidbody -> gets position
        r = GetComponent<Rigidbody2D>();
        //makes sure to assign controls
        //controls = new Movement();

        // Register input event
        controls.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => movement = Vector2.zero;
        instance = this;
        if (player == null)
        {
            player = gameObject;
            //Instance = this;
            DontDestroyOnLoad(gameObject);
            //changeChances();
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    { 
        finished = false;
    }
    

    void OnEnable()
    {
        if (controls == null)
        {
            controls = new Movement();
            controls.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
            controls.Player.Move.canceled += ctx => movement = Vector2.zero;
        }
        //if the player is moving -> start
        controls.Enable();
    }

    void OnDisable()
    {
        //don't do anything if not starting
        if (controls != null)
        {
            controls.Disable();
        }
    }
    
    //this is a function that is being called at all times
    void Update()
    {
        //checks if the player is triggering/in range
        //b = interaction.inRange();
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
        if (Keyboard.current.qKey.wasPressedThisFrame && check)
        {
            return true;
        }

        return false;
        //return false;
    }
    
    //acesses time -> allows for all programs to be ran at the same pace
    
    void OnTriggerEnter2D(Collider2D other)
    {
        interrogate p = other.GetComponent<interrogate>();
        if (p!=null)
        {
            interogateOn = p;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<interrogate>() == interogateOn)
        {
            interogateOn = null;
        }
    }

    public void setFinished(bool booll)
    {
        finished = booll;
        if (booll)
        {
            interogateOn = null;
        }
    }


    void FixedUpdate()
    {
        if (finished || interogateOn==null || interogateOn.getB()==true)
        {
            Vector2 current = r.position;
            Vector2 newPos = current + movement * (5f * Time.fixedDeltaTime);
            r.MovePosition(newPos);
            //text.deleteText();
        }
        else
        {
            Debug.Log("Blocked");
        }
    }
}