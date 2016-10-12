using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukiAPI.WebAPI
{
    public enum LockAction
    {
        Unlock = 1,
        Lock = 2,
        Unlatch = 3,
        LockNGo = 4,
        LockNGoWithUnlatch = 5
    }
}