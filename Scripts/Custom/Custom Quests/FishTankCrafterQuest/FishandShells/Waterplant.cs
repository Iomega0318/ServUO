using System; 
using Server; 

namespace Server.Items 
{ 
   public class Waterplant : Item 
   { 
      

      [Constructable] 
      public  Waterplant( ) : base( 0xD04 ) 
      {
	 Name = "Waterplant";
	 
         Weight = 0.1; 
           ItemID = 33312;   
          
      } 

      public    Waterplant( Serial serial ) : base( serial ) 
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
