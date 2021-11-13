//Created By Mil
using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands;

namespace Server.Gumps
{ 
   public class FishTankCrafterGump : Gump 
   { 
      public static void Initialize() 
      {
          CommandSystem.Register(" FishTankCrafterGump", AccessLevel.GameMaster, new CommandEventHandler( FishTankCrafterGump_OnCommand)); 
      } 

      private static void   FishTankCrafterGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new   FishTankCrafterGump( e.Mobile ) ); 
      } 

      public   FishTankCrafterGump( Mobile owner ) : base( 50,50 ) 
      { 
                                                 this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
//----------------------------------------------------------------------------------------------------

			AddPage( 0 );
			AddImageTiled(13, 9, 382, 433, 2524);
			AddImageTiled(14, 8, 381, 14, 11392);
			AddImageTiled(15, 433, 381, 9, 11392);
			AddImage(13, 198, 3005, 32);
			AddImage(392, 191, 3003, 32);
			AddImage(391, 17, 3003, 32);
                                                AddImage(13, 21, 3005, 32);
             AddTextEntry(123, 33, 159, 20, 147, 0, @"    Fish Tank Crafter Quest!");
            
            
           
			
			

            AddHtml( 32, 89, 346, 281, "<BODY>"+
			
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=Red>Ethan, hello so your interested in my Fish Tank Boat?.<BR>" +
"<BASEFONT COLOR=Red>I'm running very low on my Keg Of Paint to create more of these<BR><BR>" +
"<BASEFONT COLOR=Red>So if your willing to help me, I shall give you one of my Fish Tank Boats for free!<BR>" +
"<BASEFONT COLOR=Red>But to create this keg of paint...<BR><BR>You will need to gather 3 items.<BR>" +
"<BASEFONT COLOR=Red>In return for your help, I will give you a special gift, please go see the The Keg Crafter.<BR><BR>" +

"<BASEFONT COLOR=Red>This Keg Crafter, lives outside of the town of Vesper.<BR><BR>Now be off with you.<BR><BR>" +
"<BASEFONT COLOR=Red>Be warned, he may not want to help so easy, lord knows he is a grumpy keg crafter.<BR><BR>" +

"<BASEFONT COLOR=Red>Please gather this full keg of paint  and I will be forever in your debt. Please take this basket.<BR><BR>" +

"<BASEFONT COLOR=Red>-Oh once you have all the pieces just click on the basket this will create the<BR><BR>" +  

"<BASEFONT COLOR=Red>-The full keg of paint,  then return to me with this Full Paint Keg. <BR><BR>" +
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
               from.SendMessage( "please bring me a full keg of paint" );
               break; 
            } 

         }
      }
   }
}