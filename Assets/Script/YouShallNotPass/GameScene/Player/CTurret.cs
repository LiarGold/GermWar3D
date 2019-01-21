using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CTurret : MonoBehaviour
{
	public GameObject[] _gunLists = null;
	public float _maxAttackSpeed = 0.0f;
	public float _shootPower = 0.0f;
	public float _angleSpeed = 0.0f;

	private float _attackSpeed = 0.0f;
	private bool _isShoot = false;

	public void Start()
	{
		_attackSpeed = _maxAttackSpeed;
	}

	//! 상태를 갱신한다
	public void Update()
	{
		if (Input.GetMouseButton((int)EMouseButton.RIGHT))
		{
			RotateTurret();
		}

		ShootBullet();

	}

	private void ShootBullet()
	{
		if (_isShoot)
		{
			_attackSpeed -= Time.deltaTime;

			if (_attackSpeed <= 0)
			{
				_isShoot = false;
			}
		}
		else
		{
			if (Input.GetMouseButton((int)EMouseButton.LEFT))
			{
				for (int i = 0; i < _gunLists.Length; ++i)
				{
					var gun = _gunLists[i].GetComponent<CGun>();
					gun.ShootBullet(_shootPower);
				}
				_attackSpeed = _maxAttackSpeed;
				_isShoot = true;
			}
		}
	}

	private void RotateTurret()
	{
		float deltaX = Input.GetAxisRaw("Mouse X");
		float deltaY = Input.GetAxisRaw("Mouse Y");

		var mainCamera = CSceneManager.MainCamera;
		var uiCamera = CSceneManager.UICamera;

		var quaternionX = Quaternion.AngleAxis(deltaX * _angleSpeed, Vector3.up);
		var quaternionY = Quaternion.AngleAxis(-deltaY * _angleSpeed, Vector3.right);

		transform.Rotate(quaternionX.eulerAngles, Space.World);
		transform.Rotate(quaternionY.eulerAngles, Space.Self);

		var limitX = transform.eulerAngles.x;

		if (transform.forward.y < -0.0001f)
		{
			limitX = Mathf.Min(limitX, 30.0f);
		}
		else if (transform.forward.y > 0.0001f)
		{
			limitX = Mathf.Max(limitX, 310.0f);
		}
		else if(transform.forward.y == 0.0f)
		{
			limitX = 0.0f;
		}

		transform.eulerAngles = new Vector3(limitX, transform.eulerAngles.y, transform.eulerAngles.z);
			
		mainCamera.transform.rotation = transform.rotation;
		uiCamera.transform.rotation = transform.rotation;
	}
}