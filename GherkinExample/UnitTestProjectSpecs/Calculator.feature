Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 127 into the calculator
    And  I have also entered 3 into the calculator
	When I press add
	Then the result should be 130 on the screen

@mytag2
Scenario: Wrongly Add two numbers
	Given I have entered 127 into the calculator
    And  I have also entered 3 into the calculator
	When I press add
	Then the wrong result should be 131 on the screen
