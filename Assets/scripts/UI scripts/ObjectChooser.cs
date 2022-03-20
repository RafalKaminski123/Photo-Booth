using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectChooser : MonoBehaviour
{
	[SerializeField] Button addObjectButtonPrefab;
	[SerializeField] Transform container;
	public string[] availableObjects;

	void Start()
	{
		for (int i = 0; i < availableObjects.Length; i++)
		{
			MakeButton(availableObjects[i], i);
		}
	}

	public void MakeButton(string objectName, int index)
	{
		Button button = Instantiate(addObjectButtonPrefab, container.transform);
		button.image.sprite = Resources.Load<Sprite>("Input/"+objectName + "-thumb");
		button.onClick.AddListener(() => AddNewObjectToScene(objectName, index));
	}

	public void AddNewObjectToScene(string objectName, int index)
	{
		Debug.Log("Adding " + objectName + " to scene.");
		ObjectController.oc.HideObjectChooser();
		ObjectController.oc.AddObjectToScene(objectName, index);

	}
}