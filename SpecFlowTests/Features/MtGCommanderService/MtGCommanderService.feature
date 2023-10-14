Feature: MtGCommanderService


Scenario: Attack for damage
	Given A Player has 20 life
	When Player takes 5 damage
	Then Lifetotal should be 15