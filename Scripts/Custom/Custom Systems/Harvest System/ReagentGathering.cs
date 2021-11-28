using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.Plants;
//using Server.Items.Crops;
//using Server.ResourceBoxes;
//using Server.SpellCrafting.Items;
//using Server.SpellCrafting;


namespace Server.Engines.Harvest
{
    public class ReagentGathering : HarvestSystem
    {
        public override HarvestVein MutateVein(Mobile from, Item tool, HarvestDefinition def, HarvestBank bank, object toHarvest, HarvestVein vein)
        {
            return base.MutateVein(from, tool, def, bank, toHarvest, vein);
        }

        private static int[] m_Offsets = new int[]
          {
         -1, -1,
         -1,  0,
         -1,  1,
         0, -1,
         0,  1,
         1, -1,
         1,  0,
         1,  1
          };

        public override void OnHarvestFinished(Mobile from, Item tool, HarvestDefinition def, HarvestVein vein, HarvestBank bank, HarvestResource resource, object harvested)
        {
                   /*double skillvaluelj = killerguy.Skills[SkillName.Magery].Base;
                   int i_itemid = (int)(killerguy.Skills[SkillName.ItemID].Base/10);

                   if ((Utility.RandomMinMax( 1, 1500 ) <= (1 + i_itemid)) && (skillvaluelj >= 70.1))
                   {
                     switch (Utility.RandomMinMax( 0, 10 ))
                     {
                       case 1 : from.AddToBackpack(new BarkFragment()); from.SendMessage ("you find something wedged in the tree, a peice of bark ");break;
                       case 2 : from.AddToBackpack(new LuminescentFungi()); from.SendMessage ("you find something wedged in the tree, some fungi ");break;
                       case 3 : from.AddToBackpack(new ParasiticPlant()); from.SendMessage ("you find something wedged in the tree, a weird looking plant");break;
                       case 4 : from.AddToBackpack(new DiseasedBark()); from.SendMessage ("you find something wedged in the tree, some weird looking bark ");break;
                     }
                   }*/
        }

        private static ReagentGathering m_System;

        public static ReagentGathering System
        {
            get
            {
                if (m_System == null)
                    m_System = new ReagentGathering();

                return m_System;
            }
        }

        private HarvestDefinition m_Definition;

        public HarvestDefinition Definition
        {
            get { return m_Definition; }
        }

        private ReagentGathering()
        {
            HarvestResource[] res;
            HarvestVein[] veins;

            #region ReagentGathering
            HarvestDefinition reagent = new HarvestDefinition();

            // Resource banks are every 4x3 tiles
            reagent.BankWidth = 2;
            reagent.BankHeight = 2;

            // Every bank holds from 20 to 45 logs
            reagent.MinTotal = 20;
            reagent.MaxTotal = 45;

            // A resource bank will respawn its content every 20 to 30 minutes
            reagent.MinRespawn = TimeSpan.FromMinutes(20.0);
            reagent.MaxRespawn = TimeSpan.FromMinutes(30.0);

            // Skill checking is done on the Magery skill
            reagent.Skill = SkillName.Magery;

            // Set the list of harvestable tiles
            reagent.Tiles = m_TreeTiles;

            // Players must be within 2 tiles to harvest
            reagent.MaxRange = 2;

            // Ten logs per harvest action
            reagent.ConsumedPerHarvest = 10;
            reagent.ConsumedPerFeluccaHarvest = 10;

            // The chopping effect
            reagent.EffectActions = new int[] { 13 };
            reagent.EffectSounds = new int[] { 0x13E };
            reagent.EffectCounts = new int[] { 1, 2 };
            reagent.EffectDelay = TimeSpan.FromSeconds(1.3);
            reagent.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            reagent.NoResourcesMessage = 500493; // There's not enough wood here to harvest.
            reagent.FailMessage = 500495; // You hack at the tree for a while, but fail to produce any useable wood.
            reagent.OutOfRangeMessage = 500446; // That is too far away.
            reagent.PackFullMessage = 500497; // You can't place any wood into your backpack!
            reagent.ToolBrokeMessage = 500499; // You broke your axe.

            res = new HarvestResource[]
              {
  // NUMBERS BELOW ARE...
  // 1st Required Skill Needed
  // 2nd Min Skill Needed
  // 3rd Max Skill Needed
  // 4th Success Message CLI No

         new HarvestResource( 100.0, 20.0, 100.0, "You put some Bloodmoss in your backpack",   typeof( Bloodmoss ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some Garlic in your backpack",     typeof( Garlic ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some Ginseng in your backpack",     typeof( Ginseng ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some MandrakeRoot in your backpack",   typeof( MandrakeRoot ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some Nightshade in your backpack",   typeof( Nightshade ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some SpidersSilk in your backpack",   typeof( SpidersSilk ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some BatWing in your backpack",   typeof( BatWing ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some DeadWood in your backpack",   typeof( DeadWood ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some PigIron in your backpack",   typeof( PigIron ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some NoxCrystal in your backpack",   typeof( NoxCrystal ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some GraveDust in your backpack",   typeof( GraveDust ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some DaemonBlood in your backpack",   typeof( DaemonBlood ) ),
         new HarvestResource( 100.0, 20.0, 100.0, "You put some DaemonBone in your backpack",   typeof( DaemonBone ) )
              };

            veins = new HarvestVein[]
              {
  // NUMBERS BELOW ARE...
  // 1ST Vein Chance
  // 2ND Chance To Fallback
  // 3RD Primary Resource
  // 4TH Fallback Resource
         new HarvestVein( 10.0, 0.0, res[0], null ),    // Bloodmoss
         new HarvestVein( 10.0, 0.2, res[1], res[0] ),    // Garlic
         new HarvestVein( 10.0, 0.2, res[2], res[0] ),    // Ginseng
         new HarvestVein( 10.0, 0.2, res[3], res[0] ),    // MandrakeRoot
         new HarvestVein( 10.0, 0.2, res[4], res[0] ),    // Nightshade
         new HarvestVein( 10.0, 0.2, res[5], res[0] ),    // SpidersSilk
         new HarvestVein( 10.0, 0.2, res[6], res[0] ),    // BatWing
         new HarvestVein( 10.0, 0.2, res[7], res[0] ),    // DeadWood
         new HarvestVein( 10.0, 0.2, res[8], res[0] ),   // PigIron
         new HarvestVein( 10.0, 0.2, res[9], res[0] ),   // NoxCrystal
         new HarvestVein( 10.0, 0.2, res[10], res[0] ),   // GraveDust
         new HarvestVein( 10.0, 0.2, res[11], res[0] ),   // DaemonBlood
         new HarvestVein( 10.0, 0.2, res[12], res[0] )   // DaemonBone
              };

            reagent.Resources = res;
            reagent.Veins = veins;

            m_Definition = reagent;
            Definitions.Add(reagent);
            #endregion
        }

        public override bool CheckHarvest(Mobile from, Item tool)
        {
            if (!base.CheckHarvest(from, tool))
                return false;

            if (from.Mounted)
            {
                from.SendMessage("You can't cut trees while riding.");
                return false;
            }

            return true;
        }

        public override bool CheckHarvest(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
            if (!base.CheckHarvest(from, tool, def, toHarvest))
                return false;

            if (from.Mounted)
            {
                from.SendMessage("You can't cut trees while riding.");
                return false;
            }

            return true;
        }

        public override void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
        {
            from.SendLocalizedMessage(500489); // You can't use an axe on that.
        }

        public static void Initialize()
        {
            Array.Sort(m_TreeTiles);
        }

        #region Tile lists
        private static int[] m_TreeTiles = new int[]
          {
         0x4CCA, 0x4CCB, 0x4CCC, 0x4CCD, 0x4CD0, 0x4CD3, 0x4CD6, 0x4CD8,
         0x4CDA, 0x4CDD, 0x4CE0, 0x4CE3, 0x4CE6, 0x4CF8, 0x4CFB, 0x4CFE,
         0x4D01, 0x4D41, 0x4D42, 0x4D43, 0x4D44, 0x4D57, 0x4D58, 0x4D59,
         0x4D5A, 0x4D5B, 0x4D6E, 0x4D6F, 0x4D70, 0x4D71, 0x4D72, 0x4D84,
         0x4D85, 0x4D86, 0x52B5, 0x52B6, 0x52B7, 0x52B8, 0x52B9, 0x52BA,
         0x52BB, 0x52BC, 0x52BD,

         0x4CCE, 0x4CCF, 0x4CD1, 0x4CD2, 0x4CD4, 0x4CD5, 0x4CD7, 0x4CD9,
         0x4CDB, 0x4CDC, 0x4CDE, 0x4CDF, 0x4CE1, 0x4CE2, 0x4CE4, 0x4CE5,
         0x4CE7, 0x4CE8, 0x4CF9, 0x4CFA, 0x4CFC, 0x4CFD, 0x4CFF, 0x4D00,
         0x4D02, 0x4D03, 0x4D45, 0x4D46, 0x4D47, 0x4D48, 0x4D49, 0x4D4A,
         0x4D4B, 0x4D4C, 0x4D4D, 0x4D4E, 0x4D4F, 0x4D50, 0x4D51, 0x4D52,
         0x4D53, 0x4D5C, 0x4D5D, 0x4D5E, 0x4D5F, 0x4D60, 0x4D61, 0x4D62,
         0x4D63, 0x4D64, 0x4D65, 0x4D66, 0x4D67, 0x4D68, 0x4D69, 0x4D73,
         0x4D74, 0x4D75, 0x4D76, 0x4D77, 0x4D78, 0x4D79, 0x4D7A, 0x4D7B,
         0x4D7C, 0x4D7D, 0x4D7E, 0x4D7F, 0x4D87, 0x4D88, 0x4D89, 0x4D8A,
         0x4D8B, 0x4D8C, 0x4D8D, 0x4D8E, 0x4D8F, 0x4D90, 0x4D95, 0x4D96,
         0x4D97, 0x4D99, 0x4D9A, 0x4D9B, 0x4D9D, 0x4D9E, 0x4D9F, 0x4DA1,
         0x4DA2, 0x4DA3, 0x4DA5, 0x4DA6, 0x4DA7, 0x4DA9, 0x4DAA, 0x4DAB,
         0x52BE, 0x52BF, 0x52C0, 0x52C1, 0x52C2, 0x52C3, 0x52C4, 0x52C5,
         0x52C6, 0x52C7, 0x647D, 0x647E, 0x6476, 0x6477, 0x624A, 0x624B,
         0x624C, 0x624D, 0x4D94, 0x4D98, 0x4D9C, 0x4DA4, 0x4DA8, 0x70A1,
         0x709C, 0x70BD, 0x70C3, 0x70D4, 0x70DA, 0xDA0
          };
        #endregion
    }
}
