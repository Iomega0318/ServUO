/* Created by Hammerhand */

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class ATACloakOfSoul : Cloak
	{
                		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }


		[Constructable]
		public ATACloakOfSoul()
		{
			 
			Name = "Put Your Soul In It";
            ItemID = 21685;
            Layer = Layer.Cloak;
			Hue = 16385;

		Attributes.SpellDamage = 2;
		Attributes.CastRecovery = 2;
		Attributes.CastSpeed = 2;
		Attributes.LowerManaCost = 5;
		

	    Attributes.RegenHits = 5;
		Attributes.RegenStam = 5;

		Attributes.RegenMana = 5;
		Attributes.DefendChance = 5;
		Attributes.AttackChance = 5;

		Attributes.WeaponDamage = 5;
		Attributes.WeaponSpeed = 5;

		Attributes.DefendChance = 10;
		Attributes.AttackChance = 10;

		Attributes.ReflectPhysical = 10;

		}
		
		public override bool OnEquip(Mobile m) 
	      { 

			if ( m.Mounted )
			{
				m.SendMessage( "You cant do that while mounted" );
				return false;
			}


            m.NameMod = m.Name + "ATA Soul";
		        m.BodyMod = 26;
			m.HueMod = 16385;
            Attributes.BonusStr = 10;
			m.DisplayGuildTitle = false;	
			m.SendMessage( "The cloak has transformed you into the Soul of ATA" );
            m.PlaySound( 484 );
			return base.OnEquip(m);
				

		}
		
		public override void OnRemoved( object parent) 
	      { 
		if (parent is Mobile) 
	        { 
	         Mobile m = (Mobile)parent; 
		   m.NameMod = null;
                   m.BodyMod = 0;
           m.HueMod = -1;
           Attributes.BonusStr = 0;
		   m.SendMessage( "You're back to your old self." );
                   m.PlaySound( 484 );		   
		   m.DisplayGuildTitle = true;
		  }

	         base.OnRemoved(parent); 
      	}

        public ATACloakOfSoul(Serial serial)
            : base(serial)
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