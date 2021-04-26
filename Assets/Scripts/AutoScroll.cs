using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    ScrollRect currentScrollRect;
    Scrollbar scrollbar1;
    // Start is called before the first frame update
    void Start()
    {
        currentScrollRect = GetComponent<ScrollRect>();
        scrollbar1 = GetComponentInChildren<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AutoScrollView(ScrollRect scrollRect, float startPosition, float endPosition, float duration)
    {
        float t0 = 0.0f;

        while (t0 < 1f)
        {
            t0 += Time.deltaTime / duration;
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(startPosition, endPosition, t0);
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(startPosition, endPosition, t0);
            yield return null;
        }
    }
    public void SetAutoScroll()
    {

        StartCoroutine(AutoScrollView(currentScrollRect, scrollbar1.value, 0, 2f));
    }
}
