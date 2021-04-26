using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactManager : MonoBehaviour
{
    GameObject openConversation;
    MessageAppManager messageAppManager;

    public InputField inputField;
    public GameObject emptyConversation;
    public Sprite bgSelectedConversation;
    public Sprite bgConversation;

    [Header("AI 1")]
    public GameObject ai1Contact;
    public GameObject ai1Conversation;
    public int ai1Number = 1;

    [Header("AI 2")]
    public GameObject ai2Contact;
    public GameObject ai2Conversation;
    public int ai2Number = 2;

    [Header("AI 3")]
    public GameObject ai3Contact;
    public GameObject ai3Conversation;
    public int ai3Number = 3;

    [Header("AI 4")]
    public GameObject ai4Contact;
    public GameObject ai4Conversation;
    public int ai4Number = 4;

    public GameObject[] allContacts;

    public int loadAllContacts = 0;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenContactConversation(GameObject targetConversation)
    {
        if (openConversation)
        {
            openConversation.SetActive(false);
            targetConversation.SetActive(true);
            
        }
        else
        {
            emptyConversation.SetActive(false);
            targetConversation.SetActive(true);
            
        }
        messageAppManager = targetConversation.GetComponentInParent<MessageAppManager>();
        if (messageAppManager.currentMessageSent)
            messageAppManager.SetUpPlayerOptions();
        else
            messageAppManager.CheckConversationType();



        //AudioManager.instance.Play("onClickSound");        
        openConversation = targetConversation;
    }
    public void ChangeBgImages(GameObject selectedChat) //change the image background to visualize selected chat
    {
        foreach (var contact in allContacts)
        {
            Image bg = contact.GetComponent<Image>();
            bg.sprite = bgConversation;
            if (selectedChat == contact)
                bg.sprite = bgSelectedConversation;
                
        }
    }
    public void GetMessage()
    {

        AudioManager.instance.Play("onClickSound");
        messageAppManager.newPlayerMessage();

    }
    public void CloseCurrentPanel()
    {
        openConversation.SetActive(false);
    }

    public void CheckNumber(int number)
    {
        AudioManager.instance.Play("onClickSound");
        if (number == ai1Number)
        {
            ai1Contact.SetActive(true);
            Debug.Log("contact active");
        }
        else if (number == ai2Number)
        {
            ai2Contact.SetActive(true);
            Debug.Log("contact active");
        }
        else if (number == ai3Number)
        {
            ai3Contact.SetActive(true);
            Debug.Log("contact active");
        }
        else if (number == ai4Number)
        {
            ai4Contact.SetActive(true);
            Debug.Log("contact active");
        }
    }

    public void CheckNumber()
    {
        AudioManager.instance.Play("onClickSound");
        if (int.Parse(inputField.text) == ai1Number)
        {
            ai1Contact.SetActive(true);
            Debug.Log("contact active");
        }
        else if (int.Parse(inputField.text) == ai2Number)
        {
            ai2Contact.SetActive(true);
            Debug.Log("contact active");
        }
        else if (int.Parse(inputField.text) == ai3Number)
        {
            ai3Contact.SetActive(true);
            Debug.Log("contact active");
        }
        else if (int.Parse(inputField.text) == ai4Number)
        {
            ai4Contact.SetActive(true);
            Debug.Log("contact active");
        }
        else if (int.Parse(inputField.text) == loadAllContacts)
        {
            for (int i = 0; i < allContacts.Length; i++)
            {
                allContacts[i].SetActive(true);
            }
            Debug.Log("all contacts are active");
        }
    }
}
