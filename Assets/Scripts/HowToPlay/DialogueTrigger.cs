using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue controls;
    public Dialogue health;
    public Dialogue powerups;
    //public Dialogue powerups;

    //Get 10 points everytime player hits an enemy. Additional 10 point for destroying the enemy. 


    public void TriggerDialogue()
    {
        //Debug.Log("Sending controls...");
        FindObjectOfType<DialogueManager>().StartDialogue(controls);
    }

    public void SendHealth()
    {
        //Debug.Log("Sending health...");
        FindObjectOfType<DialogueManager>().StartDialogue(health);
    }

    public void SendPowerups()
    {
        //Debug.Log("Sending score...");
        FindObjectOfType<DialogueManager>().StartDialogue(powerups);
    }
}
