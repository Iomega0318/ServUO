//Created By Milva

using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class NathanKegCrafterGump : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register("KegCrafterGump", AccessLevel.GameMaster, new CommandEventHandler(NathanKegCrafterGump_OnCommand)); 
      } 

      private static void NathanKegCrafterGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new NathanKegCrafterGump( e.Mobile ) ); 
      } 

      public NathanKegCrafterGump( Mobile owner ) : base( 50,50 ) 
      { 
            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
//----------------------------------------------------------------------------------------------------

          AddPage(0);
          AddImageTiled(14, 10, 377, 433, 2524);
          AddImageTiled(9, 6, 388, 13, 1143);
          AddImageTiled(9, 433, 384, 11, 1143);
         AddImage(108, 29, 96);
         AddImage(104, 420,96);
          AddImage(14, 18, 3005, 1152);
         AddImage(389, 191, 3003, 1152);
         AddImage(14, 187, 3005, 1152);
         AddImage(389, 17, 3003, 1152);
      
			
     AddTextEntry(136, 40, 150, 120, 33, 0, @" Fish Tank Crafter Quest!");
			
			
        
         
		
			

			AddHtml( 34, 90, 346, 281, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=Red> Stop bothering me..You need what?  So the Fish Tank Crafter sent ye here, he needs what!.<BR><BR>" +

"<BASEFONT COLOR=Red>You are collecting items to make a Full Keg Of Paint for him.<BR><BR>" +

"<BASEFONT COLOR=Red>Ok! I'm in need of another Special Tool Kit.<BR><BR>" +

"<BASEFONT COLOR=Red>I will reward you with one of my empty kegs, but I really need another Special Tool Kit.<BR><BR>" +

"<BASEFONT COLOR=Red>For this kit you will will need to go find Murdock The Junk Yard Boss!.<BR><BR>" +

"<BASEFONT COLOR=Red>be careful he does not give up his stuff up easy!<BR><BR>" +
"<BASEFONT COLOR=Red>This Junk Yard Boss lives, east of Empath Abbey!<BR><BR>" +

"<BASEFONT COLOR=Red>Come back with this Special Tool Kit and my book in which i jotted down a clue to the next person will be yours.<BR><BR>" +
						      "</BODY>", false,true);
			
          AddButton(163, 385, 247, 248, 0, GumpButtonType.Reply, 0);
          

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               from.SendMessage( "Please bring me that Special Tool Kit!" );
               break; 
            } 

         }
      }
   }
}