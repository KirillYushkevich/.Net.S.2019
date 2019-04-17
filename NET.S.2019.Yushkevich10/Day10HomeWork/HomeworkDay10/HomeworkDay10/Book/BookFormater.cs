namespace Day10HomeWork
{
    using System;
    using System.Text;
    using HomeworkDay10;

    public class BookFormater : IFormatProvider, ICustomFormatter
    {
        ///<summary>Format given object with given format</summary>
        /// <param name="format">given format</param>
        /// <param name="arg">object to format</param>
        /// <param name="formatProvider">provider </param>
        /// <returns>string</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is Book)
            {
                StringBuilder sb = new StringBuilder();
                switch (format)
                {
                    case "T":
                        return ("Title:" + (arg as Book).Title + "\n");
                    case "A":
                        return("Author:" + (arg as Book).Author + "\n");
                    case "PB":
                       return("Publisher:" + (arg as Book).Publisher + "\n");
                    default:
                        sb.Append("Title:" + (arg as Book).Title + "\n");
                        sb.Append("Current Price" + (arg as Book).Price + "\n");
                        break;
                }

                return sb.ToString();
            }
            else
            {
                throw new Exception("Unsupportable format");
            }
        }

        public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;
    }
}