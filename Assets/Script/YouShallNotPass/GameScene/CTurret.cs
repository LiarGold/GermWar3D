using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTurret : MonoBehaviour
{
	public GameObject _originBullet = null;
	public GameObject _spawnPoint = null;
	public GameObject _gunObject = null;

	//! 초기화
	public void Awake()
	{
		
	}

	//! 상태를 갱신한다
	public void Update()
	{
		if (Input.GetMouseButton((int)EMouseButton.LEFT))
		{
			var bullet = Function.CreateCopiedGameObject("Bullet", _originBullet, CSceneManager.ObjectRoot);
			bullet.transform.position = _spawnPoint.transform.position;
			bullet.transform.rotation = _gunObject.transform.rotation;

			var ray = CSceneManager.MainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayCastHit;

			if (Physics.Raycast(ray, out rayCastHit))
			{

			}
		}
	}

}
