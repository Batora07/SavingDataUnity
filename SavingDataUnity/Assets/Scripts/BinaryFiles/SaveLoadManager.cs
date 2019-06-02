using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{
    public static void SavePlayer(Player player)
	{
		BinaryFormatter bf = new BinaryFormatter();

		string fileName = Application.persistentDataPath + "/SaveData/player.sav";

		Directory.CreateDirectory(Path.GetDirectoryName(fileName));

		using(FileStream fs = new FileStream(fileName, FileMode.Create))
		{
			PlayerData data = new PlayerData(player);

			bf.Serialize(fs, data);
			fs.Close();
		}
		Debug.Log("File saved at : " + fileName);
	}

	public static int[] LoadPlayer()
	{
		if(File.Exists(Application.persistentDataPath + "/SaveData/player.sav"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream stream = new FileStream(Application.persistentDataPath + "/SaveData/player.sav", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize(stream);

			stream.Close();
			return data.stats;
		}
		else
		{
			Debug.LogError("File does not exists.");
			return new int[4];
		}
	}
}

[Serializable]
public class PlayerData
{
	public int[] stats;

	public PlayerData(Player player)
	{
		stats = new int[4];
		stats[0] = player.level;
		stats[1] = player.health;
		stats[2] = player.attack;
		stats[3] = player.defense;
	}
}
