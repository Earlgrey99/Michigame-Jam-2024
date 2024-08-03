using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    public float fadeMultiplier;
    public float duration;
    public TextMeshProUGUI textMesh;

    public bool doneFading;

    private Color blue = new Color(0.596f, 0.961f, 0.976f);
    private Color red = new Color(0.945f, 0.384f, 0.388f);

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TriggerFade(bool isCutscene, int color)
    {
        StartCoroutine(Fade(isCutscene, color).GetEnumerator());
    }

    IEnumerable Fade(bool isCutscene, int color)
    {
        doneFading = false;
        switch (color)
        {
            case 0:
                textMesh.color = Color.white;
                break;
            case 1:
                textMesh.color = blue;
                break;
            case 2:
                textMesh.color = red;
                break;
            default:
                textMesh.color = Color.white;
                break;
        }
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0f);
        while (textMesh.color.a < 1f)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a + (Time.deltaTime * fadeMultiplier));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(duration);
        while (textMesh.color.a > 0f)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - (Time.deltaTime * fadeMultiplier));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Typewriter.Pop();
        doneFading = true;
        if (!isCutscene)
        {
            this.gameObject.SetActive(false);
        }
    }
}
