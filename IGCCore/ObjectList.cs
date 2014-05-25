using System;
using System.Collections;

using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore
{
	/// <summary>
	/// A list of Allegiance objects
	/// </summary>
	public class ObjectList : ArrayList
	{
		public ObjectList () : base()
		{}

		public int Add (IGCCoreObject module)
		{
			return base.Add(module);
		}

		public void Remove (IGCCoreObject module)
		{
			base.Remove(module);
		}

		public bool Contains (IGCCoreObject module)
		{
			return base.Contains((object)module);
		}

		public IGCCoreObject GetObject (ushort uid)
		{
			IGCCoreObject Result = null;
			foreach (Object Item in this)
			{
				IGCCoreObject Module = (IGCCoreObject)Item;
				ushort ModuleID = Module.UID;
				if (Module is IGCCorePart)
				{
					ushort SpecID = ((IGCCorePart)Module).SpecUID;
					if (SpecID != 0)
						ModuleID = SpecID;
				}

				if (ModuleID == uid)
				{
					Result = Module;
					break;
				}
			}
			return Result;
		}

		public new IGCCoreObject this [int index]
		{
			get {return (IGCCoreObject)base[index];}
			set {base[index] = value;}
		}
	}
}
