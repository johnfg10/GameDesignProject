using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteract : MonoBehaviour, IInteractable {

	public void Interact(GameObject sender)
	{
		print("i have been interacted with");
	}
}
