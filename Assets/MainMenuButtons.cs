using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    public Button StartGameButton;
    public string StartGameSceneName;

    // Start is called before the first frame update
    void Start()
    {
        StartGameButton.onClick.AddListener(() => OnStartClick());
    }

    void OnStartClick()
    {
        SceneManager.LoadScene(StartGameSceneName);
        
    }
}
