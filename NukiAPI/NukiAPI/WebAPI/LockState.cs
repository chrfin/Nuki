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
        Unlocking = 2,
        Unlocked = 3,
        Locking = 4,
        Unlatched = 5,
        UnlockedAndGo = 6,
        Unlatching = 7,
        MotorBlocked = 254,
        Undefined = 255
    }
}