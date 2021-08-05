using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject hudPanel;
    public GameObject gameOverPanel;
    public GameObject SuccessPanel;
    public GameObject CarsPanel;

    // public GameObject settingsPanel;
    // public GameObject purchasePanel;
    // public GameObject pausePanel;

    // public GameObject warningPanel;

    public void CloseAllPanel()
    {
        homePanel.SetActive(false);
        hudPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        SuccessPanel.SetActive(false);
        CarsPanel.SetActive(false);

        /*Used Animation */
        // settingsPanel.SetActive(false);
        // purchasePanel.SetActive(false);
        // pausePanel.SetActive(false);
    }

    public void ShowHomePanel()
    {
        CloseAllPanel();
        homePanel.SetActive(true);
    }

    public void ShowHUDPanel()
    {
        CloseAllPanel();
        hudPanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        CloseAllPanel();
        gameOverPanel.SetActive(true);
    }

    public void ShowSuccessPanel()
    {
        CloseAllPanel();
        SuccessPanel.SetActive(true);
    }
    public void ShowCarsPanel()
    {
        // CloseAllPanel();
        // CarsPanel.SetActive(true);

        CloseAllPanel();
        homePanel.SetActive(true);
        CarsPanel.SetActive(true);
    }
    public void CloseCarsPanel()
    {
        StartCoroutine(ClosePanel(CarsPanel));
    }

    /*Start Settings Panel*/
    // public void ShowSettingsPanel()
    // {
        // CloseAllPanel();
        // homePanel.SetActive(true);
        // settingsPanel.SetActive(true);
        // OpenPanel(settingsPanel);
    // }

    // public void CloseSettingsPanel()
    // {
    //     StartCoroutine(ClosePanel(settingsPanel));
    // }
    /*End Settings Panel*/


    /* Start Purchase Panel */
    // public void ShowPurchasePanel()
    // {
        // GameManager.Instance.Pause();
        // CloseAllPanel();
        // homePanel.SetActive(true);
        // purchasePanel.SetActive(true);
        // OpenPanel(purchasePanel);
    // }

    // public void ClosePurchasePanel()
    // {
    //     StartCoroutine(ClosePanel(purchasePanel));

    //     GameManager.Instance.Unpause();
    // }
    /* End Purchase Panel */

    // public void ShowWarningPanel()
    // {
    //     warningPanel.SetActive(true);
    //     GameManager.Instance.Pause();
    // }

    // public void CloseWarningPanel()
    // {
    //     StartCoroutine(ClosePanel(warningPanel));
    //     GameManager.Instance.Unpause();
    // }

    /* Start Pause Panel */
    // public void ShowPausePanel()
    // {
    //     GameManager.Instance.Pause();
        // CloseAllPanel();
        // pausePanel.SetActive(true);
        // OpenPanel(pausePanel);
    // }
    
    // public void ClosePausePanel()
    // {
        // CloseAllPanel();
        // hudPanel.SetActive(true);
        // StartCoroutine(ClosePanel(pausePanel));

        // GameManager.Instance.Unpause();
    // }
    /* End Pause Panel */


    // void OpenPanel(GameObject openingPanel)
    // {
    //     openingPanel.SetActive(true);
    //     openingPanel.GetComponent<Animator>().SetTrigger("Open");
    // }

    IEnumerator ClosePanel(GameObject closingPanel)
    {
        // closingPanel.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(0.10f);
        closingPanel.SetActive(false);
    }
}
