using System; 
using Server.Network;
using Server.Engines.VeteranRewards;

namespace Server.Items 
{
    public class UnBlessBag : Container, IRewardItem
   	{
        private bool m_IsRewardItem;
        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsRewardItem
        {
            get { return m_IsRewardItem; }
            set { m_IsRewardItem = value; InvalidateProperties(); }
        }
      	public virtual int MaxHolding{ get{ return 5; } } 
      
	/*public override int DefaultGumpID{ get{ return 0x3C; } }
	public override int DefaultDropSound{ get{ return 0x48; } }
	public override Rectangle2D Bounds 
      	{ 
         get{ return new Rectangle2D( 44, 65, 142, 94 ); } 
      	}*/

   [Constructable]
      public UnBlessBag() : base( 0xE76 )
      { 
	 Name = "An Unblessing Bag";
         Weight = 0.0; 
         LootType = LootType.Blessed;
	 Hue = 0x313;
      } 

      public UnBlessBag( Serial serial ) : base( serial )
      { 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 
         writer.Write((bool)m_IsRewardItem);
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt();
         m_IsRewardItem = reader.ReadBool();
      } 

      public override bool OnDragDrop( Mobile from, Item dropped ) 
      {
          if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
          {
              from.SendMessage("This does not belong to you!!");
              return false;
          }
        if ( !base.OnDragDrop( from, dropped ) )
		return false;
		dropped.LootType = LootType.Regular;
		from.SendMessage("The item becomes UnBlessed");
         //LootType = LootType.Blessed;

		return true;
      } 

      public override bool OnDragDropInto( Mobile from, Item item, Point3D p ) 
      {
          if (m_IsRewardItem && !RewardSystem.CheckIsUsableBy(from, this, null))
          {
              from.SendMessage("This does not belong to you!!");
              return false;
          }
         if ( !base.OnDragDropInto( from, item, p ) )
		return false;
		item.LootType = LootType.Regular;
		from.SendMessage("Thee item becomes UnBlessed");
		return true;
      } 

      //public override void OnItemRemoved(Mobile from, Item item ) 
      //{ 
		//base.OnItemRemoved( item );
			//PublicOverheadMessage( Network.MessageType.Regular, 0x3B2, Utility.Random( 1042891, 8 ) );
			//PublicOverheadMessage( "Thank You!! Come Again." );
		//from.SendMessage("Thank You! Come Again.");
     // } 

   } 
}
