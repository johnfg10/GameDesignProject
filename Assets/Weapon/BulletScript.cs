using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	private float speed = 2;
	private Rigidbody _rigidbody;
	
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		_rigidbody = this.GetComponent<Rigidbody>();
		StartCoroutine("Kill");
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.position = transform.forward * speed;
	}

	IEnumerator Kill()
	{
		yield return new WaitForSecondsRealtime(10);
		Destroy(gameObject);
	}

	private void FixedUpdate()
	{
		//this.transform.position = this.transform.forward * speed;
	}
}
