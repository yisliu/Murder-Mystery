using UnityEngine;
using UnityEngine.SceneManagement;
public class loadScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SceneManager.LoadScene("StartGame", LoadSceneMode.Single);
        if (SceneManager.GetSceneByName("StartGame").isLoaded == false)
        {
            SceneManager.LoadScene("StartGame", LoadSceneMode.Additive);
        }
    }

}
