using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AImessage currentKimMessage;
    public AImessage currentJerryMessage;
    public AImessage currentLauraMessage;
    public AImessage currentMarkMessage;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
