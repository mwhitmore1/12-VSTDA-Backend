using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSTDA_Backend.API.Models
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
    }
}