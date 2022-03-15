using System;
using System.Collections.Generic;

#nullable disable

namespace StudentRegister.Server.Models
{
    public partial class StudentMaster
    {
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
