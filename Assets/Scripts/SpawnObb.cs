using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObb : MonoBehaviour {

	[System.Serializable]
	public class DropCurrency
	{
		public string name;
		public GameObject item;
		public int dropRarity;
	}

	public List <DropCurrency> LootTable = new List<DropCurrency> ();

	public int DropChance;
	public float x;

	public float tutam;

	public void Start()
	{

        calculateLoot();

    }




	public void calculateLoot()	{
		int calc_dropChance = Random.Range (0, 101);

		if (calc_dropChance > DropChance) {

			return;
		}

		if(calc_dropChance <= DropChance){
			int itemWeight = 0;
			for(int i = 0 ; i < LootTable.Count; i++	)
			{
				itemWeight += LootTable[i].dropRarity;
			}
			int randomValue = Random.Range(0,itemWeight);
			for(int j = 0; j < LootTable.Count; j++ )
			{
				if(randomValue <= LootTable[j].dropRarity)
				{


                    LootTable[j].item.gameObject.SetActive(true);
					//	Instantiate (LootTable[j].item, new Vector3 (x*tutam, y, 0), Quaternion.identity);
						
						return;
					




				}
				randomValue -= LootTable [j].dropRarity;
			}

		}




	}











}
