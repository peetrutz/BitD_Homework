Feature: Challenge1
 
 This is the test suite for Challange 1 each scenario check every operation on the list


@mytag
Scenario:  I want to check that I can access the home solutions
	Given I am on the home page using Chrome
    When I click the home_solutions button on the home page
	Then I should be on the /solutions URL

Scenario:  I want to check the scroll function of the multiplatform button
	Given I am on the home_solutions page using Chrome
    When I click the multiplatform button on the home_solutions page
	Then I should see the "multiplatform" fixed menu button highlighted

Scenario:  I want to the BUY NOW button takes me to the e-shop
	Given I am on the home_solutions page using Chrome
    When I click the BUY NOW button for the Multiplatform Premium Security solution
	Then I should be on the cart URL


