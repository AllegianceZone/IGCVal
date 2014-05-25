using System;
using System.Collections;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreShipMP.
	/// </summary>
	public class IGCCoreShipMP // size 30
	{
		ushort uk1; // sound
		ushort uk2; // sound
		string position;	// Length 13;
		byte[] todo; // Length 9; //30 00 .. 00
		BitArray part_mask; //usemask of weapon
		ushort part_type; //1=normal, 0=other player (turret).
		
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="reader"></param>
		public IGCCoreShipMP (DataReader reader)
		{
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			uk1 = reader.ReadUShort();
			uk2 = reader.ReadUShort();
			position = reader.ReadString(13);
			todo = reader.ReadBytes(9);
			part_mask = new BitArray(reader.ReadBytes(2));
			part_type = reader.ReadUShort();
		}

		/// <summary>
		/// The sound played when this weapon is mounted
		/// </summary>
		public ushort MountSound
		{
			get {return uk1;}
			set {uk1 = value;}
		}

		/// <summary>
		/// The sound played when this weapon is unmounted
		/// </summary>
		public ushort UnmountSound
		{
			get {return uk2;}
			set {uk2 = value;}
		}

		/// <summary>
		/// UNKNOWN
		/// </summary>
		public string Position
		{
			get {return position;}
			set {position = value;}
		}

		/// <summary>
		/// UNKNOWN
		/// </summary>
		public BitArray PartMask
		{
			get {return part_mask;}
			set {part_mask = value;}
		}

		/// <summary>
		/// The type of part (0 = turreted or 1 = normal)
		/// </summary>
		public ushort PartType
		{
			get {return part_type;}
			set {part_type = value;}
		}
	}
}
