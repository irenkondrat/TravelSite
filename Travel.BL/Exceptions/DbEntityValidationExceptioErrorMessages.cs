using System.Data.Entity.Validation;
using System.Text;

namespace Kondrat.PracticeTask.Travel.BL.Exceptions
{
    static class DbEntityValidationExceptioErrorMessages
    {
        public static string ErrorMessages(DbEntityValidationException ex)
        {
            StringBuilder textError = new StringBuilder();
            foreach (var validationError in ex.EntityValidationErrors)
            {
                foreach (var err in validationError.ValidationErrors)
                {
                    textError.Append(err.ErrorMessage + " ");
                }
            }
            return textError.ToString();
        }
    }
}
