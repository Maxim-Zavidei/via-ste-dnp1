namespace Polymorphism {
    abstract class Employee {
        public string Name;

        public Employee(string Name) {
            this.Name = Name;
        }

        public abstract double GetMonthlySalary();
    }
}