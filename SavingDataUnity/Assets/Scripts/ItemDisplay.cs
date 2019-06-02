using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
	public ItemBlock blockPrefab;

	private void Start()
	{
		Display();
	}

	public void Display()
	{
		foreach(Transform child in transform)
		{
			Destroy(child.gameObject);
		}

		foreach(ItemEntry item in XMLManager.instance.itemDB.list)
		{
			ItemBlock newBlock = Instantiate(blockPrefab) as ItemBlock;
			newBlock.transform.SetParent(transform, false);

			// set ui of the item
			newBlock.Display(item);
		}
	}
}
