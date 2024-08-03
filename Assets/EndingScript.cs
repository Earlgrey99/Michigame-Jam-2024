using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public TextFade tf;
    public float waitTime;

    private List<int> colors = new List<int> {2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 1, 1};

    private List<string> texties = new List<string>
    {
        "Blue! Oh, Blue! Thank the galaxies I found you!",
        "...",
        "Who are you?",
        "Wh- what do you mean? It’s your buddy, Red!",
        "I knew I had to find you, even if I risked my life. I’m here to rescue you!",
        "...Red?",
        "I’m sorry, but I don’t know a Red.",
        "But you have to remember me! I’m your best friend!",
        "I warned you about this place, remember? But it’s alright now! I forgive you!",
        "...but that’s impossible. I’ve never seen another star...",
        "...if you’ll excuse me, I have to look for something.",
        "I have to find it.",
        "Think... think... think..."
    };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowEndingText().GetEnumerator());
    }

    IEnumerable ShowEndingText()
    {
        for (int i = 0; i < texties.Count; i++)
        {
            Typewriter.Add(texties[i]);
            Typewriter.Activate();
            tf.TriggerFade(true, colors[i]);
            yield return new WaitUntil(() => tf.doneFading);
        }
    }
}
