﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FruitStocker.Model
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
