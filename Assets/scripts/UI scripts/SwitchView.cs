using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{

	[SerializeField] GameObject MainCam;
	[SerializeField] GameObject TopCam;
	

	bool onMainLevel;

	public static SwitchView sw;

	[HideInInspector]
	public bool canMoveObject;

	void Start()
	{
		sw = this;
		canMoveObject = false;
		onMainLevel = false;
	}

	public void toggleCam()
	{

		if (onMainLevel)
		{

			MainCam.SetActive(true);
			TopCam.SetActive(false);
			canMoveObject = false;
			onMainLevel = false;
			ObjectController.oc.HideObjectTool();

		}
		else
		{

			MainCam.SetActive(false);
			TopCam.SetActive(true);
			canMoveObject = true;
			onMainLevel = true;
			
		}

	}

}

