using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace C246SpellBook_V_2.Logic

{
    internal class DisplayFormatter
    {
        internal DataTable DisplayTableReference;

        ///<summary>  
        ///  This method sets the local DisplayTable.
        ///</summary>
        ///<param name="displayTable">
        ///  Referance to the data table that holds all the data.
        ///</param>   
        public void SetDataTable(DataTable displayTable)
        {
            DisplayTableReference = displayTable;
        }
        ///<summary>  
        ///  Takes a key and searches thru the data Table te find the unique spell
        ///</summary>
        ///<param name="key">
        ///  Tho key is a unique spell identifier.
        ///</param> 
        public string FormatData(string key)
        {
            //temporary dataRow to allow display of data
            var spellRow = DisplayTableReference.Rows.Find(key);

            //call the formatter
            return Format(spellRow);
        }

        //format the string to be outputted on the display
        private static string Format(DataRow spell)
        {
            /**
             * Representation within the spell DataRow
             * spell[0] --> spell's ID
             * spell[1] --> spell's Name
             * spell[2] --> spell's Level
             * spell[3] --> spell's school
             * spell[4] --> Ritual attribute
             * spell[5] --> spell's Concentration time
             * spell[6] -->
             * spell[7] --> spell's casting time
             * spell[8] --> spell's range
             * spell[9] --> spell's Components
             * spell[10] --> spell's materials
             * spell[11] --> spell's duration
             * spell[12] --> spell's description
             * spell[13] --> casting at higher levels
             * spell[14] --> the source of the spell's information
             */
            //create a text holder
            var displayText = new StringBuilder();

            //Displays the name
            displayText.AppendLine(spell[1].ToString());

            //line spacing after the name 
            displayText.AppendLine();

            //switch on the spells level
            switch (spell[2].ToString())
            {
                //remember spell[3] is the spell's school
                case "0":
                    displayText.AppendLine(spell[3] + " Cantrip");
                    break;
                case "1":
                    displayText.AppendLine(spell[2] + "st-level " + spell[3]);
                    break;
                case "2":
                    displayText.AppendLine(spell[2] + "nd-level " + spell[3]);
                    break;
                case "3":
                    displayText.AppendLine(spell[2] + "rd-level " + spell[3]);
                    break;
                default:
                    displayText.AppendLine(spell[2] + "th-level " + spell[3]);
                    break;
            }

            //add a line space
            displayText.AppendLine();

            //Displays the casting time of the spell
            displayText.AppendLine("Casting Time: " + spell[7]);

            //Displays the range of the spell
            displayText.AppendLine("Range: " + spell[8]);

            //Componets #9 & Materials #10
            displayText.Append("Components: " + spell[9]);

            MaterialCheck(ref displayText, spell[9].ToString());

            displayText.Append("Duration: ");

            //spell[4] --> ritual attr.
            //spell[5] --> concentration attr.
            if (spell[4].Equals("true") && spell[5].Equals("true"))
            {
                displayText.AppendLine("Ritual & Concentration, up to " + spell[11]);
            }
            else if (spell[4].Equals("false") && spell[5].Equals("true"))
            {
                displayText.AppendLine("Concentration, up to " + spell[11]);
            }
            else if (spell[4].Equals("true") && spell[5].Equals("false"))
            {
                displayText.AppendLine("Ritual or " + spell[11]);
            }
            else
            {
                displayText.AppendLine(spell[11].ToString());
            }

            //add a line space
            displayText.AppendLine();

            //Displays the spell's description
            NewlineParser(ref displayText, spell[12].ToString());

            //add a line space
            displayText.AppendLine();

            //higher level #13

            if (!(spell[13].Equals("")))
            {
                displayText.AppendLine("At Higher Levels: " + spell[13]);

                //displayText.AppendFormat(spell[13].ToString(), "\n"); 
            }


            //add a line space
            displayText.AppendLine();

            //spell[14] --> spell's source
            displayText.AppendLine("Source: " + spell[14]);

            return displayText.ToString();
        }


        private static void MaterialCheck(ref StringBuilder text, string spell)
        {
            var materialChecker = spell.Split(new[] { "," }, StringSplitOptions.None);

            var hasMat = false;

            foreach (var t in materialChecker)
            {
                if (t == " Material" || t == "Material")
                {
                    hasMat = true;
                }
            }

            if (hasMat)
            {
                text.AppendLine("(" + spell[10] + ")");
            }
            else
            {
                text.AppendLine();
            }
        }

        /**
         * This function searches the description of a spell's toString representation for a '\n' character
         * sequence and inserts line breaks whenever that sequence is found. This function is called by the
         * format method to properly display a spell's description.
         */

        private static void NewlineParser(ref StringBuilder text, string spell)
        {
            //will hold the spell description read up until a '\n' is found
            var temp = "";
            for (var i = 0; i < spell.Length; i++)
            {
                //looking for a \n in the paragraph description
                if (spell[i].Equals('\\') && spell[i + 1].Equals('n') || i + 1 == spell.Length)
                {
                    //if we have reached the end of the description
                    if (i + 1 == spell.Length)
                    {
                        //appends the last item
                        temp += spell[i];
                    }

                    //This adds additional spacing between paragraphs
                    temp += "\n";

                    //we found a newline so print everything stored in the line read so far
                    text.AppendLine(temp);

                    //we are on a new paragraph so reset the string
                    temp = "";

                    //skips the 'n' character in the '/n' string
                    i++;
                }
                else
                {
                    //copies the character back to the output string
                    temp += spell[i];
                }
            }
        }
    }
}
