using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageEntities
{
   

        public class AddGarageDto
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }
            public int ZipCode { get; set; }
            public string Type { get; set; }
            public string Manager { get; set; }
        }
    }

