using System; 
using Server; 

namespace Server.Items 
{ 
   public class FishOrange1 : Item 
   { 
      

      [Constructable] 
      public   FishOrange1( ) : base( 0x3B08 ) 
      {
	 Name = "Fish";
	 
         Weight = 0.1; 
           ItemID = 15112;   
          
      } 

      public     FishOrange1( Serial serial ) : base( serial ) 
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
