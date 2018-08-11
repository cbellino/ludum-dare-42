using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
	private UIApp ui;
	private AppData data;

	private void Awake()
	{
		ui = GetComponent<UIApp>();
	}

	public void Initialize(AppData data)
	{
		this.data = data;

		SyncUI();
	}

	private void SyncUI()
	{
		name = data.name;

		ui.SetData(data);
	}
}
