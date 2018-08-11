using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIApp : MonoBehaviour
{
	[SerializeField] private Text nameText;
	[SerializeField] private Image iconImage;
	[SerializeField] private Text coolText;
	[SerializeField] private Text diskText;

	public void SetName(string name)
	{
		nameText.text = name;
	}

	public void SetIcon(Sprite sprite)
	{
		iconImage.sprite = sprite;
	}

	public void SetData(AppData data)
	{
		SetName(data.name);
		SetIcon(data.icon);

		// DEBUG
		coolText.text = "Cool: " + data.cool;
		coolText.text = "Disk: " + data.size;
	}
}
