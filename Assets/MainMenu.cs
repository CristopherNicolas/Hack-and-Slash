using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]Button startGameButton;
    private void Awake()
    {
        startGameButton.onClick.AddListener(() => SceneManager.LoadScene(1));
    }
}
