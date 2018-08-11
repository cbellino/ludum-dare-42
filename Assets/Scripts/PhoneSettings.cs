using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhoneSettings", menuName = "LD42/PhoneSettings")]
public class PhoneSettings : ScriptableObject
{
	public int diskSpace;
	public int cool;
	public List<AppData> apps;
}
