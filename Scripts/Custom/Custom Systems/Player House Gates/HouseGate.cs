#region References
using System;
using System.Collections.Generic;
using System.Linq;

using Server.Accounting;
using Server.ContextMenus;
using Server.Multis;

using VitaNex.SuperGumps.UI;
#endregion

namespace Server.Items
{
	public class HouseGate : Moongate
	{
		public static List<HouseGate> Instances { get; private set; }

		static HouseGate()
		{
			Instances = new List<HouseGate>();
		}

		public static int CountGatesFor(Mobile m)
		{
			return CountGatesFor(m.Account);
		}

		public static int CountGatesFor(IAccount a)
		{
			return Instances.Count(g => g._House != null && g._House.Owner != null && g._House.Owner.Account == a);
		}

		private BaseHouse _House;

		[CommandProperty(AccessLevel.Counselor, true)]
		public BaseHouse House
		{
			get
			{
				if (_House != null && _House.Deleted)
				{
					_House = null;

					Timer.DelayCall(Delete);
				}

				return _House;
			}
			private set { _House = value; }
		}

		private HouseGateTile _Tile;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public HouseGateTile Tile
		{
			get { return _Tile; }
			set
			{
				if (_Tile == value)
				{
					return;
				}

				var old = _Tile;

				_Tile = value;

				if (old != null && old.Gate == this)
				{
					old.Gate = null;
				}

				if (_Tile != null && _Tile.Gate != this)
				{
					_Tile.Gate = this;
				}

				if (_Tile != null)
				{
					Target = _Tile.GetWorldLocation();
					TargetMap = _Tile.Map;

					Hue = _Tile.Hue;
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
		public override int Hue
		{
			get { return base.Hue; }
			set
			{
				base.Hue = value;

				if (_Tile != null && !_Tile.Deleted && _Tile.Gate == this && _Tile.Hue != value)
				{
					_Tile.Hue = value;
				}
			}
		}

		public override double DefaultWeight { get { return 0; } }

		public override string DefaultName
		{
			get
			{
				var h = House;

				if (h != null && h.Owner != null)
				{
					return h.Owner.Name;
				}

				return "House Gate";
			}
		}

		public override bool ForceShowProperties { get { return true; } }

		public override bool ShowFeluccaWarning { get { return false; } }

		public HouseGate(BaseHouse house)
			: base(false)
		{
			_House = house;

			ItemID = 3948;

			Movable = false;
			Light = LightType.Circle300;

			Instances.Add(this);
		}

		public HouseGate(Serial serial)
			: base(serial)
		{
			Instances.Add(this);
		}

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
			if (this.CheckDoubleClick(m))
			{
				CheckGate(m, 18);
			}
		}

		public override void OnLocationChange(Point3D oldLocation)
		{
			base.OnLocationChange(oldLocation);

			if (Tile != null && !Tile.Deleted && Tile.Gate == this)
			{
				Tile.Target = GetWorldLocation();
			}
		}

		public override void OnMapChange()
		{
			base.OnMapChange();

			if (Tile != null && !Tile.Deleted && Tile.Gate == this)
			{
				Tile.TargetMap = Map;
			}
		}

		public override void OnDelete()
		{
			base.OnDelete();

			if (_Tile != null && _Tile.Gate == this)
			{
				_Tile.Hue = 0;
				_Tile.Name = null;
			}

			Tile = null;
			House = null;
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			Instances.Remove(this);
		}

		public override void GetContextMenuEntries(Mobile m, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(m, list);

			if (!IsOwner(m))
			{
				return;
			}

			// Movement: 1078235
			list.Add(new CustomContextEntry(1078235, BeginReposition));

			// Set Hue: 1151720
			list.Add(new CustomContextEntry(1151720, BeginRecolor));

			// Rename: 1111680
			list.Add(new CustomContextEntry(1111680, BeginRename));

			// Remove: 1011403
			list.Add(new CustomContextEntry(1011403, BeginRemove));
		}

		public bool IsOwner(Mobile m)
		{
			var h = House;

			if (!Deleted && h != null)
			{
				return h.IsOwner(m);
			}

			return false;
		}

		public void BeginRecolor(Mobile m)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			if (!m.HasItem<GateHueTicket>())
			{
				m.SendMessage(0x22, "A Gate Hue Ticket is required to recolor this gate.");

				return;
			}

			m.SendMessage(0x55, "Enter the new color for the gate (1-2999)...");
			m.BeginPrompt(EndRecolor, false);
		}

		private void EndRecolor(Mobile m, string color)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			int hue;

			if (!Int32.TryParse(color, out hue) || hue <= 0 || hue >= 3000)
			{
				m.SendMessage(0x22, "You must pick a color between 1 and 2999 inclusive.");

				BeginRecolor(m);

				return;
			}

			var ticket = m.FindItemByType<GateHueTicket>();

			if (ticket == null)
			{
				m.SendMessage(0x22, "A Gate Hue Ticket is required to recolor this gate.");

				return;
			}

			ticket.Consume();

			Hue = hue;

			m.SendMessage(0x55, "The color of the gate has been changed.");
		}

		public void BeginRename(Mobile m)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			m.SendMessage(0x55, "Enter a new name for the gate...");
			m.BeginPrompt(EndRename, false);
		}

		private void EndRename(Mobile m, string name)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			if (String.IsNullOrWhiteSpace(name))
			{
				name = null;
			}

			Name = name;

			if (_Tile != null && _Tile.Gate == this && _Tile.Name != Name)
			{
				_Tile.Name = Name;
			}

			m.SendMessage(0x55, "The name of the gate has been changed.");
		}

		public void BeginReposition(Mobile m)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			m.SendMessage(0x55, "Target a location to move the gate to...");
			m.BeginTarget<IPoint3D>(EndReposition, CancelReposition, -1, true);
		}

		private void EndReposition(Mobile m, IPoint3D p)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			if (_House == null || _House.Map == null || _House.Region == null)
			{
				return;
			}

			var o = p.GetWorldTop(_House.Map);

			var area = _House.Region.Area.Highest(b => b.End.Y);

			var bounds = new Rectangle2D(area.Start.X, area.End.Y, area.Width, 5);

			if (!bounds.Contains(o))
			{
				m.SendMessage(0x22, "The gate can only be moved within 5 tiles of the front of your house.");

				BeginReposition(m);

				return;
			}

			if (!_House.Map.CanFit(o, 20, true, false))
			{
				m.SendMessage(0x22, "The gate would not fit there.");

				BeginReposition(m);

				return;
			}

			MoveToWorld(o, m.Map);
		}

		private void CancelReposition(Mobile m)
		{
			if (IsOwner(m))
			{
				m.SendMessage(0x22, "You decide not to place the gate.");
			}
		}

		public void BeginRemove(Mobile m)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			new ConfirmDialogGump(m)
			{
				Title = "Remove House Gate?",
				Html =
					"Are you sure you wish to remove this house gate?\n" +
					"This action can not be undone!\n\nClick OK to remove the gate...",
				AcceptHandler = b => EndRemove(m),
				CancelHandler = b => CancelRemove(m)
			}.Send();
		}

		private void EndRemove(Mobile m)
		{
			if (!IsOwner(m))
			{
				m.SendMessage("You do not own this gate.");

				return;
			}

			m.SendMessage(0x22, "You remove the gate.");

			Delete();
		}

		private void CancelRemove(Mobile m)
		{
			if (IsOwner(m))
			{
				m.SendMessage(0x22, "You decide not to remove the gate.");
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.SetVersion(0);

			writer.Write(_House);
			writer.Write(_Tile);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.GetVersion();

			_House = reader.ReadItem<BaseHouse>();
			_Tile = reader.ReadItem<HouseGateTile>();
		}
	}
}