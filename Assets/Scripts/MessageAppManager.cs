using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageAppManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI aiName;
    //[SerializeField] TextMeshProUGUI aiMessage;
    //[SerializeField] TextMeshProUGUI playerAnswer;
    public AutoScroll autoScroll;
    public Dropdown dropdown;

    public GameObject aiMessagePrefab;
    private GameObject aiMes;
    public GameObject playerAnswerPrefab;
    private GameObject playerMes;
    public GameObject messagePlaceHolder;
    public GameObject conversationPanel;

    public Sprite photoSprite;
    public ChatManager chatManager;
    public string aiNameString = "ACORDARSE DE ESCRIBIR";
    public bool aItalking;
    public bool currentMessageSent = false;
    public GameObject redDot;

    int optionChosenValue = 0;

    public AImessage currentMessage;

    
    // Start is called before the first frame update
    void Start()
    {

        dropdown.onValueChanged.AddListener(
            delegate 
            { 
                GetDropdownValue(dropdown); 
            });
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMessage != null)
        {
            aiName.text = aiNameString;
        }
        
        //aiMessage.text = currentMessage.messageText;
    }
    public void SetupAndLaunchConversation()
    {
        if (currentMessage.conversationType == AImessage.Type.PLAYER_STARTS)
            SetUpPlayerOptions();
        else
            OpenConversation();

            
    }
    public void OpenConversation()
    {
        Debug.Log("mensaje a mandar: " + currentMessage.messageText);
        if (currentMessage != null && !aItalking)
        {
            SendMessage();
        }
        else if (aItalking && !currentMessageSent)
        {
            Destroy(aiMes);
            SendMessage();
        }
        else if (currentMessage == null)
        {
            dropdown.ClearOptions();
        }
        if (conversationPanel.activeInHierarchy)
            autoScroll.SetAutoScroll();
    }

    private void SendMessage()
    {
        aItalking = true;
        if (conversationPanel.activeInHierarchy)
            dropdown.ClearOptions();
        else
            redDot.SetActive(true);
        
        aiMes = Instantiate(aiMessagePrefab);
        aiMes.transform.SetParent(messagePlaceHolder.transform);
        aiMes.SetActive(false);

        TextMeshProUGUI typingText = aiMes.transform.Find("Text AI typing").GetComponent<TextMeshProUGUI>();
        GameObject messagePanel = aiMes.transform.Find("Message Panel").gameObject;
        TextMeshProUGUI messageText = messagePanel.transform.Find("Text AI message").GetComponent<TextMeshProUGUI>();
        aiMes.transform.Find("Profile").GetComponent<Image>().sprite = photoSprite;

        StartCoroutine(AIReads(typingText, messagePanel, messageText));
    }

    public void SetUpPlayerOptions()
    {
        aItalking = false;
        if (conversationPanel.activeInHierarchy)
        {
            //Debug.Log("indicando opciones al jugador " + aiNameString);
            List<string> options = new List<string>();

            dropdown.ClearOptions();

            foreach (var option in currentMessage.playerAnswers)
            {
                options.Add(option.answer);
            }
            dropdown.AddOptions(options);
            GetDropdownValue(dropdown);
        }
    }
    public void newPlayerMessage()
    {
        if (currentMessage != null && aiMessagePrefab != null && currentMessage.playerAnswers.Length != 0)
        {
            playerAnswerPrefab.GetComponentInChildren<TextMeshProUGUI>().text = currentMessage.playerAnswers[optionChosenValue].answer;
            playerMes = Instantiate(playerAnswerPrefab);
            playerMes.transform.SetParent(messagePlaceHolder.transform);
            currentMessage = currentMessage.playerAnswers[optionChosenValue].aiMessage;
            currentMessageSent = false;
            autoScroll.SetAutoScroll();
            SetupAndLaunchConversation();
        }
    }

    IEnumerator AIReads(TextMeshProUGUI typingText, GameObject messagePanel, TextMeshProUGUI messageText)
    {
        yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
        StartCoroutine(AITyping(typingText, messagePanel, messageText));

    }

    IEnumerator AITyping(TextMeshProUGUI typingText, GameObject messagePanel, TextMeshProUGUI messageText)
    {
        aiMes.SetActive(true);
        if (conversationPanel.activeInHierarchy)
            autoScroll.SetAutoScroll();
        StartCoroutine(AITypingAnimation(typingText));
        yield return new WaitForSeconds(currentMessage.messageText.Length * 0.05f);
        StopCoroutine(AITypingAnimation(typingText));
        messageText.text = currentMessage.messageText;
        if (typingText)
            typingText.gameObject.SetActive(false);
        if (messagePanel)
            messagePanel.SetActive(true);
        aItalking = false;
        currentMessageSent = true;
        CheckIfLaunchedSomething();
        AudioManager.instance.Play("newMessage");

        //currentMessage.sent = true;

        if (currentMessage.conversationType == AImessage.Type.AI_STARTS_WAITING_PLAYER)
            SetUpPlayerOptions();
        else if (currentMessage.conversationType == AImessage.Type.AI_STARTS_FOLLOWS_TALKING)
        {
            currentMessage = currentMessage.nextAiMessage;
            currentMessageSent = false;
            OpenConversation();
        }
        else
            dropdown.ClearOptions();
            
    }

    private void CheckIfLaunchedSomething()
    {
        if (currentMessage.launchedOtherAiMessage)
        {
            chatManager.CheckWhatChat(currentMessage.launchedOtherAiMessage);
        }
        if (currentMessage.launchedNotification)
        {
            chatManager.SendNotification(currentMessage.launchedNotification);

        }
    }

    IEnumerator AITypingAnimation(TextMeshProUGUI typingText)
    {
        int counter = 0;
        while (true)
        {
            counter++;
            if (counter > 3)
            {
                typingText.text = "Typing";
                counter = 0;
            }
            else
                typingText.text += ".";
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void GetDropdownValue(Dropdown sender)
    {
        optionChosenValue = sender.value;
        //Debug.Log("You have chosen: " + sender.value);
    }
}

