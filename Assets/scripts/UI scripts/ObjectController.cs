using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

	[SerializeField] GameObject objectTool;
	[SerializeField] GameObject objectChooser;
	[SerializeField] GameObject addNewButton;

	public static ObjectController oc;
	public PhotoCamera photoCamera;

	[SerializeField] public string selectedObject;

	void Start()
	{

		oc = this;
	}

	public void Back()
	{

	}

	public void Forward()
	{

	}

	public void TakePhoto()
    {
		photoCamera.gameObject.SetActive(true);
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
		objectTool.SetActive(true);
		addNewButton.SetActive(false);
	}

}

