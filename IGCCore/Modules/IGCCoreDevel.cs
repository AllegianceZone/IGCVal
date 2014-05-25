using System;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// A research entry viewable on the F5 research pane
	/// </summary>
	public class IGCCoreDevel : IGCCoreObject // Tag: 32; Length: 468;
	{
		uint cost;
		uint research_time;
		string model; // Length 13;
		//string uk1; // Length 1 (cc)
		string icon; // Length 13; // always 'icontech'
//		string name; // Length 25;
		string description; // Length 200;
		//byte pad1; // 00
		byte root_tree; // tree root (0=construction,1=garrison,2=sup,3=tac,4=exp,5=sy)
//		Techtree techtree; // Length 100
		//byte[] pad2 = new byte[2]; // cd cd
		Factors factors; // Length 25
		//ushort uid;
		ushort cat; // sound

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="reader">The DataReader used to read this IGCCoreDevel</param>
		public IGCCoreDevel (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_Development;
			Parse(reader);
		}

		/// <summary>
		/// Parses an IGCCoreDevel from the specified DataReader
		/// </summary>
		/// <param name="reader">The DataReader from which to read this IGCCoreDevel</param>
		private void Parse (DataReader reader)
		{
			cost = reader.ReadUInt();
			research_time = reader.ReadUInt();
			model = reader.ReadString(13);
			reader.Assert((byte)0xCC, 0, "Model: " + model, "Development", "Model");
			icon = reader.ReadString(13);
			name = reader.ReadString(25);
			description = reader.ReadString(200);
			reader.Assert((byte)0, 0, name, "Development", "Description");

			root_tree = reader.ReadByte();
			techtree = new Techtree(reader);
			reader.Assert((ushort)0xCDCD, 0, name, "Development", "Techtree");
			factors = new Factors(reader);

			uid = reader.ReadUShort();
			cat = reader.ReadUShort();
		}

		/// <summary>
		/// The cost of this development
		/// </summary>
		public uint Cost
		{
			get {return cost;}
			set {cost = value;}
		}

		/// <summary>
		/// The amount of time required to research this development
		/// </summary>
		public uint ResearchTime
		{
			get {return research_time;}
			set {research_time = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			get {return model;}
			set {model = value;}
		}

		/// <summary>
		/// The icon of this development (always icontech)
		/// </summary>
		public string Icon
		{
			get {return icon;}
			set {icon = value;}
		}

//		/// <summary>
//		/// The name of this development
//		/// </summary>
//		public string Name
//		{
//			get {return name;}
//			set {name = value;}
//		}

		/// <summary>
		/// The description of this Developent
		/// </summary>
		public string Description
		{
			get {return description;}
			set {description = value;}
		}

		/// <summary>
		/// Determines where this research entry is displayed on the techtree.
		/// </summary>
		public TreeRoot Root_Tree
		{
			get {return (TreeRoot)root_tree;}
			set {root_tree = (byte)value;}
		}

//		/// <summary>
//		/// The set of prerequisites and definitions this research entry defines/requires
//		/// </summary>
//		public Techtree Techtree
//		{
//			get {return techtree;}
//			set {techtree = value;}
//		}

		/// <summary>
		/// The set of 25 modifiers this research entry defines
		/// </summary>
		public Factors Factors
		{
			get {return factors;}
			set {factors = value;}
		}

//		/// <summary>
//		/// The unique ID of this research entry
//		/// </summary>
//		public ushort UID
//		{
//			get {return uid;}
//			set {uid = value;}
//		}

		/// <summary>
		/// The sound played when this research entry has been researched
		/// </summary>
		public ushort Sound
		{
			get {return cat;}
			set {cat = value;}
		}
	}
}
