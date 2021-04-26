using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMessagesLoader : MonoBehaviour
{
    public List<Notification_SO> messages_SO;

    // Start is called before the first frame update
    void Start()
    {
        messages_SO = new List<Notification_SO>();
        messages_SO.AddRange(Resources.LoadAll<Notification_SO>("Notifications")); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
