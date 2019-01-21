using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAim : MonoBehaviour
{
    //! 상태를 갱신한다
    public void Update()
    {
		var mousePos = Input.mousePosition;
		mousePos.z = 35;
		var aimPos = CSceneManager.MainCamera.ScreenToWorldPoint(mousePos);

		var ray = CSceneManager.MainCamera.ScreenPointToRay(mousePos);
		RaycastHit rayCastHit;

		if (Physics.Raycast(ray, out rayCastHit))
		{
			aimPos.z = rayCastHit.collider.transform.position.z;
			transform.position = aimPos;
		}
	}
}
