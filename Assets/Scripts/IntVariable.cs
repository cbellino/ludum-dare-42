using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Variable", menuName = "LD42/Int Variable")]
[System.Serializable]
public class IntVariable : ScriptableObject
{
	public int current;
	[SerializeField] private bool persistent = false;
	[HideIf("persistent")][SerializeField] private int value;

	private void OnEnable()
	{
		if (!persistent)
		{
			current = value;
		}
	}
}
