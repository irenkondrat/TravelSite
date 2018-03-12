using System.Data.Entity.Validation;
using System.Text;

namespace Travel.BL.Exceptions
{
    static class DbEntityValidationExceptioErrorMessages
    {
        public static string ErrorMessages(DbEntityValidationException ex)
        {
            StringBuilder textError = new StringBuilder();
            foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
            {
                foreach (DbValidationError err in validationError.ValidationErrors)
                {
                    textError.Append(err.ErrorMessage + " ");
                }
            }
            return textError.ToString();
        }
    }
}
