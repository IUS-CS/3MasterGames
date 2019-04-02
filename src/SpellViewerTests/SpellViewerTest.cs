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
            Assert.AreEqual(expectedClasses, actualClasses);
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
        public void format_a_spell()
        {
            //Arrange 


            //Act


            //Assert


        }
    }
}
