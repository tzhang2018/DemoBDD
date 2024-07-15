Feature: LoadApplication

As a loan application evaluator
I want to only approve loan requests that meet our agreed upon load amount rules
So the risk associated with supplying loans remains within regulatory boundaries

Scenario Outline: Loan amounts under 1000 are always approved
	Given John is an active ParaBank customer
	When they apply for a <amount> dollar loan
	Then the loan application is approved
	Examples: 
	| amount |
	| 999    |
	| 1      |

Scenario Outline: Loan amounts greater than or equal to 100000 are always denied
	Given John is an active ParaBank customer
	When they apply for a <amount> dollar loan
	Then the loan application is denied
	Examples: 
	| amount |
	| 100000 |
	| 999999 |


Scenario Outline: For loan amounts between 1000 and 100000 the result depnes on income
	Given John is an active ParaBank customer
	When they apply for a <amount> dolloar loan and their monthly income is <income>
	Then the loan application is <result>
	Examples: 
	| amount | income | result   |
	| 1000   | 500    | Approved |
	| 50000  | 3000   | Approved |
	| 99999  | 3000   | Denied   |

