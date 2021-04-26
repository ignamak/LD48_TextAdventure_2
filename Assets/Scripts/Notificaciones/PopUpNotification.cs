using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpNotification : MonoBehaviour
{

    RectTransform rectTransform;

    Vector3 hidePosition;
    Vector3 showPosition;

    bool movingNotification;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        hidePosition = new Vector3(1492.4100341796875f, 180.0f, 0);
        showPosition = new Vector3(1098.4100341796875f, 180.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //-----------------------------------------------------------DEBUG----------ESTO HABRA QUE QUITARLO
        if (Input.GetKeyDown(KeyCode.H) && !movingNotification)
        {
            movingNotification = true;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            movingNotification = false;
        }
        //-----------------------------------------------------------------------


        switch (movingNotification)
        {
            case true:
                rectTransform.position = Vector3.MoveTowards(rectTransform.position, showPosition , 2f);
                break;
            case false:
                rectTransform.position = Vector3.MoveTowards(rectTransform.position, hidePosition, 3.5f);
                break;
        }
    }

    public void MoveNotification(bool inOut) 
    {
        movingNotification = inOut;      
    }

    public void OnNotificationClick(ButtonState button) 
    {
        MoveNotification(false);

        DesktopManager desktopManager = GameObject.FindObjectOfType<DesktopManager>();
        desktopManager.OpenPanel(button);
        //desktopManager.OpenPanel(SystemMessages);
    }
}
