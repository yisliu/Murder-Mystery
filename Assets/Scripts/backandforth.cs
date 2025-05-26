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
    //[SerializeField] private GameObject panel;
    private int i = 0;
    [SerializeField] string sceneName;

    //public GameObject mode;
    
    void Start()
    {
        //panel.SetActive();
        panels[0].SetActive(true);
        //gets the value of button
        //Button back = backButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        backButton.onClick.AddListener(backTo);
        //Button next = nextButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        nextButton.onClick.AddListener(nextTo);
        finishButton.onClick.AddListener(endText);
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

    public void endText()
    {
        for (int index = 0; index < panels.Length; index++)
        {
            panels[index].SetActive(false);
        }

        backButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        finishButton.gameObject.SetActive(false);
        //panel.SetActive(false);
        
        string current = SceneManager.GetActiveScene().name;
        if (current != sceneName)
        {
            StartCoroutine(waitForLoad(current, sceneName));
        }

        if (PlayerMovement.instance != null)
        {
            PlayerMovement.instance.setFinished(true);
        }
        

        //string current = SceneManager.GetActiveScene().name;
        //StartCoroutine(waitForLoad(current, sceneName));
    }

    private IEnumerator waitForLoad(string oldS, string newS)
    {
        if (string.IsNullOrEmpty(newS))
        {
            yield break;
        }
        //Scene newScene = SceneManager.GetSceneByName(newS);
        //if (!newScene.isLoaded)
        //{
            AsyncOperation loadS = SceneManager.LoadSceneAsync(newS, LoadSceneMode.Additive);
            while (!loadS.isDone)
            {
                yield return null;
            }
        //}
        Scene newScene = SceneManager.GetSceneByName(newS);
        if (newScene.IsValid())
        {
            SceneManager.SetActiveScene(newScene);
        }
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("EasyGame1"));
        if (oldS != newS)
        {
            Scene oldScene = SceneManager.GetSceneByName(oldS);
            if (oldScene.IsValid() && oldScene.isLoaded)
            {
                SceneManager.UnloadSceneAsync(oldScene);
            }
            //SceneManager.UnloadSceneAsync("EasyGame");
        }
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