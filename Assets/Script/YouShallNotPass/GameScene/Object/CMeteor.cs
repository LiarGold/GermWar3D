using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMeteor : MonoBehaviour
{
	public ParticleSystem _impactParticle = null;

	//! 피탄되었을 경우
	public void OnCollisionEnter(Collision collision)
	{
		var impactPos = collision.contacts[0].point;
		var impactDir = impactPos - transform.position;

		_impactParticle.transform.position = impactPos;
		_impactParticle.transform.Rotate(-impactDir);
		_impactParticle.Play();

		Destroy(collision.gameObject, 1.0f);
	}
}
