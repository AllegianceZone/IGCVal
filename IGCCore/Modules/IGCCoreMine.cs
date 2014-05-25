using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreMine.
	/// </summary>
	public class IGCCoreMine : IGCCorePart
	{
		float pcRED; // all zero = percent RGBA
		float pcGreen;
		float pcBlue;
		float pcAlpha;
		//UCHAR pad0[4]; // all 'CC' (could be float 'scale')
		float stats_s1; // rate rotation 
		//UCHAR pad1[13]; // all '00'
		//string icon; // Length [13]; //fxmine
		//UCHAR pad2[2]; // all 'CC'
		float stats_s2; // load time
		float stats_duration;
		float stats_s3; // sig
		int cost;
		//UCHAR pad3[4]; // all '00'
		//string model; // Length [13];// inactive & loadout bmp (prefix with 'l')
		//UCHAR pad4; // CC
		string type; // Length [13]; //part
		//string name; // Length [25];
		//string description; // Length [200];
		//byte group;
		//byte zero;
		//Techtree techtree;
		//UCHAR pad5[2]; // CD
		//float stats_s4; // ship sig%
		//float stats_s5; // mass
		//BitArray usemask; //usemask	(2)
		//ushort stats_ss2; //cargo payload
		float stats_s6; // hitpoints
		IGCArmorClass AC; // OB
		//UCHAR pad6[1]; // CD 
		//ushort uid;
		//ushort pad_zero; // 0000
		string ukbmp; // length [13]; // icon bmp
		//UCHAR pad7; // CD
		float stats_radius;
		float stats_damage;
		float stats_endurance; // endurance
		byte DM; // 10
//		UCHAR pad8[3]; // CD CD CD

		public IGCCoreMine (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_MineType;
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			pcRED = reader.ReadFloat(); // all zero = percent RGBA
			pcGreen = reader.ReadFloat();
			pcBlue = reader.ReadFloat();
			pcAlpha = reader.ReadFloat();
			reader.Assert((uint)0xCCCCCCCC, 0, "UNKNOWN", "Part: Mine", "RGBA Colours");
			stats_s1 = reader.ReadFloat(); // rate rotation
			reader.Skip(13);
			icon = reader.ReadString(13); // Length [13]; //fxmine
			reader.Assert((ushort)0xCCCC, 0, "UNKNOWN", "Part: Mine", "Icon");
			stats_s2 = reader.ReadFloat(); // load time
			stats_duration = reader.ReadFloat();
			stats_s3 = reader.ReadFloat(); // sig
			cost = reader.ReadInt();
			reader.Assert((int)0, 0, "UNKNOWN", "Part: Mine", "Cost");
			model = reader.ReadString(13); // Length [13];// inactive & loadout bmp (prefix with 'l')
			reader.Assert((byte)0xCC, 0, "UNKNOWN", "Part: Mine", "Model");
			type = reader.ReadString(13); // Length [13]; //part
			name = reader.ReadString(25); // Length [25];
			description = reader.ReadString(200); // Length [200];
			group = reader.ReadShort();
			techtree = new Techtree(reader);
			reader.Assert((ushort)0xCDCD, 0, name, "Part: Mine", "Techtree");
			sigmod = reader.ReadFloat(); // ship sig%
			mass = reader.ReadFloat(); // mass
			usemask = new BitArray(reader.ReadBytes(2)); //usemask	(2)
			amount = reader.ReadUShort(); //cargo payload
			stats_s6 = reader.ReadFloat(); // hitpoints
			AC = (IGCArmorClass)reader.ReadByte(); // OB
			reader.Assert((byte)0xCD, 0, name, "Part: Mine", "Armour Class");
			uid = reader.ReadUShort();
			reader.Assert((short)0, uid, name, "Part: Mine", "UID");
			ukbmp = reader.ReadString(13); // length [13]; // icon bmp
			reader.Assert((byte)0xCD, uid, name, "Part: Mine", "UKBMP");
			stats_radius = reader.ReadFloat();
			stats_damage = reader.ReadFloat();
			stats_endurance = reader.ReadFloat(); // endurance
			DM = reader.ReadByte(); // 10
			reader.Assert((byte)0xCD, uid, name, "Part: Mine", "Damage Index");
			reader.Assert((ushort)0xCDCD, uid, name, "Part: Mine", "Damage Index");
		}

		public float Red
		{
			get {return pcRED;}
			set {pcRED = value;}
		}

		public float Green
		{
			get {return pcGreen;}
			set {pcGreen = value;}
		}

		public float Blue
		{
			get {return pcBlue;}
			set {pcBlue = value;}
		}

		public float Alpha
		{
			get {return pcAlpha;}
			set {pcAlpha = value;}
		}

		public float RateRotation
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

//		public string Icon
//		{
//			get {return icon;}
//			set {icon = value;}
//		}

		public float LoadTime
		{
			get {return stats_s2;}
			set {stats_s2 = value;}
		}

		public float Duration
		{
			get {return stats_duration;}
			set {stats_duration = value;}
		}

		public float SignatureFloating
		{
			get {return stats_s3;}
			set {stats_s3 = value;}
		}

		public int Cost
		{
			get {return cost;}
			set {cost = value;}
		}

//		public string Model
//		{
//			get {return model;}
//			set {model = value;}
//		}

		public string Type
		{
			get {return type;}
			set {type = value;}
		}

//		public string Name
//		{
//			get {return name;}
//			set {name = value;}
//		}
//
//		public string Description
//		{
//			get {return description;}
//			set {description = value;}
//		}
//
//		public byte Group
//		{
//			get {return group;}
//			set {group = value;}
//		}
//
//		public byte Zero
//		{
//			get {return zero;}
//			set {zero = value;}
////		}
//
//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}
//
//		public float Signature
//		{
//			get {return stats_s4;}
//			set {stats_s4 = value;}
//		}
//
//		public float Mass
//		{
//			get {return stats_s5;}
//			set {stats_s5 = value;}
//		}
//
//		public BitArray UseMask
//		{
//			get {return usemask;}
//			set {usemask = value;}
//		}
//
//		public ushort CargoPayload
//		{
//			get {return stats_ss2;}
//			set {stats_ss2 = value;}
//		}

		public float Hitpoints
		{
			get {return stats_s6;}
			set {stats_s6 = value;}
		}

		public IGCArmorClass ArmorClass
		{
			get {return AC;}
			set {AC = value;}
		}

		public string UKBMP
		{
			get {return ukbmp;}
			set {ukbmp = value;}
		}

		public float Radius
		{
			get {return stats_radius;}
			set {stats_radius = value;}
		}

		public float Damage
		{
			get {return stats_damage;}
			set {stats_damage = value;}
		}

		public float Endurance
		{
			get {return stats_endurance;}
			set {stats_endurance = value;}
		}

		public byte DamageIndex
		{
			get {return DM;}
			set {DM = value;}
		}
	}
}
