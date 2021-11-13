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
	
	public class TerynAppleClothWeaver : BaseCreature
	{
		[Constructable]
		public TerynAppleClothWeaver() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Teryn";
                                                Title = "*Apple Cloth Weaver*";
			Body = 401;
                                               Hue = 33786;
                                               Female = true;

                        Sandals s = new Sandals();
                        s.Hue = 38;
                        AddItem( s );

                        Kilt k = new Kilt();
                        k.Hue = 38;
                       AddItem( k );

                        Shirt sh = new  Shirt();
                        sh.Hue = 0;
                        AddItem( sh );

                         HalfApron ha = new  HalfApron();
                        ha.Hue = 0;
                        AddItem( ha );

                        LeatherGloves lg = new  LeatherGloves();
                        lg.Hue = 38;
                        AddItem( lg );

                        Item hair = new Item(8252);
                        hair.Hue = 38;
                        hair.Layer = Layer.Hair;
                        hair.Movable = false;
                        AddItem(hair);


                       
                                     Item tessen = new Tessen();
                                     tessen.Movable = false;
                                    tessen.LootType = LootType.Blessed;
                                      AddItem(tessen);

			

			SetStr( 100, 110 );
			SetDex( 125, 200 );
			SetInt( 110, 110 );

			SetHits( 900, 1000 );

			SetDamage( 30, 40 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Fire, 90 );

			SetResistance( ResistanceType.Physical, 90, 95 );
			SetResistance( ResistanceType.Fire, 80, 85 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Poison, 90, 95 );
			SetResistance( ResistanceType.Energy, 100, 110 );

			SetSkill( SkillName.MagicResist, 120.0 );
			SetSkill( SkillName.Tactics, 70.0 );
			SetSkill( SkillName.Wrestling, 90.0 );



           
            
					
			VirtualArmor = 40;

			PackGold( 200, 300 );
			PackItem( new RedAppleWovenCloth() );
		}

		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }

		public  TerynAppleClothWeaver( Serial serial ) : base( serial )
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

