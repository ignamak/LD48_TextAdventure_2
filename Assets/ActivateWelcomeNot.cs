using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWelcomeNot : MonoBehaviour
{
    public float welcomeNotDelay = 2f;
    public GameObject welcomeNotification;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(welcomeNotificationDelay());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator welcomeNotificationDelay()
    {
        yield return new WaitForSeconds(welcomeNotDelay);
        welcomeNotification.SetActive(true);
    }
}
