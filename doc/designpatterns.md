## Design Patterns

We don't have a concrete design pattern that we are currently using, but right now
the

We are currently trying to make our program more modular for testing purposes
by breaking our program up into smaller objects that complete specific tasks.
We have our main UI class, and this class calls on other objects to do smaller
tasks such as generate data, create spell attributes, sort rows by selected columns,
etc. We plan on creating future objects that will handle other tasks such as importing
and exporting data, adding spells, and we plan on breaking apart our filters function in
the future into its own class. One of the things our program is lacking as well is an
interface. This is something we could add in the future as well. 