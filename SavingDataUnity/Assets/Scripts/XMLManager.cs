using System.Collections;
using System.Collections.Generic;	// lets us use lists
using UnityEngine;
using System.Xml;					// basic XML attributes
using System.Xml.Serialization;		// access xmlSerialiser
using System.IO;					// file management

public class XMLManager : MonoBehaviour
{
	public static XMLManager instance;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	/// <summary>
	/// lists of items
	/// </summary>
	public ItemDatabase itemDB;

	// save function
	public void SaveItems()
	{
		// open a new xml file
		XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
		/**
		 * classical way of serializing streams
		 * */
		 /* FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/Data/XML/item_data.xml", FileMode.Create);
			serializer.Serialize(stream, itemDB); */

		// this method prevents errors with encoding streams
		var encoding = System.Text.Encoding.GetEncoding("UTF-8");
		using(var stream = new StreamWriter(Application.dataPath + "/StreamingAssets/Data/XML/item_data.xml", false, encoding))
		{
			serializer.Serialize(stream, itemDB);
			stream.Close();
		}
		// stream.Close();
	}

	// load function
	public void LoadItems()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
		FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/Data/XML/item_data.xml", FileMode.Open);
		itemDB = (ItemDatabase)serializer.Deserialize(stream);
		stream.Close();
	}
}

[System.Serializable]
public class ItemEntry
{
	public string itemName;
	public Material material;
	public int value;
}

[System.Serializable]
public class ItemDatabase
{
	[XmlArray("CombatEquipment")]
	public List<ItemEntry> list = new List<ItemEntry>();
}

public enum Material
{
	Wood,
	Copper,
	Iron,
	Steel,
	Obsidian
}