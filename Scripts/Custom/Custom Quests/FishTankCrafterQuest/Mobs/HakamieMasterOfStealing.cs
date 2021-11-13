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
	
	public class HakamieMasterOfStealing : BaseCreature
	{
                 public virtual double WeaponAbilityChance{ get{ return 0.9; } }
                                public override WeaponAbility GetWeaponAbility()
		{
		return WeaponAbility.ShadowStrike;
		}   
		[Constructable]
		public HakamieMasterOfStealing() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Hakamie";
                                                 Title = "*Master Of Stealing*";
			Body = 400;
                                               Hue = 33786;
                                                Female = false;

                        NinjaTabi nt = new  NinjaTabi ();
                        nt.Hue = 1109;
                        AddItem( nt );

                        TattsukeHakama th = new TattsukeHakama();
                        th.Hue = 0;
                        AddItem( th );

                        HakamaShita hs = new  HakamaShita();
                        hs.Hue = 1109;
                        AddItem( hs );

                        ClothNinjaHood ch = new   ClothNinjaHood();
                        ch.Hue = 1109;
                        AddItem( ch );

                        LeatherGloves lg = new    LeatherGloves  ();
                        lg.Hue = 1109;
                        AddItem( lg );

                                     Item kama = new Kama();
                                    kama.Movable = false;
                                    kama.LootType = LootType.Blessed;
                                     AddItem(kama);

			

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
			PackItem( new HeavySteelSkillet() );
		}

		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }

		public  HakamieMasterOfStealing ( Serial serial ) : base( serial )
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

