using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMeter : MonoBehaviour
{
	public Slider slider;

	public void SetValue(float value)
	{
		slider.value = value;
	}

	public void AddValue(float value)
	{
		slider.value += value;
	}
}