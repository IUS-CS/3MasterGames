using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C246SpellBook_V_2.Model;
using System.Collections.Generic;



namespace SpellViewerTests
{
    [TestClass]
    public class SpellViewerTest
    {
        ///<summary>  
        ///  This test evaluates the process of adding the attributes to the spell, and checking if it has completed it correctly.
        ///</summary>
        ///<param>
        ///  No param required
        ///</param>   
        [TestMethod]
        public void AddingAttribute_ToASpell()
        {
            string ID = "power blast";
            string Name = "Power Blast";
            string Level = "3";
            string School = "Conjuration";
            bool Ritual = true;
            bool Concentration = false;
            string Time = "30 seconds";
            string Range = "5 feet";
            string Components = "fire";
            string Materials = "wood";
            string Duration = "1 hour";
            string Classes = "Wizard";
            string Description = "Huge blast from the power within";
            string HigherLevel = "Unknown";
            string Source = "dnd";

            // Arrange
            string expectedName = "Power Blast";
            string expectedClasses = "Wizard";
            string expectedDuration = "1 hour";
            SpellList spell = new SpellList();

            spell.ID = ID;
            spell.Name = Name;
            spell.Level = Level;
            spell.School = School;
            spell.Ritual = Ritual;
            spell.Concentration = Concentration;
            spell.Time = Time;
            spell.Range = Range;
            spell.Components = Components;
            spell.Materials = Materials;
            spell.Duration = Duration;
            spell.Classes = Classes;
            spell.Description = Description;
            spell.HigherLevel = HigherLevel;
            spell.Source = Source;

            //Act
            string actualName = spell.Name;
            string actualClasses = spell.Classes;
            string actualDuration = spell.Duration;

            // Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedClasses, actualClasses);
            Assert.AreEqual(expectedDuration, actualDuration);
        }

        ///<summary>  
        ///  This test evaluates the process of adding a null spell, and checks if it can add a null spell.
        ///</summary>
        ///<param>
        ///  No param required
        ///</param>   
        [TestMethod]
        public void AddingNullSpell_ToSpellList()
        {
            // Arrange
            List<SpellList> sList = new List<SpellList>();
            SpellList spell = null;

            //Act
            sList.Add(spell);

            // Assert
            Assert.AreEqual(sList[0], null);
        }

        ///<summary>  
        ///  This test evaluates the process of adding a spell with attributes, and checking if it has completed it correctly.
        ///</summary>
        ///<param>
        ///  No param required
        ///</param>   
        [TestMethod]
        public void AddingSpell_ToSpellList()
        {
            string ID = "power blast";
            string Name = "Power Blast";
            string Level = "3";
            string School = "Conjuration";
            bool Ritual = true;
            bool Concentration = false;
            string Time = "30 seconds";
            string Range = "5 feet";
            string Components = "fire";
            string Materials = "wood";
            string Duration = "1 hour";
            string Classes = "Wizard";
            string Description = "Huge blast from the power within";
            string HigherLevel = "Unknown";
            string Source = "dnd";

            // Arrange
            List<SpellList> sList = new List<SpellList>();
            SpellList spell = new SpellList();

            spell.ID = ID;
            spell.Name = Name;
            spell.Level = Level;
            spell.School = School;
            spell.Ritual = Ritual;
            spell.Concentration = Concentration;
            spell.Time = Time;
            spell.Range = Range;
            spell.Components = Components;
            spell.Materials = Materials;
            spell.Duration = Duration;
            spell.Classes = Classes;
            spell.Description = Description;
            spell.HigherLevel = HigherLevel;
            spell.Source = Source;

            //Act
            sList.Add(spell);

            // Assert
            Assert.AreEqual(sList[0], spell);
        }

        ///<summary>  
        ///  This test evaluates if you can add multiple spells to the spellList. Then checks if they are added in order.
        ///</summary>
        ///<param>
        ///  No param required
        ///</param>   
        [TestMethod]
        public void AddingMultipleSpells_ToSpellList()
        {
            string ID = "power blast";
            string Name = "Power Blast";
            string Level = "3";
            string School = "Conjuration";
            bool Ritual = true;
            bool Concentration = false;
            string Time = "30 seconds";
            string Range = "5 feet";
            string Components = "fire";
            string Materials = "wood";
            string Duration = "1 hour";
            string Classes = "Wizard";
            string Description = "Huge blast from the power within";
            string HigherLevel = "Unknown";
            string Source = "dnd";

            string ID2 = "water blast ";
            string Name2 = "Water Blast";
            string Level2 = "7";
            string School2 = "Destruction";
            bool Ritual2 = true;
            bool Concentration2 = false;
            string Time2 = "25 seconds";
            string Range2 = "30 feet";
            string Components2 = "water";
            string Materials2 = "pool";
            string Duration2 = "30 minutes";
            string Classes2 = "Wizard";
            string Description2 = "Huge blast from the power within";
            string HigherLevel2 = "Unknown";
            string Source2 = "dnd";

            // Arrange
            List<SpellList> sList = new List<SpellList>();
            SpellList spell = new SpellList();

            spell.ID = ID;
            spell.Name = Name;
            spell.Level = Level;
            spell.School = School;
            spell.Ritual = Ritual;
            spell.Concentration = Concentration;
            spell.Time = Time;
            spell.Range = Range;
            spell.Components = Components;
            spell.Materials = Materials;
            spell.Duration = Duration;
            spell.Classes = Classes;
            spell.Description = Description;
            spell.HigherLevel = HigherLevel;
            spell.Source = Source;

            //Act
            sList.Add(spell);
            SpellList spell2 = new SpellList(ID2, Name2, Level2, School2, Ritual2, Concentration2, Time2, Range2,
                Components2, Materials2, Duration2, Classes2, Description2, HigherLevel2, Source2);
            sList.Add(spell2);
            int count = sList.Count;

            // Assert
            Assert.AreEqual(count, 2);
            Assert.AreEqual(sList[0], spell);
            Assert.AreEqual(sList[1], spell2);
        }

        [TestMethod]
        public void LevelAppend_0_Abjuration()
        {
            //Arrange 
            var level = "0";

            var school = "Abjuration";

            var formatter = new displayFormatter();

            var expected = "Abjuration Cantrip\r\n\r\n";
            //Act

            var result = formatter.LevelAppend(level, school);
            
            //Assert

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void LevelAppend_1_Abjuration()
        {
            //Arrange 
            var level = "1";

            var school = "Abjuration";

            var formatter = new displayFormatter();

            var expected = "1st-level Abjuration\r\n\r\n";
            //Act

            var result = formatter.LevelAppend(level, school);

            //Assert

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void LevelAppend_2_Abjuration()
        {
            //Arrange 
            var level = "2";

            var school = "Abjuration";

            var formatter = new displayFormatter();

            var expected = "2nd-level Abjuration\r\n\r\n";
            //Act

            var result = formatter.LevelAppend(level, school);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LevelAppend_3_Abjuration()
        {
            //Arrange 
            var level = "3";

            var school = "Abjuration";

            var formatter = new displayFormatter();

            var expected = "3rd-level Abjuration\r\n\r\n";
            //Act

            var result = formatter.LevelAppend(level, school);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LevelAppend_9_Abjuration()
        {
            //Arrange 
            var level = "9";

            var school = "Abjuration";

            var formatter = new displayFormatter();

            var expected = "9th-level Abjuration\r\n\r\n";
            //Act

            var result = formatter.LevelAppend(level, school);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LevelAppend_chicken_Abjuration()
        {
            //Arrange 
            var level = "6";

            var school = "Abjuration";

            var formatter = new displayFormatter();

            var expected = "6th-level Abjuration\r\n\r\n";
            //Act

            var result = formatter.LevelAppend(level, school);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MaterialCheck_V_S_NM()
        {
            //Arrange 
            var componets = "Verbal, Somatic, ";

            var materials = "";

            var formatter = new displayFormatter();

            var expected = "\r\n";
            //Act

            var result = formatter.MaterialCheck(componets, materials);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MaterialCheck_V_NM()
        {
            //Arrange 
            var componets = "Material";

            var materials = "a chicken egg";

            var formatter = new displayFormatter();

            var expected = " (a chicken egg)\r\n";
            //Act

            var result = formatter.MaterialCheck(componets, materials);

            //Assert

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MaterialCheck_V_S_M()
        {
            //Arrange 
            var componets = "Verbal, Somatic, Material";

            var materials = "a chicken egg";

            var formatter = new displayFormatter();

            var expected = " (a chicken egg)\r\n";
            //Act

            var result = formatter.MaterialCheck(componets, materials);

            //Assert

            Assert.AreEqual(expected, result);
        }

        /*
        [TestMethod]
        public void NewlineParser_long()
        {
            //Arrange 
            var description = "  You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage.\\n This spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).";

            var formatter = new displayFormatter();

            var expected =    "  You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage.\n\r\n  This spell's damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).\n";
            //Act

            var result = formatter.NewlineParser(description);

            //Assert

            Assert.AreEqual(expected, result);
        }
        */
    }
}
