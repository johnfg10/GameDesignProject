using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

	public int Range = 200;
	public int Speed = 10;
	public GameObject GunObject;
	public GameObject FirePoint;
	
	public Rigidbody Bullet;
	public Time lastFire;
	public GameObject bulletRef = null;
	
	
	// Use this for initialization
	void Start ()
	{
		//FirePoint = GetComponentInChildren<GameObject>();
		FirePoint = GameObject.FindGameObjectWithTag("FirePoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire()
	{
		if (bulletRef != null)
		{
			return;
		}
		Debug.Log("firing");
		Debug.Log(FirePoint.transform);

		//var gameobject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//var rigid = gameobject.AddComponent<Rigidbody>();
		
/*		var bullet = Instantiate(Resources.Load("/Weapon/Sphere (2).prefab"), 
			FirePoint.transform.position, 
			FirePoint.transform.rotation) as GameObject;*/
/*		var bullet = Instantiate(Resources.Load("Sphere (2).prefab"), 
			FirePoint.transform.position, 
			FirePoint.transform.rotation) as GameObject;*/
/*		var bullet = Instantiate(Resources.Load("Bullet 1"), 
			FirePoint.transform.position,
			FirePoint.transform.rotation) as GameObject;	*/	
/*		var bullet = Instantiate(Resources.Load("bullet2"), 
			FirePoint.transform.position, 
			FirePoint.transform.rotation) as GameObject;*/
/*		var bullet = Instantiate(Resources.Load("/Weapon/bullet2"), 
			FirePoint.transform.position, 
			FirePoint.transform.rotation) as GameObject;*/
/*
		var bullet = Instantiate(Resources.Load("/Weapon/bullet2.prefab"), 
			FirePoint.transform.position, 
			FirePoint.transform.rotation) as GameObject;
*/

/*		var bullet = Instantiate(Bullet, 
			FirePoint.transform.position, 
			FirePoint.transform.rotation);*/
		var bullet = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), 
			FirePoint.transform.position + transform.forward,
			FirePoint.transform.rotation) as GameObject;	
		System.Diagnostics.Debug.Assert(bullet != null, "bullet != null");
	
		var rigid = bullet.AddComponent<Rigidbody>();
		rigid.mass = 0.00000000001f;
		rigid.useGravity = false;
		rigid.velocity = transform.forward * 50;
		
		Destroy(bullet, 1);
	}
}
