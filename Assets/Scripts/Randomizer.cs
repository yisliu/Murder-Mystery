using UnityEngine;

public class Randomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] clues;
    private string s;
    void Start()
    {
        s = "npc" + keepInfo.Instance.randomNumber.ToString();
        for (int i = 0; i < clues.Length; i++)
        {
            if (clues[i].tag == s)
            {
                clues[i].SetActive(true);
            }
            else
            {
                clues[i].SetActive(false);
            }
        }
    }

}
