using UnityEngine;
using TMPro;

public class dialouge : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    public void displayText()
    {
        text.gameObject.SetActive(true);
    }

    public void deleteText()
    {
        text.gameObject.SetActive(false);
    }
}
