Feature: Failed_Login_Without_Credentials_Feature


@web
Scenario: Login with no credentials. Ensure correct error message is displayed.
	Given User is at the Home Page
	And Navigate to LogIn Page
	When User does not enter UserName and Password
	And Click on the LogIn button
	Then Correct error message should display