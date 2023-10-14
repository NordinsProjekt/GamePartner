Feature: MtGCommanderService


Scenario: Attack for damage
	Given Apply 2 damage
	And to a player
	When lifetotal is 20
	Then Lifetotal should be 18