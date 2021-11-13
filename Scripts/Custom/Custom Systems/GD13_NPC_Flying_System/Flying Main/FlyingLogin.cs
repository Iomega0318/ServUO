using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Flying
{
	public class FlyingLogin
	{
		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( OnLogin );
		}

		private static void OnLogin( LoginEventArgs e )
		{
			if ( e.Mobile is PlayerMobile )
			{
                PlayerMobile m = e.Mobile as PlayerMobile;

                m.Flying = false;
                m.CantWalk = false;
                
                List<Item> mfdList = m.Backpack.Items;

                foreach (Item item in mfdList)
                {
                    if (item.Name == "Magic Flying Device-Active")
                    {
                        item.Name = "Magic Flying Device";
                        item.Visible = true;
                    }
                    if (item.Name == "Magic Flying Rug-Active")
                    {
                        item.Name = "Magic Flying Rug";
                        item.Visible = true;
                    }
                    if (item.Name == "Flight Feather")
                    {
                        item.Delete();
                    }
                }
            }
		}
	}
}
