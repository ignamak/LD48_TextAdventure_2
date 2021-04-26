using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI message")][System.Serializable]
public class AImessage : ScriptableObject
{
    public string aiName;
    public enum Type
    {
        PLAYER_STARTS,
        AI_STARTS_FOLLOWS_TALKING,
        AI_STARTS_WAITING_PLAYER,
        END_MESSAGE
    }
    public Type conversationType;
    [TextArea(10, 14)] public string messageText;

    public PlayerAnswer[] playerAnswers;
    public AImessage nextAiMessage;

    public Notification_SO launchedNotification;
    public AImessage launchedOtherAiMessage;

    public bool sent = false;

    public string GetAIName()
    {
        return aiName;
    }
    public string GetMessage()
    {
        return messageText;
    }
}

