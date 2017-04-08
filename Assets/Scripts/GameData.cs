using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameData : MonoBehaviour {

	public static GameData data;
	public int score;
	// Use this for initialization
	void Awake () {
		if (data == null )
		{
			DontDestroyOnLoad(gameObject);
			data = this;
		}
		else if (data != this) Destroy(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Save()
	{
		//DOESN'T WORK ON WEB
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/gameData.dat");
		DataClean data = new DataClean();
		data.score = this.score;
		bf.Serialize(file, data);
		file.Close();

	}

	public void Load()
	{
		//DOESN'T WORK ON WEB
		if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
			DataClean data = (DataClean) bf.Deserialize(file);
			file.Close();
			score = data.score;
		}

	}
}

[Serializable]
class DataClean
{
	
	public int score;
}
