using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.Custom
{
    /// <summary>
    /// Custom TextBox allows enter data type of Number
    /// </summary>
    public class CustomTextBox : TextBox
    {
        public CustomTextBox() { }

        public TypeTextBox TypeTextBox { get; set; } = TypeTextBox.Int;

        //Handling when changing data
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            Regex regex;
            var value = Text;
            switch (TypeTextBox)
            {
                case TypeTextBox.Int:
                    regex = new Regex(@"\D");
                    value = regex.Replace(value, "");
                    int.TryParse(value, out int intValue);
                    Text = intValue.ToString();
                    this.SelectionStart = Text.Length;
                    break;
                    // need view again double
                case TypeTextBox.Double:
                    regex = new Regex(@"[^.]?[\D]*");
                    value = regex.Replace(value, "");
                    double.TryParse(value, out var doubleValue);
                    Text = doubleValue.ToString();
                    this.SelectionStart = Text.Length;
                    break;
                case TypeTextBox.Text:
                    break;
                default:
                    break;
            }
        }

    }

    public enum TypeTextBox { Int, Double, Text}
}
