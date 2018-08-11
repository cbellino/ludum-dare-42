using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIApp : MonoBehaviour
{
	[SerializeField] private Text nameText;
	[SerializeField] private Image iconImage;
	[SerializeField] private Text coolText;
	[SerializeField] private Text diskText;

	public UnityEvent OnUninstall;

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
		diskText.text = "Disk: " + data.size;
	}

	public void SendUninstallEvent()
	{
		if (OnUninstall != null)
		{
			OnUninstall.Invoke();
		}
	}
}
