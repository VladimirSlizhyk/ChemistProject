﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.Core
{
    public class MainEntity<T>:Entity
    {
        public T Id { get; set; }
    }
}
