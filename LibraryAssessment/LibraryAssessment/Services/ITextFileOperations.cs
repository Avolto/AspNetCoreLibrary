using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssessment.Services
{
    public interface ITextFileOperations
    {
        IEnumerable<string> LoadConditionsForAcceptanceText();
    }
}
