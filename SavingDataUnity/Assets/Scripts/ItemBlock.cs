using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBlock : MonoBehaviour
{
	public Text name, material, value;

	public void Display(ItemEntry item)
	{
		name.text = item.itemName;
		material.text = item.material.ToString();
		value.text = "$" + item.value.ToString();
	}
}