using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "App", menuName = "LD42/AppData")]
public class AppData : ScriptableObject
{
	public new string name;
	public Sprite icon;
	public int size;
	public int cool;
}
