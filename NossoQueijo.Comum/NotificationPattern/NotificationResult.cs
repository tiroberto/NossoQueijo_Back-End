using System;
using System.Collections.Generic;
using System.Linq;

namespace NossoQueijo.Comum.NotificationPattern
{
    public class NotificationResult
    {
        private readonly List<NotificationError> _errors;
        private string _message;

        public string Message
        {
            get
            {
                _errors.ForEach(f => _message += f.Message);
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        public dynamic Result { get; set; }

        public bool HasResult => Result != null;

        public bool IsValid => _errors.Any() == false;

        public int Status => Convert.ToInt32(IsValid);

        public object AsJson => new { status = Status, message = Message };

        public object AsJsonWithResult => new { status = Status, message = Message, hasResult = HasResult, result = Result };

        public List<NotificationError> Errors => _errors;

        public NotificationResult()
        {
            _errors = new List<NotificationError>();
        }

        public NotificationResult(List<NotificationError> errors) : this()
        {
            _errors = errors;
        }

        public NotificationResult Add(string message)
        {
            _message = message;
            return this;
        }

        public NotificationResult Add(NotificationError error)
        {
            _errors.Add(error);
            return this;
        }

        public NotificationResult Add(params NotificationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _errors.AddRange(result.Errors);

            return this;
        }

        public NotificationResult Remove(NotificationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
            return this;
        }

    }
}
