using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverOutlineColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private TMP_Text myText;
    [SerializeField] private Color normalColor = Color.black;
    [SerializeField] private Color pressColor = new Color(255, 217, 0);
    [SerializeField]private TMP_FontAsset fontOutline;
    [SerializeField]private TMP_FontAsset font;

    void Start()
    {
        if (myText == null)
        {
            myText = GetComponentInChildren<TMP_Text>();
            if (myText == null)
            {
                Debug.LogError("TextMeshPro component not found!");
                enabled = false;
                return;
            }
        }
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.font = fontOutline; 
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        myText.font = font;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        myText.color = pressColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        myText.color = normalColor;
    }
    
    //need create 2 times the same Font and change the outline of one of them
}