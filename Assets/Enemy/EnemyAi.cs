using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAi : MonoBehaviour
{
	public BoxCollider Collider;

	private Vector3 frontRight;
	
	private Vector3 backLeft;

	private Vector3 targetPosition;
	
	private bool isAlive = true;

	public static int Killed = 0;
	
	// Use this for initialization
	void Start ()
	{
		frontRight = new Vector3(transform.position.x + Collider.size.x, 
			transform.position.y + Collider.size.y,
			transform.position.z
			);
		
		frontRight = new Vector3(transform.position.x - Collider.size.x, 
			transform.position.y - Collider.size.y,
			transform.position.z
		);

		targetPosition = transform.position;
		
		StartCoroutine("RunEnumerable");
	}

	private void OnCollisionEnter(Collision other)
	{
		isAlive = false;
		
		Killed++;
		
		Destroy(this.gameObject);
	}

	// Update is called once per frame
	void Update ()
	{
		var pos = transform.position;
		if (Math.Abs(transform.position.x - targetPosition.y) > 0.05)
		{
			
			
			//pos.x = 1
		}
		if (Math.Abs(transform.position.x - targetPosition.y) > 0.05)
		{
				
		}
		
		transform.SetPositionAndRotation(pos, transform.rotation);
		
	}

	public IEnumerable RunEnumerable()
	{
		while (isAlive)
		{
			yield return new WaitForSecondsRealtime(5);
			var vec = RandomVecRange(backLeft, frontRight);
			transform.position = transform.position + vec;
		}
	}

	public Vector3 RandomVecRange(Vector3 minPos, Vector3 maxPos)
	{
		return new Vector3(
			Random.Range(minPos.x, maxPos.x),
			Random.Range(minPos.y, maxPos.y),
			Random.Range(minPos.z, maxPos.z)
			);
	}
}
