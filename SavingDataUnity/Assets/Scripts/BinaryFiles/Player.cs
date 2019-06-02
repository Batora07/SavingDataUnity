using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int level = 1;
	public int health = 20;
	public int attack = 6;
	public int defense = 4;

	public void Save()
	{
		SaveLoadManager.SavePlayer(this);
	}

	public void Load()
	{
		int[] loadedStats = SaveLoadManager.LoadPlayer();

		level = loadedStats[0];
		health = loadedStats[1];
		attack = loadedStats[2];
		defense = loadedStats[3];

		GetComponent<PlayerDisplay>().UpdateDisplay();
	}

	// FOR UI ONLY
	public void Adjust(ref int stat, int value)
	{
		stat += value;
		if( stat <1)
		{
			stat = 1;
		}

		GetComponent<PlayerDisplay>().UpdateDisplay();
	}

	public void AdjustLevel(int value)
	{
		Adjust(ref level, value);
	}

	public void AdjustHealth(int value)
	{
		Adjust(ref health, value);
	}

	public void AdjustAttack(int value)
	{
		Adjust(ref attack, value);
	}

	public void AdjustDefense(int value)
	{
		Adjust(ref defense, value);
	}
}
