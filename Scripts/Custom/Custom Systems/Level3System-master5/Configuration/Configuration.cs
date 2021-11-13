/*	System Configuration, changes to the system should be 
	made here instead of changes to the scripts
*/
using System;
using System.Collections;
using Server;

namespace Server
{
    public class Configured
    {		
		#region Enable or Disable System
		public bool ExpGainFromKill		= false;		
		/* PLAYERS Gain EXP Per Kill. Set to false to disable.  */
		/* Setting to false doesn't disable the pet gain system, however for any kills to register for the
		pet gain system, the playermobile MUST have the XMLPlayerLevelAtt attached, otherwise the kills are
		not registered.  This could be done different however this is done to avoid unneeded distro edits.*/

		#endregion

		#region Int Variable Options
        public int StartMaxLvl			= 100;		//What is the highest level reachable without scrolls?
        public int EndMaxLvl			= 500;		//What is the highest level reachable with scrolls?
		public int SkillCoinCap			= 10800;		//Change this to match the servers skill cap
		
		public int ExpCoinValue = 100;
		/* Example of specific value */ 
		//	public int ExpCoinValue = 100; 
		/* Random beteen 50-70, can be set to a specific number to adjusted in game with [props */
		#endregion
		
		#region LowLevel XML attachment
		public bool LowLevelBonus		= false;	/* This is a bonus to players under a specific level  */
		public int WhatLevelToDelete	= 21;		/* For LowLevelBonus, what level should the bonus be deleted and kept
													deleted after that level? default 21 and up, LowLevelBonus must be true
													for this to apply! */
		public int StatBonusStr			= 12;		/* LowLevelBonus must be enabled for this to work */
		public int StatBonusDex			= 14;		/* LowLevelBonus must be enabled for this to work */
		public int StatBonusInt			= 16;		/* LowLevelBonus must be enabled for this to work */
		#endregion
		  
		#region General Bool Off and On
		public bool GainExpFromBods 	= true;	/* gain exp from turning in bods, based on points */
		public bool AttachOnEquipCreate = true;	/* Attach Level Requirement Item to all weapons and armor!
														Edit LevelEquipXML.cs to configure */
		
		public int ExpPowerAmount		= 75;		/* How much bonus exp for power hour? */
		public bool DisableSkillGain	= false;	/*This will Disable Normal Skill Gain Mechanics, only 
													leveling will allow skill gain. False by default*/
		public bool LevelBelowToon		= false;	/*Default False: In current Servuo Distro, when titles activate this disappears.
													In Older Distro or servers that do not use skill titles over toons head
													this should work. */
		public bool AttachonLogon		= true;		//Attach Level Attachment on Toon Login / This does affect ALL playermobiles. 
		public bool PaperdollLevel		= false;		//Show Players Level In Paperdoll?
        public bool PetKillGivesExp		= true;     //When players pet kills something player gets exp
        public bool CraftGivesExp		= true;		//A sucessful craft gives players exp. (EXPTables.cs for changes) 
        public bool AdvancedSkillExp	= true;	//Only fighting skills give exp?
		public bool TamingGivesExp		= true;		/* Taming Creatures gives EXP, Exp based on attempt, not creature stats */
        public bool AdvancedExp			= true;	/* Use tables to give exp off of killed. 
													set to false to gain exp based on RawStats and Hits*/
		
		
        public bool StaffHasLevel		= true;		//Do Staff Display A Level?
        public bool MaxLevel			= true;	//Show the max level? ex: 86/100
        public bool BonusStatOnLvl		= true;		//On Level Give A Chance To Get A Bonous Stat?
        public bool RefreshOnLevel		= true;		//Sets players hits, stam, and mana to max on level.
		public bool LevelSheetPerma		= false;	/*Shold Player be allowed to drop or move the level sheet?
													Set True to prevent player from dropping, set false to allow drop.*/
		public bool VendorLevels		= false;	//When CreatureLvls is true, do vendors display a level also?
        public bool CreatureLevels		= false;	//Do creatures have levels?
		public bool DiscountsForLevels	= true;		/* Do Level Venders give discounts? */
		#endregion 
		
		#region Party EXP Sharing
        public int PartyRange			= 15;		//When parties share exp, how close do they need to be to get it?
        public bool PartyExpShare		= true;	//False by Default: Do parties share exp?
		
		/* MUST ENABLE PartyExpShare for this to work!!! */
        public bool PartySplitExp		= true;	/*if parties share exp do they split it evenly? */
		
		#endregion
		
		#region Level Up Multpilier
		/* Math = Current Level * Multiplier = AmountNeededForNextLevelUp */
		/* Reduce these numbers to lower the amount of EXP needed per level */
		public int L2to20Multiplier		= 100;		/* Leve 2 to Level 20 */
		public int L21to40Multiplier	= 200;		/* Leve 21 to Level 40 */
		public int L41to60Multiplier	= 400;		/* Leve 41 to Level 60 */
		public int L61to70Multiplier	= 700;		/* Leve 61 to Level 70 */
		public int L71to80Multiplier	= 900;		/* Leve 71 to Level 80 */
		public int L81to90Multiplier		= 1100;		/* Leve 81 to Level 90 */
		public int L91to100Multiplier	= 1300;		/* Leve 91 to Level 100 */
		
		public int L101to110Multiplier	= 1500;		/* Leve 101 to Level 110 */
		public int L111to120Multiplier	= 1700;		/* Leve 110 to Level 120 */
		public int L121to130Multiplier	= 1900;		/* Leve 121 to Level 130 */
		public int L131to140Multiplier	= 2200;		/* Leve 131 to Level 140 */
		public int L141to150Multiplier	= 2500;		/* Leve 141 to Level 150 */
		public int L151to160Multiplier	= 3500;		/* Leve 151 to Level 160 */
		public int L161to170Multiplier	= 3900;		/* Leve 161 to Level 170 */
		public int L171to180Multiplier	= 4110;		/* Leve 171 to Level 180 */
		public int L181to190Multiplier	= 4300;		/* Leve 181 to Level 190 */
		public int L191to200Multiplier	= 6000;		/* Leve 191 to Level 200 */
		
		public int L201to210Multiplier	= 6300;		/* Leve 201 to Level 210 */
		public int L211to220Multiplier	= 6500;		/* Leve 211 to Level 220 */
		public int L221to230Multiplier	= 7700;		/* Leve 221 to Level 230 */
		public int L231to240Multiplier	= 8900;		/* Leve 231 to Level 240 */
		public int L241to250Multiplier	= 9200;		/* Leve 241 to Level 250 */
		public int L251to260Multiplier	= 10500;	/* Leve 251 to Level 260 */
		public int L261to270Multiplier	= 11500;	/* Leve 261 to Level 270 */
		public int L271to280Multiplier	= 12900;	/* Leve 271 to Level 280 */
		public int L281to290Multiplier	= 13110;	/* Leve 281 to Level 290 */
		public int L291to300Multiplier	= 14300;	/* Leve 291 to Level 300 */	
		
		public int L301to310Multiplier	= 15000;	/* Leve 301 to Level 310 */
		public int L311to320Multiplier	= 15500;	/* Leve 311 to Level 320 */
		public int L321to330Multiplier	= 16000;	/* Leve 321 to Level 330 */
		public int L331to340Multiplier	= 16500;	/* Leve 331 to Level 340 */
		public int L341to350Multiplier	= 17000;	/* Leve 341 to Level 350 */
		public int L351to360Multiplier	= 17500;	/* Leve 351 to Level 360 */
		public int L361to370Multiplier	= 18000;	/* Leve 361 to Level 370 */
		public int L371to380Multiplier	= 18500;	/* Leve 371 to Level 380 */
		public int L381to390Multiplier	= 19000;	/* Leve 381 to Level 390 */
		public int L391to400Multiplier	= 20000;	/* Leve 391 to Level 400 */	
		
		public int L401to410Multiplier	= 21000;	/* Leve 401 to Level 410 */
		public int L411to420Multiplier	= 22000;	/* Leve 411 to Level 420 */
		public int L421to430Multiplier	= 23000;	/* Leve 421 to Level 430 */
		public int L431to440Multiplier	= 24000;	/* Leve 431 to Level 440 */
		public int L441to450Multiplier	= 25000;	/* Leve 441 to Level 450 */
		public int L451to460Multiplier	= 26000;	/* Leve 451 to Level 460 */
		public int L461to470Multiplier	= 27000;	/* Leve 461 to Level 470 */
		public int L471to480Multiplier	= 28000;	/* Leve 471 to Level 480 */
		public int L481to490Multiplier	= 29000;	/* Leve 481 to Level 490 */
		public int L491to500Multiplier	= 30000;	/* Leve 491 to Level 500 */
		#endregion
		
		#region Player Level Gump Config
		public bool LevelSheetStatResetButton	= true;	/* Master Stat Reset button - adds a button to playerlevelgump */
		public bool LevelSheetSkillResetButton	= true;	/* Master Skill Reset button - adds a button to playerlevelgump */
		
		/* Categories - set false to hide category */
		public bool Miscelaneous		= true; 		/* Enabled by Default */
		public bool Combat				= true; 		/* Enabled by Default */
		public bool TradeSkills			= true; 		/* Enabled by Default */
		public bool Magic				= true; 		/* Enabled by Default */
		public bool Wilderness			= true; 		/* Enabled by Default */
		public bool Thieving			= true; 		/* Enabled by Default */
		public bool Bard				= true; 		/* Enabled by Default */
		
		/* Stygian Abyss Skills */
		public bool Imbuing				= true;
		public bool Throwing			= true;
		public bool Mysticism			= true;
		
		/* Mondain's Legacy */
		public bool Spellweaving		= true;
		

		#endregion
		
		/* Being phased out */
        public const Active Curr = Active.Enviroment;
        // -<  Off | Classic | Enviroment | PvP >-

        public const View Cnfg = View.BelowName;
        // -< None | InName | BelowName >-
		/* Being phased out */
    }

    #region  !!! DO NOT CHANGE ANY THING BELOW THIS POINT !!!
    public class Off
    {
        public static bool Enabled { get { return Configured.Curr == Active.Off; } }
    }
    public class Cl
    {
        public static bool Enabled { get { return Configured.Curr == Active.Classic; } }
    }
    public class En
    {
        public static bool Enabled { get { return Configured.Curr == Active.Enviroment; } }
    }
    public class PvP
    {
        public static bool Enabled { get { return Configured.Curr == Active.PvP; } }
    }
    public class None
    {
        public static bool Enabled { get { return Configured.Cnfg == View.None; } }
    }
    public class InName
    {
        public static bool Enabled { get { return Configured.Cnfg == View.InName; } }
    }
    public class BelowName
    {
        public static bool Enabled { get { return Configured.Cnfg == View.BelowName; } }
    }

    public enum Active
    {
        Off,
        Classic,
        Enviroment,
        PvP
    }

    public enum View
    {
        None,
        InName,
        BelowName
    }
    #endregion
}
