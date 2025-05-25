using UnityEngine;
//needed to access button
using UnityEngine.UI;
using System.Collections;
//needed to do scene thing
using UnityEngine.SceneManagement;
public class interrogate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button intButton;
    public Interaction interaction;
    [SerializeField] private GameObject gObject;
    private bool b = true;
    
    
    void Start()
    {
        intButton.GetComponent<Button>();
        //call function 'whenClicked' when button is clicked
        intButton.gameObject.SetActive(false);
        gObject.SetActive(false);
        //gObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        intButton.gameObject.SetActive(interaction.getTriggered());
        if (interaction.getTriggered())
        {
            intButton.onClick.AddListener(whenClicked);
        }
    }

    public void whenClicked()
    {
        b = false;
        gObject.SetActive(true);
    }

    public bool getB()
    {
        return b;
    }

    //void Update()
    //{
        //bool triggered = interaction.getTriggered();
        //Debug.Log("Triggered? " + triggered);
        //intButton.gameObject.SetActive(triggered);
    //}
}
