using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace C246SpellBook_V_2.Model
{
    public class displayFormatter
    {

        ///<summary>  
        ///  Takes a key and searches thru the data Table te find the unique spell
        ///</summary>
        ///<param name="spell">
        ///  Tho key is a unique spell identifier.
        ///</param> 
       //format the string to be outputted on the display
        public string Format(DataRow spell)
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

            displayText.Append(LevelAppend(spell[2].ToString(), spell[3].ToString()));

            //Displays the casting time of the spell
            displayText.AppendLine("Casting Time: " + spell[7]);

            //Displays the range of the spell
            displayText.AppendLine("Range: " + spell[8]);

            //Componets #9 & Materials #10
            displayText.Append("Components: " + spell[9]);

            displayText.Append(MaterialCheck(spell[9].ToString(), spell[10].ToString()));

            displayText.Append("Duration: ");

            displayText.Append(RitAndCon(spell[4].ToString(), spell[5].ToString(), spell[11].ToString()));

            //Displays the spell's description
            displayText.Append(NewlineParser(spell[12].ToString()));

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

        public string RitAndCon(string spell4, string spell5, string spell11)
        {

            StringBuilder text = new StringBuilder();

            //spell[4] --> ritual attr.
            //spell[5] --> concentration attr.
            if (spell4.Equals("true") && spell5.Equals("true"))
            {
                text.AppendLine("Ritual & Concentration, up to " + spell11);
            }
            else if (spell4.Equals("false") && spell5.Equals("true"))
            {
                text.AppendLine("Concentration, up to " + spell11);
            }
            else if (spell4.Equals("true") && spell5.Equals("false"))
            {
                text.AppendLine("Ritual or " + spell11);
            }
            else
            {
                text.AppendLine(spell11);
            }

            //add a line space
            text.AppendLine();

            return text.ToString();
        }

        public string LevelAppend(string spell2, string spell3)
        {
            StringBuilder text = new StringBuilder();
            
            switch (spell2)
            {
                //remember spell[3] is the spell's school
                case "0":
                    text.AppendLine(spell3 + " Cantrip");
                    break;
                case "1":
                    text.AppendLine(spell2 + "st-level " + spell3);
                    break;
                case "2":
                    text.AppendLine(spell2 + "nd-level " + spell3);
                    break;
                case "3":
                    text.AppendLine(spell2 + "rd-level " + spell3);
                    break;
                default:
                    text.AppendLine(spell2 + "th-level " + spell3);
                    break;
            }

            //add a line space
            text.AppendLine();

            return text.ToString();

        }
        
        public string MaterialCheck(string spell9, string spell10)
        {
            StringBuilder text = new StringBuilder();

            var materialChecker = spell9.Split(new[] { "," }, StringSplitOptions.None);

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
                text.AppendLine(" (" + spell10 + ")");
            }
            else
            {
                text.AppendLine();
            }

            return text.ToString();
        }

        /**
         * This function searches the description of a spell's toString representation for a '\n' character
         * sequence and inserts line breaks whenever that sequence is found. This function is called by the
         * format method to properly display a spell's description.
         */

        public string NewlineParser(string spell)
        {
            StringBuilder text = new StringBuilder();

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

            return text.ToString();
        }
    }
}
