using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SystemMessagesReader : MonoBehaviour
{
    public GameObject textObjectsContainer;
    public GameObject MessagePrefab;

    public SystemMessagesLoader messagesLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        //-------------------------Debug----------------------Comentar o borrar luego
        if (Input.GetKeyDown(KeyCode.J))
        {
            CreateNewMessage(messagesLoader.messages_SO[Random.Range(0,messagesLoader.messages_SO.Count)]);
            //CreateNewMessage("Supertitulo", "fdiuhaòhd aoidjhoiajsd  dajois jdoaijd ad aosijd oiajdoaijsd oiajdiaj   aoisdj oajisd ajd oaj");
        }
        //-----------------------------------------------------------------------------
    }

    public void CreateNewMessage(Notification_SO messageSO) 
    {
        CreateNewMessage(messageSO.getTitle(), messageSO.getBody());
    }

    private void CreateNewMessage(string title, string msg) 
    {

        GameObject newMsg = Instantiate(MessagePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newMsg.transform.SetParent(textObjectsContainer.transform);

        List<Text> titleAndBody = newMsg.GetComponentsInChildren<Text>().ToList();

        foreach (var t in titleAndBody)
        {
            if (t.gameObject.name == "TitleText")
            {
                t.text = title;
            }

            if (t.gameObject.name == "BodyText")
            {
                t.text = msg;
            }
        }
    }

}
