# Requirements:

- As a HR personel, i would like to increase the salary of the employee by using his/her e-mail address and percentage of the increase and get the notification if it is successful or not.
  - if i don't give any percentage, it should automatically take the average of old increases of the employee from the database, 
  - if there are no salary increases for the employee before, then take the average of last year salaries of all employees.
  - if there are no salary increases for the all employees before, then increase %10.
  - if the calculated salary should not be more than %15.
  - the manual salary can be more than %15.
  - the salary increase percentage cannot be entered negative value. It can be always between 0-100 or can be null.
  - Noone can enter unknown, wrong e-mail address. Always valid end existing e-mail address will be used.
  - Notifications, for success: '{e-mail} salary was manually increased %{percent} successfully and new salary is ${salary}.'
  - Notifications, for success: '{e-mail} salary was calculated and increased %{percent} successfully and new salary is ${salary}.'
  - Notifications, for success: '{e-mail} salary was calculated from employee salaries and increased %{percent} successfully and new salary is ${salary}.'
  - Notifications, for success: '{e-mail} salary was calculated from all employee salaries and increased %{percent} successfully and new salary is ${salary}.'
  - Notifications, for fail: '{e-mail} salary could NOT be increased successfully.'
  - all salaries are in $.

# Story

- A crazy dude gave you these interfaces. 
- the crazy guy is expecting from you to implement the IEmployeeSalaryIncrease interface only.
- you cannot change anything interfaces.
- you are a developer who knows only these interfaces and that's it. no database, no system. nothing.
- you need to make sure that given requirements for the methods will be fulfilled!
- the network is so bad, the connections are closed all the time.

# Technical 

- When you change the salary of the employee, you need to create a employee salary log as well.
  - you can reach Employee table with IRepository interface and IEmployeeSalary interface.
  - you can reach EmployeeSalaryLog table with IRepository interface and ISalaryLog interface. (we know that we have naming mismatch)
- if something happens while writing to 2 tables, you need to rollback all operations and notify the user.
- to notify the end user, use INotify interface.
- logging exceptions are out of scope for now. (like i said, a crazy dude)
- for Unitofwork, Begin if necessary, opens connection, but always creates a new transaction. (Begin method could return IDbTransaction but this is the life :)) 

# Approach:

TDD