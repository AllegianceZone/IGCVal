using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Base class for all ship parts.
	/// </summary>
	public abstract class IGCCorePart : IGCCoreObject
	{
		// byte[] header; // Length 8; all zero
		protected string model;  // Length 13;
		//byte pad1; // CC
		protected string icon; // Length 13;
//		protected string name; // Length 25;
		protected string description; // Length 200;
		protected short group;
//		protected Techtree techtree; // Length 100;
		// byte[] pad2; // Length 2; CC CC
		protected float mass; // Mass
		protected ushort amount;	//
		protected float sigmod;
		//protected ushort uid;
		protected short overriding_uid; // uid of part that overrides this one (-1 if none)
		protected short parttype; // 1 = weapon, 2 = shield, 5 = cloak, 7 = after, 6 = default
		protected BitArray usemask; // = uid a corresponding object for SPECS PARTS
		protected string slot; // Length 13;
		//byte pad3; // CC -  END FOR MISSILE/CHAFF/MINES (SPECS PARTS)
		//byte[] pad4; // Length 2; CC CC

		protected ushort specUID = 0;

		public IGCCorePart ()
		{
		}

		public IGCCorePart (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_PartType;
			if (reader != null)
				Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			reader.Assert(0L, 0, "UNKNOWN", "Part", "First 4 bytes");

			model = reader.ReadString(13);
			reader.Assert((byte)0xCC, 0, "Model: " + model, "UNKNOWN PART", "Model");

			icon = reader.ReadString(13);
			name = reader.ReadString(25);
			description = reader.ReadString(200);
			group = reader.ReadShort();
			techtree = new Techtree(reader);

			reader.Assert((ushort)0xCCCC, 0, name, "UNKNOWN PART", "Techtree");

			mass = reader.ReadFloat();
			sigmod = reader.ReadFloat();
			uid = reader.ReadUShort();
			specUID = uid;
			overriding_uid = reader.ReadShort();
			parttype = reader.ReadShort();
			usemask = new BitArray(reader.ReadBytes(2));
			slot = reader.ReadString(13);
			
			string PartTypeName = PartType.GetName(typeof(PartType), parttype);
			//reader.Assert((byte)0xCC, uid, name, PartTypeName, "Slot");
			reader.Skip(1);
			reader.Assert((ushort)0xCCCC, uid, name, PartTypeName, "Slot");
		}

		public string Model
		{
			get {return model;}
			set {model = value;}
		}

		public string Icon
		{
			get {return icon;}
			set {icon = value;}
		}

//		public string Name
//		{
//			get {return name;}
//			set {name = value;}
//		}

		public string Description
		{
			get {return description;}
			set {description = value;}
		}

		public short Group
		{
			get {return group;}
			set {group = value;}
		}

//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}

		public float Signature
		{
			get {return sigmod;}
			set {sigmod = value;}
		}
		
		public ushort SpecUID
		{
			get {return specUID;}
			set {specUID = value;}
		}
//
//		public ushort UID
//		{
//			get {return uid;}
//			set {uid = value;}
//		}
		
		public float Mass
		{
			get {return mass;}
			set {mass = value;}
		}

		public ushort CargoPayload
		{
			get {return amount;}
			set {amount = value;}
		}

		public short OverridingUID
		{
			get {return overriding_uid;}
			set {overriding_uid = value;}
		}

		public PartType PartType
		{
			get {return (PartType)parttype;}
			set {parttype = (short)value;}
		}

		public BitArray UseMask
		{
			get {return usemask;}
			set {usemask = value;}
		}

		public string Slot
		{
			get {return slot;}
			set {slot = value;}
		}
	}

	public class IGCCorePartSpec : IGCCorePart
	{
		public IGCCorePartSpec (DataReader reader) : base(null)
		{
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			amount = reader.ReadUShort();
			uid = reader.ReadUShort();
			overriding_uid = reader.ReadShort();
			parttype = reader.ReadShort();
			group = reader.ReadShort();
			slot = reader.ReadString(13);
			reader.Assert((byte)0xCC, uid, name, PartType.GetName(typeof(PartType), parttype), "Slot");
		}

		public ushort Amount
		{
			get {return amount;}
			set {amount = value;}
		}
	}

	public class IGCCorePartWeapon: IGCCorePart
	{
		float wep_stats_s1; // Time ready
		float wep_stats_s2; // Shot interval
		float wep_stats_s3; // Energy consumption
		float wep_stats_s4; // Particle spread
		ushort wep_stats_ss1; // ammo consumption
		ushort wep_projectile_uid;
		ushort wep_stats_ss2; // activation sound
		ushort wep_stats_ss3; // shot sound
		ushort wep_stats_ss4; // burst sound
		//byte wep_pad1[2]; // CC CC

		public IGCCorePartWeapon (DataReader reader) : base(reader)
		{
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			wep_stats_s1 = reader.ReadFloat();
			wep_stats_s2 = reader.ReadFloat();
			wep_stats_s3 = reader.ReadFloat();
			wep_stats_s4 = reader.ReadFloat();

			wep_stats_ss1 = reader.ReadUShort();
			wep_projectile_uid = reader.ReadUShort();
			wep_stats_ss2 = reader.ReadUShort();
			wep_stats_ss3 = reader.ReadUShort();
			wep_stats_ss4 = reader.ReadUShort();

			reader.Assert((ushort)0xCCCC, uid, name, PartType.GetName(typeof(PartType), parttype), "Burst sound");
		}

		/// <summary>
		/// The amount of time it takes for this weapon to become ready
		/// </summary>
		public float TimeReady
		{
			get {return wep_stats_s1;}
			set {wep_stats_s1 = value;}
		}

		/// <summary>
		/// The amount of time between projectile shots
		/// </summary>
		public float ShotInterval
		{
			get {return wep_stats_s2;}
			set {wep_stats_s2 = value;}
		}

		/// <summary>
		/// The amount of energy each shot consumes
		/// </summary>
		public float EnergyConsumption
		{
			get {return wep_stats_s3;}
			set {wep_stats_s3 = value;}
		}

		/// <summary>
		/// The degree of "spread" or inaccuracy this weapon exhibits
		/// </summary>
		public float ParticleSpread
		{
			get {return wep_stats_s4;}
			set {wep_stats_s4 = value;}
		}

		/// <summary>
		/// The amount of ammo this weapon consumes
		/// </summary>
		public ushort AmmoConsumption
		{
			get {return wep_stats_ss1;}
			set {wep_stats_ss1 = value;}
		}

		/// <summary>
		/// The UID of the projectile fired by this weapon
		/// </summary>
		public ushort ProjectileUID
		{
			get {return wep_projectile_uid;}
			set {wep_projectile_uid = value;}
		}

		/// <summary>
		/// The sound played when this weapon is activated
		/// </summary>
		public ushort ActivationSound
		{
			get {return wep_stats_ss2;}
			set {wep_stats_ss2 = value;}
		}

		/// <summary>
		/// The sound played when this weapon is fired
		/// </summary>
		public ushort ShotSound
		{
			get {return wep_stats_ss3;}
			set {wep_stats_ss3 = value;}
		}

		/// <summary>
		/// The sound played when this weapon fires in a burst
		/// </summary>
		public ushort BurstSound
		{
			get {return wep_stats_ss4;}
			set {wep_stats_ss4 = value;}
		}
	}

	/// <summary>
	/// A shield part
	/// </summary>
	public class IGCCorePartShield : IGCCorePart
	{
		float shld_stats_s1; //Recharge rate
		float shld_stats_s2; //Hitpoints
		IGCArmorClass shld_AC; // armor class
		//byte shld_pad; //CC
		ushort shld_sound1;//Activate sound
		ushort shld_sound2;//Desactivate sound
		// byte[] shld_pad1; // Length 2; CC CC

		public IGCCorePartShield (DataReader reader) : base(reader)
		{
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			shld_stats_s1 = reader.ReadFloat();
			shld_stats_s2 = reader.ReadFloat();
			shld_AC = (IGCArmorClass)reader.ReadByte();
			
			string PartTypeName = PartType.GetName(typeof(PartType), parttype);
			reader.Assert((byte)0xCC, uid, name, PartTypeName, "ShieldAC");

			shld_sound1 = reader.ReadUShort();
			shld_sound2 = reader.ReadUShort();
			
			reader.Assert((ushort)0xCCCC, uid, name, PartTypeName, "Deactivate Sound");
		}

		/// <summary>
		/// The rate at which this shield recharges
		/// </summary>
		public float RechargeRate
		{
			get {return shld_stats_s1;}
			set {shld_stats_s1 = value;}
		}

		/// <summary>
		/// The number of hitpoints this shield has
		/// </summary>
		public float Hitpoints
		{
			get {return shld_stats_s2;}
			set {shld_stats_s2 = value;}
		}

		/// <summary>
		/// This shield's armor class
		/// </summary>
		public IGCArmorClass ArmorClass
		{
			get {return shld_AC;}
			set {shld_AC = value;}
		}

		/// <summary>
		/// The sound played when this shield activates
		/// </summary>
		public ushort ActivateSound
		{
			get {return shld_sound1;}
			set {shld_sound1 = value;}
		}

		/// <summary>
		/// The sound played when this shield deactivates
		/// </summary>
		public ushort DeactivateSound
		{
			get {return shld_sound2;}
			set {shld_sound2 = value;}
		}
	}

	/// <summary>
	/// A Cloak part
	/// </summary>
	public class IGCCorePartCloak : IGCCorePart
	{
		float clk_stats_s1; // Energy drain
		float clk_stats_s2; // Sig reduction
		float clk_stats_s3; // Activation duration
		float clk_stats_s4; // Release duration
		ushort clk_sound1; // sound on
		ushort clk_sound2; // sound off

		public IGCCorePartCloak (DataReader reader) : base(reader)
		{
			this.Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			clk_stats_s1 = reader.ReadFloat();
			clk_stats_s2 = reader.ReadFloat();
			clk_stats_s3 = reader.ReadFloat();
			clk_stats_s4 = reader.ReadFloat();
			clk_sound1 = reader.ReadUShort();
			clk_sound2 = reader.ReadUShort();
		}

		/// <summary>
		/// The amount of energy this shield drains per second
		/// </summary>
		public float EnergyDrain
		{
			get {return clk_stats_s1;}
			set {clk_stats_s1 = value;}
		}

		/// <summary>
		/// The amount of signature this shield reduces
		/// </summary>
		public float SignatureReduction
		{
			get {return clk_stats_s2;}
			set {clk_stats_s2 = value;}
		}

		/// <summary>
		/// The amount of time this shield takes to activate
		/// </summary>
		public float ActivationDuration
		{
			get {return clk_stats_s3;}
			set {clk_stats_s3 = value;}
		}

		/// <summary>
		/// The amount of time it takes to deactivate this shield
		/// </summary>
		public float ReleaseDuration
		{
			get {return clk_stats_s4;}
			set {clk_stats_s4 = value;}
		}

		/// <summary>
		/// The sound played when this shield activates
		/// </summary>
		public ushort ActivateSound
		{
			get {return clk_sound1;}
			set {clk_sound1 = value;}
		}

		/// <summary>
		/// The sound played when this shield deactivates
		/// </summary>
		public ushort DeactivateSound
		{
			get {return clk_sound2;}
			set {clk_sound2 = value;}
		}
	}

	/// <summary>
	/// An Afterburner part
	/// </summary>
	public class IGCCorePartAfterburner : IGCCorePart
	{
		float aftb_stats_s1; // Rate of consumption
		float aftb_stats_s2; // Thrust amount
		float aftb_stats_s3; // % acceleration
		float aftb_stats_s4; // Release duration
		ushort aftb_stats_ss1; // activate sound
		ushort aftb_stats_ss2; // desactivate sound

		public IGCCorePartAfterburner (DataReader reader) : base(reader)
		{
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			aftb_stats_s1 = reader.ReadFloat();
			aftb_stats_s2 = reader.ReadFloat();
			aftb_stats_s3 = reader.ReadFloat();
			aftb_stats_s4 = reader.ReadFloat();

			aftb_stats_ss1 = reader.ReadUShort();
			aftb_stats_ss2 = reader.ReadUShort();
		}

		/// <summary>
		/// The rate at which this afterburner consumes fuel
		/// </summary>
		public float ConsumptionRate
		{
			get {return aftb_stats_s1;}
			set {aftb_stats_s1 = value;}
		}

		/// <summary>
		/// The number of thrust applied by this afterburner
		/// </summary>
		public float Thrust
		{
			get {return aftb_stats_s2;}
			set {aftb_stats_s2 = value;}
		}

		/// <summary>
		/// This acceleration performed by this afterburner
		/// </summary>
		public float Acceleration
		{
			get {return aftb_stats_s3;}
			set {aftb_stats_s3 = value;}
		}

		/// <summary>
		/// The amount of time required for this afterburner to stop firing
		/// </summary>
		public float ReleaseDuration
		{
			get {return aftb_stats_s4;}
			set {aftb_stats_s4 = value;}
		}

		/// <summary>
		/// The sound played when this afterburner activates
		/// </summary>
		public ushort ActivateSound
		{
			get {return aftb_stats_ss1;}
			set {aftb_stats_ss1 = value;}
		}

		/// <summary>
		/// The sound played when this afterburner deactivates
		/// </summary>
		public ushort DeactivateSound
		{
			get {return aftb_stats_ss2;}
			set {aftb_stats_ss2 = value;}
		}
	}

	public class IGCCorePartPack : IGCCorePart
	{
		byte pak_stats_ss1; // Type (0=Ammo,1=fuel)
		//byte pak_pad1; // CC
		ushort pak_stats_ss2; // Quantity

		public IGCCorePartPack (DataReader reader) : base(reader)
		{
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			pak_stats_ss1 = reader.ReadByte();
			reader.Assert((byte)0xCC, uid, name, "Part: Pack", "Packtype");
			pak_stats_ss2 = reader.ReadUShort();
		}

		/// <summary>
		/// The type of pack (Ammo or Fuel)
		/// </summary>
		public PackType PackType
		{
			get {return (PackType)pak_stats_ss1;}
			set {pak_stats_ss1 = (byte)value;}
		}

		/// <summary>
		/// The quantity of ammo or fuel of this pack
		/// </summary>
		public ushort Quantity
		{
			get {return pak_stats_ss2;}
			set {pak_stats_ss2 = value;}
		}
	}
}
