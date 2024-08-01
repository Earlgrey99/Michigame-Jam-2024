using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TypeWriterMessage(string msg)
    {
        currentMsg = msg;
    }

    public string GetFullMsg()
    {
        return currentMsg;
    }

    public string GetMsg()
    {
        return displayMsg;
    }

    public void Update()
    {
        if (string.IsNullOrEmpty(currentMsg))
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer += timePerChar;
            charIndex++;

            displayMsg = currentMsg.Substring(0, charIndex);

            if (charIndex >= currentMsg.Length)
            {
                currentMsg = null;
            }
        }
    }

    public bool isActive()
    {
        if (string.IsNullOrEmpty(currentMsg))
        {
            return false;
        }

        return charIndex < currentMsg.Length;
    }
}

public class Typewriter : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    private static Typewriter instance;
    private List<TypeWriterMessage> messages = new List<TypeWriterMessage>();

    private TypeWriterMessage currentMsg = null;

    private int msgIndex = 0;

    public static void Add(string msg)
    {
        TypeWriterMessage typeMsg = new TypeWriterMessage(msg);
        instance.messages.Add(typeMsg);
    }

    public static void Pop()
    {
        instance.messages.RemoveAt(0);
    }

    public static void Activate()
    {
        instance.currentMsg = instance.messages[0];
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (messages.Count > 0 && currentMsg != null)
        {
            currentMsg.Update();
            textComponent.text = currentMsg.GetMsg();
        }
    }

    public void WriteNextMessageInQueue()
    {
        if(currentMsg != null && currentMsg.isActive())
        {
            textComponent.text = currentMsg.GetFullMsg();
            currentMsg = null;
            return;
        }

        msgIndex++;

        if(msgIndex >= messages.Count)
        {
            currentMsg = null;
            textComponent.text = "";
            return;
        }

        currentMsg = messages[msgIndex];
    }
}
