using System;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// The core-level constant definitions
	/// </summary>
	public class IGCCoreConstants // Tag: 21; Length: 1760;
	{
		const int DAMAGEINDEXCOUNT = 20;
		float[] _constants;
		DamageIndex[] _damageIndexes;

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="reader">The DataReader from which to read the constants</param>
		public IGCCoreConstants (DataReader reader)
		{
			_constants = new float[40];
			_damageIndexes = new DamageIndex[20];
			Parse(reader);
		}

		/// <summary>
		/// Parses the constants and DamageIndexes
		/// </summary>
		/// <param name="reader">The DataReader from which to parse the data</param>
		public void Parse (DataReader reader)
		{
			// Read the "constants" array
			for (int i = 0; i < _constants.Length; i++)
			{
				_constants[i] = reader.ReadFloat();
			}

			// Read the "damages" 2D array
			for (int i = 0; i < DAMAGEINDEXCOUNT; i++)
			{
				_damageIndexes[i] = new DamageIndex(reader);
			}
		}

		/// <summary>
		/// Retrieves the array of DamageIndexes
		/// </summary>
		public DamageIndex[] DamageIndexes
		{
			get {return _damageIndexes;}
		}

//		/// <summary>
//		/// Returns the DamageIndex specified, or null if index is out of bounds.
//		/// </summary>
//		/// <param name="index">The index of the DamageIndex to retrieve</param>
//		/// <returns>The specified DamageIndex, or null if not found</returns>
//		public DamageIndex DamageIndex (int index)
//		{
//			if (index < DAMAGEINDEXCOUNT)
//				return _damageIndexes[index];
//
//			return null;
//		}

		/// <summary>
		/// Retrieves the array of float constants.
		/// </summary>
		public float[] Constants
		{
			get {return _constants;}
			set {_constants = value;}
		}

		/// <summary>
		/// The vertical size of a sector depicting where rocks/etc are placed.
		/// </summary>
		public float LensMultiplier
		{
			get {return _constants[(int)CoreConstantIndex.LensMultiplier];}
			set {_constants[(int)CoreConstantIndex.LensMultiplier] = value;}
		}

		/// <summary>
		/// The size of a sector from the center to the outer edge
		/// </summary>
		public float RadiusUniverse
		{
			get {return _constants[(int)CoreConstantIndex.RadiusUniverse];}
			set {_constants[(int)CoreConstantIndex.RadiusUniverse] = value;}
		}

		/// <summary>
		/// OutOfBounds: UNKNOWN
		/// </summary>
		public float OutOfBounds
		{
			get {return _constants[(int)CoreConstantIndex.OutOfBounds];}
			set {_constants[(int)CoreConstantIndex.OutOfBounds] = value;}
		}

		/// <summary>
		/// The speed at which a player exits an aleph
		/// </summary>
		public float ExitWarpSpeed
		{
			get {return _constants[(int)CoreConstantIndex.ExitWarpSpeed];}
			set {_constants[(int)CoreConstantIndex.ExitWarpSpeed] = value;}
		}

		/// <summary>
		/// The speed at which a player exits a station when launching
		/// </summary>
		public float ExitStationSpeed
		{
			get {return _constants[(int)CoreConstantIndex.ExitStationSpeed];}
			set {_constants[(int)CoreConstantIndex.ExitStationSpeed] = value;}
		}

		/// <summary>
		/// DownedShield: UNKNOWN
		/// </summary>
		public float DownedShield
		{
			get {return _constants[(int)CoreConstantIndex.DownedShield];}
			set {_constants[(int)CoreConstantIndex.DownedShield] = value;}
		}

		/// <summary>
		/// The number of seconds between paydays
		/// </summary>
		public float SecondsBetweenPaydays
		{
			get {return _constants[(int)CoreConstantIndex.SecondsBetweenPayouts];}
			set {_constants[(int)CoreConstantIndex.SecondsBetweenPayouts] = value;}
		}

		/// <summary>
		/// The default HE3 capacity of miners
		/// </summary>
		public float CapacityHe3
		{
			get {return _constants[(int)CoreConstantIndex.CapacityHe3];}
			set {_constants[(int)CoreConstantIndex.CapacityHe3] = value;}
		}

		/// <summary>
		/// The number of credits earned for each unit of He3 retrieved
		/// </summary>
		public float ValueHe3
		{
			get {return _constants[(int)CoreConstantIndex.ValueHe3];}
			set {_constants[(int)CoreConstantIndex.ValueHe3] = value;}
		}

		/// <summary>
		/// The default amount of He3 available in each sector
		/// </summary>
		public float AmountHe3
		{
			get {return _constants[(int)CoreConstantIndex.AmountHe3];}
			set {_constants[(int)CoreConstantIndex.AmountHe3] = value;}
		}

		/// <summary>
		/// MountRate: UNKNOWN
		/// </summary>
		public float MountRate
		{
			get {return _constants[(int)CoreConstantIndex.MountRate];}
			set {_constants[(int)CoreConstantIndex.MountRate] = value;}
		}

		/// <summary>
		/// The default amount of money each team starts with
		/// </summary>
		public float StartingMoney
		{
			get {return _constants[(int)CoreConstantIndex.StartingMoney];}
			set {_constants[(int)CoreConstantIndex.StartingMoney] = value;}
		}

		/// <summary>
		/// The amount of money required to win in "" mode
		/// </summary>
		public float WinTheGameMoney
		{
			get {return _constants[(int)CoreConstantIndex.WinTheGameMoney];}
			set {_constants[(int)CoreConstantIndex.WinTheGameMoney] = value;}
		}

		/// <summary>
		/// The default ripcord timer
		/// </summary>
		public float RipcordTime
		{
			get {return _constants[(int)CoreConstantIndex.RipcordTime];}
			set {_constants[(int)CoreConstantIndex.RipcordTime] = value;}
		}

		/// <summary>
		/// The default rate that He3 regenerates on rocks
		/// </summary>
		public float He3Regeneration
		{
			get {return _constants[(int)CoreConstantIndex.He3Regeneration];}
			set {_constants[(int)CoreConstantIndex.He3Regeneration] = value;}
		}

		/// <summary>
		/// The number of points a player earns by destroying an Aleph
		/// </summary>
		public float PointsAleph
		{
			get {return _constants[(int)CoreConstantIndex.PointsWarp];}
			set {_constants[(int)CoreConstantIndex.PointsWarp] = value;}
		}

		/// <summary>
		/// The number of points a player earns by destroying an asteroid
		/// </summary>
		public float PointsAsteroid
		{
			get {return _constants[(int)CoreConstantIndex.PointsAsteroid];}
			set {_constants[(int)CoreConstantIndex.PointsAsteroid] = value;}
		}

		/// <summary>
		/// The number of points a player earns by assimilating technology for their team
		/// </summary>
		public float PointsTech
		{
			get {return _constants[(int)CoreConstantIndex.PointsTech];}
			set {_constants[(int)CoreConstantIndex.PointsTech] = value;}
		}

		/// <summary>
		/// The number of points a player earns by destroying a Miner
		/// </summary>
		public float PointsMiner
		{
			get {return _constants[(int)CoreConstantIndex.PointsMiner];}
			set {_constants[(int)CoreConstantIndex.PointsMiner] = value;}
		}

		/// <summary>
		/// The number of points a player earns by destroying a Constructor
		/// </summary>
		public float PointsBuilder
		{
			get {return _constants[(int)CoreConstantIndex.PointsBuilder];}
			set {_constants[(int)CoreConstantIndex.PointsBuilder] = value;}
		}

		/// <summary>
		/// The number of points a player earns by destroying a mine layer
		/// </summary>
		public float PointsLayer
		{
			get {return _constants[(int)CoreConstantIndex.PointsLayer];}
			set {_constants[(int)CoreConstantIndex.PointsLayer] = value;}
		}

		/// <summary>
		/// The number of points a player earns by destroying a Carrier
		/// </summary>
		public float PointsCarrier
		{
			get {return _constants[(int)CoreConstantIndex.PointsCarrier];}
			set {_constants[(int)CoreConstantIndex.PointsCarrier] = value;}
		}

		/// <summary>
		/// The number of points a player earns by ejecting a pilot
		/// </summary>
		public float PointsPlayer
		{
			get {return _constants[(int)CoreConstantIndex.PointsPlayer];}
			set {_constants[(int)CoreConstantIndex.PointsPlayer] = value;}
		}

		/// <summary>
		/// The number of points a player earns by destroying a base
		/// </summary>
		public float PointsBaseKill
		{
			get {return _constants[(int)CoreConstantIndex.PointsBaseKill];}
			set {_constants[(int)CoreConstantIndex.PointsBaseKill] = value;}
		}

		/// <summary>
		/// The number of points a player earns by capturing a base
		/// </summary>
		public float PointsBaseCapture
		{
			get {return _constants[(int)CoreConstantIndex.PointsBaseCapture];}
			set {_constants[(int)CoreConstantIndex.PointsBaseCapture] = value;}
		}

		/// <summary>
		/// The number of points a player earns by capturing a flag in "Capture the Flag" game mode
		/// </summary>
		public float PointsFlags
		{
			get {return _constants[(int)CoreConstantIndex.PointsFlags];}
			set {_constants[(int)CoreConstantIndex.PointsFlags] = value;}
		}

		/// <summary>
		/// The number of points a player earns by capturing an Artifact in "Artifacts" game mode
		/// </summary>
		public float PointsArtifacts
		{
			get {return _constants[(int)CoreConstantIndex.PointsArtifacts];}
			set {_constants[(int)CoreConstantIndex.PointsArtifacts] = value;}
		}

		/// <summary>
		/// The number of points a player earns by rescuing a teammate's pod
		/// </summary>
		public float PointsRescue
		{
			get {return _constants[(int)CoreConstantIndex.PointsRescues];}
			set {_constants[(int)CoreConstantIndex.PointsRescues] = value;}
		}

		/// <summary>
		/// RatingAdd: UNKNOWN
		/// </summary>
		public float RatingAdd
		{
			get {return _constants[(int)CoreConstantIndex.RatingAdd];}
			set {_constants[(int)CoreConstantIndex.RatingAdd] = value;}
		}

		/// <summary>
		/// RatingDivide: UNKNOWN
		/// </summary>
		public float RatingDivide
		{
			get {return _constants[(int)CoreConstantIndex.RatingDivide];}
			set {_constants[(int)CoreConstantIndex.RatingDivide] = value;}
		}

		/// <summary>
		/// Income: UNKNOWN
		/// </summary>
		public float Income
		{
			get {return _constants[(int)CoreConstantIndex.Income];}
			set {_constants[(int)CoreConstantIndex.Income] = value;}
		}

		/// <summary>
		/// LifepodEndurance: UNKNOWN
		/// </summary>
		public float LifepodEndurance
		{
			get {return _constants[(int)CoreConstantIndex.LifepodEndurance];}
			set {_constants[(int)CoreConstantIndex.LifepodEndurance] = value;}
		}

		/// <summary>
		/// The default delay between an Aleph Resonator's impact and its explosion
		/// </summary>
		public float WarpBombDelay
		{
			get {return _constants[(int)CoreConstantIndex.WarpBombDelay];}
			set {_constants[(int)CoreConstantIndex.WarpBombDelay] = value;}
		}

		/// <summary>
		/// The "life cost" of an eject pod, which works towards a "sector overload"
		/// </summary>
		public float LifepodCost
		{
			get {return _constants[(int)CoreConstantIndex.LifepodCost];}
			set {_constants[(int)CoreConstantIndex.LifepodCost] = value;}
		}

		/// <summary>
		/// The "life cost" of an turret gunner, which works towards a "sector overload"
		/// </summary>
		public float TurretCost
		{
			get {return _constants[(int)CoreConstantIndex.TurretCost];}
			set {_constants[(int)CoreConstantIndex.TurretCost] = value;}
		}

		/// <summary>
		/// The "life cost" of a drone, which works towards a "sector overload"
		/// </summary>
		public float DroneCost
		{
			get {return _constants[(int)CoreConstantIndex.DroneCost];}
			set {_constants[(int)CoreConstantIndex.DroneCost] = value;}
		}

		/// <summary>
		/// The "life cost" of a pilot, which works towards a "sector overload"
		/// </summary>
		public float PlayerCost
		{
			get {return _constants[(int)CoreConstantIndex.PlayerCost];}
			set {_constants[(int)CoreConstantIndex.PlayerCost] = value;}
		}

		/// <summary>
		/// BaseClusterCost: UNKNOWN
		/// </summary>
		public float BaseClusterCost
		{
			get {return _constants[(int)CoreConstantIndex.BaseClusterCost];}
			set {_constants[(int)CoreConstantIndex.BaseClusterCost] = value;}
		}

		/// <summary>
		/// ClusterDivisor: UNKNOWN
		/// </summary>
		public float ClusterDivisor
		{
			get {return _constants[(int)CoreConstantIndex.ClusterDivisor];}
			set {_constants[(int)CoreConstantIndex.ClusterDivisor] = value;}
		}

		/// <summary>
		/// UNUSED
		/// </summary>
		public float UNUSED
		{
			get {return _constants[(int)CoreConstantIndex.UNUSED];}
			set {_constants[(int)CoreConstantIndex.UNUSED] = value;}
		}
	} // IGCCoreConstants

}
