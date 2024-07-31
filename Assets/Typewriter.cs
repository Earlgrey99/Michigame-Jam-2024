using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adapted from https://medium.com/@jonbednez/how-to-create-typewriter-effect-in-ui-with-unity-a-step-by-step-tutorial-bcd6d33d86d4

[System.Serializable]
public class TypeWriterMessage
{
    private float timer = 0;
    private int charIndex = 0;
    private float timePerChar = 0.05f;

    [SerializeField]
    public string currentMsg = null;
    private string displayMsg = null;
    //private Action onActionCallback = null;
}

public class Typewriter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
