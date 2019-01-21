using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CJoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public GameObject _aimObject = null;

	private bool _isTouch = false;

	public void Start()
	{
		Input.simulateMouseWithTouches = true;
	}

	public void Update()
	{
		if(Input.touchCount > 0)
		{
			Function.ShowLog("Touch");
			var touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Moved && _isTouch)
			{
				_aimObject.transform.Translate(touch.deltaPosition);
			}
		}

		var ray = CSceneManager.MainCamera.ScreenPointToRay(_aimObject.transform.position);
		RaycastHit rayCastHit;

		if (Physics.Raycast(ray, out rayCastHit))
		{
			var collider = rayCastHit.collider;
			var aimPos = _aimObject.transform.position;
			aimPos.z = collider.transform.position.z;
			_aimObject.transform.position = aimPos;
		}
	}

	//! 이동 버튼을 눌렀을 경우
	public void OnPointerDown(PointerEventData eventData)
	{
		_isTouch = true;
	}

	//! 이동 버튼을 땠을 경우
	public void OnPointerUp(PointerEventData eventData)
	{
		_isTouch = false;
	}
}
