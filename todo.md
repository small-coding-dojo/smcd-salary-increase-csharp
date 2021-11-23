# Todo List

- Continue working on implementing MemoryEmployeeRepository and Tests
- Continue writing SpecFlow Gherkin tests.
- Check if the filter is applied.
- Specify Test for the case where "EmployeeRepository".get doesn't return any Employees
- make actual a field in the test class
- remove single parameter constructor of EmployeeSalaryIncrease
  - how do we handle or prevent the case, that a repository is null?
- care about _ in naming of test methods -> consistent naming
- convert local variables to fields in tests

- stefan hates the way, the mock overrides the setup method
  - the filter given in the mock is actually not used
  - better: mock.Setup() ... .where (x => filter(x)).ToList;

- Discussions
  - How do we like the repository.find(filter) method?
  - Shall we add a business object on top of the repository which has the knowledge about employee querying?
    - EmployeeRoaster.GetByEmail(email) => Repository.Find(x => x.email == email)
  - Shall we implement an in-memory stub repository for test?
  - 
