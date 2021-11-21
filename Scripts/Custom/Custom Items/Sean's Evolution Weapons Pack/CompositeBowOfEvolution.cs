/*
 created by:
     /\       
____/_ \____  ### ### ### ### #  ### ### # ##  ##  ###
\  ___\ \  /  #   #   # # # # #  # # # # # # # # # #
 \/ /  \/ /   ### ##  ### # # #  ### # # # # # ##  ##
 / /\__/_/\     # #   # # # # #  # # # # # # # # # #
/__\ \_____\  ### ### # # # ###  # # # ### ##  # # ###
    \  /             http://www.wftpradio.net/
     \/       
*/
using System;
using Server;

namespace Server.Items
{
	public class CompositeBowOfEvolution : CompositeBow
	{
                
		public override int EffectID{ get{ return 0xF42; } }
		//--<< AA Edit >>-------------------------[start 1/1]
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }		
		//public override Type AmmoType { get { return GetArrowSelected(); } }
		//public override Item Ammo { get { return AmmoArrowSelected(); } }
		//--<< AA Edit >>-------------------------[end 1/1]	

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ArmorIgnore; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }

		private int mEvolutionPoints = 0;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int EvolutionPoints { get { return mEvolutionPoints; } set { mEvolutionPoints = value; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public CompositeBowOfEvolution()
		{	Name = "Composite Bow Of Evolution";
			Hue = 0x4F2;
			WeaponAttributes.UseBestSkill = 1;

            Attributes.Luck = 100;
            WeaponAttributes.SelfRepair = 100;

            Attributes.WeaponDamage = 1;
            Attributes.WeaponSpeed = 10;
            Attributes.SpellChanneling = 1;
        }

        public CompositeBowOfEvolution(Serial serial)
            : base(serial)
        {
        }
        public override void OnHit(Mobile attacker, IDamageable defender, double Damagebonus)
        {
            if (Utility.Random(2) == 1)
            {
                ApplyGain();
            }

            base.OnHit(attacker, defender, Damagebonus);
        }

        public void ApplyGain()
        {
            int expr;
            if (mEvolutionPoints < 10001)
            {
                mEvolutionPoints++;
                this.Name = "Composite Bow Of Evolution (" + mEvolutionPoints.ToString() + ")";

                if ((mEvolutionPoints / 100) > 0)
                {
                    expr = mEvolutionPoints / 100;

                    this.WeaponAttributes.HitHarm = expr;
                    this.WeaponAttributes.HitMagicArrow = expr;
                }

                if ((mEvolutionPoints / 200) > 0)
                {
                    expr = mEvolutionPoints / 100;

                    this.WeaponAttributes.HitLightning = expr;
                    this.WeaponAttributes.HitFireball = expr;
                    this.Attributes.WeaponDamage = expr;
                }

                if ((25 + (mEvolutionPoints / 200)) > 0) this.Attributes.WeaponSpeed = (25 + (mEvolutionPoints / 200));

                if ((mEvolutionPoints / 2000) > 0)
                {
                    expr = mEvolutionPoints / 2000;

                    this.Attributes.CastRecovery = expr;
                    this.Attributes.CastSpeed = expr;
                }
                InvalidateProperties();


            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
            writer.Write(mEvolutionPoints);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            mEvolutionPoints = reader.ReadInt();
        }
    }
}