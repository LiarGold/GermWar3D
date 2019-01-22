using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
	//! 초기화
	public void Start()
	{
		Destroy(this.gameObject, 5.0f);
	}

	//! 총알을 발사한다
	public void ShootBullet(float power)
	{
		var rigidBody = GetComponent<Rigidbody>();
		rigidBody.AddForce(transform.forward * power,
			ForceMode.VelocityChange);
	}

	//! 충돌했을 경우
	public void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
