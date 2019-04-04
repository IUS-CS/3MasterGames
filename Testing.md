## Testing

We have implemented multiple test functions for our project. So far we are tesitng
adding attributes to spells to ensure our SpellList class is working as it should and
receiving the proper attributes. 

We added a test to ensure that our SpellList can hold a null spell.

We added a test that creats a SpellList object and adds it into a list. We ensure that
the spell successfully goes into the first index of the list.

We added a test that basically does the same as the previous test, except ensures that
the list can hold multiple spells.

Our next tests check our LevelAppend function is working. This function checks the level
of a spell and adds the respective text to the end of the spell, so if a spell is level 0
it will add " Cantrip" to the end, if the spell is level 1 it will add "st-level" to the end, 
etc.

The next tests check if the material check function works. This function checks if a spell has 
Materials, if it does it adds the spell name at the end, if not it adds a new line. 

We plan on adding more tests in the future regarding filters. These will check if a data table 
is displaying all the proper filtered spells, by checking the list count in levels and comparing it
with the datarow count in the table. This will be based off of what boxes are checked. 