using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvAddIn
{
    internal interface IBoltFactory
    {
        IBolt CreateBolt(double diameter, double length, double threadDepth, double threadPitch);
    }
}
