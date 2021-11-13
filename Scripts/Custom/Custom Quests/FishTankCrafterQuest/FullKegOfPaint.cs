using System; 
using Server; 

namespace Server.Items 
{ 
   public class FullKegOfPaint : Item 
   { 
      

      [Constructable] 
      public  FullKegOfPaint( ) : base( 0x1AD6 ) 
      {
	 Name = "Full Keg Of Paint";
	 Hue = 396;
         Weight = 0.1; 
           ItemID = 6870;   
          
      } 

      public   FullKegOfPaint( Serial serial ) : base( serial ) 
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
