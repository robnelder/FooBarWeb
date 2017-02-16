using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace FooBarWeb.Models
{
    public class Foo
    {
        public int FooID { get; set; }
        [DisplayName("Foo Name")]
        public string FooName { get; set; }
    }
}