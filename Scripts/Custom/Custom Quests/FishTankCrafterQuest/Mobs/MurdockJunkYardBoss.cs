//Created By Milva
using System;
using Server;
using Server.Items;
using System.Collections; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles
{
	
	public class MurdockJunkYardBoss : BaseCreature
	{
		[Constructable]
		public  MurdockJunkYardBoss() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Murdock";
                                                Title = "*Junk Yard Boss*";
			Body = 400;
                                                 Female = false;
			Hue = 33774;

			SetStr( 300, 400 );
			SetDex( 66, 75 );
			SetInt( 101, 250 );

			SetHits( 900, 1000 );
			SetStam( 0 );

			SetDamage( 40, 50 );

                        Shoes s = new Shoes();
                        s.Hue = 1441;
                        AddItem( s );

                        LongPants p = new LongPants();
                        p.Hue = 1441;
                        AddItem( p );

                        TallStrawHat tsh = new  TallStrawHat();
                        tsh.Hue = 1441;
                        AddItem( tsh );

                        LeatherGloves lg = new  LeatherGloves();
                        lg.Hue = 1441;
                        AddItem( lg );


                         Item doubleaxe = new DoubleAxe();
                         doubleaxe.Movable = false;
                         doubleaxe.LootType = LootType.Blessed;
                         AddItem(doubleaxe);
			

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Poison, 90 );

			SetResistance( ResistanceType.Physical, 105, 115 );
			SetResistance( ResistanceType.Fire, 75, 85 );
			SetResistance( ResistanceType.Cold, 90, 95 );
			SetResistance( ResistanceType.Poison, 80, 85 );
			SetResistance( ResistanceType.Energy, 100, 110 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 100.1, 125.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 95.0 );

			
                                                 
			
			   
			
			
			VirtualArmor = 40;
                        
                        PackGold( 200, 300 );
			PackItem( new SpecialToolKit() );
			
                        
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
		}
        public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override int TreasureMapLevel{ get{ return 2; } }
		//public override bool DisallowAllMoves{ get{ return true; } }

		public   MurdockJunkYardBoss( Serial serial ) : base( serial )
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
		}
	}
}