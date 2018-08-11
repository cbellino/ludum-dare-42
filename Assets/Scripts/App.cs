using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
	public delegate void UninstallAction(App app);
	public static event UninstallAction OnUninstall = delegate { };
	[HideInInspector] public AppData data;

	private UIApp ui;

	private void Awake()
	{
		ui = GetComponent<UIApp>();
	}

	public void Initialize(AppData data)
	{
		this.data = data;
		SyncUI();
	}

	public void Uninstall()
	{
		OnUninstall(this);
	}

	private void SyncUI()
	{
		name = data.name;
		ui.SetData(data);
	}
}
