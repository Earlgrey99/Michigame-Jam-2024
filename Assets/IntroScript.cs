using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public TextFade tf;

    private List<int> colors = new List<int> {0, 0, 0, 1, 2, 0, 1, 2, 1, 2, 2, 1, 2, 0, 0, 0 };

    private List<string> texties = new List<string>
    {
        "Something... something is missing.",
        "I have to find it.",
        "Think... think... what went astray?",
        "Tag, you’re it!",
        "Haha, you got me, Blue! How come you’re so much faster than me?",
        "Not something - someone.",
        "Look, Red! Over there!",
        "Look at what? I don’t see anything.",
        "Exactly! It’s uncharted territory! I bet we could find something cool there!",
        "I don’t know about that. It looks dark... ",
        "I don’t think there’s any light in there at all. What if we get lost?",
        "Well, we don’t know what’s in there until we look! Last one in is a white dwarf!",
        "Blue, wait! Don’t go in there!",
        "He must still be in there. I have to go find him before he loses his way.",
        "Even if it kills me.",
        "Maybe if I retrace his steps... locate his memories...",
    };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowIntroText().GetEnumerator());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerable ShowIntroText()
    {
        for (int i = 0; i < texties.Count; i++)
        {
            Typewriter.Add(texties[i]);
            Typewriter.Activate();
            tf.TriggerFade(true, colors[i]);
            yield return new WaitUntil(() => tf.doneFading);
        }
        SceneManager.LoadScene("SampleScene");
    }
}
