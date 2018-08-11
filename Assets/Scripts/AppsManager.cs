using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AppsManager : MonoBehaviour
{
	public delegate void AppInstallAction(App app);
	public static event AppInstallAction OnAppInstall = delegate { };
	public delegate void AppUninstallAction(App app);
	public static event AppUninstallAction OnAppUninstall = delegate { };

	[SerializeField] private GameObject appPrefab;
	[SerializeField] private Transform appsContainer;

	private List<App> installedApps = new List<App>();

	private void OnEnable()
	{
		App.OnUninstall += UninstallApp;
		PhoneController.OnPhoneInitialize += AddInstalledApps;
	}

	private void OnDisable()
	{
		App.OnUninstall -= UninstallApp;
		PhoneController.OnPhoneInitialize -= AddInstalledApps;
	}

	private void AddInstalledApps(PhoneState phoneState)
	{
		foreach (AppData data in phoneState.installedApps)
		{
			InstallApp(data);
		}
	}

	private void InstallApp(AppData data)
	{
		var app = InstantiateApp(data);
		installedApps.Add(app);
		OnAppInstall(app);
	}

	private void UninstallApp(App app)
	{
		Debug.Log("Uninstalling app: " + app.name);

		OnAppUninstall(app);
		installedApps.Remove(app);
		GameObject.Destroy(app.gameObject);
	}

	private App InstantiateApp(AppData data)
	{
		var instance = GameObject.Instantiate(appPrefab);
		instance.transform.SetParent(appsContainer);

		var app = instance.GetComponent<App>();
		app.Initialize(data);

		return app;
	}
}
