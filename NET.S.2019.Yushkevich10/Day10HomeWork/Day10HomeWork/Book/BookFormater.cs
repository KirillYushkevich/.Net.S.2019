namespace Day10HomeWork
{
    using System;
    using System.Text;
    using HomeworkDay10;

    public class BookFormater : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is Book)
            {
                StringBuilder sb = new StringBuilder();
                switch (format)
                {
                    case "T":
                        sb.Append("Title:" + (arg as Book).Title + "\n");
                        break;
                    case "A":
                        sb.Append("Author:" + (arg as Book).Author + "\n");
                        break;
                    case "PB":
                        sb.Append("Publisher:" + (arg as Book).Publisher + "\n");
                        break;
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