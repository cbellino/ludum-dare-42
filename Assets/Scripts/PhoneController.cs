using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public struct PhoneState
{
	public int coolMeterCurrent;
	public int coolMeterMax;
	public int diskSpaceCurrent;
	public int diskSpaceMax;
	public List<AppData> installedApps;
}

public class PhoneController : MonoBehaviour
{
	public delegate void PhoneInitializeAction(PhoneState phoneState);
	public static event PhoneInitializeAction OnPhoneInitialize = delegate { };

	public delegate void CoolMeterUpdateAction(int value);
	public static event CoolMeterUpdateAction OnCoolMeterUpdate = delegate { };

	public delegate void DiskSpaceUpdateAction(int value);
	public static event DiskSpaceUpdateAction OnDiskSpaceUpdate = delegate { };

	[SerializeField] private PhoneSettings phoneSettings;
	[SerializeField][ReadOnly] private int diskSpaceCurrent;
	[SerializeField][ReadOnly] private int coolMeterCurrent;

	// TODO: Maybe put this in a global config ?
	private const int coolMeterMax = 100; // This is the max cool we can have

	private void OnEnable()
	{
		AppsManager.OnAppInstall += OnAppInstall;
		AppsManager.OnAppUninstall += OnAppUninstall;
	}

	private void OnDisable()
	{
		AppsManager.OnAppInstall -= OnAppInstall;
		AppsManager.OnAppUninstall -= OnAppUninstall;
	}

	private void Start()
	{
		Initialize();
		var state = new PhoneState
		{
			coolMeterCurrent = coolMeterCurrent,
				coolMeterMax = coolMeterMax,
				diskSpaceCurrent = diskSpaceCurrent,
				diskSpaceMax = phoneSettings.diskSpace,
				installedApps = phoneSettings.installedApps,
		};
		OnPhoneInitialize(state);
	}

	private void Initialize()
	{
		coolMeterCurrent = 0;
		diskSpaceCurrent = phoneSettings.diskSpace;
	}

	private void OnAppInstall(App app)
	{
		AddCoolMeter(app.data.cool);
		AddDiskSpace(-app.data.size);
	}

	private void OnAppUninstall(App app)
	{
		AddCoolMeter(-app.data.cool);
		AddDiskSpace(app.data.size);
	}

	private void AddCoolMeter(int value)
	{
		Debug.Log("Increase cool meter -> " + value);
		coolMeterCurrent = Mathf.Clamp(
			coolMeterCurrent + value,
			0,
			coolMeterMax
		);
		OnCoolMeterUpdate(coolMeterCurrent);
	}

	private void AddDiskSpace(int value)
	{
		Debug.Log("Free disk space -> " + value);
		diskSpaceCurrent = Mathf.Clamp(
			diskSpaceCurrent + value,
			0,
			phoneSettings.diskSpace
		);
		OnDiskSpaceUpdate(diskSpaceCurrent);
	}
}
