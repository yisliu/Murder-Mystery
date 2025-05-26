using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
//needed to do scene thing
using UnityEngine.SceneManagement;
public class Hard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button startButton;
    //public GameObject mode;
    void Start()
    {
        //gets the value of button
        Button b = startButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        b.onClick.AddListener(whenClicked);
        
        

    }

    // Update is called once per frame
    public void whenClicked()
    {
        //sends a message in console or was it terminal? check both...
        Debug.Log("Hard Clicked :))))");
        //loads next scene -> requires you to type in the name of the level
        StartCoroutine(waitForLoad());
    }
    
    private IEnumerator waitForLoad()
    {
        AsyncOperation loadS = SceneManager.LoadSceneAsync("HardGame", LoadSceneMode.Additive);
        while (!loadS.isDone)
        {
            yield return null;
        }


        SceneManager.UnloadSceneAsync("StartGame");
    }
}