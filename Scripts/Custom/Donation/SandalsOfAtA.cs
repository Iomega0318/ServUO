using System;
using Server;
using Server.Guilds;

namespace Server.Items
{
	public class SandalsOfAtA : PlateChest 
	{
		  public override int ArtifactRarity{ get{ return 100; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public SandalsOfAtA()
		{
			Weight = 1.0; 
            		Name = "Sandals Of AtA"; 
            		Hue = 1150;
                        ItemID = 5901;                         
                        Layer = Layer.Shoes;


			Attributes.AttackChance = 2;
            Attributes.WeaponDamage = 20;
            Attributes.BonusStr = 25;
            Attributes.BonusDex = 25 ;
            Attributes.BonusInt = 15;
            Attributes.RegenHits = 7;
            Attributes.RegenStam = 7;
			Attributes.BonusMana = 2;
			Attributes.CastRecovery = 2;
			Attributes.CastSpeed = 2;
			Attributes.LowerManaCost = 2;
			Attributes.LowerRegCost = 5;
			Attributes.Luck = 10;
			Attributes.SpellDamage = 2;
			ArmorAttributes.SelfRepair = 50;
			

			//LootType = LootType.nn; //Blessed, Newbied or Cursed
		

                                     }
                                    public SandalsOfAtA( Serial serial ) : base( serial )
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
                                    public override bool OnEquip( Mobile from )
		{
			return Validate( from ) && base.OnEquip( from );
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Validate( Parent as Mobile ) )
				base.OnSingleClick( from );
		}

		public bool Validate( Mobile m )
		{
			if ( m == null || !m.Player )
				return true;

			

			
			{
				
				m.FixedEffect( 0x3728, 10, 13 );
				m.PlaySound( 0x108 );
				m.SendMessage( "Support empowers your artifact as you adorn it!" );

			}
			
			
				
			             


			

			return true;
		}
	}
}
