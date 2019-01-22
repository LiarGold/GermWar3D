using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameController : MonoBehaviour
{
	public GameObject _originMeteor = null;

	public void Start()
	{
		GameStart();
	}

	public void Update()
	{
		
	}

	public void CreateMeteor()
	{
		var meteor = Function.CreateCopiedGameObject("Meteor", _originMeteor, CSceneManager.ObjectRoot);
		
	}

	public void GameStart()
	{
		CGameDataStorage.Instance.MaxLife = 5;
		CGameDataStorage.Instance.MaxGold = 999999;
		CGameDataStorage.Instance.MaxResource = 999999;

		CGameDataStorage.Instance.CurrentWave = 1;
		CGameDataStorage.Instance.CurrentGold = 100;
		CGameDataStorage.Instance.CurrentResource = 100;
		CGameDataStorage.Instance.CurrentLife = CGameDataStorage.Instance.MaxLife;

		CGameDataStorage.Instance.ShotPowerLevel = 1;
		CGameDataStorage.Instance.ShotSpeedLevel = 1;
		CGameDataStorage.Instance.FiringRateLevel = 1;
		CGameDataStorage.Instance.RotateSpeedLevel = 1;
	}
}
