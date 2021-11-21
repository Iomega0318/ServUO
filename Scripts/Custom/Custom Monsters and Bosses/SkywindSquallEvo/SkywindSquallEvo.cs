using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Xanthos.Interfaces;

namespace Xanthos.Evo
{
	[CorpseName( "a skywind squall corpse" )]
	public class SkywindSquall : BaseEvo, IEvoCreature
	{
		public override BaseEvoSpec GetEvoSpec()
		{
			return SkywindSquallSpec.Instance;
			
			SetSpecialAbility(SpecialAbility.DragonBreath);
		}

		public override BaseEvoEgg GetEvoEgg()
		{
			return new SkywindSquallEgg();
		}

		public override bool AddPointsOnDamage { get { return true; } }
		public override bool AddPointsOnMelee { get { return false; } }
		public override Type GetEvoDustType() { return typeof( SkywindSquallDust ); }

		//public override bool HasBreath{ get{ return true; } }

		public SkywindSquall( string name ) : base( name, AIType.AI_Mage, 0.01 )
		{
		}

		public  SkywindSquall( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write( (int)0 );			
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}