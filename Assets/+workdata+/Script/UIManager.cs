using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject _escPanel;
    private Button _backToMainMenuButtonEsc;
    private Button _backtoGameEsc;
    
    private TMP_Text _coinTextEsc;
    private TMP_Text _cryTextEsc;
    private TMP_Text _timerTextEsc;
    
    private GameObject _deathPanel;
    private Button _backToMainMenuButtonD;
    private Button _retryButtonD;
    
    private TMP_Text _coinTextD;
    private TMP_Text _cryTextD;
    private TMP_Text _timerTextD;
    
    private GameObject _winPanel;
    private Button _backToMainMenuButtonW;
    private Button _retryButtonW;
    
    private TMP_Text _coinTextW;
    private TMP_Text _cryTextW;
    private TMP_Text _timerTextW;
    
    private GameObject _ingamePanel;
    
    private TMP_Text _coinTextI;
    private TMP_Text _cryTextI;
    private TMP_Text _timerTextI;
    
    private float _time = 60;
    void Start()
    {
        _deathPanel = GameObject.Find("DeathPanel");
        _escPanel = GameObject.Find("EscPanel");
        _winPanel = GameObject.Find("WinPanel");
        _ingamePanel = GameObject.Find("InGamePanel");
        
        _backToMainMenuButtonEsc = GameObject.Find("BackToMenuButtonEsc").GetComponent<Button>();
        _backtoGameEsc = GameObject.Find("BackToGameEsc").GetComponent<Button>();
        _coinTextEsc = GameObject.Find("CoinCounterEsc").GetComponent<TMP_Text>();
        _cryTextEsc = GameObject.Find("CrystalCounterEsc").GetComponent<TMP_Text>();
        _timerTextEsc = GameObject.Find("TimeLeftEsc").GetComponent<TMP_Text>();
        
        _backtoGameEsc.onClick.AddListener(BackToGame);
        _backToMainMenuButtonEsc.onClick.AddListener(BackToMainMenu);
        _escPanel.SetActive(false);
        
        _backToMainMenuButtonD = GameObject.Find("BackToMenuButtonD").GetComponent<Button>();
        _retryButtonD = GameObject.Find("RetryButtonD").GetComponent<Button>();
        _coinTextD = GameObject.Find("CoinCounterD").GetComponent<TMP_Text>();
        _cryTextD = GameObject.Find("CrystalCounterD").GetComponent<TMP_Text>();
        _timerTextD = GameObject.Find("TimeLeftD").GetComponent<TMP_Text>();
        
        _retryButtonD.onClick.AddListener(Retry);
        _backToMainMenuButtonD.onClick.AddListener(BackToMainMenu);
        _deathPanel.SetActive(false);
        
        _backToMainMenuButtonW = GameObject.Find("BackToMainMenuButtonW").GetComponent<Button>();
        _retryButtonW = GameObject.Find("RetryButtonW").GetComponent<Button>();
        _coinTextW = GameObject.Find("CoinCounterW").GetComponent<TMP_Text>();
        _cryTextW = GameObject.Find("CrystalCounterW").GetComponent<TMP_Text>();
        _timerTextW = GameObject.Find("TimeLeftW").GetComponent<TMP_Text>();
        
        _retryButtonW.onClick.AddListener(Retry);
        _backToMainMenuButtonW.onClick.AddListener(BackToMainMenu);
        _winPanel.SetActive(false);
        
        _coinTextI = GameObject.Find("CoinCounterI").GetComponent<TMP_Text>();
        _cryTextI = GameObject.Find("CrystalCounterI").GetComponent<TMP_Text>();
        _timerTextI = GameObject.Find("TimeLeftI").GetComponent<TMP_Text>();
        _ingamePanel.SetActive(false);
        
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
        _ingamePanel.SetActive(true);
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
            _ingamePanel.SetActive(false);
            _escPanel.SetActive(true);
        }
    }

    private void BackToGame()
    {
        _escPanel.SetActive(false);
        _ingamePanel.SetActive(true);
        Time.timeScale = 1;
    }

    private void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ActiveDeathPanel()
    {
        _deathPanel.SetActive(true);
        _ingamePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void WinPanel()
    {
        _winPanel.SetActive(true);
        _ingamePanel.SetActive(false);
        Time.timeScale = 0;
    }
    
    public void UpdateTextCoinCount(int newCount)
    {
        _coinTextEsc.text = newCount.ToString();
        _coinTextD.text = newCount.ToString();
        _coinTextW.text = newCount.ToString();
        _coinTextI.text = newCount.ToString();
    }

    public void UpdateTextCry(int newCry)
    {
        _cryTextEsc.text = newCry.ToString();
        _cryTextD.text = newCry.ToString();
        _cryTextW.text = newCry.ToString();
        _cryTextI.text = newCry.ToString();
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
        _timerTextEsc.text = _time.ToString();
        _timerTextD.text = _time.ToString();
        _timerTextW.text = _time.ToString();
        _timerTextI.text = _time.ToString();
        UpdateTextTimer();
    }
    
    
    
    
    
    
}
