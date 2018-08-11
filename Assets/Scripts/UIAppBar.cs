using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIAppBar : MonoBehaviour
{
	[SerializeField] private UIMeter coolMeter;
	[SerializeField] private UIMeter diskMeter;

	private void OnEnable()
	{
		PhoneController.OnPhoneInitialize += InitializeMeters;
		PhoneController.OnCoolMeterUpdate += coolMeter.SetValue;
		PhoneController.OnDiskSpaceUpdate += diskMeter.SetValue;
	}

	private void OnDisable()
	{
		PhoneController.OnPhoneInitialize -= InitializeMeters;
		PhoneController.OnCoolMeterUpdate -= coolMeter.SetValue;
		PhoneController.OnDiskSpaceUpdate -= diskMeter.SetValue;
	}

	private void InitializeMeters(PhoneState phoneState)
	{
		coolMeter.SetMaxValue(phoneState.coolMeterMax);
		coolMeter.SetValue(phoneState.coolMeterCurrent);
		diskMeter.SetMaxValue(phoneState.diskSpaceMax);
		diskMeter.SetValue(phoneState.diskSpaceCurrent);
	}
}
