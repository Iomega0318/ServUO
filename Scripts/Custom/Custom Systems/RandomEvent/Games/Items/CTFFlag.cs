using Server.Mobiles;
using Server.OneTime;

namespace Server.RandomEvent
{
    class CTFFlag : Item, IGameItem, IOneTime
    {
        public int OneTimeType { get; set; }

        public PlayerMobile PM { get; set; }

        [Constructable]
        public CTFFlag() : base(0x166F)
        {
            Name = "CTF - Flag";
            
            Hue = 1177;

            OneTimeType = 3; //second : 3 = second, 4 = minute, 5 = hour, 6 = day (Pick a time interval 3-6)
        }

        public CTFFlag(Serial serial) : base(serial)
        {
        }

        private Point3D OldLocation;

        public void OneTimeTick()
        {
            if (RootParent != null)
            {
                Hue = 1177;

                if (RootParent is PlayerMobile pm)
                {
                    PM = pm;

                    if (PM.Alive && Map != Map.Internal && GameZones.CheckZone(PM, GameMain.GameRegion))
                    {
                        bool FlagEffect = Utility.RandomBool();

                        if (FlagEffect)
                        {
                            PM.FixedParticles(0x37C4, 3, 8, 0, 1176, 0, EffectLayer.Waist); //ItemID (Start), Speed (delay between frames), Number of Frames, Effect = 0, hue, render = 0, layer
                        }

                        OldLocation = new Point3D(PM.X, PM.Y, PM.Z);
                    }
                    else
                    {
                        ReturnFlag();
                    }
                }
                else if (PM != null)
                {
                    ReturnFlag();
                }
            }
            else
            {
                PM = null;

                if (Hue == 1177)
                    Hue = 1175;
                else
                    Hue = 1177;
            }
        }

        public void ReturnFlag()
        {
            PM = null;

            CTFFlag flag = new CTFFlag();

            GameMain.GameItem = flag;

            flag.MoveToWorld(GameMain.GameItemSpawnPoint, GameMain.GameMap);

            Delete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(PM as Mobile);

            writer.Write(OneTimeType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            PM = reader.ReadMobile() as PlayerMobile;

            OneTimeType = reader.ReadInt();
        }
    }
}
