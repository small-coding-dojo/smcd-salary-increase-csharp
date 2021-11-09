Feature: Increase an employees salary

Scenario: The right employee is updated 
    Given there is an employee with email "imbored@example.com" and id "1" and salary 3000,
    And there is an employee with email "horst@example.com" and id "2" and salary 1000,
    When I Increase the Salary for "horst@example.com" by "20" percent
    Then "imbored@example.com" salary is 3000
    And "horst@example.com" salary is 1200
