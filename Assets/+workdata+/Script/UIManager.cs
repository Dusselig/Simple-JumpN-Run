using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _panel;
    private Button _backToMainMenuButton;
    private Button _backtoGame;
    void Start()
    {
        _panel = GameObject.Find("Panel");
        _backToMainMenuButton = GameObject.Find("BackToMenuButton").GetComponent<Button>();
        _backtoGame = GameObject.Find("BackToGame").GetComponent<Button>();
        _backtoGame.onClick.AddListener(BackToGame);
        _backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        
        _panel.SetActive(false);
        
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Time.timeScale = 0;
            _panel.SetActive(true);
        }
    }

    private void BackToGame()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }
    
    private void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
