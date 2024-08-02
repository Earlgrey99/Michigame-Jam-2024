using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip memoryGet;
    public AudioClip refuel;
    public AudioClip whoosh;

    public float fadeMultiplier;
    public GameObject panel;

    public GameObject popupText;
    public List<GameObject> memories;
    private List<string> memoryText = new List<string>
    {
        "Hey, this is neat! I wish Red was here to explore with me!",
        "No wonder Red didn�t want to come. These vortexes keep sucking me in!",
        "Where are all the other stars? They�re disappearing! Hey, wait, come back!",
        "What�s going on? I�m� not feeling so well.",
        "How long have I been traversing this endless void? It feels like forever�",
        "Something� something is missing."
    };
    private int memoryIndex;

    //Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        StartCoroutine(FadeFromBlack().GetEnumerator());
        popupText.SetActive(false);
        memoryIndex = 0;
        foreach (GameObject memory in memories)
        {
            memory.SetActive(false);
        }
        memories[0].SetActive(true);
        source.PlayOneShot(whoosh);
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
            source.PlayOneShot(memoryGet);
        }
        else
        {
            //TODO: trigger ending
        }
    }

    public void PlayRefuel()
    {
        source.PlayOneShot(refuel);
    }

    IEnumerable FadeFromBlack()
    {
        Image image = panel.GetComponent<Image>();
        image.color = new Color(0f, 0f, 0f, 1f);
        while (image.color.a > 0f)
        {
            image.color = new Color(0f, 0f, 0f, image.color.a - (Time.deltaTime * fadeMultiplier));
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
