using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// A ship, and all its characteristics
	/// </summary>
	public class IGCCoreShip : IGCCoreObject // Tag: 29; Length: 540 to 690
	{
		int cost;
		//byte[] header; // Length 4; All zero
		string model; // Length 13;
		//byte pad1; // 00
		string icon; // Length 13;
//		string name; // Length 25;
		string description; //Length 200;
		byte zero;
		byte group; // Length 1;
//		Techtree techtree; // Length 100;
		//byte[] pad2 = new byte[2]; //00 00
		float stats_s1; // mass
		float stats_s2; // sig%
		float stats_s3; // speed
		float stats_s4; // SAX = MaxRollRate in radians
		float stats_s5; // SAY = MaxPitchRate in radians
		float stats_s6; // SAZ = MaxYawRate in radians
		float stats_s7; // SBX = DriftRoll (unit ?)
		float stats_s8; // SBY = DriftPitch (unit ?) 
		float stats_s9; // SBZ = DriftYaw  (unit ?)
		float stats_s10; // max thrust
		float stats_s11; // STM (side thrust multiplier)
		float stats_s12; // RTM (reverse thrust multiplier)
		float stats_s13; // scan
		float stats_s14; // fuel
		float stats_s15; // lock mode (ecm)
		float stats_s16; // scale
		float stats_s17; // energy
		float stats_s18; // recharge
		float stats_s19; // rip time
		float stats_s20; // rip cost
		ushort stats_ss1; // ammo capacity
		//ushort uid; // confirmed
		short overriding_uid; // -1 if none
		byte nb_parts; // part size = 30
		byte mnt_nbwpslots;
		float stats_hp;  // hitpoints
		//byte[] TODO2 = new byte[2]; //1C 02
		byte AC;
		//byte pad; = 0
		ushort stats_ld1; // missiles capacity
		ushort stats_ld2; // pack capacity
		ushort stats_ld3; // CM capacity
		short[] def_loadout; // Length 14; -1 or part uid
		BitArray hullability;
		//byte[] TODO3 = new byte[14];// all zero
		BitArray[] can_use; // Length 8; usage masks,see IGCShipUseMasks
		ushort Sound_Interior;
		ushort Sound_Exterior;
		ushort Sound_ThrustInterior;
		ushort Sound_ThrustExterior;
		ushort Sound_TurnInterior;
		ushort Sound_TurnExterior;
		//byte[] TODO4 = new byte[2];// all zero
		IGCCoreShipMP[] parts;

		public IGCCoreShip (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_BucketStart;
			def_loadout = new short[14];
			can_use = new BitArray[8];

			Parse(reader);
		}

		public void Parse (DataReader reader)
		{
			cost = reader.ReadInt();
			reader.Assert((int)0, 0, "UNKNOWN", "Ship", "Cost");
			model = reader.ReadString(13); // Length 13;
			reader.Assert((byte)0, 0, "Model: " + model, "Ship", "Model");

			icon = reader.ReadString(13); // Length 13;
			name = reader.ReadString(25); // Length 25;
			description = reader.ReadString(200); //Length 200;
			zero = reader.ReadByte(); // Length 1;
			group = reader.ReadByte(); // Length 1;
			techtree = new Techtree(reader); // Length 100;
			reader.Assert((short)0, 0, name, "Ship", "Techtree");
			
			stats_s1 = reader.ReadFloat(); // mass
			stats_s2 = reader.ReadFloat(); // sig%
			stats_s3 = reader.ReadFloat(); // speed
			stats_s4 = reader.ReadFloat(); // SAX = MaxRollRate in radians
			stats_s5 = reader.ReadFloat(); // SAY = MaxPitchRate in radians
			stats_s6 = reader.ReadFloat(); // SAZ = MaxYawRate in radians
			stats_s7 = reader.ReadFloat(); // SBX = DriftRoll (unit ?)
			stats_s8 = reader.ReadFloat(); // SBY = DriftPitch (unit ?) 
			stats_s9 = reader.ReadFloat(); // SBZ = DriftYaw  (unit ?)
			stats_s10 = reader.ReadFloat(); // max thrust
			stats_s11 = reader.ReadFloat(); // STM (side thrust multiplier)
			stats_s12 = reader.ReadFloat(); // RTM (reverse thrust multiplier)
			stats_s13 = reader.ReadFloat(); // scan
			stats_s14 = reader.ReadFloat(); // fuel
			stats_s15 = reader.ReadFloat(); // lock mode (ecm)
			stats_s16 = reader.ReadFloat(); // scale
			stats_s17 = reader.ReadFloat(); // energy
			stats_s18 = reader.ReadFloat(); // recharge
			stats_s19 = reader.ReadFloat(); // rip time
			stats_s20 = reader.ReadFloat(); // rip cost
			stats_ss1 = reader.ReadUShort(); // ammo capacity
			uid = reader.ReadUShort(); // confirmed
			overriding_uid = reader.ReadShort(); // -1 if none
			nb_parts = reader.ReadByte(); // Length 1; part size = 30
			mnt_nbwpslots = reader.ReadByte(); // Length 1
			stats_hp = reader.ReadFloat(); 
			reader.Assert((ushort)0x021C, uid, name, "Ship", "Hitpoints");

			AC = reader.ReadByte();
			reader.Assert((byte)0, uid, name, "Ship", "Armour Class");
			stats_ld1 = reader.ReadUShort(); // missiles capacity
			stats_ld2 = reader.ReadUShort(); // pack capacity
			stats_ld3 = reader.ReadUShort(); // CM capacity
			for (int i = 0; i < 14; i++)
			{
				def_loadout[i] = reader.ReadShort(); // Length 14; -1 or part uid
			}
			hullability = new BitArray(reader.ReadBytes(2));
			reader.Skip(14); // all zero

			for (int i = 0; i < 8; i++)
			{
				can_use[i] = new BitArray(reader.ReadBytes(2)); // Length 8; usage masks,see IGCShipUseMasks
			}
			Sound_Interior = reader.ReadUShort();
			Sound_Exterior = reader.ReadUShort();
			Sound_ThrustInterior = reader.ReadUShort();
			Sound_ThrustExterior = reader.ReadUShort();
			Sound_TurnInterior = reader.ReadUShort();
			Sound_TurnExterior = reader.ReadUShort();
			reader.Assert((short)0, uid, name, "Ship", "Exterior Turn Sound");

			parts = new IGCCoreShipMP[nb_parts];
			for (int i = 0; i < nb_parts; i++)
			{
				IGCCoreShipMP Part = new IGCCoreShipMP(reader);
				parts[i] = Part; // Length 20
			}
		}

		/// <summary>
		/// The amount of credits required to purchase one of these ships
		/// </summary>
		public int Cost
		{
			get {return cost;}
			set {cost = value;}
		}

		/// <summary>
		/// The name of the model used by this ship
		/// </summary>
		public string Model
		{
			get {return model;}
			set {model = value;}
		}

		/// <summary>
		/// The name of the icon to be displayed by this ship
		/// </summary>
		public string Icon
		{
			get {return icon;}
			set {icon = value;}
		}

//		/// <summary>
//		/// The name of this ship
//		/// </summary>
//		public string Name
//		{
//			get {return name;}
//			set {name = value;}
//		}

		/// <summary>
		/// A description that describes this probe
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
//		/// The set of prerequisites and definitions this probe defines/requires
//		/// </summary>
//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}

		/// <summary>
		/// The mass of this ship
		/// </summary>
		public float Mass
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

		/// <summary>
		/// The signature modifier of this ship
		/// </summary>
		public float Signature
		{
			get {return stats_s2;}
			set {stats_s2 = value;}
		}

		/// <summary>
		/// The maximum speed of this ship
		/// </summary>
		public float MaxSpeed
		{
			get {return stats_s3;}
			set {stats_s3 = value;}
		}

		/// <summary>
		/// The rate at which this ship can roll
		/// </summary>
		public float RollRate
		{
			get {return stats_s4;}
			set {stats_s4 = value;}
		}

		/// <summary>
		/// The rate at which this can ship pitch up/down
		/// </summary>
		public float PitchRate
		{
			get {return stats_s5;}
			set {stats_s5 = value;}
		}

		/// <summary>
		/// The rate at which this ship can yaw left and right
		/// </summary>
		public float YawRate
		{
			get {return stats_s6;}
			set {stats_s6 = value;}
		}
		

		/// <summary>
		/// The amount of drifting or "extra rolling" that occurs after a Roll operation is stopped
		/// </summary>
		public float RollTorque
		{
			get {return stats_s7;}
			set {stats_s7 = value;}
		}

		/// <summary>
		/// The amount of drifting or "extra pitching" that occurs after a Pitch operation is stopped
		/// </summary>
		public float PitchTorque
		{
			get {return stats_s8;}
			set {stats_s8 = value;}
		}

		/// <summary>
		/// The amount of drifting or "extra turning" that occurs after a Yaw operation is stopped
		/// </summary>
		public float YawTorque
		{
			get {return stats_s9;}
			set {stats_s9 = value;}
		}

		/// <summary>
		/// The maximum thrust exertable by this ship
		/// </summary>
		public float MaxThrust
		{
			get {return stats_s10;}
			set {stats_s10 = value;}
		}

		/// <summary>
		/// The percentage of thrust exertable to the sides
		/// </summary>
		public float SideThrustMultiplier
		{
			get {return stats_s11;}
			set {stats_s11 = value;}
		}

		/// <summary>
		/// The percentage of thrust exertable to the rear
		/// </summary>
		public float ReverseThrustMultiplier
		{
			get {return stats_s12;}
			set {stats_s12 = value;}
		}

		/// <summary>
		/// The distance from this ship that can be seen
		/// </summary>
		public float Scanrange
		{
			get {return stats_s13;}
			set {stats_s13 = value;}
		}

		/// <summary>
		/// The amount of fuel carried by this ship
		/// </summary>
		public float Fuel
		{
			get {return stats_s14;}
			set {stats_s14 = value;}
		}

		/// <summary>
		/// The ability for this ship to evade missile locks (Default 1)
		/// </summary>
		public float ECM
		{
			get {return stats_s15;}
			set {stats_s15 = value;}
		}

		/// <summary>
		/// A multiplier dictating the size of this ship
		/// </summary>
		public float Scale
		{
			get {return stats_s16;}
			set {stats_s16 = value;}
		}

		/// <summary>
		/// The amount of energy this ship can hold
		/// </summary>
		public float Energy
		{
			get {return stats_s17;}
			set {stats_s17 = value;}
		}

		/// <summary>
		/// The rate at which this ship recharges its energy
		/// </summary>
		public float RechargeRate
		{
			get {return stats_s18;}
			set {stats_s18 = value;}
		}

		/// <summary>
		/// The number of seconds this ship requires to ripcord
		/// </summary>
		public float RipcordTime
		{
			get {return stats_s19;}
			set {stats_s19 = value;}
		}

		/// <summary>
		/// The amount of energy required in a SmallRipcord for this ship to be able to ripcord
		/// </summary>
		public float RipcordCost
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

		/// <summary>
		/// The amount of ammo this ship can carry
		/// </summary>
		public ushort AmmoCapacity
		{
			get {return stats_ss1;}
			set {stats_ss1 = value;}
		}

//		/// <summary>
//		/// The Unique ID of this ship
//		/// </summary>
//		public ushort UID
//		{
//			get {return uid;}
//			set {uid = value;}
//		}

		/// <summary>
		/// The ID of the ship that this one overrides, or -1 if none
		/// </summary>
		public short OverridingUID
		{
			get {return overriding_uid;}
			set {overriding_uid = value;}
		}

		/// <summary>
		/// The number of weapon mounts (Turreted and non-turreted) on this ship
		/// </summary>
		public int NumberOfParts
		{
			get {return (parts == null) ? 0 : parts.Length;}
		}

		/// <summary>
		/// The number of pilot-controlled weapon mounts on this ship
		/// </summary>
		public byte NumberOfWeaponSlots
		{
			get {return mnt_nbwpslots;}
			set {mnt_nbwpslots = value;}
		}

		/// <summary>
		/// The number of hitpoints this ship's hull has
		/// </summary>
		public float Hitpoints
		{
			get {return stats_hp;}
			set {stats_hp = value;}
		}

		public IGCArmorClass ArmorClass
		{
			get {return (IGCArmorClass)AC;}
			set {AC = (byte)value;}
		}

		public ushort MissileCapacity
		{
			get {return stats_ld1;}
			set {stats_ld1 = value;}
		}

		public ushort PackCapacity
		{
			get {return stats_ld2;}
			set {stats_ld2 = value;}
		}

		public ushort CountermeasureCapacity
		{
			get {return stats_ld3;}
			set {stats_ld3 = value;}
		}

		public short[] DefaultLoadout
		{
			get {return def_loadout;}
			set {def_loadout = value;}
		}

		public BitArray Abilities
		{
			get {return hullability;}
			set {hullability = value;}
		}

		public BitArray[] UseMasks
		{
			get {return can_use;}
			set {can_use = value;}
		}

		/// <summary>
		/// The sound played on the inside of this ship
		/// </summary>
		public ushort SoundInterior
		{
			get {return Sound_Interior;}
			set {Sound_Interior = value;}
		}
		
		/// <summary>
		/// The sound played on the outside of this ship
		/// </summary>
		public ushort SoundExterior
		{
			get {return Sound_Exterior;}
			set {Sound_Exterior = value;}
		}
		
		/// <summary>
		/// The sound played on the inside of this ship when the thrusters are fired
		/// </summary>
		public ushort SoundThrustInterior
		{
			get {return Sound_ThrustInterior;}
			set {Sound_ThrustInterior = value;}
		}
		
		/// <summary>
		/// The sound played on the outside of this ship when the thrusters are fired
		/// </summary>
		public ushort SoundThrustExterior
		{
			get {return Sound_ThrustExterior;}
			set {Sound_ThrustExterior = value;}
		}
		
		/// <summary>
		/// The sound played on the inside of this ship when it turns
		/// </summary>
		public ushort SoundTurnInterior
		{
			get {return Sound_TurnInterior;}
			set {Sound_TurnInterior = value;}
		}
		
		/// <summary>
		/// The sound played on the outside of this ship when it turns
		/// </summary>
		public ushort SoundTurnExterior
		{
			get {return Sound_TurnExterior;}
			set {Sound_TurnExterior = value;}
		}

		/// <summary>
		/// Weapons on this ship (turretable and non-turretable)
		/// </summary>
		public IGCCoreShipMP[] WeaponMounts
		{
			get {return parts;}
			set {parts = value;}
		}
	}
}
