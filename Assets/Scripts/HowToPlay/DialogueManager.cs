using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> instructionSet;//Keeps all sentences to be displayed
    private string topicSet;
    public Text topicText;
    public Text instructionText;
    private DialogueTrigger DT;
    private static int i = 0;

    void Start()
    {
        instructionSet = new Queue<string>();
        DT = GameObject.Find("InstructionsButton").GetComponent<DialogueTrigger>();
    }

    public void StartDialogue(Dialogue info)
    {
        instructionSet.Clear();

        topicText.text = info.topic;
        i++;

        foreach (string ins in info.instructions)
        {
           instructionSet.Enqueue(ins);
        }
        
        dispayNext();
    }

    public void dispayNext()
    {
       if(instructionSet.Count == 0 & i == 1)
       {
          Health();
          return;
       }
       else if (instructionSet.Count == 0 & i == 2)
        {
            Powerups();
            return;
        }
        else if (instructionSet.Count == 0 & i == 3)
        {
            End();
            return;
        }

        string sentence = instructionSet.Dequeue();
        instructionText.text = sentence;
    }

    void Health()
    {
        DT.SendHealth();
    }

    void Powerups()
    {
        DT.SendPowerups();
    }

    void End()
    {
        i = 0;
        Debug.Log("End");
    }
}
