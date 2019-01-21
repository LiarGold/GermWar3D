using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGun : MonoBehaviour
{
	public GameObject _originBullet = null;
	public ParticleSystem _muzzleParticle = null;

	//! 총알을 발사한다
	public void ShootBullet(float power)
	{
		var bullet = Function.CreateCopiedGameObject<CBullet>("Bullet",
					_originBullet,
					CSceneManager.ObjectRoot);

		var direction = Quaternion.LookRotation(transform.right, transform.up);

		_muzzleParticle.Play();
		bullet.transform.position = _muzzleParticle.transform.position;
		bullet.transform.rotation = direction;
		bullet.ShootBullet(power);
	}
}
