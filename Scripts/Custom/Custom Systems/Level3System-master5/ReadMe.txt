

///////////////////Distro Edits in PlayerMobile.cs ////////////////////

Under
		public override void GetProperties( ObjectPropertyList list )
		{
		
Add
            #region Player Level system
            Configured cf = new Configured();
            XMLPlayerLevelAtt xmlplayer = (XMLPlayerLevelAtt)XmlAttach.FindAttachment(this, typeof(XMLPlayerLevelAtt));
            if (cf.LevelBelowToon && xmlplayer != null)
            {
                string d = LevelCore.Display(this, new Configured());
                list.Add("<BASEFONT COLOR=#7FCAE7>Level: <BASEFONT COLOR=#17FF01>" + d);
            }
            #endregion
			

/////////////////Distro Edits in BaseCreature.cs ////////////////////////////

Under
		public override string ApplyNameSuffix( string suffix )
		{
			
			
Add
			#region Level System
			Configured c = new Configured();
			XMLPetLevelAtt petxml2 = (XMLPetLevelAtt)XmlAttach.FindAttachment(this, typeof(XMLPetLevelAtt));
			int cl = LevelCore.CreatureLevel(this, new Configured());
			if (c.CreatureLevels && petxml2 == null)
			{
					if (cl > 0)
					{
							if (suffix.Length == 0)
								suffix = String.Concat(suffix, "(level " + cl + ")");
							else
								suffix = String.Concat(suffix, " (level " + cl + ")");
					}
			}
			#endregion
			
Just after public override string ApplyNameSuffix Sectoin, Add the getprops section.
If you happen to already have a getprops, merge this edit, otherwise its not in the normal distro so it won't typically exist.

		#region Player Level system - BaseCreature Expansion
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);	
            ConfiguredPetXML cp2 = new ConfiguredPetXML();
            XMLPetLevelAtt petxml = (XMLPetLevelAtt)XmlAttach.FindAttachment(this, typeof(XMLPetLevelAtt));
            if (cp2.LevelBelowPet)
			{
				if (petxml != null)
				{
					int petlevelint = LevelCore.PetLevelXML(this, new Configured());
					list.Add("<BASEFONT COLOR=#7FCAE7>Level: <BASEFONT COLOR=#17FF01>" + petlevelint);
				}
			}
			
		}
		#endregion
			




Update ExpTables.cs Based on Shard. Default Tables may not be complete for all creatures. 
Update Configuration.cs 

				
				
/////////////////////Craftitem.cs ///////////////////////////////
Locate the Section: 

{
from.AddToBackpack
}

Below that Section, add the below 

                   #region Level System
                    PlayerMobile pm = from as PlayerMobile;
                    Configured c = new Configured();

                    double ch = GetSuccessChance(pm, typeRes, craftSystem, false, ref allRequiredSkills);
                    double ex = GetExceptionalChance(craftSystem, ch, pm);

                    LevelCore.Craft(item, quality, ch, ex, pm, new Configured());
                    #endregion
					
//////////////////////// Titles.cs /////////////////////////
Add the Service to top of file
using Server.Engines.XmlSpawner2;

Locate this Section: Should be around Line Number 277

            if (Core.SA)
            {
                if (beheld is PlayerMobile && ((PlayerMobile)beheld).PaperdollSkillTitle != null)
                    title.Append(", ").Append(((PlayerMobile)beheld).PaperdollSkillTitle);
                else if (beheld is BaseVendor)
                    title.AppendFormat(" {0}", customTitle);
            }
			
Replace with this
			
            if (Core.SA)
            {
                #region Level System
                PlayerMobile pm = beheld as PlayerMobile;
                XMLPlayerLevelAtt xmlplayer = (XMLPlayerLevelAtt)XmlAttach.FindAttachment(pm, typeof(XMLPlayerLevelAtt));
                Configured c = new Configured();
             
                if (beheld is PlayerMobile && ((PlayerMobile)beheld).PaperdollSkillTitle != null)
                {
                    if (c.PaperdollLevel)
                    {
                        string d = LevelCore.Display(pm, new Configured());
                        title.Append(" - Level " + d + ", ").Append(((PlayerMobile)beheld).PaperdollSkillTitle);
                    }
                    else
                        title.Append(", ").Append(((PlayerMobile)beheld).PaperdollSkillTitle);
                }
                else if (beheld is PlayerMobile && ((PlayerMobile)beheld).PaperdollSkillTitle == null)
                {
                    string d = LevelCore.Display(pm, new Configured());
                    if (c.PaperdollLevel)
                    {
                        if (pm.AccessLevel > AccessLevel.Player && c.StaffHasLevel)
                        {
                            title.Append(" - Level " + d);
                        }
                        else
                        {
                            if (pm.AccessLevel < AccessLevel.GameMaster)
                            {
                                title.Append(" - Level " + d);
                            }
                        }
                     
                    }
                }
 
                else if (beheld is BaseVendor)
                    title.AppendFormat(" {0}", customTitle);
             
             
                /*
                if (beheld is PlayerMobile && ((PlayerMobile)beheld).PaperdollSkillTitle != null)
                    title.Append(", ").Append(((PlayerMobile)beheld).PaperdollSkillTitle);
                else if (beheld is BaseVendor)
                    title.AppendFormat(" {0}", customTitle);
                */
                #endregion
            }
			
/////////////SkillCheck.cs Edits/////////////////
/* This is required for the disable built in skill mechanics and EXP Gain from Skill Usage*/
Locate the below section(s)

Should be 4 sections in total we needed to locate.  

Locate 
public static bool Mobile_SkillCheckLocation

Before the line
var loc = new Point2D add the below

			#region Level System Skills
			LevelHandler.DoGainSkillExp(from, skill, skillName);
			#endregion
			
Locate
public static bool Mobile_SkillCheckDirectLocation

After the line
var skill = from.Skills[skillName]; add the below

			#region Level System Skills
			LevelHandler.DoGainSkillExp(from, skill, skillName);
			#endregion
			
Locate 
public static bool Mobile_SkillCheckTarget

After the line
CrystalBallOfKnowledge.TellSkillDifficulty(from, skillName, chance);
Add the below
			#region Level System Skills
			LevelHandler.DoGainSkillExp(from, skill, skillName);
			#endregion
			
Locate
public static bool Mobile_SkillCheckDirectTarget
After the line
var skill = from.Skills[skillName];

Add the below
			#region Level System Skills
			LevelHandler.DoGainSkillExp(from, skill, skillName);
			#endregion




Locate The below section

		public static void Gain(Mobile from, Skill skill)
		{
			
Below the bracket, add this

			#region Level System
			Configured c = new Configured();
			if (c.DisableSkillGain == true && from is PlayerMobile)
			{
				return;
			}
			#endregion
			
/////////////BaseVender.cs Edits/////////////////
Locate the below section

		public void UpdateBuyInfo()
		{
		}
		
Merge the following into the seciton so it looks something like this

        public void UpdateBuyInfo()
        {
            #region Level Vendor Discount Edit
            Configured c = new Configured();
            Town town = Town.FromRegion(Region);
            int priceScalar = GetPriceScalar();
     
			if (c.DiscountsForLevels == true)
			{
				if (this is LevelVendor10 	|| this is LevelVendor20 	|| this is LevelVendor30 	|| this is LevelVendor40  ||
					this is LevelVendor50 	|| this is LevelVendor60 	|| this is LevelVendor70 	|| this is LevelVendor80  ||
					this is LevelVendor90	|| this is LevelVendor100	|| this is LevelVendor120	|| this is LevelVendor140 ||
					this is LevelVendor160	|| this is LevelVendor180	|| this is LevelVendor200	|| this is LevelVendor230 ||
					this is LevelVendor250)
				{
					priceScalar = (int)(priceScalar * 0.6);
				}
			}
 
            var buyinfo = (IBuyItemInfo[])m_ArmorBuyInfo.ToArray(typeof(IBuyItemInfo));
 
            if (buyinfo != null)
            {
                foreach (IBuyItemInfo info in buyinfo)
                {
                    info.PriceScalar = priceScalar;
                }
            }
            #endregion
        }
			
/////////////ConfirmBankPointsGump.cs Edits/////////////////
At the bottom of the section
public ConfirmBankPointsGump

Add in this

			#region Level System Mod
			Configured c = new Configured();
			if (c.GainExpFromBods == true)
			{
				LevelHandler.BodGainEXP(user, (int)points);
			}
			#endregion