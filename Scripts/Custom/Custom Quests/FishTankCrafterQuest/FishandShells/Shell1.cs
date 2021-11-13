using System; 
using Server; 

namespace Server.Items 
{ 
   public class Shell1 : Item 
   { 
      

      [Constructable] 
      public  Shell1( ) : base( 0x3B12 ) 
      {
	 Name = "Large Shell";
	 
         Weight = 0.1; 
           ItemID = 15122;   
          
      } 

      public    Shell1( Serial serial ) : base( serial ) 
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
