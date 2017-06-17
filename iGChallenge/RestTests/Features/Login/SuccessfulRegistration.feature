Feature: SuccessfulRegistration

Scenario: Successful login for the registration endpoint
Given The user sends a correct email
And A correct password for the email is sent
Then Response with '201' code is sent back
And Token is sent back