using System;
using Server.Items;
using Server.Flying;

namespace Server.Mobiles
{
    public abstract class BaseFlying : BaseCreature
    {
        private const int FlySpeed = 450;//shadow despawn, 450 milliseconds default (should not be changed)
        private static int Ground { get; set; }

        private static Direction LastDirection { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsLanding { get { return Landing; } set { Landing = value; } }
        private static bool Landing { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxFlyStam { get { return M_FlyStam; } set { M_FlyStam = value; } }
        private static int M_FlyStam { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int FlyStam { get { return F_Stam; } set { F_Stam = value; } }
        private static int F_Stam { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool FlyShadowOn { get { return F_Shadow; } set { F_Shadow = value; } }
        private static bool F_Shadow { get; set; }

        public BaseFlying(AIType aiType, FightMode fightMode, int rangePerception, int rangeFight, double activeSpeed, double passiveSpeed)
            : base(aiType, fightMode, rangePerception, rangeFight, activeSpeed, passiveSpeed)
        {
            Landing = false;
        }

        public BaseFlying(Serial serial) : base(serial)
        {
        }

        public static bool NullCheck(BaseFlying flyingcreature)
        {
            if (flyingcreature == null)
                return true;
            else if (!flyingcreature.Alive)
                return true;
            else if (flyingcreature.Deleted)
                return true;
            else
                return false;
        }

        public static void SpawnShadow(BaseFlying flyingcreature)
        {
            if (NullCheck(flyingcreature))
                return;

            if (flyingcreature.Z > (Ground + 20))
            {
                FlyingMobileShadow shadow = new FlyingMobileShadow(flyingcreature.Body, flyingcreature.Direction, Ground, FlySpeed); 

                Point3D loc = new Point3D(flyingcreature.X, flyingcreature.Y, Ground);

                shadow.MoveToWorld(loc, flyingcreature.Map);
            }
            else if (flyingcreature.FlyShadowOn)
            {
                FlyingMobileShadow shadow = new FlyingMobileShadow(51, flyingcreature.Direction, Ground, FlySpeed);

                Point3D loc = new Point3D(flyingcreature.X, flyingcreature.Y, Ground);

                shadow.MoveToWorld(loc, flyingcreature.Map);
            }
        }

        private static void BadLocationCleanup(BaseFlying flyingcreature)
        {
            LandTile landTile = flyingcreature.Map.Tiles.GetLandTile(flyingcreature.X, flyingcreature.Y);

            if (landTile.Z > (flyingcreature.Z + 5))
                flyingcreature.Delete();

            TileFlag lF = TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags;

            if ((lF & TileFlag.Impassable) != 0)
                flyingcreature.Delete();
        }

        public override void OnThink()
        {
	        if (Flying == true)
            {
                //Map Checks
                FlyingMap.CheckMap(this);

                //Landtile checks
                Ground = FlyingTileCheck.CheckLandTile(this, Ground);
                Ground = FlyingTileCheck.CheckStaticLandTile(this, Ground);

                //check above for objects
                if (FlyingTileCheck.CheckAbove(this))
                {
                    if (Flying)
                        Landing = true;
                    else
                        Flying = false;
                }

                if (Combatant != null)
                {
                    FlyStam = 0;
                }

                if (RangeHome > 49)  //Min distance allowed for flying creatures? Should it be larger!
                    FlyingRange(this);
            }
            else
            {
                BadLocationCleanup(this); //Clean up stuck creatures
            }

            if (FlyStam <= 0 && !Landing)
            {
                Landing = true;
            }
            else if (FlyStam == MaxFlyStam)
            {
                Flying = true;
            }

            if (Flying == true) 
            {
                CantWalk = true;
                Random rnd = new Random();
                int getRnd = rnd.Next(10);

                if (!Landing && FlyingTileCheck.CheckAheadStaticTile(this))
                {
                    FlyStam--;

                    if (Ground + 20 <= Z)
                    {
                        CanMove = true;

                        if (Z >= FlyingMap.Ceiling)
                        {
                            Z--;
                            //add rnd direction change
                        }
                        else if (getRnd < 5 && Z > (Ground + 35))
                        {
                            Z--;
                            //add rnd direction change
                        }
                        else
                        {
                            PlaySound(0x2D0);
                            Z++;
                        }

                        X = (X + FlyingDirection.GetDirection($"{Direction}", out int getY));
                        Y = (Y + getY);
                    }
                    else
                    {
                        if (Z == Ground)
                        {
                            LastDirection = Direction;
                        }

                        if (FlyingTileCheck.CheckAbove(this))
                        {
                            if (Ground < Z)
                            {
                                Direction = LastDirection;
                                CanMove = false;

                                Z--;
                            }
                            else
                            {
                                CanMove = true;

                                if (Flying)
                                    Landing = true;
                                else
                                    Flying = false;
                            }
                        }
                        else
                        {
                            Direction = LastDirection;
                            CanMove = false;

                            PlaySound(0x2D0);
                            Z++;
                        }
                    }
                    if (Ground < Z)
                        SpawnShadow(this);
                }
                else
                {
                    if (FlyingTileCheck.CheckAheadStaticTile(this))
                    {
                        if (Z > (Ground + 19))
                        {
                            LastDirection = Direction;
                        }

                        if (Ground < Z)
                        {
                            Direction = LastDirection;

                            CanMove = false;

                            Z--;
                        }
                        else
                        {
                            CanMove = true;
                            Landing = false;
                            Flying = false;
                        }
                    }
                    else
                    {
                        CanMove = false;
                        FlyStam += (MaxFlyStam / 2);
                        Landing = false;
                    }
                    if (Ground < Z)
                        SpawnShadow(this);
                }
            }
            else
            {
                CanMove = true;
                CantWalk = false;
                FlyStam++;
            }

            base.OnThink();
        }

        public static void FlyingRange(BaseFlying flyingcreature)
        {
            if (NullCheck(flyingcreature))
                return;

            int hx = flyingcreature.Home.X;
            int hy = flyingcreature.Home.Y;

            if ((hx + hy) == 0)
                return;

            int mx = flyingcreature.X;
            int my = flyingcreature.Y;

            int range = flyingcreature.RangeHome;

            if (hx > mx)
            {
                if ((hx - mx) >= range)
                    flyingcreature.Direction = FlyingDirection.ChangeDirection($"{flyingcreature.Direction}");
            }
            if (hx < mx)
            {
                if ((mx - hx) >= range)
                    flyingcreature.Direction = FlyingDirection.ChangeDirection($"{flyingcreature.Direction}");
            }
            if (hy > my)
            {
                if ((hy - my) >= range)
                    flyingcreature.Direction = FlyingDirection.ChangeDirection($"{flyingcreature.Direction}");
            }
            if (hy < my)
            {
                if ((my - hy) >= range)
                    flyingcreature.Direction = FlyingDirection.ChangeDirection($"{flyingcreature.Direction}");
            }
        }

        public override void AlterMeleeDamageFrom(Mobile from, ref int damage)
        {
            if (from.Weapon != null)
            {
                if (from.Weapon is BaseRanged)
                {
                    from.Animate(21, 6, 1, true, true, 0);

                    base.AlterMeleeDamageFrom(from, ref damage);
                }
                else if ((from.Z > this.Z + 10) || (from.Z < this.Z - 10))
                {
                    from.SendMessage($"You have to be closer to attack the {this.Name}!");
                    damage = 0;
                    base.AlterMeleeDamageFrom(from, ref damage);
                }
                else
                {
                    from.Animate(21, 6, 1, true, true, 0);

                    base.AlterMeleeDamageFrom(from, ref damage);
                }
            }
            else if ((from.Z > this.Z + 10) || (from.Z < this.Z - 10))
            {
                from.SendMessage($"You have to be closer to attack the {this.Name}!");
                damage = 0;
                base.AlterMeleeDamageFrom(from, ref damage);
            }
            else
            {
                from.Animate(21, 6, 1, true, true, 0);

                base.AlterMeleeDamageFrom(from, ref damage);
            }
        }

        public override void AlterMeleeDamageTo(Mobile from, ref int damage)
        {
            if (from.Weapon != null)
            {
                if (from.Weapon is BaseRanged)
                {
                    base.AlterMeleeDamageFrom(from, ref damage);
                }
                else if ((from.Z > this.Z + 10) || (from.Z < this.Z - 10))
                {
                    damage = 0;
                    base.AlterMeleeDamageFrom(from, ref damage);
                }
                else
                {
                    base.AlterMeleeDamageFrom(from, ref damage);
                }
            }
            else if ((from.Z > this.Z + 10) || (from.Z < this.Z - 10))
            {
                damage = 0;
                base.AlterMeleeDamageFrom(from, ref damage);
            }
            else
            {
                base.AlterMeleeDamageFrom(from, ref damage);
            }
        }

        public override bool OnBeforeDeath()
        {
            LandTile landTile = Map.Tiles.GetLandTile(X, Y);

            int cnt = 0;

            while (landTile.Z < Z)
            {
                cnt++;

                if (cnt >= 10) //Falling Delay
                {
                    Z--;

                    cnt = 0;
                }
            }
            Z = (landTile.Z);

            PlaySound(0x525);

            return base.OnBeforeDeath();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(M_FlyStam);
            writer.Write(F_Stam);
            writer.Write(F_Shadow);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            M_FlyStam = reader.ReadInt();
            F_Stam = reader.ReadInt();
            F_Shadow = reader.ReadBool();
        }
    }
}
