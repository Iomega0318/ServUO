//Base Bracelet Template....Made by Gold Draco 13.
//Just remove the // before the lines you want to allow on weapon.
//Replace the nn with your values.
//If you have problems please visit my site at www.81x.com/golddraco13/dragons_of_pern and use email link there.
using System;
using Server;

namespace Server.Items
{
	public class FishingBracelet : GoldBracelet
	{
		//public override int ArtifactRarity{ get{ return 100; } }

		[Constructable]
		public FishingBracelet()
		{
			Weight = 1.0; 
            		Name = "Fishing Bracelet"; 
            		Hue = 1289;

                                                //Attributes.MageArmor = 1;

			//Attributes.AttackChance = nn;
			Attributes.BonusDex = 2;
			Attributes.BonusHits = 3;
			//Attributes.BonusInt = nn;
			Attributes.BonusMana = 3;
			//Attributes.BonusStam = nn;
			Attributes.BonusStr = 1;
			//Attributes.CastRecovery = nn;
			Attributes.CastSpeed = 15;
			//Attributes.DefendChance = nn;
			//Attributes.EnhancePotions = nn;
			 Attributes.LowerManaCost = 2;
			 Attributes.LowerRegCost = 15;
			  Attributes.Luck = 50;
			  //Attributes.Nightsight = 1;
			Attributes.ReflectPhysical = 4;
			//Attributes.RegenHits = nn;
			//Attributes.RegenMana = nn;
			//Attributes.RegenStam = nn;
			Attributes.SpellChanneling = 1;
			//Attributes.SpellDamage = nn;
			Attributes.WeaponDamage = 2;
			Attributes.WeaponSpeed = 2;

			SkillBonuses.SetValues( 0, SkillName.Fishing, 5.0 );
			//SkillBonuses.SetValues( 1, SkillName.Hiding, 10.0 );
			//SkillBonuses.SetValues( 2, SkillName.nn, nn.n );
			//SkillBonuses.SetValues( 3, SkillName.nn, nn.n );
			//SkillBonuses.SetValues( 4, SkillName.nn, nn.n );

			Resistances.Cold = 8;
			Resistances.Energy = 8;


			
			
		}

		public FishingBracelet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}