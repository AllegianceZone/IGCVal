IGCCore Library by Tigereye

This library reads .igc files.


Changes
=======
0.86
Reverted all "skips" to actual read statements
Read errors now throw an event instead of an exception; IGCCore will continue reading cores until the end or a catastrophic failure.

0.85
Changed a few "readlongs" into "skip"s
Added "LaunchCount" and "QtyPerPack" properties to IGCCoreMissile, and modified the Core parser to set them from the missile's spec entry

0.84
Spec Parts are no longer added to the _parts collection. The true missile/probe/mine
	is looked up and added in its place.

0.83
Updated the ShipAbilities enumeration to properly reference "WarnStationAtRisk"
Fixed up some errors in the armorclass properties

0.82
Fixed a failed assert when reading A+ and Empire cores. Changed an "Assert" to a "skip"
Fixed IGCCoreProbe's signature values... it's floating signature and signature modifier were swapped.

0.81
Added "IGCCoreObject" base class that exposes only "Name" and "Techtree" to make it easier
 to parse multiple object types with these two common fields.
Updated each module that has these fields to inherit from IGCCoreObject
Made each part type module (probe, mine, counter, missile) inherit from IGCCorePart
 Changed member names, and hid the local ones as necessary.
Added ObjectList which works just like ModuleList, but with IGCCoreObjects
 
0.80
Can read every module type except for Drones without problems.
Cannot save, or sort modules based on IGCCore specifications (override orders, pre/def orders)
