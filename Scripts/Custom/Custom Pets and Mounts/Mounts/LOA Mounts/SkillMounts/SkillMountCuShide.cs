// Created by Crow

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class SkillMountCuShide : EtherealMount 
	{ 
		[Constructable] 
		//public SkillMountCuShide() : base( 11670, 0x3E91 
		public SkillMountCuShide() : base(0x2D96, 0x3E91, 0x3E91, DefaultEtherealHue)
		{ 
			Name = "Ethereal Skill CuShide";
			ItemID = 11670;
			
		} 
                 public override void OnAdded( Object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base += 10;
                                from.Skills.Fencing.Base += 10;
                                from.Skills.Magery.Base += 10;
                                from.Skills.Archery.Base += 10;
                                from.Skills.Macing.Base += 10;
                                from.Skills.Wrestling.Base += 10;
                                from.Skills.Anatomy.Base += 10; 
                                from.Skills.Meditation.Base += 10;
                                from.Skills.EvalInt.Base += 10;
			}
		}
		public override void OnRemoved( Object parent )
		{
			base.OnRemoved( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.Skills.Swords.Base -= 10;
                                from.Skills.Fencing.Base -= 10;
                                from.Skills.Magery.Base -= 10;
                                from.Skills.Archery.Base -= 10;
                                from.Skills.Macing.Base -= 10;
                                from.Skills.Wrestling.Base -= 10;
                                from.Skills.Anatomy.Base -= 10;
                                from.Skills.Meditation.Base -= 10;
                                from.Skills.EvalInt.Base -= 10;
			}
			
		}

		public SkillMountCuShide( Serial serial ) : base( serial ) 
		{ 
		} 

		

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 

			if ( Name != "Ethereal CuShide Statuette" )
				Name = "Ethereal CuShide Statuette";
		} 
	}
}