using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public enum States
    {
        Start,
        Play,
        Pause,
        GameOver,
        Success
    };

    public static GameManager Instance { get; private set; }

    const string keyReset = "reset";

    public States gameState;

    PanelManager panelMngr;
    // SocialManager socialMngr;

    GameObject gg;

    [SerializeField]
    GameObject Garage;

    void Awake()
    {
        Application.targetFrameRate = 60;

        Instance = this;

        gameState = States.Start;

        panelMngr = GetComponent<PanelManager>();
        // socialMngr = GetComponent<SocialManager>();

        // TODO: to remove the line
        PlayerPrefs.DeleteAll();    
    }

    void Start()
    {
        // Garage.GetComponent<CarsController>().CarId = PlayerPrefs.GetInt("ChosenCar");

        if (PlayerPrefs.GetInt("ActiveLevelNumber") == 0)
        {
            PlayerPrefs.SetInt("ActiveLevelNumber", 1);
        }

        // socialMngr.AuthenticateGameServices();
        // if (PlayerPrefs.GetInt(keyReset) == 1)
        // {
        //     PlayerPrefs.SetInt(keyReset, 0);

        //     Play();
        // }

        PlayerPrefs.SetInt(LevelManager.IsPlay, 1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void leftTurn()
    {
        Garage.GetComponentInChildren<Drift>().leftt = true;
    }

    public void rightTurn()
    {
        Garage.GetComponentInChildren<Drift>().rightt = true;
    }

    public void leftOff()
    {
        Garage.GetComponentInChildren<Drift>().leftt = false;
    }
    public void rightOff()
    {
        Garage.GetComponentInChildren<Drift>().rightt = false;
    }

    
	public void ChangeCar(int id)
	{
    	// if(PlayerPrefs.GetInt("Selected") == 1)
        // {    
            PlayerPrefs.SetInt("ChosenCar", id);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            // Garage.GetComponent<CarsController>().CarId = id;

            // PlayerPrefs.SetInt("Selected", 0);
        // }        
	}

	public void ChangeUICar(int id)
	{
        ModelRotation mr = GameObject.Find("3dCarModel").GetComponent<ModelRotation>();

        for(var t=0; t<mr.carModels.Count; t++)
        {
            mr.carModels[t].SetActive(false);
        }
    
        mr.carModels[id].SetActive(true);
	}

    public bool IsStart()
    {
        return gameState == States.Start;
    }

    public bool IsPlay()
    {
        return gameState == States.Play;
    }

    public void Play()
    {
        // PlayerPrefs.SetInt(LevelManager.IsPlay, 1);
        panelMngr.ShowHUDPanel();

        gameState = States.Play;    

        // PlayerPrefs.SetInt(LevelManager.IsPlay, 1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.DeleteKey("GameScorePrefs");

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // public void Pause()
    // {
    //     if (IsPlay()) gameState = States.Pause;
    // }

    // public void Unpause()
    // {
        // if (gameState == States.Pause) 
        // gameState = States.Play;
    //     if (gameState == States.Pause) gameState = States.Play;
    // }

    // public void GameOver(int score)
    // {
    //     gameState = States.GameOver;
    //     panelMngr.ShowGameOverPanel();

    //     Analytics.CustomEvent("game_over", new Dictionary<string, object>
    //     {
    //         {"score", score}
    //     });
    // }
    public void GameOver()
    {
        gameState = States.GameOver;
        panelMngr.ShowGameOverPanel();
        // AdsManager.Instance.ShowInterstitialAdDelayed();
    }
    public void Success()
    {
        gameState = States.Success;
        panelMngr.ShowSuccessPanel();

        // AdsManager.Instance.ShowInterstitialAdDelayed();
    }

    public bool isSuccess()
    {
        return gameState == States.Success;
    }
    public void Restart()
    {
        // PlayerPrefs.SetInt("ActivelevelNumber", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Replay()
    {
        PlayerPrefs.SetInt(LevelManager.IsPlay, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        // print("activeLevelNumber");
        PlayerPrefs.SetInt("ActiveLevelNumber",  PlayerPrefs.GetInt("ActiveLevelNumber")+1);
        // PlayerPrefs.Save();
        Replay();

        // if(PlayerPrefs.GetInt("UnlockedLvl") < PlayerPrefs.GetInt("activeLevelNumber")){
        //     GetComponent<LevelManager>().levelsButton[PlayerPrefs.GetInt("UnlockedLvl")+1].GetComponent<Button>().interactable = true;
        //     PlayerPrefs.SetInt("UnlockedLvl", PlayerPrefs.GetInt("UnlockedLvl")+1);
        // } else {

        // }
    }


    // public void Next()
    // {

    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //     // panelMngr.ShowHomePanel();
        
    //     // ts.stack = 8;
    // }

    // public void ResetTutorial()
    // {
        // PlayerPrefs.SetInt(TipController.IsTip, 0);
    //     Reset();
    // }

    // public void Reset()
    // {
        // PlayerPrefs.SetInt(keyReset, 1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    // public SocialManager SocialMngr
    // {
        // get { return socialMngr; }
    // }

    public PanelManager PanelMngr
    {
        get { return panelMngr; }
    }

    void OnApplicationPause() 
    {
        PlayerPrefs.Save(); 
    }


    // void Start()
	// {
	// 	car.GetComponent<SpriteRenderer>().sprite = carSprites[PlayerPrefs.GetInt("ChosenCar")];
	// }


}