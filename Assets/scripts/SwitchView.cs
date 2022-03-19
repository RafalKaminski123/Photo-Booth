using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{

	[SerializeField] GameObject MainCam;
	[SerializeField] GameObject TopCam;
	[SerializeField] GameObject PhotoCam;

	bool onEyeLevel;

	public static SwitchView sw;

	[HideInInspector]
	public bool canMoveObject;

	void Start()
	{
		sw = this;
		canMoveObject = false;
		onEyeLevel = false;
	}

	public void toggleCam()
	{

		if (onEyeLevel)
		{

			MainCam.SetActive(true);
			TopCam.SetActive(false);
			canMoveObject = false;
			onEyeLevel = false;
			ObjectController.oc.HideObjectTool();

		}
		else
		{

			MainCam.SetActive(false);
			TopCam.SetActive(true);
			canMoveObject = true;
			onEyeLevel = true;

		}

	}

}

