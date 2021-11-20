using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
    public Sprite orginalSprite;
    public Sprite onHoverSprite;
    private Image buttonImage;
    private Transform buttonRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = gameObject.GetComponent<Button>().image;
        buttonRectTransform = gameObject.GetComponent<Button>().transform;
        buttonImage.sprite = orginalSprite;
    }

    private void OnMouseOver()
    {
        buttonImage.sprite = onHoverSprite;
        Debug.Log("On Mouse Over");
    }

    private void OnMouseExit()
    {
        Debug.Log("On Mouse Exit");
        buttonImage.sprite = orginalSprite;
    }

    private void OnMouseEnter()
    {

        Debug.Log("On Mouse Enter");
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseUp()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
