﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemDomain.Entity
{
    public class Login : Registration
    {
        public Login() { }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
