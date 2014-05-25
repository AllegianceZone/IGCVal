using System;

namespace FreeAllegiance.IGCCore.Util
{
	public enum AGCObjectType : short
	{
		AGCObjectType_Invalid = -1,
		AGC_ModelBegin = 0,
		AGC_Ship = 0,
		AGC_Station = 1,
		AGC_Missile = 2,
		AGC_Mine = 3,
		AGC_Probe = 4,
		AGC_Asteroid = 5,
		AGC_Projectile = 6,
		AGC_Warp = 7,
		AGC_Treasure = 8,
		AGC_Buoy = 9,
		AGC_Chaff = 10,
		AGC_BuildingEffect = 11,
		AGC_ModelEnd = 11,
		AGC_Side = 12,
		AGC_Cluster = 13,
		AGC_Bucket = 14,
		AGC_PartBegin = 15,
		AGC_Weapon = 15,
		AGC_Shield = 16,
		AGC_Cloak = 17,
		AGC_Pack = 18,
		AGC_Afterburner = 19,
		AGC_LauncherBegin = 20,
		AGC_Magazine = 20,
		AGC_Dispenser = 21,
		AGC_LauncherEnd = 21,
		AGC_PartEnd = 21,
		AGC_StaticBegin = 22,
		AGC_ProjectileType = 22,
		AGC_MissileType = 23,
		AGC_MineType = 24,
		AGC_ProbeType = 25,
		AGC_ChaffType = 26,
		AGC_Civilization = 27,
		AGC_TreasureSet = 28,
		AGC_BucketStart = 29,
		AGC_HullType = 29,
		AGC_PartType = 30,
		AGC_StationType = 31,
		AGC_Development = 32,
		AGC_DroneType = 33,
		AGC_BucketEnd = 33,
		AGC_StaticEnd = 33,
		AGC_Constants = 34,
		AGC_AdminUser = 35,
		AGCObjectType_Max = 36,
		AGC_Any_Objects = 36
	};

	/// <summary>
	/// Armor Classes
	/// </summary>
	public enum IGCArmorClass : byte
	{
		Asteroid = 0,
		Light_Hull = 1,
		Medium_Hull = 2,
		Heavy_Hull = 3,
		Extra_Heavy_Hull = 4,
		Utility_Hull = 5,
		Minor_Base_Hull = 6,
		Major_Base_Hull = 7,
		Light_and_Medium_Shield = 8,
		Minor_Base_Shield = 9,
		Major_Base_Shield = 10,
		Parts = 11,
		Light_Base_Hull = 12,
		Light_Base_Shield = 13,
		Large_Shield = 14,
		AC15 = 15,
		AC16 = 16,
		AC17 = 17,
		AC18 = 18,
		AC19 = 19
	}

	public enum FactorIndex // : int
	{
		ShipSpeed = 0,
		ShipAcceleration = 1,
		ShipTurnRate = 2,
		ShipTurnTorque = 3,
		StationHull = 4,
		StationHullRepairRate = 5,
		StationShield = 6,
		StationShieldRepairRate = 7,
		ShipHull = 8,
		ShipShield = 9,
		ShipShieldRepairRate = 10,
		ShipSensors = 11,
		ShipSignature = 12,
		ShipEnergy = 13,
		PWRange = 14,
		EWRange = 15,
		MissileTrack = 16,
		He3Speed = 17,
		He3Yield = 18,
		MinerCapacity = 19,
		Ripcord = 20,
		PWDamage = 21,
		MissileDamage = 22,
		Cost = 23,
		ResearchTime = 24
	}

	public enum CoreConstantIndex // : int
	{
		LensMultiplier = 0,
		RadiusUniverse = 1,
		OutOfBounds = 2,
		ExitWarpSpeed = 3,
		ExitStationSpeed = 4,
		DownedShield = 5,
		SecondsBetweenPayouts = 6,
		CapacityHe3 = 7,
		ValueHe3 = 8,
		AmountHe3 = 9,
		MountRate = 10,
		StartingMoney = 11,
		WinTheGameMoney = 12,
		RipcordTime = 13,
		He3Regeneration = 14,
		PointsWarp = 15,
		PointsAsteroid = 16,
		PointsTech = 17,
		PointsMiner = 18,
		PointsBuilder = 19,
		PointsLayer = 20,
		PointsCarrier = 21,
		PointsPlayer = 22,
		PointsBaseKill = 23,
		PointsBaseCapture = 24,
		PointsFlags = 25,
		PointsArtifacts = 26,
		PointsRescues = 27,
		RatingAdd = 28,
		RatingDivide = 29,
		Income = 30,
		LifepodEndurance = 31,
		WarpBombDelay = 32,
		LifepodCost = 33,
		TurretCost = 34,
		DroneCost = 35,
		PlayerCost = 36,
		BaseClusterCost = 37,
		ClusterDivisor = 38,
		UNUSED = 39
	}

	public enum TreeRoot : byte
	{
		None = 255,
		Construction = 0,
		Garrison = 1,
		Supremacy = 2,
		Tactical = 3,
		Expansion = 4,
		Shipyard = 5
	}

	public enum MissileSpecialEffect : ushort
	{
		None = 0,
		NerveGas = 1,
		Resonator = 2
	}

	public enum StationType : byte
	{
		Garrison = 0,
		Outpost = 1,
		Shipyard = 2,
		Teleport = 3,
		Refinery = 4,
		Expansion = 5,
		Supremacy = 6,
		Tactical = 7,
		Platform = 8,
		Mine_Uranium = 9,
		Mine_Carbon = 10,
		Mine_Silicon = 11,
		Custom1 = 12,
		Custom2 = 13,
		Custom3 = 14,
		Custom4 = 15,
		Custom5 = 16,
		Custom6 = 17,
		Custom7 = 18,
		Custom8 = 19
	}

	public enum StationAbility : ushort
	{
		MinersCanOffload = 0,
		StartingBase = 1,
		RestartingBase = 2,
		Ripcord = 3,
		Capturable = 4,
		Dockable = 5,
		Repairable = 6,
		RelaysLeadIndicator = 7,
		ReloadShips = 8,
		CountsForVictory = 9,			// Counts for victory
		FlagPedestal = 10,			// Is a pedestal for a flag
		MinersCanTeleOffload = 11,		// 
		CapitalDockable = 12,
		RescuesTeamPods = 13,
		RescuesAllPods = 14    //           not used (but reserved for pods)
	}

	[FlagsAttribute]
	public enum BuildOn : ushort
	{
		Helium = 1,
		Thorium = 4,
		Asteroid = 8,
		Uranium = 16,
		Silicon = 32,
		Carbon = 64
	}

	public enum PartType : short
	{
		Chaff = 0,
		Weapon = 1,
		Missile = 2,
		MinesProbes = 3,
		Shield = 4,
		Cloak = 5,
		Pack = 6,
		Afterburner = 7
	}

	public enum PackType : byte
	{
		Ammo = 0,
		Fuel = 1
	}

	[FlagsAttribute]
	public enum ProbeFeatures : short
	{
		Capture = 0,
		ResonateAleph = 1,
		QuickReady = 3,
		WarnWhenDrop = 4,
		ShootStations = 5,
		ShootShips = 6,
		ShootMissiles = 7,
		ShootOnlyTarget = 12,
		RescueTeamPods = 13,
		RescueAllPods = 14
	}

	public enum ShipAbilities : short
	{
		Captures = 0,
		CanRescue = 1,
		IsLifepod = 2,
		Pickup = 3,			//unknown
		NoEjection = 4,
		CantRipcord = 5,
		LargeRipcord = 6,
		SmallShip = 7,
		RelaysLeadIndicator = 8,
		WarnStationAtRisk = 9,
		Carrier = 10,
		HasLeadIndicator = 11,
		SmallRipcord = 12,
		CanUseSmallRip = 13,
		Miner = 14,
		Constructor = 15
	}

	public enum ShipUseMasks
	{
		Counter = 0,
		Unknown = 1,
		Missile = 2,
		Pack = 3,
		Shield = 4,
		Cloak = 5,
		Unknown2 = 6,
		Booster = 7
	}
}
