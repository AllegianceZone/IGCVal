using System;
using System.Collections;

using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore
{
	/// <summary>
	/// The base class for all modules
	/// </summary>
	public abstract class IGCCoreModule
	{
		protected short		moduletype;
		protected ushort	uid;

//		public IGCCoreModule ()
//		{
//			
//		}

		public AGCObjectType ModuleType
		{
			get {return (AGCObjectType)moduletype;}
			set {moduletype = (short)value;}
		}

		public ushort UID
		{
			get {return uid;}
			set {uid = value;}
		}
	}
}
