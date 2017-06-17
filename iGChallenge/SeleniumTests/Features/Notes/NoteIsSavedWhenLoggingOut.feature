Feature: NoteIsSavedWhenLoggingOut


@web
Scenario Outline: The user can create a note and the note is saved after the user is logged out
	Given The user logs into the application
	And User clicks on the create new note button
	When Note '<title>' and '<description>' is entered
	And Done button is clicked
	And User logs out and back in
	Then Note '<title>' should be saved

	Examples: 
	| title     | description     |
	| testtitle | testdescription |
	 