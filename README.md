# Requirements:

- As a HR personel, i would like to increase the salary of the employee by using his/her email address and percentage of the increase and get the notification if it is successful or not.
  - if i will not give any percentage, it should automatically take the average of old increases of the employee, 
  - if there is no salary increases for the employee before, then take the average of last year salaries of all employees.
  - if the calculated salary should not be more than %15.
  - the manual salary can be more than %15.
  - if there is no salary increases for the all employees before, then use %10 increase.
  - Notifications, for success: '{email} salary is manually increased {percent} successfully.'
  - Notifications, for success: '{email} salary is calculated and increased {percent} successfully.'
  - Notifications, for warning: '{email} salary is calculated from employee salaries.'
  - Notifications, for warning: '{email} salary is calculated from all employee salaries.'
  - Notifications, for fail: '{email} salary is NOT increased successfully.'

# Story

- A crazy dude gave you these interfaces. 
- You can only play in the one class that implements the IEmployeeSalaryIncrease interface
- you cannot change anything else.
- you are a developer who knows only these interfaces and that's it. no database, no system. nothing.
- you need to make sure that given requirements for the methods will be fulfilled!

# Technical 

- When you change the salary of the employee, you need to create a employee salary log as well.
  - you can reach Employee table with IRepository interface and Employee class.
  - you can reach EmployeeSalaryLog table with IRepository interface and SalaryLog class. (we know that we have naming mismatch)
- if something happens while writing to 2 tables, you need to rollback all operations and notify the user.
- to notify the end user, use INotify interface.
- logging exceptions are out of scope for now. (like i said, a crazy dude)
- for Unitofwork, Begin if necessary, opens connection, but always creates a new transaction. (Begin method could return IDbTransaction but this is the life :)) 

# Approach:

TDD