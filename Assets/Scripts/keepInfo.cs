using UnityEngine;
using UnityEngine.SceneManagement;
public class keepInfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static GameObject player;
    public static keepInfo Instance;

    public int randomNumber;

    public bool win = false;
    public int chances = 3;

    public string[] arrStr = {"Victor", "Emily", "Jenny"};
    
    private int r;

    public string murderer = "";
    //[SerializeField] private restart r;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        //if (player == null)
        //{
            //player = gameObject;
            Instance = this;
            DontDestroyOnLoad(gameObject);
            randomNumber = Random.Range(1, 4);
            r = Random.Range(0, arrStr.Length);
            murderer = arrStr[r];
            //changeChances();
            SceneManager.sceneLoaded += OnSceneLoaded;
        //}
        //else
        //{
            //Destroy(gameObject);
        //}
    }

    //void Start()
    //{
       // SceneManager.LoadScene("StartGame");
    //}

    void decreaseChances()
    {
        chances--;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string s = SceneManager.GetActiveScene().name;
        if (s == "GuessScene")
        {
            decreaseChances();
        }

        Debug.Log(chances);
    }

    public void resetChances()
    {
        chances = 3;
    }


    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
