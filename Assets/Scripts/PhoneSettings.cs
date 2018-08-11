using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhoneSettings", menuName = "LD42/Phone Settings")]
public class PhoneSettings : ScriptableObject
{
	public int diskSpace;

	public List<AppData> installedApps;
}
