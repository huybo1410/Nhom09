﻿using MessagePack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Nhom09.Models
{
    public class admin
    {
        
        public int Id { get; set; }

        public string Admin_name { get; set; }

        public bool Sex { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
