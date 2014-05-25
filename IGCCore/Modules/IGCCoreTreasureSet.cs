using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreTreasureSet.
	/// </summary>
	public class IGCCoreTreasureSet : IGCCoreModule
	{
		string name;	// Length = 26;
		//short uid;
		short count;
		short uk; //= 200
		ArrayList treasures;

		public IGCCoreTreasureSet (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_TreasureSet;
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			name = reader.ReadString(26);
			uid = (ushort)reader.ReadShort();
			count = reader.ReadShort();
			uk = reader.ReadShort();

			treasures = new ArrayList(count);
			for (int i = 0; i < count; i++)
			{
				treasures.Add(new IGCCoreTreasureSetChance(reader));
			}
		}

		public string Name
		{
			get {return name;}
			set {name = value;}
		}

//		public short UID
//		{
//			get {return uid;}
//			set {uid = value;}
//		}

		public short Count
		{
			get {return count;}
			set {count = value;}
		}

		/// <summary>
		/// UNKNOWN
		/// </summary>
		public short UK
		{
			get {return uk;}
			set {uk = value;}
		}

		public ArrayList TreasureChances
		{
			get {return treasures;}
			set {treasures = value;}
		}
	}

	public class IGCCoreTreasureSetChance
	{
		short uid;
		TreasureSetCode code; // 1-> uid = part uid, 2-> uid = 31 for powerup, 4-> uid = amount of $
		byte chance;

		public IGCCoreTreasureSetChance (DataReader reader)
		{
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			uid = reader.ReadShort();
			code = (TreasureSetCode)reader.ReadByte();
			chance = reader.ReadByte();
		}

		public short UID
		{
			get {return uid;}
			set {uid = value;}
		}

		public TreasureSetCode Code
		{
			get {return code;}
			set {code = value;}
		}

		/// <summary>
		/// The chance of this treasure appearing (UKNOWN how its value works)
		/// </summary>
		public byte Chance
		{
			get {return chance;}
			set {chance = value;}
		}
	}

	public enum TreasureSetCode : byte
	{
		PartUID = 1,
		Powerup = 2,
		Cash = 4
	}
}
