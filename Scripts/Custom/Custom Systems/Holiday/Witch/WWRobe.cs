//Amherst Script
using System;
using Server;
using Server.Items;

namespace Server.Items
{
   [FlipableAttribute( 0x2683, 0x2684 )]
   public class WWRobe : BaseArmor, IDyable
   {

        	public override int ArtifactRarity{ get{return 12; } }

		public override int BasePhysicalResistance{ get{ return 13; } }
		public override int BaseFireResistance{ get{ return 13; } }
		public override int BaseColdResistance{ get{ return 13; } }
		public override int BasePoisonResistance{ get{ return 13; } }
		public override int BaseEnergyResistance{ get{ return 13; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }


		public bool m_Transformed;
		public Timer m_TransformTimer;
		private DateTime m_End;

		private StatMod m_StatMod0;
		private StatMod m_StatMod1;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Transformed
		{
			get{ return m_Transformed; }
			set{ m_Transformed = value; }
		}

      [Constructable]
      public WWRobe() : base( 0x2683 )
      {

         Weight = 5.0;
         Name = "Shroud of the Wicked Witch";
	 Hue = 1109;
	 Attributes.NightSight = 1;
         Layer = Layer.OuterTorso;

      }

		public WWRobe( Serial serial ) : base( serial )
		{
		}

     		public override void OnDoubleClick( Mobile from ) 
		{

                        if ( Parent != from ) 
                        { 
                                from.SendMessage( "The Shroud of the Wicked Witch must be equiped to be used." ); 
                        } 

			else if ( from.Mounted == true )
			{
				from.SendMessage( "You cannot be mounted while trying to transform!" );
			}

                        else if ( this.Transformed == false )
                        { 
				
               			from.SendMessage( "You pull the hood over your head." );
				from.PlaySound( 0x363 );
				from.BodyMod = 81;
				from.NameHue = 57;
				from.HueMod = 1409;
				from.DisplayGuildTitle = false; 
				this.Transformed = true; 
				ItemID = 9860;
				from.RemoveItem(this);
              			from.EquipItem(this);

				m_StatMod0 = new StatMod( StatType.Str, "MOD0", 5, TimeSpan.Zero );
				m_StatMod1 = new StatMod( StatType.Int, "MOD1", 5, TimeSpan.Zero );
				from.AddStatMod( m_StatMod0 );
				from.AddStatMod( m_StatMod1 );
                        
			}
			else
			{
				from.SendMessage( "You lower the hood." );
				from.PlaySound( 0x220 );
				from.Title = null;
				from.BodyMod = 0x0;
				from.NameHue = -1;
				from.HueMod = -1;
				from.DisplayGuildTitle = true;
				this.Transformed = false;
				ItemID = 0x1F03;
				from.RemoveItem(this);
              			from.EquipItem(this);
				from.RemoveStatMod( "MOD0" );
				from.RemoveStatMod( "MOD1" );
			}
		}

		public virtual bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;
			else if ( RootParent is Mobile && from != RootParent )
				return false;

			Hue = sender.DyedHue;

			return true;
		}
			
		public override void OnRemoved( Object o )
      		{
      			if( o is Mobile )
      			{
				( (Mobile)o).RemoveStatMod( "MOD0" );
				( (Mobile)o).RemoveStatMod( "MOD1" );
				
     			}
      			if( o is Mobile && ((Mobile)o).Kills >= 5)
               		{
               			( (Mobile)o).Criminal = true;
                	}
      			if( o is Mobile && ((Mobile)o).GuildTitle != null )
               		{
          			( (Mobile)o).DisplayGuildTitle = true;
                	}
				
      			base.OnRemoved( o );
      		}			

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );
         writer.Write( (int) 0 ); // version
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );
         int version = reader.ReadInt();
      }

   }
}
