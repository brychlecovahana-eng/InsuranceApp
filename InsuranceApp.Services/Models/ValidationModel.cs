using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceApp.Services.Models
{
    public class ValidationModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public ValidationModel()
        {

        }

        public ValidationModel(bool isValid, string messege)
        {
            this.IsValid = isValid;
            this.Message = messege;
        }
    }
}
