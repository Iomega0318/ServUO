using System; 
using Server; 

namespace Server.Items 
{ 
   public class FishButterfly1 : Item 
   { 
      

      [Constructable] 
      public   FishButterfly1( ) : base( 0x3AFF ) 
      {
	 Name = "Butterfly Fish";
	 
         Weight = 0.1; 
           ItemID = 15103;   
          
      } 

      public    FishButterfly1( Serial serial ) : base( serial ) 
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
