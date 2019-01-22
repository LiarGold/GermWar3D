using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameDataStorage : CSingleton<CGameDataStorage>
{
	public int CurrentWave { get; set; }
	public int MaxLife { get; set; }
	public int CurrentLife { get; set; }
	public int MaxResource { get; set; }
	public int CurrentResource { get; set; }
	public int MaxGold { get; set; }
	public int CurrentGold { get; set; }
	public int RotateSpeedLevel { get; set; }
	public int ShotSpeedLevel { get; set; }
	public int ShotPowerLevel { get; set; }
	public int FiringRateLevel { get; set; }
}
