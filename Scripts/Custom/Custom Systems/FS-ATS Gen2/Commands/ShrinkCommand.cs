using System;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Items;

namespace Server.Commands
{
    public class ShrinkCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Shrink", AccessLevel.GameMaster, new CommandEventHandler(Shrink_OnCommand));
        }

        [Usage("Shrink")]
        [Description("Shrinks a creature.")]
        private static void Shrink_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                e.Mobile.Target = new ShrinkTarget(true);
                e.Mobile.SendMessage("What would you like to Shrink?");
            }
        }
        public class ShrinkTarget : Target
        {
            private bool m_StaffCommand;

            public ShrinkTarget(bool staffCommand) : base(-1, true, TargetFlags.None)
            {
                m_StaffCommand = staffCommand;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                BaseCreature pet = o as BaseCreature;

                if (o == from)
                    from.SendMessage("You cannot shrink yourself!");

                else if (o is Item)
                    from.SendMessage("You cannot shrink that!");

                else if (o is PlayerMobile)
                    from.SendMessage("That person gives you a dirty look!");

                else if (Server.Spells.SpellHelper.CheckCombat(from))
                    from.SendMessage("You cannot shrink your pet while you are fighting.");

                else if (null == pet)
                    from.SendMessage("That is not a pet!");

                else if ((pet.BodyValue == 400 || pet.BodyValue == 401) && pet.Controlled == false)
                    from.SendMessage("That person gives you a dirty look!");

                else if (pet.IsDeadPet)
                    from.SendMessage("You cannot shrink the dead!");

                else if (pet.Summoned)
                    from.SendMessage("You cannot shrink a summoned creature!");

                else if (!m_StaffCommand && pet.Combatant != null && pet.InRange(pet.Combatant, 12) && pet.Map == pet.Combatant.Map)
                    from.SendMessage("Your pet is fighting; you cannot shrink it yet.");

                else if (pet.BodyMod != 0)
                    from.SendMessage("You cannot shrink your pet while it is polymorphed.");

                else if (!m_StaffCommand && pet.Controlled == false)
                    from.SendMessage("You cannot not shrink wild creatures.");

                else if (!m_StaffCommand && pet.ControlMaster != from)
                    from.SendMessage("That is not your pet.");

                /*else if (!m_StaffCommand && ShrinkItem.IsPackAnimal(pet) && (null != pet.Backpack && pet.Backpack.Items.Count > 0))
                    from.SendMessage("You must unload this pet's pack before it can be shrunk.");*/

                /*else if ( o is RoninsBaseCreature && ( (RoninsBaseCreature)o).Pregnant == true )
					from.SendMessage( 53, "Warning! Shrinking a pet while pregnant could cause a server crash." );

				else if ( o is RoninsBaseCreature && ( (RoninsBaseCreature)o).IsMating == true )
					from.SendMessage( 53, "Warning! Shrinking a pet while mating could cause a server crash." );*/

                else if (o is BaseCreature)
                {
                    BaseCreature c = (BaseCreature)o;
                    Type type = c.GetType();
                    ShrinkItem si = new ShrinkItem();
                    si.MobType = type;
                    si.Pet = c;
                    si.PetOwner = from;


                    if (c is BaseMount)
                    {
                        BaseMount mount = (BaseMount)c;
                        si.MountID = mount.ItemID;
                    }
                    from.AddToBackpack(si);

                    c.Controlled = true;
                    c.ControlMaster = null;
                    c.Internalize();

                    c.OwnerAbandonTime = DateTime.MinValue;

                    c.IsStabled = true;
                }
                else
                    from.SendMessage("You cannot shrink that, MOBILES ONLY");
            }
        }
    }
}
