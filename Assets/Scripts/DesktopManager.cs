using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesktopManager : MonoBehaviour
{
    public int delayToRestart = 2;

    GameObject openPanel;
    ButtonState currentButton; //ref to the script

    private void Start()
    {
        openPanel = null;
        currentButton = null;
    }
    public void OpenPanel(ButtonState b)
    {
        CloseCurrentPanel();
        if (b)
        {
            b.associatedPanel.SetActive(true);
            b.SelectButton();
            currentButton = b;
        }

    }
    public void CloseCurrentPanel()
    {

        if (currentButton)
        {
            currentButton.associatedPanel.SetActive(false);
            currentButton.ActiveButton();

            //AudioManager.instance.Play("openPanelSound");

        }
    }
    public void RestartGame()
    {
        StartCoroutine(LoadGameAgain());
    }
    IEnumerator LoadGameAgain()
    {
        AudioManager.instance.Play("restartSound");

        yield return new WaitForSeconds(delayToRestart);

        SceneManager.LoadScene(0);
    }
}
