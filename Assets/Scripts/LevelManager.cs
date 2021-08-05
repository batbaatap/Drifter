using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	public List<GameObject> levels = new List<GameObject>();
	// public List<GameObject> levelsButton = new List<GameObject>();
	// public const string ActiveLevelNumber = "activeLevelNumber";
	public const string IsPlay = "IsPlay";
	
	// public const string UnlockedLvl = "UnlockedLvl";
	// public const string Again = "Again";

	void Start(){
		// Debug.Log(PlayerPrefs.GetInt("ActiveLevelNumber"));

		// print("Active Level Number: " + PlayerPrefs.GetInt(ActiveLevelNumber));
		
		// print("isPlay: " + PlayerPrefs.GetInt("ActiveLevelNumber"));
	}

	void Update()
	{
		if(PlayerPrefs.GetInt(IsPlay) == 1)
		{
			// active levelnumber dahij achaallahdaa 0 -oos ehelj achaallana tiim uchraas scene level 1 ee dahij duudaad bga 
			Instantiate(levels[PlayerPrefs.GetInt("ActiveLevelNumber", 1)], new Vector3(0, -0.12f,0), Quaternion.identity);
			// GameManager.Instance.ShowHUDPanel();
			
			// GameObject.Find("Flappy").GetComponent<PlayerController>().Score = PlayerPrefs.GetInt(ActiveLevelNumber);

			PlayerPrefs.SetInt(IsPlay, 0);
			// active levelnumber dahij achaallahdaa 0 -oos ehelj achaallana tiim uchraas level number n level 1 iig davsan ch gsn dahina level 1 
			GameObject.Find("LevelNumber").GetComponent<Text>().text =  "LEVEL " + PlayerPrefs.GetInt("ActiveLevelNumber", 1);
			
			// GameManager.Instance.gameState = GameManager.States.Play;
		}
	}

	

	// public void ManageWorld(int levelNumber) {
	// 	PlayerPrefs.SetInt(ActiveLevelNumber, levelNumber);
	// 	PlayerPrefs.SetInt(IsPlay, 1);
	// 	PlayerPrefs.SetInt(Again, levelNumber);

	// 	if(PlayerPrefs.GetInt(UnlockedLvl) < levelNumber){
	// 		PlayerPrefs.SetInt(UnlockedLvl, levelNumber);
	// 	} else {
	// 		print("suuliin ue davsan utga hadgalagdana");
	// 	}

	// 	GameManager.Instance.Replay();
	// }
	
	// public void WorldOne(int buttonNumber){
	// 	ManageWorld(buttonNumber);
	// }
}