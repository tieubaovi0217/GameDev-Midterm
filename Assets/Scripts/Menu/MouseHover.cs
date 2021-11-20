using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite originalSprite;
    public Sprite onHoverSprite;
    private Image buttonImage;
    private RectTransform buttonRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = gameObject.GetComponent<Button>().image;
        buttonRectTransform = gameObject.GetComponent<RectTransform>();
        buttonImage.sprite = originalSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = onHoverSprite;
        buttonRectTransform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = originalSprite;
        buttonRectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
