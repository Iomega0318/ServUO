using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Engines.XmlSpawner2
{
    public class BonusStatAtt10 : XmlAttachment
    {		
		private int StrVar = 6;
		private int DexVar = 6;
		private int IntVar = 6;
		
        public BonusStatAtt10(ASerial serial) : base(serial)
        {
        }

        [Attachable]
        public BonusStatAtt10()
        {
			Expiration = TimeSpan.FromMinutes(5);
        }

        [Attachable]
        public BonusStatAtt10(double seconds, double duration)
        {
			Expiration = TimeSpan.FromMinutes(duration);
        }
		
		public override void OnAttach()
		{
			base.OnAttach();
			if(AttachedTo is PlayerMobile)
			{
				((PlayerMobile)AttachedTo).Str += StrVar;
				((PlayerMobile)AttachedTo).Dex += DexVar;
				((PlayerMobile)AttachedTo).Int += IntVar;
				((PlayerMobile)AttachedTo).SendMessage("Your loyal pet imbues you with its blood lust!");
				InvalidateParentProperties();
			}
			else
				Delete();
		}
		public override void OnDelete()
		{
			Configured c = new Configured();
			base.OnDelete();
			if(AttachedTo is PlayerMobile)
			{
				((PlayerMobile)AttachedTo).Str -= StrVar;
				((PlayerMobile)AttachedTo).Dex -= DexVar;
				((PlayerMobile)AttachedTo).Int -= IntVar;
				InvalidateParentProperties();
			}
		}
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize(writer);
			writer.Write( (int) 0 );
			// version 
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			// version 0
		}
		
    }
}
