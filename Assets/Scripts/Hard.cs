using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
//needed to do scene thing
using UnityEngine.SceneManagement;

public class Hard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //Goal: Make a button that will switch scenes -> later beautify it
    //used to get reference :)
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
        //keepInfo.Instance.setChances();
        //loads next scene -> requires you to type in the name of the level
        
        SceneManager.LoadScene("HardGame", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("StartGame");
    }
}
