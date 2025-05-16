using UnityEngine;
using TMPro;

public class dialouge : MonoBehaviour
{
    [SerializeField] TMP_Text[] text;
    private PlayerMovement p;
    private int i = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    //make a function thing for displaying and then continuing text 
    void Awake()
    {
        p = FindObjectOfType<PlayerMovement>();
        for (int i = 0; i < 2; i++)
        {
            deleteText(text[i]);
        }
    }
    public void displayText()
    {
        //text.gameObject.SetActive(true);
        if (p.continueText()==true&&i==0)
        {
            text[i].gameObject.SetActive(true);
            i++;
        }
        else if (p.continueText()&&i<2)
        {
            deleteText(text[i - 1]);
            text[i].gameObject.SetActive(true);
        }
    }
    //

    public void deleteText(TMP_Text t)
    {
        t.gameObject.SetActive(false);
    }
}
