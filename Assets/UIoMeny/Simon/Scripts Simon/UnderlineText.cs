using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UnderlineText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    TextMeshProUGUI currentText;

    [SerializeField]
    string Text;
    public void OnPointerEnter(PointerEventData eventData)
    {
        currentText.text = $"<u>{Text}</u>";
        print("point");
    }

    public void OnPointerExit (PointerEventData eventData) 
    {
        currentText.text = Text;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentText.text = Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopUnderline();
        }
    }

    public void StopUnderline()
    {
        currentText.text = Text;
    }
}
