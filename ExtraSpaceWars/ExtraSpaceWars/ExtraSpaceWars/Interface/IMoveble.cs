using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;

namespace ExtraSpaceWars.Interface
{
    interface IMoveble
    {
        int PositionX();

        int PositionY();
    }
}
