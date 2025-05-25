using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class replay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void whenClicked()
    {
        if (keepInfo.Instance != null)
        {
            keepInfo.Instance.resetChances();
        }
    }

}
