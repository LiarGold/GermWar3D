using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
	public float _shootPower = 0.0f;

	//! 초기화
	public void Start()
	{
		ShootBullet(_shootPower);
	}

	//! 상태를 갱신한다

	//! 총알을 발사한다
	public void ShootBullet(float power)
	{
		var rigidBody = GetComponent<Rigidbody>();
		var rotation = new Vector3(0, this.transform.rotation.y, 0);
		rigidBody.AddForce(rotation * power,
			ForceMode.VelocityChange);
	}

}
