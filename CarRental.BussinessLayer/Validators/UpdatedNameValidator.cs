using System.Text.RegularExpressions;

namespace CarRental.BussinessLayer.Validators
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

        public bool CheckNullEmpty(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public void CheckNullEmpty(string name, string customerId)
        {
            if (CheckNullEmpty(name) || CheckNullEmpty(customerId))
            {
                throw new ArgumentNullException(nameof(name) + "/" + nameof(customerId));
            }
        }

        public bool ValidateNameLengthDefault(string name)
        {
            if ((name.Length < 3) || (name.Length > 100))
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
