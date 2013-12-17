DominionWar - a C# .Net Forms Uni Assignment 
================================
20/20 mark - October 2013

This assignment built on Assignment 1 and was focused around battles between two fleets of space ships. There was a new file format required 
as well as the file format from the first assignment. See dominion2.txt and allies2.txt. Also, this assignment was a Windows Forms application, 
rather than a console application. 

The logic around the ordering of firing between the two fleets is the same as the first assignment. 
The result of the battle would be printed out into the text area field. 

Ended up with full marks :) 

File format
----------------
Straight from the assignment spec:

 - The first line will contain the following characters #2
 - This represents version 2 of the format and is used to distinguish between the new format and the old.
 - The second line of the file will be the name of the fleet. This is a string.
 - Unlike the format in Assignment 1, the number of ships to be loaded is not listed. Instead, each ship class will be listed along 
	with the number of each ship. Ships are defined by 2 pieces of information, each on a separate line
1. Ship Class name. A string.
2. The number of ships of that class. An integer >= 1.
- There are no blank lines in the file except after the last ship has been listed.

The file format from first assignment also applied.

Restrictions for this assignment
--------------------------------
 - Could NOT use Arrays
 - Must use Lists
 - No Linq
 - Must use Inheritance
 - Could only use what was covered in class at the time the assignment was released