using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;
using Moq;
using FluentAssertions;

namespace SCD_SalaryIncrease
{
	public class EmployeeSalaryIncreaseTestWithRepository
	{
		private Mock<INotify> _notifyMock;
		private SimpleListEmployeeRepository _simpleListEmployeeRepository;

		[SetUp]
		public void Setup()
		{
			_notifyMock = new Mock<INotify>();
			_simpleListEmployeeRepository = new SimpleListEmployeeRepository();
			_simpleListEmployeeRepository.Insert(new Employee()
			{
				CurrentSalary = 1000, 
				Email = "hugo@example.com",
				Id = 1
			});
/*
			{
				CurrentSalary = 2000, 
				Email = "emil@example.com",
				Id = 2
			});
*/
		}

		[Test]
		public void GetSuccessNotificationOnManualSalaryIncrease()
		{
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _simpleListEmployeeRepository);
			const string expected = "someone@example.com salary is manually increased 45 successfully.";

			actual.IncreaseSalaryByEmail("someone@example.com", 45);

			_notifyMock.Verify(x => x.NotifySuccess(expected), Times.Once);
		}
		
		[Test]
		public void ManualSalaryIncreaseBy45PercentInvokesRepositoryInsert()
		{
			Employee captured = null;
			
			// given an employee with a salary of 1000 and the email address hugo@example.com

			// when calling increaseSalaryByEmail on that employee with an increase of 45
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _simpleListEmployeeRepository);
			actual.IncreaseSalaryByEmail("hugo@example.com", 45);

			// then the salary of the employee is updated to 1450

			Expression<Func<Employee, bool>> filterByIdEqualsOne = x => x.Id == 1;
			
			var res = _simpleListEmployeeRepository.Get(filterByIdEqualsOne);
			captured = res.First();
//            captured = testEmployeeRepository.Get(filterByIdEqualsOne);
			captured.CurrentSalary.Should().Be(1450);
		}
		[Test]
		public void ManualSalaryIncreaseBy35PercentInvokesRepositoryInsert()
		{
			Employee captured = null;
			_simpleListEmployeeRepository = new SimpleListEmployeeRepository();
			_simpleListEmployeeRepository.Insert(new Employee()
			{
				CurrentSalary = 1000, 
				Email = "emil@example.com",
				Id = 5
			});
			// given an employee with a salary of 1000 and the email address hugo@example.com

			// when calling increaseSalaryByEmail on that employee with an increase of 45
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _simpleListEmployeeRepository);
			actual.IncreaseSalaryByEmail("emil@example.com", 35);

			// then the salary of the employee is updated to 1450

//			Expression<Func<Employee, bool>> filterByIdEqualsOne = x => x.Id == 1;
			Expression<Func<Employee, bool>> filterByIdEqualsOne = x => x.Email == "emil@example.com";
			
			var res = _simpleListEmployeeRepository.Get(filterByIdEqualsOne);
			captured = res.First();
//            captured = testEmployeeRepository.Get(filterByIdEqualsOne);
			captured.CurrentSalary.Should().Be(1350);
		}
		
	}
	
	

	public class EmployeeSalaryIncreaseTests
	{
		private Mock<INotify> _notifyMock;
		private Mock<IRepository<Employee>> _repositoryMock;

		[SetUp]
		public void setup()
		{
			_notifyMock = new Mock<INotify>();
			_repositoryMock = new Mock<IRepository<Employee>>();

			_repositoryMock.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>()))
				.Returns(new List<Employee> { new Employee() { CurrentSalary = 1000, Email = "hugo@example.com" } });
		}

		[Test]
		public void HasAppropriateInterface()
		{
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object);
			Assert.IsInstanceOf<IEmployeeSalaryIncrease>(actual);
		}


		[Test]
		public void EmailIsNull_ThrowsArgumentException()
		{
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object);
			Assert.Throws<ArgumentException>(() => actual.IncreaseSalaryByEmail(null, null));
		}

		[Test]
		public void GetSuccessNotificationOnManualSalaryIncrease()
		{
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _repositoryMock.Object);
			const string expected = "someone@example.com salary is manually increased 45 successfully.";

			actual.IncreaseSalaryByEmail("someone@example.com", 45);

			_notifyMock.Verify(x => x.NotifySuccess(expected), Times.Once);
		}

		[Test]
		public void ManualSalaryIncreaseBy45PercentInvokesRepositoryInsert()
		{
			Employee captured = null;

			_repositoryMock.Setup(m => m.Update(It.IsAny<Employee>())).Callback<Employee>(emp => captured = emp);

			// given an employee with a salary of 1000 and the email address hugo@example.com

			// when calling increaseSalaryByEmail on that employee with an increase of 45
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _repositoryMock.Object);
			actual.IncreaseSalaryByEmail("hugo@example.com", 45);

			// then the salary of the employee is updated to 1450

			_repositoryMock.Verify(m => m.Update(It.IsAny<Employee>()), Times.Once);
			captured.CurrentSalary.Should().Be(1450);
		}

		[Test]
		public void ManualSalaryIncreaseBy30PercentInvokesRepositoryInsert()
		{
			Employee captured = null;
			_repositoryMock.Setup(m => m.Update(It.IsAny<Employee>())).Callback<Employee>(emp => captured = emp);

			// when calling increaseSalaryByEmail on that employee with an increase of 30
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _repositoryMock.Object);
			actual.IncreaseSalaryByEmail("hugo@example.com", 30);

			// then the salary of the employee is updated to 1300

			_repositoryMock.Verify(m => m.Update(It.IsAny<Employee>()), Times.Once);
			captured.CurrentSalary.Should().Be(1300);
		}

		[Test]
		public void testIncreaseCeleryByPercentageDoesntThrowAnExceptionOnNullPercent()
		{
			var actual = new EmployeeSalaryIncrease(_notifyMock.Object, _repositoryMock.Object);
			Assert.Throws<NotImplementedException>(
				() => actual.IncreaseSalaryByEmail("hugo@example.com", null));

		}
	}
}
