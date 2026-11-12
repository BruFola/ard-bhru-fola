Feature: BloodPressure Category Calculator

As a user of the app Ard Bhru - Blood Pressure Calculator - i want to input the values for systolic and diastolic and for it to tell me what Blood Pressure Category it belongs so I can see a doctor if needed or take action to lower my blood pressure.


Scenario Outline: What is the blood pressure category for a given systolic and diastolic reading?
	Given a systolic reading of <systolic> and a diastolic reading of <diastolic>
	When I calculate the blood pressure category
    Then the result should be "<expectedCategory>"

	Examples:
  | systolic | diastolic | expectedCategory |
  | 180      | 80        | High	    |
  | 120      | 80        | PreHigh  |
  | 110      | 70        | Ideal  |
  | 90       | 60        | Ideal  |
  | 80       | 59        | Low  |
  | 130      | 60        | PreHigh  |
