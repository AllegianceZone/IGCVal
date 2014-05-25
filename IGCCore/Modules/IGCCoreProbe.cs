using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// A probe part that can be picked up, loaded, and dropped by capable ships
	/// </summary>
	public class IGCCoreProbe : IGCCorePart // tag = 0x19 (AGC_ProbeType), size = 492
	{
		//		UCHAR header[16]; // ALL '0' = 4 floats = RGBA values (as in SIGCCoreMine)
		float stats_s1; // scale
		float stats_s2; // rate rotation
		//string model;	// length 13;
		string model1;	// length 13;
		//		char pad1[2]; // CC CC
		float stats_s3; // arming time
		float stats_s4; // lifespan
		float stats_s5; // sig
		int cost;
		//		UCHAR TODO1[4];// all '0'
		string ukbmp;	// Length 13; // inactive/loadout model
		//		char pad2; // CC
		string type;	// Length 13; // part
//		string name;	// Length 25;
//		string description;	// Length 200;
//		byte group;
//		byte zero;
//		Techtree techtree;	// Length 100;
		//		char pad3[2]; // CD CD
//		float stats_sig; // *** ADDED BY TIGEREYE. WAS MARKED "TODO[4]" IN ICE ***
//		float stats_s6; // mass
//		BitArray usemask; // usemask
//		ushort stats_ss2; // cargo playload
		float stats_s7; // hitpoints
		IGCArmorClass AC;// 0B
		//		char pad4; // CD
		//ushort uid;
		BitArray stats_ss3; //features (bits mask, as in AbilityBitMask in igc.h)
		//string icon; // Length 13;
		//		char pad5; // CD
		float stats_s8; // scan range
		float stats_s9; // shot interval
		float stats_s10; // accuracy
		float stats_s11; // leading
		short stats_ss4; // ammo capacity
		short stats_projectile;
		short stats_sound; // 720 mainly (soundprobe)
		//		UCHAR pad6[2];    // CD CD 
		float stats_activation_delay; // -1 or # secs for teleport activation

		/// <summary>
		/// Constructs an IGCCoreProbe from the specified DataReader
		/// </summary>
		/// <param name="reader">The DataReader from which to read the IGCCoreProbe</param>
		public IGCCoreProbe (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_ProbeType;
			Parse(reader);
		}

		/// <summary>
		/// Reads an IGCCoreProbe from the specified DataReader
		/// </summary>
		/// <param name="reader">The DataReader from which to read the IGCCoreProbe</param>
		private void Parse (DataReader reader)
		{
			reader.Assert(0L, 0, "UNKNOWN", "Part: Probe", "First 8 bytes");
			reader.Assert(0L, 0, "UNKNOWN", "Part: Probe", "Second 8 bytes");
			stats_s1 = reader.ReadFloat();
			stats_s2 = reader.ReadFloat();
			model = reader.ReadString(13);
			model1 = reader.ReadString(13);
			reader.Assert((ushort)0xCCCC, 0, "Model: " + model, "Part: Probe", "Model1");
			stats_s3 = reader.ReadFloat();
			stats_s4 = reader.ReadFloat();
			sigmod = reader.ReadFloat();
			cost = reader.ReadInt();
			reader.Assert((int)0, 0, "UNKNOWN", "Part: Probe", "Cost");
			ukbmp = reader.ReadString(13);
			reader.Assert((byte)0xCC, 0, "UNKNOWN", "Part: Probe", "UKBMP");
			type = reader.ReadString(13);
			name = reader.ReadString(25);
			description = reader.ReadString(200);
			group = reader.ReadShort();
			techtree = new Techtree(reader);
			reader.Assert((ushort)0xCDCD, 0, name, "Part: Probe", "Techtree");
			stats_s5 = reader.ReadFloat();
			mass = reader.ReadFloat();
			usemask = new BitArray(reader.ReadBytes(2));
			amount = reader.ReadUShort();
			stats_s7 = reader.ReadFloat();
			AC = (IGCArmorClass)reader.ReadByte();
			reader.Assert((byte)0xCD, 0, name, "Part: Probe", "Armour Class");
			uid = reader.ReadUShort();
			stats_ss3 = new BitArray(reader.ReadBytes(2));
			icon = reader.ReadString(13);
			reader.Assert((byte)0xCD, uid, name, "Part: Probe", "Icon");
			stats_s8 = reader.ReadFloat();
			stats_s9 = reader.ReadFloat();
			stats_s10 = reader.ReadFloat();
			stats_s11 = reader.ReadFloat();
			stats_ss4 = reader.ReadShort();
			stats_projectile = reader.ReadShort();
			stats_sound = reader.ReadShort();
			reader.Assert((ushort)0xCDCD, uid, name, "Part: Probe", "Sound");
			stats_activation_delay = reader.ReadFloat();
		}

		/// <summary>
		/// A multiplier dictating the size of the probe
		/// </summary>
		public float Scale
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

		/// <summary>
		/// How quickly the probe spins once deployed
		/// </summary>
		public float RotationRate
		{
			get {return stats_s2;}
			set {stats_s2 = value;}
		}

//		/// <summary>
//		/// The name of the model used by these probes
//		/// </summary>
//		public string Model
//		{
//			get {return model;}
//			set {model = value;}
//		}

		/// <summary>
		/// UNKNOWN
		/// </summary>
		public string Model1
		{
			get {return model1;}
			set {model1 = value;}
		}

		/// <summary>
		/// The amount of time it takes to arm these probes
		/// </summary>
		public float ArmingTime
		{
			get {return stats_s3;}
			set {stats_s3 = value;}
		}

		/// <summary>
		/// The length of time these probes remain once deployed
		/// </summary>
		public float LifeSpan
		{
			get {return stats_s4;}
			set {stats_s4 = value;}
		}

		/// <summary>
		/// The signature of a pack of these probes while floating in space
		/// </summary>
		public float SignatureFloating
		{
			get {return stats_s5;}
			set {stats_s5 = value;}
		}

		/// <summary>
		/// The cost to purchase one of these probes to load into your ship
		/// </summary>
		public int Cost
		{
			get {return cost;}
			set {cost = value;}
		}

		/// <summary>
		/// The name of the model to display on the Ship Loadout screen
		/// </summary>
		public string LoadoutModel
		{
			get {return ukbmp;}
			set {ukbmp = value;}
		}

		/// <summary>
		/// The type of this object ("part")
		/// </summary>
		public string Type
		{
			get {return type;}
			set {type = value;}
		}

//		/// <summary>
//		/// The name of this Probe
//		/// </summary>
//		public string Name
//		{
//			get {return name;}
//			set {name = value;}
//		}
//
//		/// <summary>
//		/// A description that describes this probe
//		/// </summary>
//		public string Description
//		{
//			get {return description;}
//			set {description = value;}
//		}
//
//		/// <summary>
//		/// UNKNOWN
//		/// </summary>
//		public byte Group
//		{
//			get {return group;}
//			set {group = value;}
//		}
//
//		/// <summary>
//		/// UNKNOWN
//		/// </summary>
//		public byte Zero
//		{
//			get {return zero;}
//			set {zero = value;}
//		}
//
//		/// <summary>
//		/// The set of prerequisites and definitions this probe defines/requires
//		/// </summary>
//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}

//		/// <summary>
//		/// The signature modifier for when the probes are loaded in a ship
//		/// </summary>
//		public float Signature
//		{
//			get {return stats_sig;}
//			set {stats_sig = value;}
//		}
//
//		/// <summary>
//		/// The mass value of these missiles
//		/// </summary>
//		public float Mass
//		{
//			get {return stats_s6;}
//			set {stats_s6 = value;}
//		}
//		
//		/// <summary>
//		/// A set of flags dictating which ships can mount these probes
//		/// </summary>
//		public BitArray UseMask
//		{
//			get {return usemask;}
//			set {usemask = value;}
//		}
//
//		/// <summary>
//		/// The number of cargo units occupied by these probes
//		/// </summary>
//		public ushort CargoPayload
//		{
//			get {return stats_ss2;}
//			set {stats_ss2 = value;}
//		}

		/// <summary>
		/// The number of hitpoints required to destroy these probes
		/// </summary>
		public float Hitpoints
		{
			get {return stats_s7;}
			set {stats_s7 = value;}
		}

		/// <summary>
		/// The ArmorClass of these probes
		/// </summary>
		public IGCArmorClass ArmorClass
		{
			get {return AC;}
			set {AC = value;}
		}

//		/// <summary>
//		/// The Unique ID of these probes
//		/// </summary>
//		public ushort UID
//		{
//			get {return uid;}
//			set {uid = value;}
//		}
		
		/// <summary>
		/// Special effect exhibited by this missile, if any
		/// </summary>
		public BitArray Features
		{
			get	{return stats_ss3;}
			set {stats_ss3 = value;}
		}

//		/// <summary>
//		/// The name of the icon to be displayed by this probe
//		/// </summary>
//		public string Icon
//		{
//			get {return icon;}
//			set {icon = value;}
//		}

		/// <summary>
		/// The distance from this probe that can be seen when deployed
		/// </summary>
		public float Scanrange
		{
			get {return stats_s8;}
			set {stats_s8 = value;}
		}

		/// <summary>
		/// The amount of time to wait between firing shots
		/// </summary>
		public float ShotInterval
		{
			get {return stats_s9;}
			set {stats_s9 = value;}
		}

		/// <summary>
		/// The accuracy of the probes shots
		/// </summary>
		public float Accuracy
		{
			get {return stats_s10;}
			set {stats_s10 = value;}
		}

		/// <summary>
		/// UNKNOWN
		/// </summary>
		public float Leading
		{
			get {return stats_s11;}
			set {stats_s11 = value;}
		}

		/// <summary>
		/// The total number of shots available to this probe
		/// </summary>
		public short AmmoCapacity
		{
			get {return stats_ss4;}
			set {stats_ss4 = value;}
		}

		/// <summary>
		/// The ID of the projectile shot by this probe
		/// </summary>
		public short Projectile
		{
			get {return stats_projectile;}
			set {stats_projectile = value;}
		}

		/// <summary>
		/// The sound played by this probe (usually 720)
		/// </summary>
		public short Sound
		{
			get {return stats_sound;}
			set {stats_sound = value;}
		}

		/// <summary>
		/// The number of seconds to wait between deployment and activation
		/// </summary>
		public float ActivationDelay
		{
			get {return stats_activation_delay;}
			set {stats_activation_delay = value;}
		}
	}
}
