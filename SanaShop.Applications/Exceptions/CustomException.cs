using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SanaShop.Applications.Exceptions
{
    public class CustomException : Exception
    {
        #region Properties

        public int? StatusCode { get; }

        #endregion Properties

        #region Constructors
        public CustomException(string? message) : base(message)
        {
        }

        public CustomException(int statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomException(int statusCode, string? message, Exception? innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public CustomException(string? message, Exception innerException) : base(message, innerException)
        {
        }
        #endregion Constructeurs

        #region Méthodes Statiques
        public static CustomException Format(CustomErrorEnum customErrorEnum, params object[] values)
        {
            return new CustomException(String.Format(customErrorEnum.ShowError(), values));
        }

        public static CustomException Format(int statusCode, CustomErrorEnum customErrorEnum, params object[] values)
        {
            return new CustomException(statusCode, String.Format(customErrorEnum.ShowError(), values));
        }

        public static CustomException Format(Exception innerException, CustomErrorEnum customErrorEnum, params object[] values)
        {
            return new CustomException(String.Format(customErrorEnum.ShowError(), values), innerException);
        }

        public static CustomException Format(Exception innerException, int statusCode, CustomErrorEnum customErrorEnum, 
            params object[] values)
        {
            return new CustomException(statusCode, String.Format(customErrorEnum.ShowError(), values), innerException);
        }

        public static CustomException Error400(params object[] values)
        {
            return values.Length != 0
                ? Format(400, CustomErrorEnum.CUSTOM_400_WITH_CAUSE, values)
                : Format(400, CustomErrorEnum.CUSTOM_400);
        }
        #endregion Méthodes Statiques
    }
}
