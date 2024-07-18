using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CarRental.Presentation.Managers;

public class AssemblyManager
{
    // METHODS

    public void LoadAssembly(string assemblyName)
    {
        Assembly.Load(assemblyName);
    }

    public Assembly GetAssemblyByNameFromAppDomain(string assemblyName)
    {
        Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(x => x.GetName().Name == assemblyName);

        return assembly;
    }
}
