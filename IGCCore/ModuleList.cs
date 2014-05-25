using System;
using System.Collections;

using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore
{
	/// <summary>
	/// A list of Allegiance Modules
	/// </summary>
	public class ModuleList : ArrayList
	{
		AGCObjectType	_type;

		public ModuleList (AGCObjectType type)
		{
			_type = type;
		}

		public int Add (IGCCoreModule module)
		{
			if (module.ModuleType == _type)
				return base.Add(module);
			else
				return 0;
		}

		public void Remove (IGCCoreModule module)
		{
			base.Remove(module);
		}

		public bool Contains (IGCCoreModule module)
		{
			return base.Contains((object)module);
		}

		public IGCCoreModule GetModule (ushort uid)
		{
			IGCCoreModule Result = null;
			foreach (Object Item in this)
			{
				IGCCoreModule Module = (IGCCoreModule)Item;
				if (Module.UID == uid)
				{
					Result = Module;
					break;
				}
			}
			return Result;
		}

		public new IGCCoreModule this [int index]
		{
			get {return (IGCCoreModule)base[index];}
			set {base[index] = value;}
		}
	}
}
