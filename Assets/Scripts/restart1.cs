using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
//needed to do scene thing
using UnityEngine.SceneManagement;
public class restart1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button startButton;
    //[SerializeField] guessesLeft chances;
    [SerializeField] string levelToLoad;
    void Start()
    {
        Button b = startButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        b.onClick.AddListener(() => whenClicked(levelToLoad));
    }

    //public string getLevelToLoad()
    //{
        //return levelToLoad;
    //}
    

    // Update is called once per frame
    public void whenClicked(string s)
    {
        //getLevelToLoad();
        string current = SceneManager.GetActiveScene().name;
        StartCoroutine(waitForLoad(current, s));
    }
    private IEnumerator waitForLoad(string oldS, string newS)
    {
        AsyncOperation loadS = SceneManager.LoadSceneAsync(newS, LoadSceneMode.Additive);
        while (!loadS.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("HardGame1"));
        SceneManager.UnloadSceneAsync("HardGame");
    }
}
