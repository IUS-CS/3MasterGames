# Spellviewer Change Log

## Version 0.6.3
 ### Major Changes
   - Recreated the classes layout so it would act the same as levels.
   - Created the correct testing folder with a few tests inside for creating a spell.
 ### Minor Changes
   - Added an if statement inside useFilterTable, that way classes an be used. It needs to be updated, im trying to figure out how to use it affectively with removing spells.
   - Cleaned up the SpellList class.
 ### Bug Fixes
   - This isnt so much a fix, but the DiplayTable.clear(); is causig a few issues inside the useFilterClass. When multiple checkboxes are selected it causes the display to become null. we need to find a way around it or keep it commented out for now.

## Version 0.6.2
  ### Major Changes
    - Spells are now displayed in a predetermined format. 

## Version 06.1
  ### Major Changes
    - The methods for the checkbox commands. Changing the format inside the design window, creating it so that it can effect the way each checkbox can be effected directly by using the parameter. 
  ### Minor Changes
    - The way the Xml file is loaded in is automatic and doesn't have to be placed inside the debug folder.
  ### Bug Fixes
    - Some of the loading issues with the level attributes, and errors with selecting 2 or more checkboxes and then deselecting 1.
