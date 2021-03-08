Feature: Challenge2
 
 This is the test suite for Challange 2 each scenario check every operation on the list. 


@mytag
Scenario:  I want to update cart quantity price
	Given I am checking the cart which contains a PREMIUM SECURITY Multiplatform Solution
	When I set the quantity to 2 and I click Update
	Then I check the the price has updated accordingly

Scenario: I want to check that the item can be removed
	Given I am checking the cart which contains a PREMIUM SECURITY Multiplatform Solution
	When I click the remove item button
	Then I should be on the /solutions URL

	

