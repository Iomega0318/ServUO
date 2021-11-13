//Created by \\Rev//
using System;
using Server;
using Server.Items;
namespace Server.Items
{
              
              public class PearlRingOfAtlantis : GoldRing
              {
              public override int ArtifactRarity{ get{ return 80; } }
              
                      [Constructable]
              public PearlRingOfAtlantis()
{

                          Weight = 1;
                          Name = "Pearl Ring Of Atlantis";
                          Hue = 1153;
              
              Attributes.AttackChance = 4;
              Attributes.BonusInt = 5;
              Attributes.BonusMana = 4;
              Attributes.CastRecovery = 2;
              Attributes.CastSpeed = 1;
              Attributes.LowerManaCost = 10;
              Attributes.LowerRegCost = 15;
               
                  }
              public PearlRingOfAtlantis( Serial serial ) : base( serial )
                      {
                      }
              
              public override void Serialize( GenericWriter writer )
                      {
                          base.Serialize( writer );
                          writer.Write( (int) 0 );
                      }
              
              public override void Deserialize(GenericReader reader)
                      {
                          base.Deserialize( reader );
                          int version = reader.ReadInt();
                      }
                  }
              }
