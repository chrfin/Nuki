using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukiAPI.WebAPI
{
    public enum LockState
    {
        Uncalibrated = 0,
        Locked = 1,
        UnlockedAndGo = 2,
        Unlocked = 3,
        Unlatched = 4,
        Locking = 5,
        Unlocking = 6,
        Unlatching = 7,
        MotorBlocked = 254,
        Undefined = 255
    }
}