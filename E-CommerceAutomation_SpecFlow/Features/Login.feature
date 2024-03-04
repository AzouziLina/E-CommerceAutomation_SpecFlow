Feature: Login

A short summary of the feature

@LoginWithCorrectCredentials
Scenario: TC001_Login_to_your_account
	Given Enter your credentials
	When Click on Login to your account
	Then Verify Login is done successfully

@LoginWithWrongPassword
Scenario: TC002_Login_to_your_account_with_Wrong_Password
	Given Enter your credentials
	When Click on Login to your account
	Then Verify Login was not done successfully

@LoginWithWrongEmailAddress
Scenario: TC003_Login_to_your_account_with_Wrong_EmailAddress
	Given Enter your credentials
	When Click on Login to your account
	Then Verify Login was not done successfully


