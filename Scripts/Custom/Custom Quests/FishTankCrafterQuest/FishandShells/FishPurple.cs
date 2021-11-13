using System; 
using Server; 

namespace Server.Items 
{ 
   public class FishPurple : Item 
   { 
      

      [Constructable] 
      public   FishPurple ( ) : base( 0x3B0A ) 
      {
	 Name = "Stripped Fish";
	 
         Weight = 0.1; 
           ItemID = 15114;   
          
      } 

      public     FishPurple ( Serial serial ) : base( serial ) 
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
