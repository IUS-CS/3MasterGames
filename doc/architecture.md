# Software Architecture Document

## 1. Introduction to SpellViewer

### 1.1 Purpose

The purpose for this document is to provide an architectural overview of our program. 

### 1.2 Structure

a) doc - Contains the documentation for our program.

b) src - Contains the necessary files to execute the game, Xml files to read from, and once inside make sure to
	  copy the SpellBookDB.xml file and place it inside the bin/debug folder in order to read correctly.

b) Soon... Testing folder, more to come.

### 1.3 Program Intoduction

This program, (SpellViewer) is a helper for the game known as Dnd. It will give the user access to all the spells
known in the game. Depending on what the user wants, this program will be able to search, and filter spells in order
to obtain what spell they needed. Once the spell has been located, it can be selected and all the description of that
spell will be displayed to the user. Any information they need at their fingertips.

### 1.4 The Future of the Program

Later, this program will be updated so that the user can create spells of their own and add the to the whole of the
spell book. By doing so will write to the xml file saving all changes to their spell book. Also be able to edit any
spell inside the spell book, being able to create your own homebrew of spells, changing anything they might want. 
Making the program auto update with the new set of spells from newer docments and or other sources other than Dnd.

![](DiagramSV.PNG)


