Feature: UnsuccessfulRegistration

Scenario: Unsuccessful login for the registration endpoint
Given The user sends a correct email
And No password is sent
Then Response with 400 is sent back
And Error message is sent back