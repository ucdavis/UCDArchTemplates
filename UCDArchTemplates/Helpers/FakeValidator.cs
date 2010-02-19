using System.Collections.Generic;
using System.Linq;
using UCDArch.Core.CommonValidator;

namespace UCDArchTemplates.Helpers
{
    public class FakeValidator : IValidator
    {
        public bool IsValid(object value)
        {
            return false;
        }

        public ICollection<IValidationResult> ValidationResultsFor(object value)
        {
            return Enumerable.Empty<IValidationResult>().ToList();
        }
    }
}