using System; 
using Server; 

namespace Server.Items 
{ 
   public class HeavySteelSkillet : Item 
   { 
     

      [Constructable] 
      public HeavySteelSkillet(): base( 0x97F ) 
      {
	 Name = "Heavy Steel Skillet";
	  Weight = 0.1; 
         
      } 

      public HeavySteelSkillet( Serial serial ) : base( serial ) 
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
