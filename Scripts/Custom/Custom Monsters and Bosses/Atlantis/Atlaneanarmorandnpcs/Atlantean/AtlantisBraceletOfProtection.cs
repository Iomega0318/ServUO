//Created by \\Rev//
using System;
using Server;
using Server.Items;
namespace Server.Items
{
              
              public class AtlantisBraceletOfProtection : GoldBracelet
              {
              public override int ArtifactRarity{ get{ return 80; } }
              
                      [Constructable]
              public AtlantisBraceletOfProtection()
{

                          Weight = 3;
                          Name = "Atlantis Bracelet Of Protection";
                          Hue = 2960;
              
              Attributes.AttackChance = 8;
              Attributes.BonusInt = 8;
              Attributes.BonusMana = 5;
              Attributes.CastRecovery = 2;
              Attributes.CastSpeed = 1;
              Attributes.LowerManaCost = 10;
              Attributes.LowerRegCost = 15;
			  		
			
               
                  }
              public AtlantisBraceletOfProtection( Serial serial ) : base( serial )
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
