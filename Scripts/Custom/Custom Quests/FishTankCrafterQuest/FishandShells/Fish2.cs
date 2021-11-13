using System; 
using Server; 

namespace Server.Items 
{ 
   public class Fish2 : Item 
   { 
      

      [Constructable] 
      public  Fish2( ) : base( 0x3B07 ) 
      {
	 Name = "Fish";
	 
         Weight = 0.1; 
           ItemID = 15111;   
          
      } 

      public    Fish2( Serial serial ) : base( serial ) 
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
