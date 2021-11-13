/***************************************************************************/
/*			ResourceBox.cs | ResourceBoxGump.cs | StorageTypes.cs          */
/*							Created by A_Li_N                              */
/*				Credits :                                                  */
/*						Original Gump Layout - Lysdexic                    */
/*						Hashtable help - UOT and daat99                    */
/***************************************************************************/
/*	Addition of different Resources :                                      */
/*		To add/remove resource types from the box, simply put the Type of  */
/*		the resource in the catagory you wish it to be in.  Each catagory  */
/*		can hold up to 32 entries without messing a LOT with the gump.     */
/*	Removing of Resources :                                                */
/*		Commenting out or deleting the type you wish to remove will remove */
/*		the type AND the amount each Resource Box contains.                */
/***************************************************************************/

using System;

namespace Server.Items
{
	public class StorageTypes
	{
		private static Type[] m_Logs = new Type[]
		{
			typeof( Log ),
			typeof( BloodwoodLog ),
			typeof( AshLog ),
			typeof( FrostwoodLog),
			typeof( YewLog ),
			typeof( OakLog ),
			typeof( HeartwoodLog ),
            typeof( EbonyLog ),
            typeof( BambooLog ),
            //typeof( MohoganyLog ),
            //typeof( PineLog ),
            //typeof( ZircoteLog ),
		};
		public static Type[] Logs{ get{ return m_Logs; } }

		private static Type[] m_Boards = new Type[]
		{
			typeof( Board ),
			typeof( BloodwoodBoard ),
			typeof( AshBoard ),
			typeof( FrostwoodBoard),
			typeof( YewBoard ),
			typeof( OakBoard ),
			typeof( HeartwoodBoard ),
            typeof( EbonyBoard ),
            typeof( BambooBoard ),
            //typeof( PineBoard ),
            //typeof( MohoganyBoard ),
            //typeof( ZircoteBoard ),
		};
		public static Type[] Boards{ get{ return m_Boards; } }

		private static Type[] m_Ingots = new Type[]
		{
			typeof( IronIngot ),
			typeof( DullCopperIngot ),
			typeof( ShadowIronIngot ),
			typeof( CopperIngot ),
			typeof( BronzeIngot ),
			typeof( GoldIngot ),
			typeof( AgapiteIngot ),
			typeof( VeriteIngot ),
			typeof( ValoriteIngot ),
            typeof( BlazeIngot ),
            typeof( IceIngot ),
            typeof( ToxicIngot ),
            typeof( ElectrumIngot ),
            typeof( PlatinumIngot ),
            typeof( IronOre ),
			typeof( DullCopperOre ),
			typeof( ShadowIronOre ),
			typeof( CopperOre ),
			typeof( BronzeOre ),
			typeof( GoldOre ),
			typeof( AgapiteOre ),
			typeof( VeriteOre ),
			typeof( ValoriteOre ),
            typeof( BlazeOre ),
            typeof( IceOre ),
            typeof( ToxicOre ),
            typeof( ElectrumOre ),
            typeof( PlatinumOre ),
		};
		public static Type[] Ingots{ get{ return m_Ingots; } }

		private static Type[] m_Granites = new Type[]
		{
			typeof( Granite ),
			typeof( DullCopperGranite ),
			typeof( ShadowIronGranite ),
			typeof( CopperGranite ),
			typeof( BronzeGranite ),
			typeof( GoldGranite ),
			typeof( AgapiteGranite ),
			typeof( VeriteGranite ),
			typeof( ValoriteGranite ),
            typeof( BlazeGranite ),
            typeof( IceGranite ),
            typeof( ToxicGranite ),
            typeof( ElectrumGranite ),
            typeof( PlatinumGranite ),
		};
		public static Type[] Granites{ get{ return m_Granites; } }

		private static Type[] m_Scales = new Type[]
		{
			typeof( RedScales ),
			typeof( YellowScales ),
			typeof( BlackScales ),
			typeof( GreenScales ),
			typeof( WhiteScales ),
			typeof( BlueScales ),
            typeof( CopperScales ),
            typeof( SilverScales ),
            typeof( GoldScales ),
		};
		public static Type[] Scales{ get{ return m_Scales; } }

		private static Type[] m_Leathers = new Type[]
		{
			typeof( Leather ),
			typeof( SpinedLeather ),
			typeof( HornedLeather ),
			typeof( BarbedLeather ),
            typeof( BlazeLeather ),
            typeof( SyntheticLeather ),
            typeof( DaemonicLeather ),
            typeof( ShadowLeather ),
            typeof( FrostLeather ),
            typeof( EtherealLeather ),
            typeof( PolarLeather ),
		};
		public static Type[] Leathers{ get{ return m_Leathers; } }

		private static Type[] m_Misc = new Type[]
		{
			typeof( Sand ),
            typeof( RelicFragment ),
            typeof( MagicalResidue ),
            typeof( RaptorTeeth ),
            typeof( Diamond ),
            typeof( Emerald ),
            typeof( Ruby ),
            typeof( Citrine ),
            typeof( Tourmaline ),
            typeof( Amber ),
            typeof( Amethyst ),
            typeof( Sapphire ),
            typeof( StarSapphire ),
            typeof( FaeryDust ),
            typeof( VoidEssence ),
            typeof( VialOfVitriol ),
            typeof( AbyssalCloth ),
            typeof( ArcanicRuneStone ),
            typeof( BottleIchor ),
            typeof( CrushedGlass ),
            typeof( CrystalShards ),
            typeof( CrystallineBlackrock ),
            typeof( DaemonClaw ),
            typeof( DelicateScales ),
            //typeof( ElvenFletchings ),
            typeof( FeyWings ),
            typeof( Fur ),
            typeof( GoblinBlood ),
            typeof( HornAbyssalInferno ),
            typeof( KepetchWax ),
            typeof( Lodestone ),
            typeof( MedusaBlood ),
            typeof( MedusaLightScales ),
            typeof( MedusaDarkScales ),
            typeof( PowderedIron ),
            typeof( PrimalLichDust ),
            typeof( ReflectiveWolfEye ),
            //typeof( SeedRenewal ),
            //typeof( ShimmeringCrystal ),
            typeof( SilverSerpentVenom ),
            typeof( SilverSnakeSkin ),
            typeof( SlithEye ),
            typeof( SlithTongue ),
            typeof( SpiderCarapace ),
            typeof( ScouringToxin ),
            typeof( ToxicVenomSac ),
            typeof( UndyingFlesh ),
            //typeof( VileTentacles ),
            typeof( VoidOrb ),
            typeof( VoidCore ),
            typeof( EssenceControl ),
            typeof( ChagaMushroom ),
            //typeof( EnchantEssence ),
            typeof( EssencePersistence ),
            typeof( EssenceSingularity ),
            typeof( EssencePrecision ),
            typeof( EssenceDiligence ),
            typeof( EssenceAchievement ),
            typeof( EssenceOrder ),
            typeof( EssenceFeeling ),
            typeof( EssencePassion ),
            typeof( EssenceDirection ),
            typeof( EssenceBalance ),
            typeof( EssenceControl ),
             
            //typeof( FireRuby ),
            


			typeof( Cloth ),
			typeof( Cotton ),
			typeof( Flax ),
			typeof( Wool ),
			typeof( Bandage ),

			typeof( Arrow ),
			typeof( Bolt ),
			typeof( Feather ),
			typeof( Shaft ),
		};
		public static Type[] Misc{ get{ return m_Misc; } }

		private static Type[] m_Reagents = new Type[]
		{
			typeof( BlackPearl ),
			typeof( Bloodmoss ),
			typeof( Garlic ),
			typeof( Ginseng ),
			typeof( MandrakeRoot ),
			typeof( Nightshade ),
			typeof( SulfurousAsh ),
			typeof( SpidersSilk ),
			typeof( BatWing ),
			typeof( GraveDust ),
			typeof( DaemonBlood ),
			typeof( NoxCrystal ),
			typeof( PigIron ),
            typeof( PetrafiedWood ),
            typeof( SpringWater ),
            typeof( DestroyingAngel ),
		};
		public static Type[] Reagents{ get{ return m_Reagents; } }
	}
}