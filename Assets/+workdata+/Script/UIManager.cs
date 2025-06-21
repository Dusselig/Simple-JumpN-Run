using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject _escPanel;
    private Button _backToMainMenuButton;
    private Button _backtoGame;
    
    private TMP_Text _coinText;
    private TMP_Text _cryText;
    private TMP_Text _TimerText;
    private float _time = 60;
    private bool _gameOn = false;
    void Start()
    {
        _escPanel = GameObject.Find("EscPanel");
        _backToMainMenuButton = GameObject.Find("BackToMenuButton").GetComponent<Button>();
        _backtoGame = GameObject.Find("BackToGame").GetComponent<Button>();
        _coinText = GameObject.Find("CoinCounter").GetComponent<TMP_Text>();
        _cryText = GameObject.Find("CrystalCounter").GetComponent<TMP_Text>();
        _TimerText = GameObject.Find("TimeLeft").GetComponent<TMP_Text>();
        _backtoGame.onClick.AddListener(BackToGame);
        _backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        _escPanel.SetActive(false);
        StartCoroutine(Countdown());
        Time.timeScale = 0;
        UpdateTextTimer();
    
    }
    
    private IEnumerator Countdown()
    {
        int count = 3;
      
        while (count > 0) 
        {
            yield return new WaitForSecondsRealtime(1);
            count --;
            Debug.Log("count" + count);
        }
        
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Time.timeScale = 0;
            _escPanel.SetActive(true);
        }
    }

    private void BackToGame()
    {
        _escPanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    private void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void UpdateTextCoinCount(int newCount)
    {
        _coinText.text = newCount.ToString();
    }

    public void UpdateTextCry(int newCry)
    {
        _cryText.text = newCry.ToString();
    }

    
    
    private void UpdateTextTimer()
    {
        if (_time > 0)
        {
            Invoke("InvokeTimer", 1);
        }
    }

    private void InvokeTimer()
    {
        Debug.Log("Countdown: " + _time);
        _time--;
        _TimerText.text = _time.ToString();
        UpdateTextTimer();
    }
    
    
    
    
    
    
}
