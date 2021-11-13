using System;

namespace Server.Items
{
	public class DustyArtifactBag : BaseRewardBag
	{
		[Constructable]
		public DustyArtifactBag()
		
		{
			this.AddItem(new Gold(0));

			switch (Utility.Random(0))
			{
				case 0:
					this.AddItem(new RAD());
					break;

			}
		}

		public DustyArtifactBag(Serial serial)
			: base (serial)
		{
			this.Name = "Dusty Artifact Bag";
		}

		public override int LabelNumber
		{
			get
			{
				return 1112994;
			}
		}
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version 
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
} 

