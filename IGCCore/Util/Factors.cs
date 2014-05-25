using System;

namespace FreeAllegiance.IGCCore.Util
{
	/// <summary>
	/// Research Factors
	/// </summary>
	public class Factors
	{
		private const int FACTORCOUNT = 25;
		private float[] _factors;

		/// <summary>
		/// Creates a new Factors list with each value initialized to 1.
		/// </summary>
		public Factors ()
		{
			_factors = new float[FACTORCOUNT];
			for (int i = 0; i < FACTORCOUNT; i++)
			{
				_factors[i] = 1;
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="reader">A DataReader from which to read the factors</param>
		public Factors (DataReader reader)
		{
			_factors = new float[FACTORCOUNT];
			Parse(reader);
		}

		/// <summary>
		/// Parses the factors from the specified DataReader
		/// </summary>
		/// <param name="reader">A DataReader from which to read the factors</param>
		private void Parse (DataReader reader)
		{
			for (int i = 0; i < FACTORCOUNT; i++)
			{
				_factors[i] = reader.ReadFloat();
			}
		}

		public void Combine (Factors factors)
		{
			for (int i = 0; i < FACTORCOUNT; i++)
			{
				_factors[i] *= factors[i];
			}
		}

		public float this[int index]
		{
			get {return _factors[index];}
			set {_factors[index] = value;}
		}

		////////////////

		/// <summary>
		/// The speed of a ship
		/// </summary>
		public float ShipSpeed
		{
			get {return _factors[(int)FactorIndex.ShipSpeed];}
			set {_factors[(int)FactorIndex.ShipSpeed] = value;}
		}

		/// <summary>
		/// The acceleration of a ship
		/// </summary>
		public float ShipAcceleration
		{
			get {return _factors[(int)FactorIndex.ShipAcceleration];}
			set {_factors[(int)FactorIndex.ShipAcceleration] = value;}
		}

		/// <summary>
		/// How quickly a ship turns
		/// </summary>
		public float ShipTurnRate
		{
			get {return _factors[(int)FactorIndex.ShipTurnRate];}
			set {_factors[(int)FactorIndex.ShipTurnRate] = value;}
		}

		/// <summary>
		/// How quickly a ship responds to turns
		/// </summary>
		public float ShipTurnTorque
		{
			get {return _factors[(int)FactorIndex.ShipTurnTorque];}
			set {_factors[(int)FactorIndex.ShipTurnTorque] = value;}
		}

		/// <summary>
		/// The number of hitpoints a station's hull has
		/// </summary>
		public float StationHull
		{
			get {return _factors[(int)FactorIndex.StationHull];}
			set {_factors[(int)FactorIndex.StationHull] = value;}
		}

		/// <summary>
		/// How quickly a station's hull repairs itself
		/// </summary>
		public float StationHullRepairRate
		{
			get {return _factors[(int)FactorIndex.StationHullRepairRate];}
			set {_factors[(int)FactorIndex.StationHullRepairRate] = value;}
		}

		/// <summary>
		/// The number of hitpoints a station's shield has
		/// </summary>
		public float StationShield
		{
			get {return _factors[(int)FactorIndex.StationShield];}
			set {_factors[(int)FactorIndex.StationShield] = value;}
		}

		/// <summary>
		/// How quickly a station's shield regenerates
		/// </summary>
		public float StationShieldRepairRate
		{
			get {return _factors[(int)FactorIndex.StationShieldRepairRate];}
			set {_factors[(int)FactorIndex.StationShieldRepairRate] = value;}
		}

		/// <summary>
		/// The number of hitpoints a ship's hull has
		/// </summary>
		public float ShipHull
		{
			get {return _factors[(int)FactorIndex.ShipHull];}
			set {_factors[(int)FactorIndex.ShipHull] = value;}
		}

		/// <summary>
		/// The number of hitpoints a ship's shield has
		/// </summary>
		public float ShipShield
		{
			get {return _factors[(int)FactorIndex.ShipShield];}
			set {_factors[(int)FactorIndex.ShipShield] = value;}
		}

		/// <summary>
		/// How quickly a ship's shield regenerates
		/// </summary>
		public float ShipShieldRepairRate
		{
			get {return _factors[(int)FactorIndex.ShipShieldRepairRate];}
			set {_factors[(int)FactorIndex.ShipShieldRepairRate] = value;}
		}

		/// <summary>
		/// How far a ship can scan
		/// </summary>
		public float ShipSensors
		{
			get {return _factors[(int)FactorIndex.ShipSensors];}
			set {_factors[(int)FactorIndex.ShipSensors] = value;}
		}

		/// <summary>
		/// How visible a ship is to enemy sensors
		/// </summary>
		public float ShipSignature
		{
			get {return _factors[(int)FactorIndex.ShipSignature];}
			set {_factors[(int)FactorIndex.ShipSignature] = value;}
		}

		/// <summary>
		/// The amount of energy a ship has
		/// </summary>
		public float ShipEnergy
		{
			get {return _factors[(int)FactorIndex.ShipEnergy];}
			set {_factors[(int)FactorIndex.ShipEnergy] = value;}
		}

		/// <summary>
		/// The range of particle weapons
		/// </summary>
		public float PWRange
		{
			get {return _factors[(int)FactorIndex.PWRange];}
			set {_factors[(int)FactorIndex.PWRange] = value;}
		}

		/// <summary>
		/// The range of energy weapons
		/// </summary>
		public float EWRange
		{
			get {return _factors[(int)FactorIndex.EWRange];}
			set {_factors[(int)FactorIndex.EWRange] = value;}
		}

		/// <summary>
		/// The turnrate of missiles
		/// </summary>
		public float MissileTrack
		{
			get {return _factors[(int)FactorIndex.MissileTrack];}
			set {_factors[(int)FactorIndex.MissileTrack] = value;}
		}

		/// <summary>
		/// The speed at which miners extract He3 from rocks
		/// </summary>
		public float He3Speed
		{
			get {return _factors[(int)FactorIndex.He3Speed];}
			set {_factors[(int)FactorIndex.He3Speed] = value;}
		}

		/// <summary>
		/// The amount of credits earned per unit of He3
		/// </summary>
		public float He3Yield
		{
			get {return _factors[(int)FactorIndex.He3Yield];}
			set {_factors[(int)FactorIndex.He3Yield] = value;}
		}

		/// <summary>
		/// The amount of He3 a miner can hold
		/// </summary>
		public float MinerCapacity
		{
			get {return _factors[(int)FactorIndex.MinerCapacity];}
			set {_factors[(int)FactorIndex.MinerCapacity] = value;}
		}

		/// <summary>
		/// The amount of time it takes to ripcord
		/// </summary>
		public float Ripcord
		{
			get {return _factors[(int)FactorIndex.Ripcord];}
			set {_factors[(int)FactorIndex.Ripcord] = value;}
		}

		/// <summary>
		/// The amount of damage performed by particle weapons
		/// </summary>
		public float PWDamage
		{
			get {return _factors[(int)FactorIndex.PWDamage];}
			set {_factors[(int)FactorIndex.PWDamage] = value;}
		}

		/// <summary>
		/// The amount of damage performed by missiles
		/// </summary>
		public float MissileDamage
		{
			get {return _factors[(int)FactorIndex.MissileDamage];}
			set {_factors[(int)FactorIndex.MissileDamage] = value;}
		}

		/// <summary>
		/// The cost to research an item
		/// </summary>
		public float Cost
		{
			get {return _factors[(int)FactorIndex.Cost];}
			set {_factors[(int)FactorIndex.Cost] = value;}
		}

		/// <summary>
		/// The amount of time it takes to research
		/// </summary>
		public float ResearchTime
		{
			get {return _factors[(int)FactorIndex.ResearchTime];}
			set {_factors[(int)FactorIndex.ResearchTime] = value;}
		}
	}
}
