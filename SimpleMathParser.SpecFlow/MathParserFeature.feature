Feature: MathParserFeature
    In order to calculate an expression 
    I want to be parse the expression and generate a result


Scenario: Execute expression
    Given I have the expression 3a2c4
    When I execute the math parser
    Then the result should be 20    

Scenario Outline: Execute any expression
    Given I have the expression <Input>
    When I execute the math parser
    Then the result should be <Output>
	Examples: 
	| Input              | Output |
	| 3a2c4              | 20     |
	| 32a2d2             | 17     |
	| 500a10b66c32       | 14208  |
	| 3ae4c66fb32        | 235    |
	| 3c4d2aee2a4c41fc4f | 990    |