using System;

namespace FreeAllegiance.IGCCore.Util
{
	/// <summary>
	/// A list of 20 damage ratios performed against each hull type, representing 1 "DM" index.
	/// </summary>
	public class DamageIndex
	{
		private float[] _damages;

		public DamageIndex (DataReader reader)
		{
			_damages = new float[20];
			Parse(reader);
		}

		/// <summary>
		/// Parses the 20 damage ratios from the specified reader
		/// </summary>
		/// <param name="reader">The datareader from which to read the 20 ratios</param>
		private void Parse (DataReader reader)
		{
			for (int i = 0; i < _damages.Length; i++)
			{
				_damages[i] = reader.ReadFloat();
			}
		}

		/// <summary>
		/// Retrieves the raw array of damage floats.
		/// </summary>
		public float[] Damages
		{
			get {return _damages;}
		}

		/// <summary>
		/// Damage performed to an asteroid
		/// </summary>
		public float Asteroid
		{
			get {return _damages[(int)IGCArmorClass.Asteroid];}
			set {_damages[(int)IGCArmorClass.Asteroid] = value;}
		}

		/// <summary>
		/// Damage performed to light ship hull
		/// </summary>
		public float LightHull
		{
			get {return _damages[(int)IGCArmorClass.Light_Hull];}
			set {_damages[(int)IGCArmorClass.Light_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to medium hull
		/// </summary>
		public float MediumHull
		{
			get {return _damages[(int)IGCArmorClass.Medium_Hull];}
			set {_damages[(int)IGCArmorClass.Medium_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to heavy hull
		/// </summary>
		public float HeavyHull
		{
			get {return _damages[(int)IGCArmorClass.Heavy_Hull];}
			set {_damages[(int)IGCArmorClass.Heavy_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to extra-heavy hull
		/// </summary>
		public float ExtraHeavyHull
		{
			get {return _damages[(int)IGCArmorClass.Extra_Heavy_Hull];}
			set {_damages[(int)IGCArmorClass.Extra_Heavy_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to utility hull
		/// </summary>
		public float UtilityHull
		{
			get {return _damages[(int)IGCArmorClass.Utility_Hull];}
			set {_damages[(int)IGCArmorClass.Utility_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to minor base hull
		/// </summary>
		public float MinorBaseHull
		{
			get {return _damages[(int)IGCArmorClass.Minor_Base_Hull];}
			set {_damages[(int)IGCArmorClass.Minor_Base_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to major base hull
		/// </summary>
		public float MajorBaseHull
		{
			get {return _damages[(int)IGCArmorClass.Major_Base_Hull];}
			set {_damages[(int)IGCArmorClass.Major_Base_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to light and medium shields
		/// </summary>
		public float LightAndMediumShield
		{
			get {return _damages[(int)IGCArmorClass.Light_and_Medium_Shield];}
			set {_damages[(int)IGCArmorClass.Light_and_Medium_Shield] = value;}
		}

		/// <summary>
		/// Damage performed to minor base shield
		/// </summary>
		public float MinorBaseShield
		{
			get {return _damages[(int)IGCArmorClass.Minor_Base_Shield];}
			set {_damages[(int)IGCArmorClass.Minor_Base_Shield] = value;}
		}

		/// <summary>
		/// Damage performed to major base shield
		/// </summary>
		public float MajorBaseShield
		{
			get {return _damages[(int)IGCArmorClass.Major_Base_Shield];}
			set {_damages[(int)IGCArmorClass.Major_Base_Shield] = value;}
		}

		/// <summary>
		/// Damage performed to parts
		/// </summary>
		public float Parts
		{
			get {return _damages[(int)IGCArmorClass.Parts];}
			set {_damages[(int)IGCArmorClass.Parts] = value;}
		}

		/// <summary>
		/// Damage performed to light base hull
		/// </summary>
		public float LightBaseHull
		{
			get {return _damages[(int)IGCArmorClass.Light_Base_Hull];}
			set {_damages[(int)IGCArmorClass.Light_Base_Hull] = value;}
		}

		/// <summary>
		/// Damage performed to light base shield
		/// </summary>
		public float LightBaseShield
		{
			get {return _damages[(int)IGCArmorClass.Light_Base_Shield];}
			set {_damages[(int)IGCArmorClass.Light_Base_Shield] = value;}
		}

		/// <summary>
		/// Damage performed to large shields
		/// </summary>
		public float LargeShield
		{
			get {return _damages[(int)IGCArmorClass.Large_Shield];}
			set {_damages[(int)IGCArmorClass.Large_Shield] = value;}
		}

		/// <summary>
		/// Damage performed to Armor Class 15
		/// </summary>
		public float AC15
		{
			get {return _damages[(int)IGCArmorClass.AC15];}
			set {_damages[(int)IGCArmorClass.AC15] = value;}
		}
		
		/// <summary>
		/// Damage performed to Armor Class 16
		/// </summary>
		public float AC16
		{
			get {return _damages[(int)IGCArmorClass.AC16];}
			set {_damages[(int)IGCArmorClass.AC16] = value;}
		}
		
		/// <summary>
		/// Damage performed to Armor Class 17
		/// </summary>
		public float AC17
		{
			get {return _damages[(int)IGCArmorClass.AC17];}
			set {_damages[(int)IGCArmorClass.AC17] = value;}
		}
		
		/// <summary>
		/// Damage performed to Armor Class 18
		/// </summary>
		public float AC18
		{
			get {return _damages[(int)IGCArmorClass.AC18];}
			set {_damages[(int)IGCArmorClass.AC18] = value;}
		}
		
		/// <summary>
		/// Damage performed to Armor Class 19
		/// </summary>
		public float AC19
		{
			get {return _damages[(int)IGCArmorClass.AC19];}
			set {_damages[(int)IGCArmorClass.AC19] = value;}
		}
	}
}
