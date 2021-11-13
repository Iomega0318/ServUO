using System;
using Server;

namespace Xanthos.Evo
{
	public sealed class SkywindSquallSpec : BaseEvoSpec
	{
		// This class implements a singleton pattern; meaning that no matter how many times the
		// Instance attribute is used, there will only ever be one of these created in the entire system.
		// Copy this template and give it a new name.  Assign all of the data members of the EvoSpec
		// base class in the constructor.  Your subclass must not be abstract.
		// Never call new on this class, use the Instance attribute to get the instance instead.

		SkywindSquallSpec()
		{
			m_Tamable = true;
			m_MinTamingToHatch = 99.9;
			m_PercentFemaleChance = 0.04;	// Made small to limit access to eggs.
			m_GuardianEggOrDeedChance = .01;
			m_AlwaysHappy = false;
			m_ProducesYoung = true;
			m_PregnancyTerm = 14.00;
			m_AbsoluteStatValues = false;
			m_MaxEvoResistance = 100;
			m_MaxTrainingStage = 3;
			m_CanAttackPlayers = false;

			m_RandomHues = new int[] { 91, 1175, 1372, 1153, 1360, 176, 275, 1154 };

			m_Skills = new SkillName[7] { SkillName.Magery, SkillName.EvalInt, SkillName.Meditation, SkillName.MagicResist,
										  SkillName.Tactics, SkillName.Wrestling, SkillName.Anatomy };
			m_MinSkillValues = new int[7] { 50, 50, 50, 15, 19, 19, 19 };
			m_MaxSkillValues = new int[7] { 120, 120, 110, 110, 100, 100, 100 };

			m_Stages = new BaseEvoStage[] { new SkywindSquallStageOne(), new SkywindSquallStageTwo(),
											  new SkywindSquallStageThree(), new SkywindSquallStageFour(),
											  new SkywindSquallStageFive(), new SkywindSquallStageSix(),
											  new SkywindSquallStageSeven() };
		}

		// These next 2 lines facilitate the singleton pattern.  In your subclass only change the
		// BaseEvoSpec class name to your subclass of BaseEvoSpec class name and uncomment both lines.
		public static SkywindSquallSpec Instance { get { return Nested.instance; } }
		class Nested { static Nested() { } internal static readonly SkywindSquallSpec instance = new SkywindSquallSpec();}
	}	

	// Define a subclass of BaseEvoStage for each stage in your creature and place them in the
	// array in your subclass of BaseEvoSpec.  See the example classes for how to do this.
	// Your subclass must not be abstract.

	public class SkywindSquallStageOne : BaseEvoStage
	{
		public SkywindSquallStageOne()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 25000; EpMinDivisor = 10; EpMaxDivisor = 5; DustMultiplier = 20;
			BaseSoundID = 0x5C6;
			BodyValue = 175; ControlSlots = 4; MinTameSkill = 99.9; VirtualArmor = 30;
			Hue = Evo.Flags.kRandomHueFlag;

			DamagesTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinDamages = new int[1] { 100 };
			MaxDamages = new int[1] { 100 };

			ResistanceTypes = new ResistanceType[1] { ResistanceType.Physical };
			MinResistances = new int[1] { 15 };
			MaxResistances = new int[1] { 15 };

			DamageMin = 11; DamageMax = 17; HitsMin = 200; HitsMax = 250;
			StrMin = 296; StrMax = 325; DexMin = 56; DexMax = 75; IntMin = 76; IntMax = 96;
		}
	}

	public class SkywindSquallStageTwo : BaseEvoStage
	{
		public SkywindSquallStageTwo()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 75000; EpMinDivisor = 20; EpMaxDivisor = 10; DustMultiplier = 20;
			BaseSoundID = 1478;
			BodyValue = 175; VirtualArmor = 40;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 100, 25, 25, 25, 25 };
			MaxDamages = new int[5] { 100, 25, 25, 25, 25 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 20, 20, 20, 20, 20 };
			MaxResistances = new int[5] { 20, 20, 20, 20, 20 };

			DamageMin = 1; DamageMax = 1; HitsMin= 500; HitsMax = 500;
			StrMin = 200; StrMax = 200; DexMin = 20; DexMax = 20; IntMin = 30; IntMax = 30;
		}
	}

	public class SkywindSquallStageThree : BaseEvoStage
	{
		public SkywindSquallStageThree()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 175000; EpMinDivisor = 30; EpMaxDivisor = 20; DustMultiplier = 20;
			BaseSoundID = 0x5C6;
			BodyValue = 0xAF; VirtualArmor = 50;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 40, 40, 40, 40, 40 };
			MaxResistances = new int[5] { 40, 40, 40, 40, 40 };

			DamageMin = 1; DamageMax = 1; HitsMin= 100; HitsMax = 100;
			StrMin = 100; StrMax = 100; DexMin = 10; DexMax = 10; IntMin = 20; IntMax = 20;
		}
	}

	public class SkywindSquallStageFour : BaseEvoStage
	{
		public SkywindSquallStageFour()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 3750000; EpMinDivisor = 50; EpMaxDivisor = 40; DustMultiplier = 20;
			BaseSoundID = 1478;
			BodyValue = 175; ControlSlots = 4; MinTameSkill = 115; VirtualArmor = 60;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 60, 60, 60, 60, 60 };
			MaxResistances = new int[5] { 60, 60, 60, 60, 60 };	

			DamageMin = 1; DamageMax = 1; HitsMin= 100; HitsMax = 100;
			StrMin = 100; StrMax = 100; DexMin = 10; DexMax = 10; IntMin = 120; IntMax = 120;
		}
	}

	public class SkywindSquallStageFive : BaseEvoStage
	{
		public SkywindSquallStageFive()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 7750000; EpMinDivisor = 160; EpMaxDivisor = 40; DustMultiplier = 20;
			BodyValue = 175; VirtualArmor = 70;
                                                BaseSoundID = 1478;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 100, 50, 50, 50, 50 };
			MaxDamages = new int[5] { 100, 50, 50, 50, 50 };

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 80, 80, 80, 80, 80 };
			MaxResistances = new int[5] { 80, 80, 80, 80, 80 };	

			DamageMin = 5; DamageMax = 5; HitsMin= 100; HitsMax = 100;
			StrMin = 100; StrMax = 100; DexMin = 20; DexMax = 20; IntMin = 120; IntMax = 120;
		}
	}

	public class SkywindSquallStageSix : BaseEvoStage
	{
		public SkywindSquallStageSix()
		{
			EvolutionMessage = "has evolved";
			NextEpThreshold = 15000000; EpMinDivisor = 540; EpMaxDivisor = 480; DustMultiplier = 20;
			BodyValue = 175; VirtualArmor = 170;
		
			DamagesTypes = null;
			MinDamages = null;
			MaxDamages = null;

			ResistanceTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
														ResistanceType.Poison, ResistanceType.Energy };
			MinResistances = new int[5] { 98, 98, 98, 98, 98 };
			MaxResistances = new int[5] { 98, 98, 98, 98, 98 };	

			DamageMin = 5; DamageMax = 5; HitsMin= 100; HitsMax = 100;
			StrMin = 100; StrMax = 100; DexMin = 20; DexMax = 20; IntMin = 120; IntMax = 120;
		}
	}

	public class SkywindSquallStageSeven : BaseEvoStage
	{
		public SkywindSquallStageSeven()
		{
			Title = "The Ancient Skywind Squall";
            EvolutionMessage = "has evolved to its highest form and is now an Ancient Skywind Squall";
			NextEpThreshold = 0; EpMinDivisor = 740; EpMaxDivisor = 660; DustMultiplier = 20;
			BaseSoundID = 1478;
			BodyValue = 175; ControlSlots = 4; VirtualArmor = 270;
		
			DamagesTypes = new ResistanceType[5] { ResistanceType.Physical, ResistanceType.Fire, ResistanceType.Cold,
													 ResistanceType.Poison, ResistanceType.Energy };
			MinDamages = new int[5] { 100, 75, 75, 75, 75 };
			MaxDamages = new int[5] { 100, 75, 75, 75, 75 };

			ResistanceTypes = null;
			MinResistances = null;
			MaxResistances = null;	

			DamageMin = 15; DamageMax = 15; HitsMin= 1350; HitsMax = 1400;
			StrMin = 125; StrMax = 125; DexMin = 125; DexMax = 35; IntMin = 125; IntMax = 125;
		}
	}
}