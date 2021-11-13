using System;
using System.Collections.Generic;
using Server.Items;
using Server.Flying;

namespace Server.Mobiles.Flying.Player
{
    public class FlyingTimer : Timer
    {
        private const int flyTime = 300;

        private readonly PlayerMobile mobile;
        private static int RugPicked;
        
        private static bool HasTakingOff = false;
        private static int Ground { get; set; }
        private static string LastDirection = "";
        private static int flyCnt = 0;

        public FlyingTimer(PlayerMobile pm) : base(TimeSpan.FromMilliseconds(flyTime))
        {
            mobile = pm;
        }

        public FlyingTimer(PlayerMobile pm, int rugType) : base(TimeSpan.FromMilliseconds(flyTime))
        {
            mobile = pm;
            RugPicked = rugType;
        }

        private static bool NullCheck(PlayerMobile player)
        {
            if (player == null)
                return true;
            else if (!player.Alive)
                return true;
            else if (player.Deleted)
                return true;
            else
                return false;
        }

        private static void SpawnShadow(PlayerMobile player)
        {
            if (NullCheck(player))
                return;

            Item ft = player.Backpack.FindItemByType(typeof(FlightTotem));
            FlightTotem flyTot = ft as FlightTotem;

            Item fd = player.Backpack.FindItemByType(typeof(MagicFlyingDevice));
            MagicFlyingDevice flyDev = fd as MagicFlyingDevice;

            Item fr = player.Backpack.FindItemByType(typeof(MagicFlyingRug));
            MagicFlyingRug flyRug = fr as MagicFlyingRug;

            bool IsDevice = false;
            if (flyDev != null && flyDev.Name == "Magic Flying Device-Active")
            {
                IsDevice = true;
            }

            bool IsRug = false;
            if (flyRug != null && flyRug.Name == "Magic Flying Rug-Active")
            {
                IsRug = true;
            }

            if (IsDevice)
            {
                MagicFlyingDeviceShadow device = new MagicFlyingDeviceShadow(1281, player.Z, flyTime); 

                MagicFlyingDeviceShadow shadow = new MagicFlyingDeviceShadow(0x4001, Ground, flyTime); 

                FlyingLantern light = new FlyingLantern(1281, player.Z, flyTime); 

                Point3D loc;
                Point3D loc2;
                Point3D loc3;
                
                if (player.Z >= (Ground + 20))
                {
                    if (player.Direction == Direction.Mask
                    || player.Direction == Direction.Down
                    || player.Direction == Direction.Left
                    || player.Direction == Direction.Right
                    || player.Direction == Direction.North
                    || player.Direction == Direction.South
                    || player.Direction == Direction.East
                    || player.Direction == Direction.West)
                    {
                        if (flyTot.FlyHover == false)
                        {
                            int x = FlyingDirection.GetDirection($"{player.Direction}", out int getY);

                            loc = new Point3D((player.X + x), (player.Y + getY), (player.Z - 1));
                            loc2 = new Point3D((player.X + x), (player.Y + getY), Ground);
                            loc3 = new Point3D((player.X + x), (player.Y + getY), (player.Z - 2));
                        }
                        else
                        {
                            loc = new Point3D((player.X), (player.Y), (player.Z - 1));
                            loc2 = new Point3D((player.X), (player.Y ), Ground);
                            loc3 = new Point3D((player.X), (player.Y), (player.Z - 2));
                        }
                    }
                    else
                    {
                        if (flyTot.FlyHover == false)
                        {
                            int x = FlyingDirection.GetDirection($"{player.Direction}", out int getY);

                            loc = new Point3D((player.X + x), (player.Y + getY), player.Z);
                            loc2 = new Point3D((player.X + x), (player.Y + getY), Ground);
                            loc3 = new Point3D((player.X + x), (player.Y + getY), (player.Z - 1));
                        }
                        else
                        {
                            loc = new Point3D((player.X), (player.Y), (player.Z - 1));
                            loc2 = new Point3D((player.X), (player.Y), Ground);
                            loc3 = new Point3D((player.X), (player.Y), (player.Z - 2));
                        }
                    }
                }
                else
                {
                    if (flyTot.FlyHover == false)
                    {
                        loc = new Point3D(player.X, player.Y, (player.Z - 1));
                        loc2 = new Point3D(player.X, player.Y, Ground);
                        loc3 = new Point3D(player.X, player.Y, (player.Z - 2));
                    }
                    else
                    {
                        loc = new Point3D((player.X), (player.Y), (player.Z - 1));
                        loc2 = new Point3D((player.X), (player.Y), Ground);
                        loc3 = new Point3D((player.X), (player.Y), (player.Z - 2));
                    }
                }

                device.MoveToWorld(loc, player.Map);
                shadow.MoveToWorld(loc2, player.Map);
                light.MoveToWorld(loc3, player.Map);
            }
            else if (IsRug)
            {
                BaseAddon rug;
                BaseAddon shadow;
                int TimeUpdate = (flyTime);

                if (RugPicked == 1)
                {
                    rug = new FlyingBlueFancyRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingBlueFancyRug(0x4001, Ground, TimeUpdate);
                }
                else if (RugPicked == 2)
                {
                    rug = new FlyingBluePlainRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingBluePlainRug(0x4001, Ground, TimeUpdate);
                }
                else if (RugPicked == 3)
                {
                    rug = new FlyingBlueRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingBlueRug(0x4001, Ground, TimeUpdate);
                }
                else if (RugPicked == 4)
                {
                    rug = new FlyingCinnamonFancyRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingCinnamonFancyRug(0x4001, Ground, TimeUpdate);
                }
                else if (RugPicked == 5)
                {
                    rug = new FlyingGoldenDecorativeRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingGoldenDecorativeRug(0x4001, Ground, TimeUpdate);
                }
                else if (RugPicked == 6)
                {
                    rug = new FlyingPinkFancyRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingPinkFancyRug(0x4001, Ground, TimeUpdate);
                }
                else if (RugPicked == 7)
                {
                    rug = new FlyingRedPlainRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingRedPlainRug(0x4001, Ground, TimeUpdate);
                }
                else
                {
                    rug = new FlyingBlueFancyRug(0, player.Z, TimeUpdate);
                    shadow = new FlyingBlueFancyRug(0x4001, Ground, TimeUpdate);
                }

                Point3D loc;
                Point3D loc2;

                if (player.Z >= (Ground + 20))
                {
                    if (player.Direction == Direction.Mask
                    || player.Direction == Direction.Down
                    || player.Direction == Direction.Left
                    || player.Direction == Direction.Right
                    || player.Direction == Direction.North
                    || player.Direction == Direction.South
                    || player.Direction == Direction.East
                    || player.Direction == Direction.West)
                    {
                        if (flyTot.FlyHover == false)
                        {
                            int x = FlyingDirection.GetDirection($"{player.Direction}", out int getY);

                            loc = new Point3D((player.X + x), (player.Y + getY), (player.Z - 1));
                            loc2 = new Point3D((player.X + x), (player.Y + getY), Ground);
                        }
                        else
                        {
                            loc = new Point3D((player.X), (player.Y), (player.Z - 1));
                            loc2 = new Point3D((player.X), (player.Y), Ground);
                        }
                    }
                    else
                    {
                        if (flyTot.FlyHover == false)
                        {
                            int x = FlyingDirection.GetDirection($"{player.Direction}", out int getY);

                            loc = new Point3D((player.X + x), (player.Y + getY), player.Z);
                            loc2 = new Point3D((player.X + x), (player.Y + getY), Ground);
                        }
                        else
                        {
                            loc = new Point3D((player.X), (player.Y), (player.Z - 1));
                            loc2 = new Point3D((player.X), (player.Y), Ground);
                        }
                    }
                }
                else
                {
                    if (flyTot.FlyHover == false)
                    {
                        loc = new Point3D(player.X, player.Y, (player.Z - 1));
                        loc2 = new Point3D(player.X, player.Y, Ground);
                    }
                    else
                    {
                        loc = new Point3D((player.X), (player.Y), (player.Z - 1));
                        loc2 = new Point3D((player.X), (player.Y), Ground);
                    }
                }

                rug.MoveToWorld(loc, player.Map);
                shadow.MoveToWorld(loc2, player.Map);
            }
            else if (player.Z > (Ground + 20))
            {
                int getBody = 0;

                if (player.Mount is FlyingHiryu)
                {
                    getBody = 243;
                }

                FlyingPlayerShadow shadow = new FlyingPlayerShadow(getBody, player.Direction, Ground, flyTime);

                Point3D loc = new Point3D(player.X, player.Y, Ground);

                shadow.MoveToWorld(loc, player.Map);
            }
            else
            {
                FlyingPlayerShadow shadow = new FlyingPlayerShadow(51, player.Direction, Ground, flyTime);

                Point3D loc = new Point3D(player.X, player.Y, Ground);

                shadow.MoveToWorld(loc, player.Map);
            }
        }

        private static void AnimateFlying(PlayerMobile pm)
        {
            pm.Animate(24, 9, 1, true, true, 0); 
        }

        protected override void OnTick()
        {
            //Map Checks
            FlyingMap.CheckMap(mobile);

            //Landtile checks
            Ground = FlyingTileCheck.CheckLandTile(mobile, Ground);
            Ground = FlyingTileCheck.CheckStaticLandTile(mobile, Ground);
            FlyingTileCheck.CheckAheadStaticTile(mobile);

            //Flying Item Checks
            Item ft = mobile.Backpack.FindItemByType(typeof(FlightTotem));
            FlightTotem flyTot = ft as FlightTotem;

            Item fd = mobile.Backpack.FindItemByType(typeof(MagicFlyingDevice));
            MagicFlyingDevice flyDev = fd as MagicFlyingDevice;

            Item fr = mobile.Backpack.FindItemByType(typeof(MagicFlyingRug));
            MagicFlyingRug flyRug = fr as MagicFlyingRug;

            if (!FlyingTileCheck.CheckAbove(mobile))
            {
                if (flyDev != null && flyDev.Name == "Magic Flying Device-Active")
                {
                    if (flyCnt == 0 && mobile.Z > (Ground + 2))
                    {
                        mobile.PlaySound(0x102);
                        flyCnt = 3;
                    }
                    else if (flyCnt > 0)
                    {
                        flyCnt--;
                    }
                }
                else if (flyRug != null && flyRug.Name == "Magic Flying Rug-Active")
                {
                    if (flyCnt == 0 && mobile.Z > (Ground + 2))
                    {
                        mobile.PlaySound(0x016);
                        flyCnt = 3;
                    }
                    else if (flyCnt > 0)
                    {
                        flyCnt--;
                    }
                }
                else
                { 
                    if (flyCnt == 0 && mobile.Z > (Ground + 2))
                    {
                        mobile.PlaySound(0x2D0);
                        AnimateFlying(mobile);
                        flyCnt = 2;
                    }
                    else if (flyCnt > 0)
                    {
                        flyCnt--;
                    }
                }

                string direction = $"{mobile.Direction}";

                if (Ground < mobile.Z)
                    SpawnShadow(mobile);

                if (mobile.Z < 100)
                {
                    if (mobile.Z < (Ground + 20))
                    {
                        if (mobile.Direction == Direction.Mask
                            || mobile.Direction == Direction.Down
                            || mobile.Direction == Direction.Left
                            || mobile.Direction == Direction.Right
                            || mobile.Direction == Direction.North
                            || mobile.Direction == Direction.South
                            || mobile.Direction == Direction.East
                            || mobile.Direction == Direction.West)
                        {
                            if (mobile.Z > Ground && HasTakingOff)
                            {
                                mobile.Z--;

                                Start();
                            }
                            else if (mobile.Z == Ground && HasTakingOff)
                            {
                                mobile.SendMessage(38, $"You have landed on the ground!");

                                HasTakingOff = false;
                                mobile.Flying = false;
                                mobile.CantWalk = false;

                                if (flyDev != null && flyDev.Name == "Magic Flying Device-Active")
                                {
                                    mobile.Animate(AnimationType.Spell, 0);
                                    mobile.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Head);
                                    mobile.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);

                                    flyDev.Name = "Magic Flying Device";
                                    flyDev.Visible = true;
                                }
                                if (flyRug != null && flyRug.Name == "Magic Flying Rug-Active")
                                {
                                    mobile.Animate(AnimationType.Spell, 0);
                                    mobile.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Head);
                                    mobile.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);

                                    flyRug.Name = "Magic Flying Rug";
                                    flyRug.Visible = true;
                                }
                                flyTot.Delete();
                                Stop();
                            }
                            else
                            {
                                mobile.Flying = true;

                                if (mobile.Z == Ground)
                                    mobile.SendMessage(60, $"You are taking off the ground!");
                                
                                LastDirection = "Up";

                                mobile.Z++;

                                Start();
                            }
                        }
                        else
                        {
                            mobile.Flying = true;

                            if (mobile.Z == Ground)
                                mobile.SendMessage(60, $"You are taking off the ground!");

                            LastDirection = "Up";

                            mobile.Z++;

                            Start();
                        }
                    }
                    else
                    {
                        if (LastDirection == "Up")
                        {
                            if (LastDirection != "Up")
                            {
                                mobile.SendMessage(60, $"Heading away at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "Up";
                            mobile.Z++;
                        }
                        else
                        {
                            HasTakingOff = true;
                        }

                        //to go down
                        if (mobile.Direction == Direction.Mask)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.Mask}")
                            {
                                mobile.SendMessage(38, $"Heading Up at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "Mask";
                            
                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y--;
                                mobile.X--;
                            }
                        }
                        if (mobile.Direction == Direction.Down)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.Down}")
                            { 
                                mobile.SendMessage(38, $"Heading Down at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "Down";

                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y++;
                                mobile.X++;
                            }
                        }
                        if (mobile.Direction == Direction.Left)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.Left}")
                            { 
                                mobile.SendMessage(38, $"Heading Left at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "Left";

                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y++;
                                mobile.X--;
                            }
                        }
                        if (mobile.Direction == Direction.Right)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.Right}")
                            { 
                                mobile.SendMessage(38, $"Heading Right at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "Right";

                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y--;
                                mobile.X++;
                            }
                        }
                        if (mobile.Direction == Direction.North)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.North}")
                            {
                                mobile.SendMessage(38, $"Heading North at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "North";

                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y--;
                            }
                        }
                        if (mobile.Direction == Direction.South)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.South}")
                            { 
                                mobile.SendMessage(38, $"Heading South at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "South";

                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y++;
                            }
                        }
                        if (mobile.Direction == Direction.East)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.East}")
                            { 
                                mobile.SendMessage(38, $"Heading East at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "East";

                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.X++;
                            }
                        }
                        if (mobile.Direction == Direction.West)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.West}")
                            { 
                                mobile.SendMessage(38, $"Heading West at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "West";

                            if (flyTot.FlyLevel == false)
                                mobile.Z--;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.X--;
                            }
                        }

                        //to go up
                        if (mobile.Direction == Direction.ValueMask)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.ValueMask}")
                            { 
                                mobile.SendMessage(60, $"Heading Up at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "ValueMask";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y--;
                                mobile.X--;
                            }
                        }
                        if (direction == "131")
                        {
                            if (LastDirection != "131")
                            { 
                                mobile.SendMessage(60, $"Heading Down at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "131";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y++;
                                mobile.X++;
                            }
                        }
                        if (direction == "133")
                        {
                            if (LastDirection != "133")
                            { 
                                mobile.SendMessage(60, $"Heading Left at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "133";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y++;
                                mobile.X--;
                            }
                        }
                        if (direction == "129")
                        {
                            if (LastDirection != $"129")
                            { 
                                mobile.SendMessage(60, $"Heading Right at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "129";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y--;
                                mobile.X++;
                            }
                        }
                        if (mobile.Direction == Direction.Running)
                        {
                            if (LastDirection != $"{mobile.Direction = Direction.Running}")
                            { 
                                mobile.SendMessage(60, $"Heading North at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "Running";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y--;
                            }
                        }
                        if (direction == "132")
                        {
                            if (LastDirection != "132")
                            { 
                                mobile.SendMessage(60, $"Heading South at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "132";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.Y++;
                            }
                        }
                        if (direction == "130")
                        {
                            if (LastDirection != "130")
                            { 
                                mobile.SendMessage(60, $"Heading East at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "130";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.X++;
                            }
                        }
                        if (direction == "134")
                        {
                            if (LastDirection != "134")
                            { 
                                mobile.SendMessage(60, $"Heading West at {mobile.Z} ft");
                                mobile.Animate(AnimationType.Spell, 0);
                            }

                            LastDirection = "134";

                            if (flyTot.FlyLevel == false)
                                mobile.Z++;

                            if (flyTot.FlyHover == false)
                            {
                                mobile.X--;
                            }
                        }
                        Start();
                    }
                }
                else
                {
                    mobile.Direction = FlyingDirection.ChangeAltitudeDown(direction);

                    mobile.Say("I'm on top of the World!");
                    mobile.Z--;

                    Start();
                }
            }
            else if (mobile.Z > Ground)
            {
                mobile.Z--;

                Start();
            }
            else if (mobile.Z == Ground)
            {
                mobile.SendMessage(38, $"You have landed on the ground!");

                HasTakingOff = false;
                mobile.Flying = false;
                mobile.CantWalk = false;

                if (flyDev != null && flyDev.Name == "Magic Flying Device-Active")
                {
                    mobile.Animate(AnimationType.Spell, 0);
                    mobile.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Head);
                    mobile.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);

                    flyDev.Name = "Magic Flying Device";
                    flyDev.Visible = true;
                }
                if (flyRug != null && flyRug.Name == "Magic Flying Rug-Active")
                {
                    mobile.Animate(AnimationType.Spell, 0);
                    mobile.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Head);
                    mobile.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);

                    flyRug.Name = "Magic Flying Rug";
                    flyRug.Visible = true;
                }
                flyTot.Delete();
                Stop();
            }
            else
            {
                HasTakingOff = false;
                mobile.Flying = false;
                mobile.CantWalk = false;

                flyTot.Delete();
                Stop();
            }
        }
    }
}
