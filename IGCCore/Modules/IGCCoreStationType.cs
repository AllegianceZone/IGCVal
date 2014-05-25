using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreStationType.
	/// </summary>
	public class IGCCoreStationType : IGCCoreObject	// Tag: 31; Length = 524;
	{
		int cost;
		int research_time;
		string model;	// Length 13;
		//byte pad1;	// Length 1; CC or 00
		string icon;	// Length 13;
//		string name;	// Length 25;
		string description;	// Length 200;
		byte group;
		byte zero;
//		Techtree techtree; // length 100; Unsigned chars
		//byte[] pad2;	// Length 2; CD CD
		float stats_s1; // sig multiplier
		float stats_s2; // hull
		float stats_s3; // shield
		float stats_s4; // hull repair rate
		float stats_s5; // shield repair rate
		float stats_s6; // scan range
		int stats_income;
		float stats_s7; // scale
		BitArray techtreelocal;	// Length 50; Unsigned chars
		
		//ushort uid;
		short overriding_uid;
		byte ACHull;
		byte ACShld;
		BitArray AbilityBitMask; // (as in igc.h)
		
		BuildOn buildon; // see IGCSTATIONF_BUILDON_* values
		byte type; // see IGCSTATION_TYPE_* value - capture related ?
		//byte pad6; // Length 1; CD
		ushort stats_ss0; // drone uid
		ushort[] sounds;
		byte[] uk3; // Length 13; 3*16+1-6-2-28
		string constructor; // Length 25;

		public IGCCoreStationType (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_StationType;
			Sounds = new ushort[13];
			Parse(reader);
		}

		public void Parse (DataReader reader)
		{
			cost = reader.ReadInt();
			research_time = reader.ReadInt();
			model = reader.ReadString(13);
			reader.ReadByte();

			icon = reader.ReadString(13);
			name = reader.ReadString(25);
			description = reader.ReadString(200);
			group = reader.ReadByte();
			zero = reader.ReadByte();
			techtree = new Techtree(reader);
			reader.Assert((ushort)0xCDCD, 0, name, "Station", "Techtree");

			stats_s1 = reader.ReadFloat();
			stats_s2 = reader.ReadFloat();
			stats_s3 = reader.ReadFloat();
			stats_s4 = reader.ReadFloat();
			stats_s5 = reader.ReadFloat();
			stats_s6 = reader.ReadFloat();
			stats_income = reader.ReadInt();
			stats_s7 = reader.ReadFloat();
			techtreelocal = new BitArray(reader.ReadBytes(50));
			//            //
			uid = reader.ReadUShort();
			overriding_uid = reader.ReadShort();
			ACHull = reader.ReadByte();
			ACShld = reader.ReadByte();
			AbilityBitMask = new BitArray(reader.ReadBytes(2));
			buildon = (BuildOn)Enum.Parse(typeof(BuildOn), reader.ReadUShort().ToString());
			type = reader.ReadByte();
			reader.Assert((byte)0xCD, uid, name, "Station", "Type");

			stats_ss0 = reader.ReadUShort();

			for (int i = 0; i < 13; i++)
			{
				sounds[i] = reader.ReadUShort();
			}
			uk3 = reader.ReadBytes(13);
			constructor = reader.ReadString(25);
		}

		public override string ToString ()
		{
			return this.name;
		}

		/// <summary>
		/// The cost to purchase one of these stations
		/// </summary>
		public int Cost
		{
			get {return cost;}
			set {cost = value;}
		}

		/// <summary>
		/// The amount of time required to research this station
		/// </summary>
		public int ResearchTime
		{
			get {return research_time;}
			set {research_time = value;}
		}

		/// <summary>
		/// The name of the model used by this station
		/// </summary>
		public string Model
		{
			get {return model;}
			set {model = value;}
		}

		/// <summary>
		/// The name of the icon to be displayed by this station
		/// </summary>
		public string Icon
		{
			get {return icon;}
			set {icon = value;}
		}

//		/// <summary>
//		/// The name of this station
//		/// </summary>
//		public string Name
//		{
//			get {return name;}
//			set {name = value;}
//		}

		/// <summary>
		/// A description that describes this station
		/// </summary>
		public string Description
		{
			get {return description;}
			set {description = value;}
		}

		/// <summary>
		/// UNKNOWN
		/// </summary>
		public byte Group
		{
			get {return group;}
			set {group = value;}
		}

		/// <summary>
		/// UNKNOWN
		/// </summary>
		public byte Zero
		{
			get {return zero;}
			set {zero = value;}
		}

//		/// <summary>
//		/// The set of prerequisites and definitions this station defines/requires
//		/// </summary>
//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}

		/// <summary>
		/// The signature modifier of this Station
		/// </summary>
		public float Signature
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

		/// <summary>
		/// The number of hitpoints this station's hull has
		/// </summary>
		public float Hull
		{
			get {return stats_s2;}
			set {stats_s2 = value;}
		}

		/// <summary>
		/// The number of hitpoints this station's shield has
		/// </summary>
		public float Shield
		{
			get {return stats_s3;}
			set {stats_s3 = value;}
		}

		/// <summary>
		/// The rate at which this station's hull regenerates
		/// </summary>
		public float HullRepairRate
		{
			get {return stats_s4;}
			set {stats_s4 = value;}
		}

		/// <summary>
		/// The rate at which this station's shield regenerates
		/// </summary>
		public float ShieldRepairRate
		{
			get {return stats_s5;}
			set {stats_s5 = value;}
		}

		/// <summary>
		/// The visible distance surrounding this station
		/// </summary>
		public float Scanrange
		{
			get {return stats_s6;}
			set {stats_s6 = value;}
		}

		/// <summary>
		/// The amount of credits this base gives per payday
		/// </summary>
		public int Income
		{
			get {return stats_income;}
			set {stats_income = value;}
		}

		/// <summary>
		/// A multiplier dictating the size of this station
		/// </summary>
		public float Scale
		{
			get {return stats_s7;}
			set {stats_s7 = value;}
		}

		public BitArray TechTreeLocal
		{
			get {return techtreelocal;}
			set {techtreelocal = value;}
		}

//		/// <summary>
//		/// The Unique ID of this station
//		/// </summary>
//		public ushort UID
//		{
//			get {return uid;}
//			set {uid = value;}
//		}

		/// <summary>
		/// The ID of the station that this one overrides, or -1 if none
		/// </summary>
		public short OverridingUID
		{
			get {return overriding_uid;}
			set {overriding_uid = value;}
		}

		/// <summary>
		/// The ArmorClass of this station's hull
		/// </summary>
		public byte HullArmorClass
		{
			get {return ACHull;}
			set {ACHull = value;}
		}

		/// <summary>
		/// The ArmorClass of this station's shields
		/// </summary>
		public byte ShieldArmorClass
		{
			get {return ACShld;}
			set {ACShld = value;}
		}

		/// <summary>
		/// A set of bitwise flags detailing this station's abilities
		/// </summary>
		public BitArray StationAbility
		{
			get {return AbilityBitMask;}
			set {AbilityBitMask = value;}
		}

		/// <summary>
		/// A bitmask detailing which rocks this station type can be built on
		/// </summary>
		public BuildOn CanBuildOn
		{
			get {return buildon;}
			set {buildon = value;}
		}

		/// <summary>
		/// The type of this station
		/// </summary>
		public byte Type
		{
			get {return type;}
			set {type = value;}
		}

		public ushort DroneUID
		{
			get {return stats_ss0;}
			set {stats_ss0 = value;}
		}

		public ushort[] Sounds
		{
			get {return sounds;}
			set {sounds = value;}
		}
//		byte[] uk3; // Length 13; 3*16+1-6-2-28
		public string Constructor
		{
			get {return constructor;}
			set {constructor = value;}
		}
	} // IGCCoreStationType
}
