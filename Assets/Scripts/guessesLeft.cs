using UnityEngine;
using TMPro;
public class guessesLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static guessesLeft gameManager;
    int GuessesLeft = 3;
    [SerializeField] private restart r;
    public TMP_Text t;
    void Start()
    {
        GuessesLeft = 3;
        if (t == null)
        {
            t = GameObject.Find("Counter").GetComponent<TMP_Text>();
        }
    }

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        t.text = GuessesLeft.ToString();
    }
    public void decreaseGuesses()
    {
        GuessesLeft--;
    }

    public int getGuessesLeft()
    {
        return GuessesLeft;
    }

}
