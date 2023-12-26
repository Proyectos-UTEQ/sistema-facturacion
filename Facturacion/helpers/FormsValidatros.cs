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
            else
            {
                label.ForeColor = System.Drawing.Color.Blue;
                return true;
            }
        }

        public static bool IsTextLength(TextBox textBox, Label label, int length, int minLength = 6)
        {
            if (textBox.Text.Length < minLength)
            {
                label.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else if (textBox.Text.Length > minLength - 1)
            {
                label.ForeColor = System.Drawing.Color.Blue;
                return true;
            }

            return true;
        }

        public static bool IsTextPrecio(TextBox textBox, Label label)
        {
            string pattern = @"^[0-9]+(\,[0-9]+)?$";

            if (string.IsNullOrWhiteSpace(textBox.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, pattern))
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

        public static bool IsNumero(Label lblTotal, string text)
        {

            // generear expresion regular para saber si es un numero
            string pattern = @"^[0-9]+(\,[0-9]+)?$";
            // si no es un numero que el label sea rojo y devuelva false para que no se pueda aceptar
            if (string.IsNullOrWhiteSpace(text) || !Regex.IsMatch(text, pattern))
            {
                lblTotal.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                lblTotal.ForeColor = System.Drawing.Color.Blue;
                return true;
            }
        }
    }
}
