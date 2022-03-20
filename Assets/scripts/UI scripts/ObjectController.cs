using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
	[SerializeField] GameObject objectTool;
	[SerializeField] ObjectChooser objectChooser;
	[SerializeField] GameObject addNewButton;

	private Dictionary<string, GameObject> instantiatedObjects = new Dictionary<string, GameObject>();
	public static ObjectController oc;
	public PhotoCamera photoCamera;
	public bool activetime;

	[SerializeField]
	private GameObject selectedObject;
	private int selectedObjectIndex = -1;

	void Start()
	{
		oc = this;
	}

	public void Back()
	{
		var availableObjects = objectChooser.availableObjects;
		var targetIndex = --selectedObjectIndex;
		if (targetIndex == -1)
			targetIndex = availableObjects.Length - 1;

		SwapObjects(availableObjects[targetIndex], targetIndex);
	}

	public void Forward()
	{
		var availableObjects = objectChooser.availableObjects;
		var targetIndex = ++selectedObjectIndex;
		if (targetIndex == availableObjects.Length)
			targetIndex = 0;

		SwapObjects(availableObjects[targetIndex], targetIndex);
	}

	public void TakePhoto()
	{
		photoCamera.gameObject.SetActive(true);
	}


	public void ShowObjectChooser()
	{
		objectChooser.gameObject.SetActive(true);
	}

	public void HideObjectChooser()
	{
		objectChooser.gameObject.SetActive(false);
	}

	public void ShowObjectTool()
	{
		objectTool.SetActive(true);
	}

	public void HideObjectTool()
	{
		objectTool.SetActive(false);
	}

	public void AddObjectToScene(string objectName, int index)
	{
		SwapObjects(objectName, index);
		objectTool.SetActive(true);
		addNewButton.SetActive(false);
	}

	private void SwapObjects(string objectName, int index)
	{
		if (selectedObject != null)
			selectedObject.gameObject.SetActive(false);

		var obj = InstantiateNewObject(objectName);
		selectedObject = obj;
		selectedObjectIndex = index;
		selectedObject.gameObject.SetActive(true);
	}

	private GameObject InstantiateNewObject(string objectName)
	{
		if (!instantiatedObjects.TryGetValue(objectName, out GameObject newObjectForScene))
		{
			newObjectForScene = Instantiate(Resources.Load("Input/" + objectName) as GameObject);
			newObjectForScene.name = newObjectForScene.name;
			instantiatedObjects.Add(objectName, newObjectForScene);
		}

		return newObjectForScene;
	}
}
