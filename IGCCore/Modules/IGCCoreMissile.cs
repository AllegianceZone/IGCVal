using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// A missile part that can be picked up, mounted, and fired by capable ships
	/// </summary>
	public class IGCCoreMissile : IGCCorePart // Tag: 23; Length: 704
	{
		//byte[] header; // Length 16; ALL ZERO
		float stats_s1; // scale
		float stats_s2; // rate rotation
		string ldbmp; // Length 13;
		//byte[] pad0; // Length 13 ALL ZERO
		//byte[] pad1;  // Length 2; 
		float stats_s3; // reload time
		float stats_s4; // life span
		float stats_s5; // sig
		int cost;
		//int pad2; // Zero - Checked
		//string model; // Length 13;
		//byte pad3; // Length 1; C - Checked
		string type; // Length 13; //part
		//string name; // Length 25;
		//string description; // Length 200
		//byte group;
		//byte zero;
		//Techtree techtree; // Length 100;
		//byte[] pad4; // Length 2; //CD CD - checked
		//float stats_sig; // sig%
		//float stats_s6; // mass
		//BitArray use_flags;
		//ushort stats_ss1; // cargo payload
		float stats_s16; // hitpoints
		byte AC; // 0B
		//byte pad5; // CD - Checked
		//ushort uid;
		ushort special_effect; // 1 for nerve, 2 for reso , 0 otherwise
		//string icon; // Length 13;
		//byte pad6;//CD - Checked
		float stats_s7; // accel
		float stats_s8; // turn radius
		float stats_s9; // launch velocity
		float stats_s10; // lock time
		float stats_s11; // ready time
		float stats_s12; // max lock
		float stats_s13; // CM resistance
		float stats_s14; // salvo ratio
		float stats_s15; // lock radius
		float stats_damage;
		float stats_unused1; // 0 Checked
		float stats_damage_radius;
		float stats_unused2; // 0 Checked
		ushort DM; 
		ushort stats_ss3; //sound launch
		ushort stats_ss4; //sound flight
		//byte[] end; // Length 2; //CDCD

		short launchCount;
		short qtyPerPack;

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="values"></param>
		public IGCCoreMissile (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_MissileType;
			Parse(reader);
		}

		/// <summary>
		/// Loads the IGCCoreMissile values from the specified DataReader
		/// </summary>
		/// <param name="reader">The DataReader from which to read the IGCCoreMissile</param>
		private void Parse (DataReader reader)
		{
			reader.Assert(0L, 0, "UNKNOWN", "Part: Missile", "First 8 bytes");
			reader.Assert(0L, 0, "UNKNOWN", "Part: Missile", "2nd 8 bytes");

			stats_s1 = reader.ReadFloat();
			stats_s2 = reader.ReadFloat();
			ldbmp = reader.ReadString(13);
			reader.Seek(13);
			reader.Assert((ushort)0xCCCC, 0, "Unknown", "Part: Missile", "13-byte spacer after LDBMP");
			stats_s3 = reader.ReadFloat();
			stats_s4 = reader.ReadFloat();
			stats_s5 = reader.ReadFloat();
			cost = reader.ReadInt();
			reader.Assert((int)0, uid, "UNKNOWN", "Part: Missile", "Cost");
			model = reader.ReadString(13);
			reader.Assert((byte)0xCC, 0, "UNKNOWN", "Part: Missile", "Model");
			type = reader.ReadString(13);
			name = reader.ReadString(25);
			description = reader.ReadString(200);
			group = reader.ReadShort();
			techtree = new Techtree(reader);
			reader.Assert((ushort)0xCDCD, 0, name, "Part: Missile", "Techtree");
			sigmod = reader.ReadFloat();
			mass = reader.ReadFloat();
			usemask = new BitArray(reader.ReadBytes(2));
			amount = reader.ReadUShort();
			stats_s16 = reader.ReadFloat();
			AC = reader.ReadByte();
			reader.Assert((byte)0xCD, 0, name, "Part: Missile", "AC");
			uid = reader.ReadUShort();
			special_effect = reader.ReadUShort();
			icon = reader.ReadString(13);
			reader.Assert((byte)0xCD, uid, name, "Part: Missile", "Icon");
			stats_s7 = reader.ReadFloat(); // accel
			stats_s8 = reader.ReadFloat(); // turn radius
			stats_s9 = reader.ReadFloat(); // launch velocity
			stats_s10 = reader.ReadFloat(); // lock time
			stats_s11 = reader.ReadFloat(); // ready time
			stats_s12 = reader.ReadFloat(); // max lock
			stats_s13 = reader.ReadFloat(); // CM resistance
			stats_s14 = reader.ReadFloat(); // salvo ratio
			stats_s15 = reader.ReadFloat(); // lock radius
			stats_damage = reader.ReadFloat();
			stats_unused1 = reader.ReadFloat(); // 0 Checked
			stats_damage_radius = reader.ReadFloat();
			stats_unused2 = reader.ReadFloat(); // 0 Checked
			DM = reader.ReadUShort(); 
			stats_ss3 = reader.ReadUShort(); //sound launch
			stats_ss4 = reader.ReadUShort(); //sound flight
			reader.Assert((ushort)0xCDCD, uid, name, "Part: Missile", "Flight Sound");
		}

		/// <summary>
		/// A multiplier dictating the size of the missile
		/// </summary>
		public float Scale
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

		/// <summary>
		/// How quickly the missile spins while inflight
		/// </summary>
		public float RotationRate
		{
			get {return stats_s2;}
			set {stats_s2 = value;}
		}

		/// <summary>
		/// The name of the model to display on the Ship Loadout screen
		/// </summary>
		public string LoadoutModel
		{
			get {return ldbmp;}
			set {ldbmp = value;}
		}

		/// <summary>
		/// The amount of time it takes to reload these missiles
		/// </summary>
		public float ReloadTime
		{
			get {return stats_s3;}
			set {stats_s3 = value;}
		}

		/// <summary>
		/// The length of time these missiles remain inflight
		/// </summary>
		public float LifeSpan
		{
			get {return stats_s4;}
			set {stats_s4 = value;}
		}

		/// <summary>
		/// The signature of a pack of these missiles while floating in space
		/// </summary>
		public float SignatureFloating
		{
			get {return stats_s5;}
			set {stats_s5 = value;}
		}

		/// <summary>
		/// The cost to purchase one of these missiles to load into your ship
		/// </summary>
		public int Cost
		{
			get {return cost;}
			set {cost = value;}
		}

//		/// <summary>
//		/// The name of the model used by these missiles
//		/// </summary>
//		public string Model
//		{
//			get {return model;}
//			set {model = value;}
//		}

		/// <summary>
		/// The type of this object ("part")
		/// </summary>
		public string Type
		{
			get {return type;}
			set {type = value;}
		}

//		/// <summary>
//		/// The name of this Missile
//		/// </summary>
//		public string Name
//		{
//			get {return name;}
//			set {name = value;}
//		}
//
//		/// <summary>
//		/// A description that describes this missile
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
//		/// The set of prerequisites and definitions this missile defines/requires
//		/// </summary>
//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}
//
//		/// <summary>
//		/// The signature modifier for when the missiles are loaded in a ship
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
//		/// A set of flags dictating which ships can mount these missiles
//		/// </summary>
//		public BitArray UseMask
//		{
//			get {return use_flags;}
//			set {use_flags = value;}
//		}
//
//		/// <summary>
//		/// The number of cargo units occupied by these missiles
//		/// </summary>
//		public ushort CargoPayload
//		{
//			get {return stats_ss1;}
//			set {stats_ss1 = value;}
//		}

		/// <summary>
		/// The number of hitpoints required to destroy these missiles
		/// </summary>
		public float Hitpoints
		{
			get {return stats_s16;}
			set {stats_s16 = value;}
		}

		/// <summary>
		/// The ArmorClass of these missiles
		/// </summary>
		public byte ArmorClass
		{
			get {return AC;}
			set {AC = value;}
		}

//		/// <summary>
//		/// The Unique ID of these missiles
//		/// </summary>
//		public ushort UID
//		{
//			get {return uid;}
//			set {uid = value;}
//		}
		
		/// <summary>
		/// Special effect exhibited by this missile, if any
		/// </summary>
		public MissileSpecialEffect SpecialEffect
		{
			get {return (MissileSpecialEffect)special_effect;}
			set {special_effect = (ushort)value;}
		}

//		/// <summary>
//		/// The name of the icon to be displayed by this missile
//		/// </summary>
//		public string Icon
//		{
//			get {return icon;}
//			set {icon = value;}
//		}

		/// <summary>
		/// How quickly these missiles accelerate after being fired;
		/// </summary>
		public float Acceleration
		{
			get {return stats_s7;}
			set {stats_s7 = value;}
		}

		/// <summary>
		/// Defines how sharply these missiles turn
		/// </summary>
		public float TurnRadius
		{
			get {return stats_s8;}
			set {stats_s8 = value;}
		}

		/// <summary>
		/// Determines the missile's speed the moment it is launched by a player
		/// </summary>
		public float LaunchVelocity
		{
			get {return stats_s9;}
			set {stats_s9 = value;}
		}

		/// <summary>
		/// The amount of time needed for these missiles to "lock" on their targets
		/// </summary>
		public float LockTime
		{
			get {return stats_s10;}
			set {stats_s10 = value;}
		}

		/// <summary>
		/// The amount of time it takes for these missiles to become ready
		/// </summary>
		public float ReadyTime
		{
			get {return stats_s11;}
			set {stats_s11 = value;}
		}

		/// <summary>
		/// A multiplier dictating the amount of lock this missile makes on its target
		/// </summary>
		public float MaxLock
		{
			get {return stats_s12;}
			set {stats_s12 = value;}
		}

		/// <summary>
		/// A multiplier of how well this missile resists countermeasures
		/// </summary>
		public float CountermeasureResistance
		{
			get {return stats_s13;}
			set {stats_s13 = value;}
		}

		/// <summary>
		/// The distance between missiles when LaunchCount > 1
		/// </summary>
		public float MissileSeparation
		{
			get {return stats_s14;}
			set {stats_s14 = value;}
		}

		/// <summary>
		/// The size of the circle in which a lock can be aquired
		/// </summary>
		public float LockRadius
		{
			get {return stats_s15;}
			set {stats_s15 = value;}
		}

		/// <summary>
		/// The number of hitpoints dealt by one of these missiles
		/// </summary>
		public float Damage
		{
			get {return stats_damage;}
			set {stats_damage = value;}
		}

		/// <summary>
		/// The blast radius of the missile (usually 0, except for res)
		/// </summary>
		public float DamageRadius
		{
			get {return stats_damage_radius;}
			set {stats_damage_radius = value;}
		}

		/// <summary>
		/// The damage class that this missile deals
		/// </summary>
		public ushort DamageIndex
		{
			get {return DM;}
			set {DM = value;}
		}

		/// <summary>
		/// The sound played when this missile is launched
		/// </summary>
		public ushort LaunchSound
		{
			get {return stats_ss3;}
			set {stats_ss3 = value;}
		}

		/// <summary>
		/// The sound this missile makes in flight
		/// </summary>
		public ushort FlightSound
		{
			get {return stats_ss4;}
			set {stats_ss4 = value;}
		}

		//==============
		public short LaunchCount
		{
			get {return launchCount;}
			set {launchCount = value;}
		}

		public short QtyPerPack
		{
			get {return qtyPerPack;}
			set {qtyPerPack = value;}
		}
	}
}
