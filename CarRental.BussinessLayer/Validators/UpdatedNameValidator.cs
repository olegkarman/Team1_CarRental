using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Validation
{
    internal class UpdatedNameValidator
    {
        // FIELDS

        private const string _defaultPattern = @"([^a-zA-z\s\'\-])|(\b\s+\b)|(\`)|((\'|\-){2,})|(\s(\'|\-))|((\'|\-)\s)|((\'|\-)$)|(^(\'|\-))|(_)";
        private const int _defaultTimeSpan = 500;
        private Regex _regExpr;
        private string _pattern;
        

        // PROPERTIES

        // CONSTRUCTORS

        public UpdatedNameValidator()
        {
        
        }

        public UpdatedNameValidator(string pattern)
        {
            this._pattern = pattern;
            this._regExpr = new Regex(pattern);
        }

        // METHODS

        public bool ValidateNameDefault(string name)
        {
            bool isNameMatch = Regex.IsMatch(name, _defaultPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(_defaultTimeSpan));

            if ((string.IsNullOrEmpty(name)) || !(ValidateNameLengthDefault(name)) || isNameMatch)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateNameLengthDefault(string name)
        {
            if ((name.Length == 0) || (name.Length < 3) || (name.Length > 100))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
