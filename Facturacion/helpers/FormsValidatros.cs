using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.helpers
{
    public class FormsValidatros
    {
        public static bool IsEmpty(string value)
        {
            return value.Trim().Length == 0;
        }

        public static bool IsNumeric(string value)
        {
            int number;
            return int.TryParse(value, out number);
        }

        public static bool IsDecimal(string value)
        {
            decimal number;
            return decimal.TryParse(value, out number);
        }

        public static bool IsEmail(string value)
        {
            return value.Contains("@");
        }

        public static bool IsDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }

        public static bool IsCedula(string value)
        {
            return value.Length == 11;
        }

        public static bool IsNumeroLength(TextBox textBox, Label label, int length)
        {
            Regex regex = new Regex(@"^[0-9]{" + length + "}$");
            if (!regex.IsMatch(textBox.Text))
            {
                label.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                label.ForeColor = System.Drawing.Color.Blue;
                return true;
            }
        }

        public static bool IsRNC(string value)
        {
            return value.Length == 9;
        }

        public static bool IsCedula(TextBox textBox, Label label)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            if (!regex.IsMatch(textBox.Text))
            {
                label.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else { 
                label.ForeColor = System.Drawing.Color.Blue;
                return true;
            }
        }

        public static bool IsTextLength(TextBox textBox, Label label, int length)
        {
            if (textBox.Text.Length < 6)
            {
                label.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (textBox.Text.Length > 5)
            {
                label.ForeColor = System.Drawing.Color.Blue;
                return true;
            }

            return true;
        }

    }
}
