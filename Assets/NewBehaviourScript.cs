using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
	private Text componenetText;
	
	// Use this for initialization
	void Start ()
	{
		componenetText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnGUI()
	{
		componenetText.text = Player.firecount.ToString();
	}
}
