using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool triggered = false;
    
    //void Update()
    //{
        //if (triggered)
        //{
            //Debug.Log("Triggered");
        //}
    //}
    

    public bool inRange()
    {
        return triggered;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
    }
}
