namespace Polymorphism {
    class FullTimeEmployee : Employee {
        public double MonthlySalary;

        public FullTimeEmployee(string Name, double MonthlySalary) : base(Name) {
            this.MonthlySalary = MonthlySalary;
        }

        public override double GetMonthlySalary() {
            return MonthlySalary;
        }
    }
}