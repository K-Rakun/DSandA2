using System;
using System.Collections.Generic;
using System.Text;

namespace DSandA2Assignment1
{
    class Department
    {
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Department> SubDepartments{ get; set; }

        public Department(string name, string managerName)
        {
            Name = name;
            ManagerName = managerName;
            Employees = new List<Employee>();
            SubDepartments = new List<Department>();
        }
    }
}
