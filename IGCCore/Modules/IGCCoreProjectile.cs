using System;

using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.IGCCore.Modules
{
	/// <summary>
	/// Summary description for IGCCoreProjectile.
	/// </summary>
	public class IGCCoreProjectile : IGCCoreModule
	{
		float percentRed;
		float percentGreen;
		float percentBlue;
		float percentAlpha;
		float stats_s1; // particle size (radius)
		float stats_s2; // rate rotation (?)
		string file_model;	// Length [13]; // ALL '0' = file model
		string file_texture; // Length [13]; // = file texture
//		UCHAR pad2[2]; // CC CC
		float stats_s3; // regular damange per shot
		float stats_s4; // area damange per shot
		float stats_s5; // area damage radius
		float stats_s6; // speed
		float stats_s7; // life span
//		ushort uid;
		byte DM;
		byte stats_ss1; // absolute speed = 1
		byte stats_ss2; // directional = 1
//		UCHAR pad3[3]; // CC CC CC
		float stats_s8; // Width OverHeigth
		ushort ambient_sound;
//		UCHAR pad4[2];// CC CC

		public IGCCoreProjectile (DataReader reader)
		{
			this.ModuleType = AGCObjectType.AGC_ProjectileType;
			Parse(reader);
		}

		private void Parse (DataReader reader)
		{
			percentRed = reader.ReadFloat();
			percentGreen = reader.ReadFloat();
			percentBlue = reader.ReadFloat();
			percentAlpha = reader.ReadFloat();
			stats_s1 = reader.ReadFloat();
			stats_s2 = reader.ReadFloat();
			file_model = reader.ReadString(13);
			file_texture = reader.ReadString(13);
			reader.Assert((ushort)0xCCCC, 0, "Texture: " + file_texture, "Projectile", "Texture");
			stats_s3 = reader.ReadFloat();
			stats_s4 = reader.ReadFloat();
			stats_s5 = reader.ReadFloat();
			stats_s6 = reader.ReadFloat();
			stats_s7 = reader.ReadFloat();
			uid = reader.ReadUShort();
			DM = reader.ReadByte();
			stats_ss1 = reader.ReadByte();
			stats_ss2 = reader.ReadByte();
			reader.Assert((byte)0xCC, uid, file_texture, "Projectile", "Directional");
			reader.Assert((byte)0xCC, uid, file_texture, "Projectile", "Directional");
			reader.Assert((byte)0xCC, uid, file_texture, "Projectile", "Directional");
			stats_s8 = reader.ReadFloat();
			ambient_sound = reader.ReadUShort();
			reader.Assert((ushort)0xCCCC, uid, file_model, "Projectile", "Ambient Sound");
		}


		public float Red
		{
			get {return percentRed;}
			set {percentRed = value;}
		}

		public float Green
		{
			get {return percentGreen;}
			set {percentGreen = value;}
		}

		public float Blue
		{
			get {return percentBlue;}
			set {percentBlue = value;}
		}

		public float Alpha
		{
			get {return percentAlpha;}
			set {percentAlpha = value;}
		}

		public float ParticleSize
		{
			get {return stats_s1;}
			set {stats_s1 = value;}
		}

		public float RateRotation
		{
			get {return stats_s2;}
			set {stats_s2 = value;}
		}

		public string FileModel
		{
			get {return file_model;}
			set {file_model = value;}
		}

		public string FileTexture
		{
			get {return file_texture;}
			set {file_texture = value;}
		}

		public float ShotDamage
		{
			get {return stats_s3;}
			set {stats_s3 = value;}
		}

		public float AreaDamage
		{
			get {return stats_s4;}
			set {stats_s4 = value;}
		}

		public float AreaRadius
		{
			get {return stats_s5;}
			set {stats_s5 = value;}
		}

		public float Speed
		{
			get {return stats_s6;}
			set {stats_s6 = value;}
		}

		public float Lifespan
		{
			get {return stats_s7;}
			set {stats_s7 = value;}
		}

		public byte DamageIndex
		{
			get {return DM;}
			set {DM = value;}
		}

		public byte AbsoluteSpeed
		{
			get {return stats_ss1;}
			set {stats_ss1 = value;}
		}

		public byte Directional
		{
			get {return stats_ss2;}
			set {stats_ss2 = value;}
		}

		public float WidthOverHeight
		{
			get {return stats_s8;}
			set {stats_s8 = value;}
		}

		public ushort AmbientSound
		{
			get {return ambient_sound;}
			set {ambient_sound = value;}
		}
	}
}
