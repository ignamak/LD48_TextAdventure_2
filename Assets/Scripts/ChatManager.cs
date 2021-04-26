using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public ContactManager contactManager;

    public GameObject chatKim;
    public GameObject chatJerry;
    public GameObject chatLaura;
    public GameObject chatMark;
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
}
