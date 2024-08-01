using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    public float fadeMultiplier;
    public float duration;
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade().GetEnumerator());
    }

    IEnumerable Fade()
    {
        textMesh.color = new Color(1f, 1f, 1f, 0f);
        while (textMesh.color.a < 1f)
        {
            textMesh.color = new Color(1f, 1f, 1f, textMesh.color.a + (Time.deltaTime * fadeMultiplier));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(duration);
        while (textMesh.color.a > 0f)
        {
            textMesh.color = new Color(1f, 1f, 1f, textMesh.color.a - (Time.deltaTime * fadeMultiplier));
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
