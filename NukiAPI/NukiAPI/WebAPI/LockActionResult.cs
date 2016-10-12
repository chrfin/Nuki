using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukiAPI.WebAPI
{
    public class LockActionResult
    {
        public bool Success { get; set; }
        public bool BatteryCritical { get; set; }
    }
}