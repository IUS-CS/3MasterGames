# 3MasterGames

## Spellviewer For DND 5E

Have you got tired of flipping through your PHB looking for your spells? Do you keep finding yourself putting your fingers in between your pages just so you can make a choice? Well, with Spellviewer you will have all of the spells at your finger tips. This application lists out all current spells, allows you to filter by class, spell level and specfic parts of the spell like if it is a ritual spell or a concentration spell, and display all components of a a spell. We have a few expansions planned that you can read about in the Future Expansion part down below and you can look at the different phases we plan to go through in the projects tab.

### Backstory

This application is a reboot of an old program that was infected with malware. It was a great program thus we want to recreate it, but unfortunately it has been wiped from the internet, except one copy. That last copy lives its days in a virtual container so that it doesn't do harm to another piece of software. We are using it to model a new redesign of the original Spellviewer.

### Issues

If you find a bug or you want to see something implemented, place an issue in and the team will do the best we can to accommodate your request. 
   
### Building

1) After you download the folder, you will need to make sure visual studio is installed and then click on the .sln file. Afterwhich, you will need to build the program or press start in visual studio.

2) In addition to downloading visual studio, for the time being you will need to locate the XML file named SpellBookDB.xml and copy it. The location is in the src folder. After copying the file, place it inside the location /src/bin/Debug. This helps the program load the list of spells. This will be updated in the future, to make it easier for the user.

3) Also, if you want the exe go to the release tab.

### Future Expansions 

In addition, to the base part of this program, we would like to also add these following expansions in the future -

1) Add a Spellbook that:

   a. Allows the user to choose a spell to be listed.
   
   b. Keep track of there spell slots (how many uses of a spell per level left).

2) Add an editor that:
    
   a. Allows the user to add there own classes, subclasses and modifiy esisting classes.
   
   b. Allows the user to add there own spells and modify existing spells.
   
   c. Allows the user to add there own notes to each spell.
