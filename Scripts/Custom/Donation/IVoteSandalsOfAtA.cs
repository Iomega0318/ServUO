using System;
using Server;
using Server.Guilds;

namespace Server.Items
{
	public class IVoteSandalsOfAtA : PlateChest 
	{
		  public override int ArtifactRarity{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public IVoteSandalsOfAtA()
		{
			Weight = 1.0; 
            		Name = "I Vote Sandals Of AtA"; 
            		Hue = 1150;
                        ItemID = 5901;                         
                        Layer = Layer.Shoes;


			Attributes.AttackChance = 2;
			
		
			Attributes.LowerRegCost = 10;
			Attributes.Luck = 10;
			Attributes.SpellDamage = 1;
			ArmorAttributes.SelfRepair = 5;
			

			//LootType = LootType.nn; //Blessed, Newbied or Cursed
		

                                     }
                                    public IVoteSandalsOfAtA( Serial serial ) : base( serial )
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
