Feature: GetUsersList


Scenario: Send a request to get the users list
Given The rest API endoing for GetUserList
And No payload is being sent
Then Response with 200 is sent back
And List with users is sent back
