using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public String EmployeeCode { get; set; }
        public String FullName { get; set; }
        public String Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public Guid DepartmentId { get; set; }
        public String DepartmentName { get; set; }
        public String PositionName { get; set; }
        public String IdentifyNumber { get; set; }
        public DateTime IdentifyDate { get; set; }
        public String IdentifyPlace { get; set; }
        public String MobilePhone { get; set; }
        public String LandlinePhone { get; set; }
        public String Email { get; set; }
        public String BankNumber { get; set; }
        public String BankName { get; set; }
        public String BankBranch { get; set; }
        public String BankPlace { get; set; }
        public int Status { get; set; }

    }
}
