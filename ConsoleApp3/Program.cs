using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            ///使用ForEach获取列表中某个字段值
            List<Employee> employeeList = GetEmployeeList();  //获取员工信息列表   
            string empNames = "";                             //员工名称字段 
            employeeList.ForEach(a => empNames += a.EmployeeName + ",");
            empNames = empNames.TrimEnd(',');
            Console.WriteLine(empNames);                     //输出：张三,李四,王五 

            var s = employeeList.Select(u => new Employee { DepartmentId = u.DepartmentId, EmployeeName = u.EmployeeName });
            foreach (var item in s)
            {
                Console.WriteLine(item.DepartmentId+item.EmployeeName);
            }
            JoinDepartmentList();
        }


        /// <summary>   
        /// 使用ForEach将部门列表与员工列表关联  
        /// </summary>    
        public static void JoinDepartmentList()
        {
            List<Department> departmentList = GetDepartmentList();   //获取部门信息列表   
            List<Employee> emplayeeList = GetEmployeeList();         //获取员工信息列表   

            foreach (var item in departmentList)
            {
                // item.
            }

            departmentList.ForEach(a => a.EmployeeList = emplayeeList.Where(e => e.DepartmentId == a.DepartmentId).ToList());

            //使用ForEach输入结果 
            departmentList.ForEach(a => Console.WriteLine(String.Format("{0}:员工数量：{1}", a.DepartmentName, a.EmployeeList.Count)));
        }

        /// <summary>   
        /// 获取员工信息列表   
        /// </summary>   
        /// <returns></returns>   
        public static List<Employee> GetEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();
            Employee emplayee1 = new Employee() { EmployeeName = "张三", DepartmentId = 1, };
            Employee emplayee2 = new Employee() { EmployeeName = "李四", DepartmentId = 2, };
            Employee emplayee3 = new Employee() { EmployeeName = "王五", DepartmentId = 2, };
            employeeList.Add(emplayee1);
            employeeList.Add(emplayee2);
            employeeList.Add(emplayee3);
            return employeeList;
        }

        /// <summary>   
        /// 获取部门信息列表   
        /// </summary>   
        /// <returns></returns>   
        public static List<Department> GetDepartmentList()
        {
            List<Department> departmentList = new List<Department>();
            Department department1 = new Department() { DepartmentId = 1, DepartmentName = "研发部" };
            Department department2 = new Department() { DepartmentId = 2, DepartmentName = "人事部" };
            Department department3 = new Department() { DepartmentId = 3, DepartmentName = "财务部" };
            departmentList.Add(department1);
            departmentList.Add(department2);
            departmentList.Add(department3);
            return departmentList;
        }
    }

    /// <summary>   
    /// 部门信息类   
    /// </summary>   
    public class Department
    {
        /// <summary>   
        /// 部门ID   
        /// </summary>   
        public int DepartmentId { get; set; }

        /// <summary>   
        /// 部门名称   
        /// </summary>   
        public string DepartmentName { get; set; }

        /// <summary> 
        /// 员工列表 
        /// </summary> 
        public List<Employee> EmployeeList { get; set; }
    }

    /// <summary>   
    /// 员工信息类   
    /// </summary>   
    public class Employee
    {
        /// <summary>   
        /// 员工姓名   
        /// </summary>   
        public string EmployeeName { get; set; }

        /// <summary>   
        /// 部门ID   
        /// </summary>   
        public int DepartmentId { get; set; }
    }

}
