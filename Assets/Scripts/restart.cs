using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
//needed to do scene thing
using UnityEngine.SceneManagement;
public class restart : MonoBehaviour
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
    

    // Update is called once per frame
    public void whenClicked(string s)
    {
        SceneManager.LoadScene(s);
    }
}
