 /*Created by Hammerhand*/

using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("A Misfit corpse")] 
	public class Misfit : BaseCreature
	{
        public override bool BardImmune { get { return !Core.SE; } }
        public override bool Unprovokable { get { return Core.SE; } }
        public override bool Uncalmable { get { return Core.SE; } }
        public override bool AlwaysMurderer { get { return true; } }
        public override bool IsScaryToPets { get { return true; } }

		private bool m_TrueForm;

        [Constructable]
        public Misfit()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {

            {
                Body = 776;
                Name = "Misfit";
            }

            SetStr(450, 555);
            SetDex(100, 125);
            SetInt(161, 175);

            SetDamage(25, 33);

            SetHits(2500, 3500);

            SetResistance(ResistanceType.Physical, 65, 80);
            SetResistance(ResistanceType.Fire, 50, 60);
            SetResistance(ResistanceType.Cold, 30, 40);
            SetResistance(ResistanceType.Poison, 20, 30);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 90.0, 102.5);
            SetSkill(SkillName.Tactics, 99.9, 110.0);
            SetSkill(SkillName.Wrestling, 100.0, 105.5);

            Fame = 10000;
            Karma = -10000;
            VirtualArmor = 50;

        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
        }
        private static readonly double[] m_Offsets = new double[]
			{
				Math.Cos( 000.0 / 180.0 * Math.PI ), Math.Sin( 000.0 / 180.0 * Math.PI ),
				Math.Cos( 040.0 / 180.0 * Math.PI ), Math.Sin( 040.0 / 180.0 * Math.PI ),
				Math.Cos( 080.0 / 180.0 * Math.PI ), Math.Sin( 080.0 / 180.0 * Math.PI ),
				Math.Cos( 120.0 / 180.0 * Math.PI ), Math.Sin( 120.0 / 180.0 * Math.PI ),
				Math.Cos( 160.0 / 180.0 * Math.PI ), Math.Sin( 160.0 / 180.0 * Math.PI ),
				Math.Cos( 200.0 / 180.0 * Math.PI ), Math.Sin( 200.0 / 180.0 * Math.PI ),
				Math.Cos( 240.0 / 180.0 * Math.PI ), Math.Sin( 240.0 / 180.0 * Math.PI ),
				Math.Cos( 280.0 / 180.0 * Math.PI ), Math.Sin( 280.0 / 180.0 * Math.PI ),
				Math.Cos( 320.0 / 180.0 * Math.PI ), Math.Sin( 320.0 / 180.0 * Math.PI ),
			};
		public void Morph()
		{
			if ( m_TrueForm )
				return;

			m_TrueForm = true;

            Name = "Misfit Ver. 2.0";
			Body = 0x3E7;
            BaseSoundID = 0x2C8;

            Hits = HitsMax;
            Stam = StamMax;
            Mana = ManaMax;

			ProcessDelta();

			Say( "Now I shall CRUSH you!!!" ); 

        }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public override int HitsMax{ get{ return m_TrueForm ? 15000 : 15000; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ManaMax{ get{ return 5000; } }

        public Misfit(Serial serial)
            : base(serial)
		{
		}

		public override bool OnBeforeDeath()
		{
			if ( m_TrueForm )
			{
                switch (Utility.Random(20))
                {
                    case 0: PackItem(new SmokedGlassTable1AddonDeed()); break;
                    case 1: PackItem(new SmokedGlassTable2AddonDeed()); break;
                    case 2: PackItem(new SmokedGlassTable3AddonDeed()); break;
                    case 3: PackItem(new SmokedGlassTable4AddonDeed()); break;
                }
				return base.OnBeforeDeath();
			}
			else
			{
				Morph();
				return false;
			}
		}
	
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			writer.Write( m_TrueForm );			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_TrueForm = reader.ReadBool();

					break;
				}
			}

        }
	}
}
