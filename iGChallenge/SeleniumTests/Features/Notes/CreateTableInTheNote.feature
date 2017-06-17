Feature: CreateTableInTheNote



@web
Scenario Outline: The user can create a table inside note body
	Given The user logs into the application
	And User clicks on the create new note button
	When Note '<title>' and '<description>' is entered
	And The add table button is pressed
	Then Table is created inside the note body
	And  Table is of the correct '<dimension>'


	Examples: 
	| title      | description     | dimension |
	| testtitle2 | testdescription | 3x3       |