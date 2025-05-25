using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
//needed to do scene thing
using UnityEngine.SceneManagement;
public class endGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button startButton;
    void Start()
    {
        Button b = startButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        b.onClick.AddListener(whenClicked);
    }

    // Update is called once per frame
    public void whenClicked()
    {
        Application.Quit();
    }
}
