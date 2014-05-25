using System;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreDrone.
	/// </summary>
	public class IGCCoreDrone : IGCCoreModule
	{
		// TODO: Fill in members
//		AGCMoney cost; // 1 for con, 4000 for miner
//		AGCMoney research_time; // 1 for con, 90 for miner
//		char model[13];
//		UCHAR pad1; // CC
//		UCHAR uks1[13]; // null string
//		char name[25];
//		char description[200];
//		BYTE group;
//		BYTE zero;
//		UCHAR techtree[100];
//		UCHAR pad2[2]; // CC
//		float f1; // ?, def = 0.5
//		float f2; // ?, def = 0.5 
//		float f3; // ?, def = 0.5
//		BYTE ss1; // AI script: miner=0,wingman=2,layer=5,con=6,carrier=9 
//		UCHAR pad3; // CC
//		unsigned short ship_uid;
//		unsigned short uid;
//		short part_uid; // -1 if none, otherwise uid of mines/probes

		public IGCCoreDrone (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_DroneType;
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			// TODO: Fill in parser
			reader.Skip(384);
		}
	}
}
