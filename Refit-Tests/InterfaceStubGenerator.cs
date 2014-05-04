using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refit.Tests
{
    // * Find all calls to RestService.For<T>, extract all T's
    // * Search for all Interfaces, find the method definitions
    // * Generate the data we need for the template based on interface method 
    //   defn's
    //
    // What if the Interface is in another module? (fuck 'em)
    // What if the Interface itself is Generic? (fuck 'em)
    public class InterfaceStubGenerator
    {
    }

    public class InterfaceStubGeneratorTests
    {
    }
}
