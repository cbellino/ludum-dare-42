using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMeter : MonoBehaviour
{
	[SerializeField] private Slider slider;

	public void SetValue(int value)
	{
		slider.value = value;
	}

	public void SetMaxValue(int value)
	{
		slider.maxValue = value;
	}
}
