using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsManager : MonoBehaviour
{
	[SerializeField] private PhoneSettings phoneSettings;
	[SerializeField] private GameObject appPrefab;
	[SerializeField] private Transform appsContainer;

	private List<App> apps = new List<App>();

	private void Start()
	{
		foreach (AppData data in phoneSettings.apps)
		{
			var app = InstantiateApp(data);
			apps.Add(app);
		}
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
