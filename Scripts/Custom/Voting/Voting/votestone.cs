using System; 
using Server; 
using Server.Mobiles; 
using Server.Items; 
using System.Collections; 
using Server.Gumps; 

namespace Server.Items 
{ 
   public class VoteStoneCUO : Item 
   { 
      public static ArrayList m_Voteds; 
       
      [Constructable] 
      public VoteStoneCUO() : base ( 0xED4 ) 
      { 
         Movable = false; 
         Hue = 1165; 
         Name = "Vote Stone"; 
          
         m_Voteds = new ArrayList(); 
      }    

      public override void AddNameProperties( ObjectPropertyList list ) 
      { 
         base.AddNameProperties( list ); 
             
         list.Add(1070722, "Click to Vote for us on ConnectUO"); 
      } 

      public VoteStoneCUO( Serial serial ) : base( serial ) 
      { 
      }    

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 
          
         writer.WriteMobileList( m_Voteds, true ); 
      } 
       
      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 
             
         m_Voteds = reader.ReadMobileList(); 
      }    
       
      public override void OnDoubleClick( Mobile from ) 
      { 
         if( m_Voteds.Contains( from )) 
         { 
            from.SendMessage( 63,"You have already voted." ); 
            return; 
         } 
          
if (from != null && from.Alive)
         {
             m_Voteds.Add(from);
	     from.SendGump(new StoneGump(from, this));	
             from.LaunchBrowser("http://www.connectuo.com/index.php?page=shards&do=vote&id=1141");
             from.SendMessage(1153, "Thank you for supporting us. ");
         } 
      } 
   } 
}
