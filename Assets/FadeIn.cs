using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeMultiplier;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeFromBlack().GetEnumerator());
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
