#region Header
//   Vorspire    _,-'/-'/  ItemRelic.cs
//   .      __,-; ,'( '/
//    \.    `-.__`-._`:_,-._       _ , . ``
//     `:-._,------' ` _,`--` -: `_ , ` ,' :
//        `---..__,,--'  (C) 2016  ` -'. -'
//        #  Vita-Nex [http://core.vita-nex.com]  #
//  {o)xxx|===============-   #   -===============|xxx(o}
//        #        The MIT License (MIT)          #
#endregion

#region References
using System;

using Server.Gumps;
using Server.Mobiles;
#endregion

namespace Server.Items
{
	public class HouseGateTile : Moongate
	{
		private HouseGate _Gate;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public HouseGate Gate
		{
			get { return _Gate; }
			set
			{
				if (_Gate == value)
				{
					return;
				}

				var old = _Gate;

				_Gate = value;

				if (old != null && old.Tile == this)
				{
					old.Tile = null;
				}

				if (_Gate != null && _Gate.Tile != this)
				{
					_Gate.Tile = this;
				}

				if (_Gate != null)
				{
					Target = _Gate.GetWorldLocation();
					TargetMap = _Gate.Map;

					Hue = _Gate.Hue;
				}
				else
				{
					Target = Point3D.Zero;
					TargetMap = null;

					Hue = 0;
					Name = null;
				}
			}
		}

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int Price { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public override int Hue
		{
			get { return base.Hue; }
			set
			{
				base.Hue = value;

				if (_Gate != null && !_Gate.Deleted && _Gate.Tile == this && _Gate.Hue != value)
				{
					_Gate.Hue = value;
				}
			}
		}

		public virtual int DefaultPrice { get { return 200000; } }

		public override double DefaultWeight { get { return 0; } }

		public override string DefaultName
		{
			get
			{
				if (Gate == null || Gate.Deleted)
				{
					return "Vacant House Gate";
				}

				var h = Gate.House;

				if (h == null || h.Deleted)
				{
					return "Vacant House Gate";
				}

				if (h.Owner != null)
				{
					return h.Owner.Name;
				}

				return "House Gate";
			}
		}

		public override bool ForceShowProperties { get { return true; } }

		public override bool ShowFeluccaWarning { get { return false; } }

		[Constructable]
		public HouseGateTile()
			: base(false)
		{
			Price = DefaultPrice;

			ItemID = 6178;

			Movable = false;
			Light = LightType.Circle300;
		}

		public HouseGateTile(Serial serial)
			: base(serial)
		{ }

		public override bool ValidateUse(Mobile m, bool message)
		{
			return this.CheckDoubleClick(m, message);
		}

		public override void BeginConfirmation(Mobile m)
		{
			EndConfirmation(m);
		}

		public override void CheckGate(Mobile m, int range)
		{
			range = 18;

			base.CheckGate(m, range);
		}

		public override void OnDoubleClick(Mobile m)
		{
			if (!this.CheckDoubleClick(m))
			{
				return;
			}

			if (Gate != null && !Gate.Deleted && Gate.House != null && !Gate.House.Deleted)
			{
				CheckGate(m, 18);

				return;
			}

			if (HouseGate.CountGatesFor(m) > 0)
			{
				m.SendMessage(0x22, "You already own too many house gates.");

				return;
			}

			new HouseGateConfirm(m, this).Send();
		}

		public override void OnLocationChange(Point3D oldLocation)
		{
			base.OnLocationChange(oldLocation);

			if (Gate != null && !Gate.Deleted && Gate.Tile == this)
			{
				Gate.Target = GetWorldLocation();
			}
		}

		public override void OnMapChange()
		{
			base.OnMapChange();

			if (Gate != null && !Gate.Deleted && Gate.Tile == this)
			{
				Gate.TargetMap = Map;
			}
		}

		public override void OnDelete()
		{
			base.OnDelete();

			if (Gate != null)
			{
				Gate.Delete();
				Gate = null;
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.SetVersion(0);

			writer.Write(Price);

			writer.Write(_Gate);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.GetVersion();

			Price = reader.ReadInt();

			_Gate = reader.ReadItem<HouseGate>();
		}
	}
}