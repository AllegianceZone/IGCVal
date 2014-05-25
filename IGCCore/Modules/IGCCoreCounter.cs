using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreCounter.
	/// </summary>
	public class IGCCoreCounter : IGCCorePart
	{
		float pcRED; // all zero = percent RGBA
		float pcGreen;
		float pcBlue;
		float pcAlpha;
		float stats_s1; // radius
		float stats_s2; // rate rotation
		//UCHAR pad0[13]; // all 0
		//string icon;	// Length [13];
		//char pad1[2]; //CC
		float stats_s3; // load time
		float stats_s4; // life span
		float stats_s5; // sigfloating
		int stats_s6; // cost
		int stats_s7; // build time (seconds)
		//string model;	// Length[13];
		//char pad3; // C
		string type; // Length [13]; //part
		//string name; // Length [25];
		//string description; // Length [200];
		//byte group;
		//byte zero;
		//Techtree techtree;
		//char pad4[2]; // CD
		//float stats_s8; // sig mod (%)
		//float stats_s9; // mass
		//BitArray use_mask;	//2
		//ushort stats_ss1;// CargoPayload
		float stats_s10; // hitpoints
		IGCArmorClass AC; // 0B default (part)
		//UCHAR pad5[1]; //  CD 
		//ushort uid;
		ushort stats_ss2;//0
		string ukbmp; // Length [13];
		//UCHAR pad6; //CC
		float stats_s11; // strength

		public IGCCoreCounter (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_ChaffType;
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			pcRED = reader.ReadFloat();
			pcGreen = reader.ReadFloat();
			pcBlue = reader.ReadFloat();
			pcAlpha = reader.ReadFloat();
			stats_s1 = reader.ReadFloat(); // radius
			stats_s2 = reader.ReadFloat(); // rate rotation
			reader.Skip(13);
			icon = reader.ReadString(13);	// Length [13];
			reader.Assert((ushort)0xCCCC, 0, "UNKNOWN", "Part: Counter", "Icon");
			stats_s3 = reader.ReadFloat(); // load time
			stats_s4 = reader.ReadFloat(); // life span
			stats_s5 = reader.ReadFloat(); // sigfloating
			stats_s6 = reader.ReadInt(); // cost
			stats_s7 = reader.ReadInt(); // build time (seconds)
			model = reader.ReadString(13);	// Length[13];
			reader.Assert((byte)0xCC, 0, "Model: " + model, "Part: Counter", "Model");
			type = reader.ReadString(13); // Length [13]; //part
			name = reader.ReadString(25); // Length [25];
			description = reader.ReadString(200); // Length [200];
			group = reader.ReadShort();
			techtree = new Techtree(reader);
			reader.Assert((ushort)0xCDCD, 0, name, "Part: Counter", "Techtree");
			sigmod = reader.ReadFloat(); // sig mod (%)
			mass = reader.ReadFloat(); // mass
			usemask = new BitArray(reader.ReadBytes(2));	//2
			amount = reader.ReadUShort();//1 - todo
			stats_s10 = reader.ReadFloat(); // hitpoints
			AC = (IGCArmorClass)reader.ReadByte(); // 0B default (part)
			reader.Assert((byte)0xCD, 0, name, "Part: Counter", "Armour Class");
			uid = reader.ReadUShort();
			stats_ss2 = reader.ReadUShort();//0
			ukbmp = reader.ReadString(13); // Length [13];
			reader.Assert((byte)0xCD, uid, name, "Part: Counter", "ukbmp");
			stats_s11 = reader.ReadFloat(); // strength
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

		public float Radius
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

		public float RateRotation
		{
			get {return stats_s2;}
			set {stats_s2 = value;}
		}

//		public string Icon
//		{
//			get {return icon;}
//			set {icon = value;}
//		}

		public float LoadTime
		{
			get {return stats_s3;}
			set {stats_s3 = value;}
		}

		public float Lifespan
		{
			get {return stats_s4;}
			set {stats_s4 = value;}
		}
		
		public float SignatureFloating
		{
			get {return stats_s5;}
			set {stats_s5 = value;}
		}

		public int Cost
		{
			get {return stats_s6;}
			set {stats_s6 = value;}
		}

		public int BuildTime
		{
			get {return stats_s7;}
			set {stats_s7 = value;}
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
//		}

//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}
//
//		public float Signature
//		{
//			get {return stats_s8;}
//			set {stats_s8 = value;}
//		}
//
//		public float Mass
//		{
//			get {return stats_s9;}
//			set {stats_s9 = value;}
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
//			get {return stats_ss1;}
//			set {stats_ss1 = value;}
//		}

		public float Hitpoints
		{
			get {return stats_s10;}
			set {stats_s10 = value;}
		}

		public IGCArmorClass ArmorClass
		{
			get {return AC;}
			set {AC = value;}
		}

		public ushort SS2
		{
			get {return stats_ss2;}
			set {stats_ss2 = value;}
		}

		public string UKBMP
		{
			get {return ukbmp;}
			set {ukbmp = value;}
		}

		public float Strength
		{
			get {return stats_s11;}
			set {stats_s11 = value;}
		}
	}
}
