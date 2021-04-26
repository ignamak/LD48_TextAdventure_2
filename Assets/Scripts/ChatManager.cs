using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public PopUpNotification popUpNotification;
    public ContactManager contactManager;

    public GameObject chatKim;
    public GameObject chatJerry;
    public GameObject chatLaura;
    public GameObject chatMark;

    int musicIndex = 1;
    void Start()
    {
        
    }

    public void CheckWhatChat(AImessage message)
    {
        print("CheckWhatChat");
        GameObject targetChat = null;
        int number = -1;
        if (message.name.Contains("Kim"))
        {
            targetChat = chatKim;
            number = 1;
        } else if (message.name.Contains("Jerry"))
        {
            targetChat = chatJerry;
            number = 2;
        } else if (message.name.Contains("Laura"))
        {
            targetChat = chatLaura;
            number = 3;

        } else if (message.name.Contains("Mark"))
        {
            targetChat = chatMark;
            number = 4;
        }
        targetChat.GetComponent<MessageAppManager>().currentMessage = message;
        //contactManager.OpenContactConversation(targetChat.transform.GetChild(0).gameObject);
        contactManager.CheckNumber(number);

    }

    public void SendNotification(Notification_SO notification)
    {
        popUpNotification.SendNotification(notification);

        if (musicIndex == 1)
        {
            AudioManager.instance.Play("firstSong");
        }
        if (musicIndex == 2)
        {
            AudioManager.instance.StartSecondSong();
        }
    }
}
