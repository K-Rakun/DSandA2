using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace DSandA2Assignment1
{
    class Program
    {
        static Department root = new Department("root", "managerRoot");
        static void Main()
        {
            SampleData();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("choose an action\n" +
                "1-Add Sub Department\n" +
                "2-Add Employee\n" +
                "3-Remove Department\n" +
                "4-Remove Employee\n" +
                "5-Move Department\n" +
                "6-Move Employee\n" +
                "7-Print All Departments\n" +
                "8-Calculate The Number Of Employees\n" +
                "0-Exit");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("What department do you want to add a sub department to");
                        string departmentName = Console.ReadLine();
                        AddSubDepartment(root, departmentName);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("What department do you want to add an employee to");
                        departmentName = Console.ReadLine();
                        AddEmployee(root, departmentName);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("What department do you want to remove a sub department from");
                        departmentName = Console.ReadLine();
                        RemoveDepartment(root, departmentName);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("What department do you want to remove an employee from");
                        departmentName = Console.ReadLine();
                        RemoveEmployee(root, departmentName);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("What department do you want to move a sub department from");
                        departmentName = Console.ReadLine();
                        MoveDepartment(root, departmentName);
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("What department do you want to move an employee from");
                        departmentName = Console.ReadLine();
                        MoveEmployee(root, departmentName);
                        Console.ReadKey();
                        break;
                    case 7:
                        Print(root);
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.WriteLine("Name of the department");
                        departmentName = Console.ReadLine();
                        var index = Search(root, departmentName);
                        int result = CalculateEmployees(index, 0) + index.Employees.Count();
                        Console.WriteLine(result);
                        Console.ReadKey();
                        break;

                }

                if(input == 0)
                {
                    break;
                }
            }

        }


        static void SampleData()
        {

            
            Department departmentA = new Department("departmentA", "managerA");
            root.SubDepartments.Add(departmentA);
            Department departmentB = new Department("departmentB", "managerB");
            root.SubDepartments.Add(departmentB);
            Department departmentA1 = new Department("departmentA1", "managerA1");
            departmentA.SubDepartments.Add(departmentA1);
            Department departmentA2 = new Department("departmentA2", "managerA2");
            departmentA.SubDepartments.Add(departmentA2);
            Department departmentB1 = new Department("departmentB1", "managerB1");
            departmentB.SubDepartments.Add(departmentB1);
            Department departmentB2 = new Department("departmentB2", "managerB2");
            departmentB.SubDepartments.Add(departmentB2);
            Department departmentA11 = new Department("departmentA11", "managerA11");
            departmentA1.SubDepartments.Add(departmentA11);
            Department departmentA12 = new Department("departmentA12", "managerA12");
            departmentA1.SubDepartments.Add(departmentA12);
            Department departmentA21 = new Department("departmentA21", "managerA21");
            departmentA2.SubDepartments.Add(departmentA21);
            Department departmentA22 = new Department("departmentA22", "managerA22");
            departmentA2.SubDepartments.Add(departmentA22);
            Department departmentB11 = new Department("departmentB11", "managerB11");
            departmentB1.SubDepartments.Add(departmentB11);
            Department departmentB12 = new Department("departmentB12", "managerB12");
            departmentB1.SubDepartments.Add(departmentB12);
            Department departmentB21 = new Department("departmentB21", "managerB21");
            departmentB2.SubDepartments.Add(departmentB21);
            Department departmentB22 = new Department("departmentB22", "managerB22");
            departmentB2.SubDepartments.Add(departmentB22);

            //employees
            Employee employeeA = new Employee("employeeA");
            departmentA.Employees.Add(employeeA);
            Employee employeeB = new Employee("employeeB");
            departmentB.Employees.Add(employeeB);
            Employee employeeA1 = new Employee("employeeA1");
            departmentA1.Employees.Add(employeeA1);
            Employee employeeA2 = new Employee("employeeA2");
            departmentA2.Employees.Add(employeeA2);
            Employee employeeB1 = new Employee("employeeB1");
            departmentB1.Employees.Add(employeeB1);
            Employee employeeB2 = new Employee("employeeB2");
            departmentB2.Employees.Add(employeeB2);
            Employee employeeA11 = new Employee("employeeA11");
            departmentA11.Employees.Add(employeeA11);
            Employee employeeA12 = new Employee("employeeA12");
            departmentA12.Employees.Add(employeeA12);
            Employee employeeA21 = new Employee("employeeA21");
            departmentA21.Employees.Add(employeeA21);
            Employee employeeA22 = new Employee("employeeA22");
            departmentA22.Employees.Add(employeeA22);
            Employee employeeB11 = new Employee("employeeB11");
            departmentB11.Employees.Add(employeeB11);
            Employee employeeB12 = new Employee("employeeB12");
            departmentB12.Employees.Add(employeeB12);
            Employee employeeB21 = new Employee("employeeB21");
            departmentB21.Employees.Add(employeeB21);
            Employee employeeB22 = new Employee("employeeB22");
            departmentB22.Employees.Add(employeeB22);
        }

        public static Department Search(Department root, string departmentName)
        {
            if (root.Name.Equals(departmentName))
            {
                return root;
            }
            
            else
                foreach (var department in root.SubDepartments)
                {
                    if (department.Name.Equals(departmentName))
                    {
                        return department;
                    }
                    Search(department, departmentName);

                }

            return null;
        }


        static void Print(Department root)
        {
            foreach(var department in root.SubDepartments)
            {
                
                Console.WriteLine(department.Name);
                Print(department);
                
            }
        }
        
        static void AddSubDepartment(Department root, string departmentName)
        {
            var input = Search(root, departmentName);
            Console.WriteLine("department name");
            string nameInput = Console.ReadLine();
            Console.WriteLine("manager name");
            string managerNameInput = Console.ReadLine();
            input.SubDepartments.Add(new Department(nameInput, managerNameInput));
            Console.WriteLine("Sub Department added");
        }

        static void AddEmployee(Department root, string departmentName)
        {
            var input = Search(root, departmentName);
            Console.WriteLine("employee name");
            string nameInput = Console.ReadLine();
            input.Employees.Add(new Employee(nameInput));
            Console.WriteLine("Employee added");
        }

        static void RemoveDepartment(Department root, string departmentName)
        {
            var input = Search(root, departmentName);
            Console.WriteLine("name of the department");
            string nameInput = Console.ReadLine();
            foreach(var department in input.SubDepartments)
            {
                if (department.Name.Equals(nameInput))
                {
                    input.SubDepartments.Remove(department);
                    Console.WriteLine("Department removed");
                    break;
                }
            }
            
        }

        static void RemoveEmployee(Department root, string departmentName)
        {
            var input = Search(root, departmentName);
            Console.WriteLine("name of the employee");
            string nameInput = Console.ReadLine();
            foreach (var employee in input.Employees)
            {
                if (employee.FullName.Equals(nameInput))
                {
                    input.Employees.Remove(employee);
                    Console.WriteLine("Employee removed");
                    break;
                }
            }
        }

        static void MoveDepartment(Department root, string departmentName)
        {
            var input = Search(root, departmentName);
            Console.WriteLine("name of the department you want to move");
            string nameInput = Console.ReadLine();
            foreach(var department in input.SubDepartments)
            {
                if (department.Name.Equals(nameInput))
                {
                    var store = department;
                    input.SubDepartments.Remove(department);
                    Console.WriteLine("where to move");
                    departmentName = Console.ReadLine();
                    var destination = Search(root, departmentName);
                    destination.SubDepartments.Add(store);
                    Console.WriteLine("Department Moved");
                    break;
                }
            }
        }

        static void MoveEmployee(Department root, string departmentName)
        {
            var input = Search(root, departmentName);
            Console.WriteLine("name of the employee you want to move");
            string nameInput = Console.ReadLine();
            foreach (var employee in input.Employees)
            {
                if (employee.FullName.Equals(nameInput))
                {
                    var store = employee;
                    input.Employees.Remove(employee);
                    Console.WriteLine("where to move");
                    departmentName = Console.ReadLine();
                    var destination = Search(root, departmentName);
                    destination.Employees.Add(store);
                    Console.WriteLine("Employee Moved");
                    break;
                }
            }
        }

        static int CalculateEmployees(Department index, int result)
        {
            foreach(var department in index.SubDepartments)
            {
                result = department.Employees.Count() + CalculateEmployees(department, result);
                
            }
            return result;
        }
    }
}
