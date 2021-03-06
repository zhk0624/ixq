﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixq.Demo.Entities
{

    public class Test : EntityBaseInt32
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Name1 { get; set; }

        [StringLength(200)]
        public string Name2 { get; set; }

        [StringLength(200)]
        public string Name3 { get; set; }

        [StringLength(200)]
        public string Name4 { get; set; }

        public bool? BoolTest { get; set; }
        public bool BoolTestNotNull { get; set; }
        public decimal? DecimalTest { get; set; }

        public int IntegerTest { get; set; }

        public TestEnum1 TestEnum1 { get; set; }
        public TestEnum2 TestEnum2 { get; set; }

        public TimeSpan TestTimeSpan { get; set; }

    }

    public enum TestEnum1
    {
        男人,
        女人,
        程序员
    }
    [Flags]
    public enum TestEnum2
    {
        C = 1 << 0,
        CPlus = 1 << 1,
        Java = 1 << 2,
        CShapr = 1 << 3,
        Php = 1 << 4
    }
}
