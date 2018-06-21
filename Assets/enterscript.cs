using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterscript : MonoBehaviour, IInteractable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnCollisionEnter(Collision other)
	{
		Debug.Log(other.GetType());
	}

	public void Interact(GameObject sender)
	{
		Debug.Log(sender.GetType());
	}
}
