Feature: BloodPressure Category Calculator

A short summary of the feature

@category_normal
Scenario: What is the blood pressure category for a given systolic and diastolic reading?
	Given a systolic reading of 120 and a diastolic reading of 80
	When I calculate the blood pressure category
	Then the result should be "Ideal"
