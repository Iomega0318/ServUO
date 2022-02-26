#region References
using System;

using Server.Gumps;
using Server.Mobiles;
using Server.Regions;

using VitaNex.SuperGumps.UI;
#endregion

namespace Server.Items
{
	public class HouseGateConfirm : ConfirmDialogGump
	{
		private const string _Info =
			"Your house gate has now been placed. " +
			"You can edit its settings by single-clicking the gate at your house and selecting an option from the menu. " +
			"To dye the gate, Have a Hue Room Tickets in your backpack, then select *set hue* in the settings.\n\n" +
			"IMPORTANT: You must make sure that the gate can be used from both sides by any player. " +
			"Placing obstacles that would trap players on any side of the gate is not allowed. " +
			"Any such gate will be removed without warning or refund.";

		private readonly HouseGateTile _Tile;

		public HouseGateConfirm(Mobile user, HouseGateTile tile)
			: base(user)
		{
			_Tile = tile;

			Title = "Place House Gate";

			Html =
				String.Format(
					"You are about to place a house gate at the cost of {0:#,0} gold. " +
					"Go to your house. Once you are in your house, click OK and the gate will be summoned!",
					_Tile.Price);

			Modal = false;

			CanMove = true;
			CanClose = true;
			CanDispose = true;
		}

		protected override void OnAccept(GumpButton button)
		{
			base.OnAccept(button);

			if (_Tile == null || _Tile.Deleted)
			{
				User.SendMessage(0x22, "The house teleporter you selected is no longer available.");

				return;
			}

			if (_Tile.Gate != null && !_Tile.Gate.Deleted && _Tile.Gate.House != null && !_Tile.Gate.House.Deleted)
			{
				User.SendMessage(0x22, "The house teleporter you selected is no longer available.");

				return;
			}

			if (HouseGate.CountGatesFor(User) > 0)
			{
				User.SendMessage(0x22, "You already own too many house gates.");

				return;
			}

			var hr = User.GetRegion<HouseRegion>();

			if (hr == null || hr.House == null)
			{
				User.SendMessage(0x22, "You must be in your house to place a gate.");

				return;
			}

			if (hr.House.Owner != User)
			{
				User.SendMessage(0x22, "You must be in a house that you own to place a gate.");

				return;
			}

			if (!Banker.Withdraw(User, _Tile.Price))
			{
				User.SendMessage(0x22, "You do not have the required gold to place a gate.");

				return;
			}

			new HouseGate(hr.House)
			{
				Tile = _Tile,
				Hue = Utility.RandomBrightHue()
			}.MoveToWorld(hr.House.BanLocation, hr.House.Map);

			new NoticeDialogGump(User)
			{
				Title = "House Gate Information",
				Html = _Info,
				Width = 600,
				Height = 400
			}.Send();
		}
	}
}
