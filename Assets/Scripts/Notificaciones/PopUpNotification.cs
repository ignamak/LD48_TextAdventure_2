using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpNotification : MonoBehaviour
{

    public Notification_SO welcomeNotification;

    public SystemMessagesReader systemMessagesReader;
    public Text notificationTitle;

    public float notificationDelay = 3f;
    RectTransform rectTransform;

    Vector3 hidePosition;
    Vector3 showPosition;

    bool movingNotification;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        hidePosition = new Vector3(320, 0, 0);
        showPosition = new Vector3(-257, 0, 0);
        SendNotification(welcomeNotification);
    }

    // Update is called once per frame
    void Update()
    {
        ////-----------------------------------------------------------DEBUG----------ESTO HABRA QUE QUITARLO
        //if (Input.GetKeyDown(KeyCode.H) && !movingNotification)
        //{
        //    movingNotification = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.H))
        //{
        //    movingNotification = false;
        //}
        ////-----------------------------------------------------------------------


        //switch (movingNotification)
        //{
        //    case true:
        //        //Vector3(-257,0,0)
        //        //rectTransform.position = Vector3.MoveTowards(rectTransform.position, showPosition , 200f * Time.deltaTime);              
        //        //Debug.Log("position = "+ rectTransform.anchoredPosition);

        //        break;
        //    case false:
        //        //rectTransform.position = Vector3.MoveTowards(rectTransform.position, hidePosition, 3.5f * Time.deltaTime);
        //        break;
        //}
    }

    public void MoveNotification(bool inOut) 
    {
        gameObject.SetActive(inOut);

      
        //movingNotification = inOut;      
    }

    public void OnNotificationClick(ButtonState button) 
    {
        MoveNotification(false);

        DesktopManager desktopManager = GameObject.FindObjectOfType<DesktopManager>();
        desktopManager.OpenPanel(button);
        systemMessagesReader.HacerLaNapa();
        //desktopManager.OpenPanel(SystemMessages);
    }

    public void SendNotification(Notification_SO notification)
    {
        StartCoroutine(NotificationDelay());
        MoveNotification(true);
        notificationTitle.text = notification.getTitle();
        systemMessagesReader.CreateNewMessage(notification);
        AudioManager.instance.Play("notificationSound");
    }
    IEnumerator NotificationDelay()
    {
        yield return new WaitForSeconds(notificationDelay);
    }

    
}
