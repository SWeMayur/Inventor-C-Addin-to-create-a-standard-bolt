using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvAddIn
{
    /// <summary>
    /// Represents an interface for creating instances of bolts through a factory pattern.
    /// </summary>
    internal interface IBoltFactory
    {
        /// <summary>
        /// Creates a new bolt with the specified properties.
        /// </summary>
        /// <param name="diameter">The diameter of the bolt.</param>
        /// <param name="length">The length of the bolt.</param>
        /// <param name="threadDepth">The thread depth of the bolt.</param>
        /// <param name="threadPitch">The thread pitch of the bolt.</param>
        /// <returns>An instance of <see cref="IBolt"/>.</returns>
        IBolt CreateBolt(double diameter, double length, double threadDepth, double threadPitch);
    }
}
