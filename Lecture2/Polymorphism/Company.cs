using System.Collections.Generic;

namespace Polymorphism {
    class Company {
        private List<Employee> employees;

        public Company() {
            employees = new List<Employee>();
        }

        public double GetMonthlySalaryTotal() {
            double sum = 0;
            foreach (Employee emp in employees) {
                sum += emp.GetMonthlySalary();
            }

            return sum;
        }

        public void HireNewEmployee(Employee emp) {
            employees.Add(emp);
        }
    }
}