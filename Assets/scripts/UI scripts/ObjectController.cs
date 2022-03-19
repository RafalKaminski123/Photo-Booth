using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

	[SerializeField] GameObject objectTool;
	[SerializeField] GameObject objectChooser;

	public static ObjectController oc;

	[SerializeField] public string selectedObject;

	void Start()
	{

		oc = this;
	}

	public void RotateLeft()
	{
		try
		{
			GameObject.Find(selectedObject).transform.Rotate(0.0f, -45f, 0.0f, Space.World);
		}
		catch 
		{
			Debug.Log("Object not found!");
		}
	}

	public void RotateRight()
	{
		try
		{
			GameObject.Find(selectedObject).transform.Rotate(0.0f, 45f, 0.0f, Space.World);
		}
		catch 
		{
			Debug.Log("Object not found!");
		}
	}

	public void RemoveObject()
	{
		try
		{
			HideObjectTool();
			Destroy(GameObject.Find(selectedObject));
		}
		catch 
		{
			Debug.Log("Object not found!");
		}
	}

	public void ShowObjectChooser()
	{
		objectChooser.SetActive(true);
	}

	public void HideObjectChooser()
	{
		objectChooser.SetActive(false);
	}

	public void ShowObjectTool()
	{
		objectTool.SetActive(true);
	}

	public void HideObjectTool()
	{
		objectTool.SetActive(false);
	}

	public void AddObjectToScene(string objectName)
	{
		GameObject newObjectForScene = Instantiate(Resources.Load(objectName) as GameObject);
		newObjectForScene.name = newObjectForScene.name + UnityEngine.Random.Range(111, 999);
	}

}

