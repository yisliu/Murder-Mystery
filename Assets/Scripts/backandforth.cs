using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
//needed to do scene thing
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //Goal: Make a button that will switch scenes -> later beautify it
    //used to get reference :)
    public Button backButton;
    public Button nextButton;
    public Button finishButton;
    [SerializeField] GameObject[] panels;
    private int i = 0;
    [SerializeField] string sceneName;

    //public GameObject mode;
    
    void Start()
    {
        panels[0].SetActive(true);
        //gets the value of button
        Button back = backButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        back.onClick.AddListener(backTo);
        //Button next = nextButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        nextButton.onClick.AddListener(nextTo);
        //Button finish = finishButton.GetComponent<Button>();
        finishButton.gameObject.SetActive(false);
        //call function 'whenClicked' when button is clicked


    }



    //public void buttonVisible()
    //{
        //backButton.gameObject.SetActive(i > 0);
        //nextButton.gameObject.SetActive(i < panels.Length - 1);
        //finishButton.gameObject.SetActive(i == panels.Length);
    //}

    public void switchScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void backTo()
    {
        if (i > 0)
        {
            i--;
            showPanels(i);
        }

        nextButton.gameObject.SetActive(true);
        finishButton.gameObject.SetActive(false);

    }
    
    public void nextTo()
    {
        if (i < panels.Length-1)
        {
            i++;
            showPanels(i);
        }

        if (i == panels.Length-1)
        {
            finishButton.gameObject.SetActive(true);
            finishButton.onClick.AddListener(switchScene);
        }

    }



    public void showPanels(int index)
    {
        for (int j = 0; j < panels.Length; j++)
        {
            panels[j].SetActive(j==index);
        }
    }

    // Update is called once per frame

}