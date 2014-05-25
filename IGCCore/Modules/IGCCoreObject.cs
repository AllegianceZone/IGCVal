using System;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreObject.
	/// </summary>
	public abstract class IGCCoreObject : IGCCoreModule
	{
		protected string name; // Length 25;
		protected Techtree techtree;

		public IGCCoreObject () {}
		
		public override string ToString ()
		{
			return name;
		}

		public string Name
		{
			get {return name;}
			set {name = value;}
		}

		public Techtree Techtree
		{
			get {return techtree;}
			set {techtree = value;}
		}
	}
}
