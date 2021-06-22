using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebApp.DAL.DBO
{
    public class Branch
    {
        public int Id { get; set; }

        [DisplayName("Branch Name")]
        public string Name { get; set; }
    }
}
