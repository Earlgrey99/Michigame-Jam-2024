using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject popupText;
    public List<GameObject> memories;
    private List<string> memoryText = new List<string>
    {
        "Hey, this is neat! I wish Red was here to explore with me!",
        "No wonder Red didn’t want to come. These vortexes keep sucking me in!",
        "Where are all the other stars? They’re disappearing! Hey, wait, come back!",
        "What’s going on? I’m… not feeling so well.",
        "How long have I been traversing this endless void? It feels like forever…",
        "Something… something is missing."
    };
    private int memoryIndex;

    //Start is called before the first frame update
    void Start()
    {
        popupText.SetActive(false);
        memoryIndex = 0;
        foreach (GameObject memory in memories){
            memory.SetActive(false);
        }
        memories[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerMemory()
    {
        if (memoryIndex < 6)
        {
            memories[memoryIndex].SetActive(false);
            memories[memoryIndex + 1].SetActive(true);
            popupText.SetActive(true);
            Typewriter.Add(memoryText[memoryIndex]);
            popupText.GetComponent<TextFade>().TriggerFade();
            Typewriter.Activate();
            memoryIndex++;
        }
        else
        {
            //TODO: trigger ending
        }
    }
}
