using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    public Sprite activeSprite;
    public Sprite selectedSprite;
    public Sprite notificationSprite;

    public Image buttonImage;
    public GameObject associatedPanel;

    void Start()
    {
        ActiveButton();
    }

    public void SelectButton()
    {
        buttonImage.sprite = selectedSprite;
    }

    public void AlertNotification()
    {
        buttonImage.sprite = notificationSprite;
    }

    public void ActiveButton()
    {
        buttonImage.sprite = activeSprite;
    }
}
