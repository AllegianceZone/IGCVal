using System;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// A Faction
	/// </summary>
	public class IGCCoreCiv : IGCCoreObject // Tag: 27; Length 268;
	{
		float[] ukf; // Length 2: 0=starting money modifier,1=bonus money
//		string name; // Length 25;
		string model; // Length 13;
		string obj; // Length 13;
//		Techtree techtree; // first = 02       Length = 100;
		//byte pad1;	// CD
		Factors factors; // Length 25
		ushort suk; // lifepod ID
		//ushort uid;
		ushort gar_uid; // uid in StationType (or last "base" uid)
		//byte[] end; // CD CD or "ออ"

		public IGCCoreCiv (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_Civilization;
			ukf = new float[2];

			Parse(reader);
		}

		/// <summary>
		/// Parses the IGCCoreCiv from the specified DataReader
		/// </summary>
		/// <param name="reader">The DataReader to use to read the IGCCoreCiv</param>
		private void Parse (DataReader reader)
		{
			ukf[0] = reader.ReadFloat();
			ukf[1] = reader.ReadFloat();

			name = reader.ReadString(25);
			model = reader.ReadString(13);
			obj = reader.ReadString(13);
			techtree = new Techtree(reader);
			reader.Assert((byte)0xCD, 0, name, "Faction", "Techtree");
			factors = new Factors(reader);

			suk = reader.ReadUShort();
			uid = reader.ReadUShort();
			gar_uid = reader.ReadUShort();
			reader.Assert((ushort)0xCDCD, uid, name, "Faction", "Garrison UID");
		}

		/// <summary>
		/// Modifier determining the amount of money this faction has when the game begins
		/// </summary>
		public float StartingMoneyModifier
		{
			get {return ukf[0];}
			set {ukf[0] = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public float BonusMoney
		{
			get {return ukf[1];}
			set {ukf[1] = value;}
		}

		/// <summary>
//		/// The name of this faction
//		/// </summary>
//		public string Name
//		{
//			get {return name;}
//			set {name = (value.Length <= 25) ? value : value.Substring(0, 25);}
//		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			get {return model;}
			set {model = (value.Length <= 13) ? value : value.Substring(0, 13);}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Object
		{
			get {return obj;}
			set {obj = (value.Length <= 13) ? value : value.Substring(0, 13);}
		}

//		/// <summary>
//		/// The set of defs/pres that this faction defines/requires defined
//		/// </summary>
//		public Techtree Techtree
//		{
//			get {return techtree;}
//		}

		/// <summary>
		/// The set of stats modifiers for this faction
		/// </summary>
		public Factors Factors
		{
			get {return factors;}
		}

		/// <summary>
		/// The ID of the LifePod this faction uses
		/// </summary>
		public ushort LifepodID
		{
			get {return suk;}
		}

//		/// <summary>
//		/// The unique ID of this faction
//		/// </summary>
//		public ushort UID
//		{
//			get {return uid;}
//		}

		/// <summary>
		/// 
		/// </summary>
		public ushort Garrison_UID
		{
			get {return gar_uid;}
		}
	}
}
