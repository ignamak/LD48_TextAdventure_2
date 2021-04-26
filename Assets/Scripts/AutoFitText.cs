using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoFitText : MonoBehaviour
{
    public ContentSizeFitter sizeFitter;
    public TextMeshProUGUI myText;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("TextLength = " + myText.text.Length);

        if (myText.text.Length > 50)
        {
            sizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
        } 
    }

}
