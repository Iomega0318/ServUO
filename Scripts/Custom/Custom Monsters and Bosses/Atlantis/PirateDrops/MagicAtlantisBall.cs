// By Neon
// Improved By Dddie

using System; 
using Server; 
using Server.Network; 

namespace Server.Items 
{ 
   public class MagicAtlantisBall : Item 
   { 
      [Constructable] 
      public MagicAtlantisBall() : base( 0xE2E ) 
      { 
         this.Name = "magic atlantis ball";
		 this.Hue = 2995;
         this.Weight = 5; 
         this.Stackable = false; 
         this.LootType = LootType.Regular; 
         this.Light = LightType.Circle150; 
      } 

      public override void OnDoubleClick( Mobile from ) 
      { 
         this.PublicOverheadMessage( MessageType.Regular, 0x3B2, 1007000 + Utility.Random( 28 )); 
      } 

      public MagicAtlantisBall( Serial serial ) : base( serial ) 
      { 
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