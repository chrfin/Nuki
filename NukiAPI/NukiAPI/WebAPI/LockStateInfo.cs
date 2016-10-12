using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukiAPI.WebAPI
{
    public class LockStateInfo
    {
        public LockState State { get; set; }
        public string StateName { get; set; }
        public bool BatteryCritical { get; set; }
        public bool Success { get; set; }
    }
}