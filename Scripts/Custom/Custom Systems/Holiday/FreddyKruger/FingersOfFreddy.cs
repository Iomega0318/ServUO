
using System;
using Server;

namespace Server.Items

{
              
              public class FingersOfFreddy : Tekagi
              {
              
                      [Constructable]
                      public FingersOfFreddy() 
                      {
                                        Weight = 0;
                                        Name = "Fingers Of Freddy";
                                        Hue = 2117;
              
                                        WeaponAttributes.DurabilityBonus = 100;
                                       
                                       
                                        WeaponAttributes.HitLightning = 10;
                                        WeaponAttributes.SelfRepair = 50;
                                        WeaponAttributes.UseBestSkill = 1;
              
                                        Attributes.AttackChance = 5;
                                        Attributes.BonusDex = 1;
                                        Attributes.BonusHits = 3;
                                        Attributes.BonusInt = 2;
                                       Attributes.CastRecovery = 2;
                                        Attributes.CastSpeed = 3;
                                        Attributes.DefendChance = 4;
                                        Attributes.Luck = 50;
                                        Attributes.NightSight = 1;
                                       
                                        Attributes.SpellChanneling = 1;
                                        Attributes.WeaponDamage = 12;
                                        Attributes.WeaponSpeed = 10;
              
                                    }
              
                      public FingersOfFreddy( Serial serial ) : base( serial )  
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
