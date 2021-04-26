using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Notification", menuName = "SystemNotification/Notification", order = 1)]
public class Notification_SO : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] string body;

    public string getTitle() { return title; }
    public string getBody() { return body; }

}
