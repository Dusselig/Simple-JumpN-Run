using System.Collections;
using TMPro;
using UnityEngine;

public class CountersAndTimer : MonoBehaviour
{
    //only counter no timer they are in UIManager
    
    private int _coinC = 0;
    private int _cryC = 0;
    
    
    [SerializeField]private UIManager _uiManager;
    
    
    public void AddCoin()
    {
        _coinC++;
        _uiManager.UpdateTextCoinCount(_coinC);
    }
    public void AddCry()
    {
        _cryC++;
        _uiManager.UpdateTextCry(_cryC);
    }
    
    
    
}
