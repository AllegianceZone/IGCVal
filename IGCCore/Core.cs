using System;
using System.IO;
using System.Collections;

using FreeAllegiance.IGCCore.Util;
using FreeAllegiance.IGCCore.Modules;

namespace FreeAllegiance.IGCCore
{
	/// <summary>
	/// Represents an Allegiance Game Core.
	/// </summary>
	public class Core
	{
		uint				_coreHeader;
		IGCCoreConstants	_coreConstants;
        ObjectList			_stationTypes;
		ObjectList			_civs;
		ObjectList			_chaffs;
		ObjectList			_devs;
		ObjectList			_drones;
		ObjectList			_mines;
		ModuleList			_projectiles;
		ObjectList			_ships;
		ObjectList			_parts;
		ObjectList			_missiles;
		ObjectList			_probes;
		ModuleList			_treasureSets;

		public Core (string fileName)
		{
			_coreConstants = null;
			_stationTypes = new ObjectList();
			_civs = new ObjectList();
			_chaffs = new ObjectList();
			_devs = new ObjectList();
			_drones = new ObjectList();
			_mines = new ObjectList();
			_projectiles = new ModuleList(AGCObjectType.AGC_ProjectileType);
			_ships = new ObjectList();
			_parts = new ObjectList();
			_missiles = new ObjectList();
			_probes = new ObjectList();
			_treasureSets = new ModuleList(AGCObjectType.AGC_TreasureSet);

			ReadFromFile(fileName);
		}

		private void ReadFromFile (string fileName)
		{
//			try
//			{
				FileStream CoreFS = File.OpenRead(fileName);
				DataReader Reader = new DataReader(CoreFS);
				
				int Size;
				int CoreSize;

				short Tag;

				_coreHeader = Reader.ReadUInt();
				CoreSize = Reader.ReadInt();

				while (CoreFS.Position < (CoreSize + 8))
				{
					Tag = Reader.ReadShort();
					Size = Reader.ReadInt();

					long Pos = CoreFS.Position;
					switch ((AGCObjectType)Tag)
					{
						case AGCObjectType.AGC_Constants:	// 21
							_coreConstants = new IGCCoreConstants(Reader);
							break;
						case AGCObjectType.AGC_StationType:	// 31;
							_stationTypes.Add(new IGCCoreStationType(Reader));
							break;
						case AGCObjectType.AGC_Civilization:	// 27
							_civs.Add(new IGCCoreCiv(Reader));
							break;
						case AGCObjectType.AGC_Development:	// 32
							_devs.Add(new IGCCoreDevel(Reader));
							break;
						case AGCObjectType.AGC_BucketStart:	//29
							_ships.Add(new IGCCoreShip(Reader));
							break;
						case AGCObjectType.AGC_PartType:	//30
							IGCCorePart Part = null;
							if (Size == 24)
							{	// It's a spec part. Look up the real part and add it instead
								IGCCorePartSpec Spec = new IGCCorePartSpec(Reader);
								ushort PartID = Spec.UID;
								ushort RealID = (ushort)Spec.Group;

								IGCCorePart Obj = null;
								switch (Spec.Slot)
								{
									case "invchaff":
										Obj = (IGCCorePart)_chaffs.GetObject(RealID);
										IGCCoreCounter Counter = (IGCCoreCounter)Obj;
										Counter.OverridingUID = Spec.OverridingUID;
										break;
									case "invsmissile":
										Obj = (IGCCorePart)_missiles.GetObject(RealID);
										IGCCoreMissile Missile = (IGCCoreMissile)Obj;
										Missile.OverridingUID = Spec.OverridingUID;
										Missile.LaunchCount = (short)Spec.PartType;
										Missile.QtyPerPack = (short)Spec.Amount;
										break;
									case "invsmine":
										Obj = (IGCCorePart)_mines.GetObject(RealID);
										if (Obj == null)
										{
											Obj = (IGCCorePart)_probes.GetObject(RealID);
											IGCCoreProbe Probe = (IGCCoreProbe)Obj;
											Probe.OverridingUID = Spec.OverridingUID;
										}
										else
										{
											IGCCoreMine Mine = (IGCCoreMine)Obj;
											Mine.OverridingUID = Spec.OverridingUID;
										}
										break;
								}
								if (Obj != null)
								{
									Obj.SpecUID = PartID;
									_parts.Add(Obj);
								}

								break;
							}
							
							Reader.Seek(376);
							short Type = Reader.ReadShort();
							Reader.Seek(-378);
							// 1 = weapon, 2 = shield, 5 = cloak, 7 = after, 6 = default
							switch (Type)
							{
								case 1:
									Part = new IGCCorePartWeapon(Reader);
									break;
								case 2:
									//Part = new IGCCorePartShield(Reader);
									break;
								case 4:
									Part = new IGCCorePartShield(Reader);
									break;
								case 5:
									Part = new IGCCorePartCloak(Reader);
									break;
								case 7:
									Part = new IGCCorePartAfterburner(Reader);
									break;
								case 6:
									Part = new IGCCorePartPack(Reader);
									break;
								default:
									break;
							}
							if (Part != null)
								_parts.Add(Part);

							break;
						case AGCObjectType.AGC_ChaffType: // 26
							_chaffs.Add(new IGCCoreCounter(Reader));
							break;
						case AGCObjectType.AGC_MissileType: // 23
							_missiles.Add(new IGCCoreMissile(Reader));
							break;
						case AGCObjectType.AGC_MineType: // 24
							_mines.Add(new IGCCoreMine(Reader));
							break;
						case AGCObjectType.AGC_DroneType:
							_drones.Add(new IGCCoreDrone(Reader));
							break;
						case AGCObjectType.AGC_ProbeType:
							_probes.Add(new IGCCoreProbe(Reader));
							break;
						case AGCObjectType.AGC_ProjectileType:	//22
							_projectiles.Add(new IGCCoreProjectile(Reader));
							break;
						case AGCObjectType.AGC_TreasureSet:
							_treasureSets.Add(new IGCCoreTreasureSet(Reader));
							break;
						default:
							break;
					}
					if (CoreFS.Position != Pos + Size)
					{
						throw new Exception("Error occured while reading core file");
					}
				}
				CoreFS.Close();
				Reader = null;
				
//			}
//			catch (Exception e)
//			{
//				return;
//			}
			return;
		}


		public IGCCoreConstants Constants
		{
			get {return _coreConstants;}
		}

		public ObjectList StationTypes
		{
			get {return _stationTypes;}
		}

		public ObjectList Factions
		{
			get {return _civs;}
		}

		public ObjectList Countermeasures
		{
			get {return _chaffs;}
		}

		public ObjectList Developments
		{
			get {return _devs;}
		}

		public ObjectList Drones
		{
			get {return _drones;}
		}

		public ObjectList Mines
		{
			get {return _mines;}
		}

		public ModuleList Projectiles
		{
			get {return _projectiles;}
		}

		public ObjectList Ships
		{
			get {return _ships;}
		}

		public ObjectList Parts
		{
			get {return _parts;}
		}

		public ObjectList Missiles
		{
			get {return _missiles;}
		}

		public ObjectList Probes
		{
			get {return _probes;}
		}

		public ModuleList TreasureSets
		{
			get {return _treasureSets;}
		}
	}
}
