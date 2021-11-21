using System;
using Server;

namespace Server.Items
{
	public class FireSwordOfATA : VikingSword
	{
        private LightSource light;
		public override int ArtifactRarity{ get{ return 101; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		//public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ConsecratedStrike; } }
		//public override WeaponAbility FourthAbility{ get{ return WeaponAbility.MagicProtection; } } 
		

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override int AosSpeed{ get{ return 28; } }
		
		#region Mondain's Legacy
		public override float MlSpeed{ get{ return 3.75f; } }
		#endregion

		public override int OldStrengthReq{ get{ return 40; } }
		public override int OldMinDamage{ get{ return 6; } }
		public override int OldMaxDamage{ get{ return 34; } }
		public override int OldSpeed{ get{ return 30; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

        [Constructable]
	 	public FireSwordOfATA()
	 	{
	 	 	Name = "FireSword Of ATA";
	 	 
			ItemID = 21518; 
			Slayer = SlayerName.ElementalBan;
            
					  
	 	 	
	 	 	Attributes.BonusStr = 15;
			Attributes.BonusDex = 10;

	 	 	Attributes.BonusHits = 25;
		    Attributes.Luck = 75;
			Attributes.LowerRegCost = 15;
	 	 	
	 	 	Attributes.DefendChance = 15;
			Attributes.AttackChance = 25;
			Attributes.ReflectPhysical = 10;
			
			
	 	 	Attributes.BonusStam = 10;
	 	 	Attributes.RegenHits = 5;
	 	 	Attributes.RegenStam = 10;
	 	 	Attributes.RegenMana = 5;

			Attributes.SpellChanneling = 4;
			Attributes.CastSpeed = 3;
	 	 	Attributes.CastRecovery = 5;
	 	 	Attributes.SpellDamage = 3;
	 	 	
	 	 	Attributes.WeaponDamage = 25;
	 	 	Attributes.WeaponSpeed = 15;

            WeaponAttributes.HitLeechHits = 25;
			WeaponAttributes.SelfRepair = 50;

						Attributes.LowerRegCost = 20;

			

		
	 	 	
	 	 	
	 	}

	 	public FireSwordOfATA(Serial serial) : base( serial )
	 	{
	 	}
		
        /*public override void OnAdded(object parent)
        {
            light = new LightSource();
            light.Layer = Layer.Unused_xF;
            light.Light = LightType.Circle300;
            if (parent is Mobile)
        {
            Mobile from = (Mobile)parent;
            from.AddItem(light);
        }
            base.OnAdded(parent);
        }
            public override void OnRemoved(object parent)
        {
            if (light != null && parent is Mobile)
        {
            light.Delete();
        }
            base.OnRemoved(parent);
        } */


	 	public override void Serialize( GenericWriter writer )
	 	{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			//writer.Write( light );
	 	}
	 	public override void Deserialize(GenericReader reader)
	 	{
	 	 	base.Deserialize( reader );
            int version = reader.ReadInt();
			//light = reader.ReadItem() as LightSource;
	 	}
	}
}
