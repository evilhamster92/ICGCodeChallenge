Feature: Successful_LogIn_Feature

@web
Scenario: Successful login with valid credentials
	Given User is at the Home Page
	And Navigate to LogIn Page
	When User enter UserName and Password
	And Click on the LogIn button
	Then Successful LogIN message should display