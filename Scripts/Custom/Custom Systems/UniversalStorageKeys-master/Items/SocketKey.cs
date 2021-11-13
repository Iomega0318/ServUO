using Server.Engines.VeteranRewards;
using Solaris.ItemStore;							//for connection to resource store data objects
using System.Collections.Generic;

namespace Server.Items
{
    //item derived from BaseResourceKey
    public class SocketKey : BaseStoreKey, IRewardItem
    {
        private bool m_IsRewardItem;

        [CommandProperty(AccessLevel.Seer)]
        public bool IsRewardItem
        {
            get => m_IsRewardItem;
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }

        //set the # of columns of entries to display on the gump.. default is 2
        public override int DisplayColumns => 2;

        public override List<StoreEntry> EntryStructure
        {
            get
            {
                List<StoreEntry> entry = base.EntryStructure;

                entry.Add(new ResourceEntry(typeof(FenCrystal), "Fen Crystal"));
                entry.Add(new ResourceEntry(typeof(RhoCrystal), "Rho Crystal"));
                entry.Add(new ResourceEntry(typeof(RysCrystal), "Rys Crystal"));
                entry.Add(new ResourceEntry(typeof(WyrCrystal), "Wyr Crystal"));
                entry.Add(new ResourceEntry(typeof(FreCrystal), "Fre Crystal"));
                entry.Add(new ResourceEntry(typeof(TorCrystal), "Tor Crystal"));
                entry.Add(new ResourceEntry(typeof(VelCrystal), "Vel Crystal"));
                entry.Add(new ResourceEntry(typeof(XenCrystal), "Xen Crystal"));
                entry.Add(new ResourceEntry(typeof(PolCrystal), "Pol Crystal"));
                entry.Add(new ResourceEntry(typeof(WolCrystal), "Wol Crystal"));
                entry.Add(new ResourceEntry(typeof(BalCrystal), "Bal Crystal"));
                entry.Add(new ResourceEntry(typeof(TalCrystal), "Tal Crystal"));
                entry.Add(new ResourceEntry(typeof(JalCrystal), "Jal Crystal"));
                entry.Add(new ResourceEntry(typeof(RalCrystal), "Ral Crystal"));
                entry.Add(new ResourceEntry(typeof(KalCrystal), "Kal Crystal"));
				
                entry.Add(new ColumnSeparationEntry());
				
                entry.Add(new ResourceEntry(typeof(RadiantRhoCrystal), "Radiant Rho Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantRysCrystal), "Radiant Rys Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantWyrCrystal), "Radiant Wyr Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantFreCrystal), "Radiant Fre Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantTorCrystal), "Radiant Tor Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantVelCrystal), "Radiant Vel Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantXenCrystal), "Radiant Xen Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantPolCrystal), "Radiant Pol Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantWolCrystal), "Radiant Wol Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantBalCrystal), "Radiant Bal Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantTalCrystal), "Radiant Tal Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantJalCrystal), "Radiant Jal Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantRalCrystal), "Radiant Ral Crystal"));
                entry.Add(new ResourceEntry(typeof(RadiantKalCrystal), "Radiant Kal Crystal"));
				
                entry.Add(new ColumnSeparationEntry());
				
                entry.Add(new ResourceEntry(typeof(MythicAmethyst), "Mythic Amethyst"));
                entry.Add(new ResourceEntry(typeof(LegendaryAmethyst), "Legendary Amethyst"));
                entry.Add(new ResourceEntry(typeof(AncientAmethyst), "Ancient Amethyst"));
                entry.Add(new ResourceEntry(typeof(MythicDiamond), "Mythic Diamond"));
                entry.Add(new ResourceEntry(typeof(LegendaryDiamond), "Legendary Diamond"));
                entry.Add(new ResourceEntry(typeof(AncientDiamond), "Ancient Diamond"));
                entry.Add(new ResourceEntry(typeof(MythicEmerald), "Mythic Emerald"));
                entry.Add(new ResourceEntry(typeof(LegendaryEmerald), "Legendary Emerald"));
                entry.Add(new ResourceEntry(typeof(AncientEmerald), "Ancient Emerald"));
                entry.Add(new ResourceEntry(typeof(MythicRuby), "Mythic Ruby"));
                entry.Add(new ResourceEntry(typeof(LegendaryRuby), "Legendary Ruby"));
                entry.Add(new ResourceEntry(typeof(AncientRuby), "Ancient Ruby"));
                entry.Add(new ResourceEntry(typeof(MythicSapphire), "Mythic Sapphire"));
                entry.Add(new ResourceEntry(typeof(LegendarySapphire), "Legendary Sapphire"));
                entry.Add(new ResourceEntry(typeof(AncientSapphire), "Ancient Sapphire"));
                entry.Add(new ResourceEntry(typeof(MythicTourmaline), "Mythic Tourmaline"));
                entry.Add(new ResourceEntry(typeof(LegendaryTourmaline), "Legendary Tourmaline"));
                entry.Add(new ResourceEntry(typeof(AncientTourmaline), "Ancient Tourmaline"));
				
                entry.Add(new ColumnSeparationEntry());
				
                entry.Add(new ResourceEntry(typeof(GlimmeringGranite), "Glimmering Granite"));
                entry.Add(new ResourceEntry(typeof(GlimmeringClay), "Glimmering Clay"));
                entry.Add(new ResourceEntry(typeof(GlimmeringHeartstone), "Glimmering Heartstone"));
                entry.Add(new ResourceEntry(typeof(GlimmeringGypsum), "Glimmering Gypsum"));
                entry.Add(new ResourceEntry(typeof(GlimmeringIronOre), "Glimmering Iron Ore"));
                entry.Add(new ResourceEntry(typeof(GlimmeringOnyx), "Glimmering Onyx"));
                entry.Add(new ResourceEntry(typeof(GlimmeringMarble), "Glimmering Marble"));
                entry.Add(new ResourceEntry(typeof(GlimmeringPetrifiedWood), "Glimmering Petrified Wood"));
                entry.Add(new ResourceEntry(typeof(GlimmeringLimestone), "Glimmering Limestone"));
                entry.Add(new ResourceEntry(typeof(GlimmeringBloodrock), "Glimmering Bloodrock"));
				
                entry.Add(new ColumnSeparationEntry());
				
                entry.Add(new ResourceEntry(typeof(TyrRune), "Tyr Rune"));
                entry.Add(new ResourceEntry(typeof(AhmRune), "Ahm Rune"));
                entry.Add(new ResourceEntry(typeof(MorRune), "Mor Rune"));
                entry.Add(new ResourceEntry(typeof(MefRune), "Mef Rune"));
                entry.Add(new ResourceEntry(typeof(YlmRune), "Ylm Rune"));
                entry.Add(new ResourceEntry(typeof(KotRune), "Kot Rune"));
                entry.Add(new ResourceEntry(typeof(JorRune), "Jor Rune"));
				
                entry.Add(new ColumnSeparationEntry());
				
                entry.Add(new ResourceEntry(typeof(MythicSkull), "Mythic Skull"));
                entry.Add(new ResourceEntry(typeof(AncientSkull), "Ancient Skull"));
                entry.Add(new ResourceEntry(typeof(LegendarySkull), "Legendary Skull"));
				
				entry.Add(new ColumnSeparationEntry());

                entry.Add(new ResourceEntry(typeof(MythicWood), "Mythic Wood"));
                entry.Add(new ResourceEntry(typeof(LegendaryWood), "Legendary Wood"));
                entry.Add(new ResourceEntry(typeof(AncientWood), "Ancient Wood"));


                return entry;
            }
        }

        [Constructable]
        public SocketKey() : base(0x0)     // hue 33
        {
            ItemID = 0xFB4;            //hammer
            Name = "Socket Keys";
        }

        //this loads properties specific to the store, like the gump label, and whether it's a dynamic storage device
        protected override ItemStore GenerateItemStore()
        {
            //load the basic store info
            ItemStore store = base.GenerateItemStore();

            //properties of this storage device
            store.Label = "Socket Storage";

            store.Dynamic = false;
            store.OfferDeeds = false;
            return store;
        }

        //serial constructor
        public SocketKey(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (m_IsRewardItem)
            {
                list.Add(1076217); // 1st Year Veteran Reward
            }
        }

        //events

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);

            writer.Write(m_IsRewardItem);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            _ = reader.ReadInt();

            m_IsRewardItem = reader.ReadBool();
        }
    }
}
