using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of a Fire Demon" )]
              public class FireDemon : Daemon
              {
                                 [Constructable]
                                    public FireDemon() : base()
                            {
                                               Name = "A Fire Demon";
                                               Hue = 1174;
                                               Body = 9; 
                                               BaseSoundID = 357; 
                                               SetStr( 98 );
                                               SetDex( 111 );
                                               SetInt( 87 );
                                               SetHits( 400, 550 );
                                               SetDamage( 15, 25 );
                                               SetDamageType( ResistanceType.Physical, 5 );
                                               SetDamageType( ResistanceType.Cold, 5 );
                                               SetDamageType( ResistanceType.Fire, 80 );
                                               SetDamageType( ResistanceType.Energy, 5 );
                                               SetDamageType( ResistanceType.Poison, 5 );

                                               SetResistance( ResistanceType.Physical, 25 );
                                               SetResistance( ResistanceType.Cold, 25 );
                                               SetResistance( ResistanceType.Fire, 100 );
                                               SetResistance( ResistanceType.Energy, 25 );
                                               SetResistance( ResistanceType.Poison, 25 );
                                               Tamable = true;
					                           Fame = 1000;
                                               Karma = -1500;
                                               VirtualArmor = 45;
     
                                               PackGold( 1000, 1150 );
                                               
                            }
                                 public override bool AutoDispel{ get{ return true; } }

public FireDemon( Serial serial ) : base( serial )
                      {
                      }

public override void Serialize( GenericWriter writer )
                      {
                                        base.Serialize( writer );
                                        writer.Write( (int) 0 );
                      }

        public override void Deserialize( GenericReader reader )
                      {
                                        base.Deserialize( reader );
                                        int version = reader.ReadInt();
                      }
    }
}
