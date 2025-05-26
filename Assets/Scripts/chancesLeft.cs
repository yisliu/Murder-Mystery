using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class chancesLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text t;

    private int guesses = 0;
    //public keepInfo k;
    
    
    void Update()
    {
        guesses = keepInfo.Instance.chances;
        t.text = guesses.ToString();
        Debug.Log(guesses);
        //if(chances)
        if (guesses == 0 && keepInfo.Instance.win==false)
        {
            SceneManager.LoadScene("gameOver");
            //keepInfo.Instance.resetChances();
        }
    }
}
