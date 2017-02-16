using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FooBarWeb.Models;

namespace FooBarWeb.ViewModels
{
    public class FooBar
    {
        public IEnumerable<Foo> Foos { get; set; }
        public IEnumerable<Bar> Bars { get; set; }
        public Foo foo { get; set; }

    }
}