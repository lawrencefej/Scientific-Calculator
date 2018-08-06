using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorLibrary;


namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        Calculation calc = new Calculation();
        double firstNumber = 0;
        string operation = "";
        bool operation_pressed = false;
        bool equals_pressed = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (equals_pressed)
            {
                result.Text = "0";
            }
            if ((result.Text == "0") || (operation_pressed))
                result.Clear();

            operation_pressed = false;
            Button b = (Button)sender;
            if (b.Text == ".")
            {
                if (!result.Text.Contains("."))
                {
                    result.Text = result.Text + b.Text;
                }
            }
            else
            {
                result.Text = result.Text + b.Text;
            }
            equals_pressed = false;

        }

        private void clearEntry_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            firstNumber = 0;
            equation.Text = "";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (firstNumber != 0)
            {
                equals.PerformClick();
                operation = b.Text;
                //firstNumber = double.Parse(result.Text);
                operation_pressed = true;
                equation.Text = firstNumber + " " + operation;

            }
            else
            {
                operation = b.Text;
                firstNumber = double.Parse(result.Text);
                operation_pressed = true;
                equation.Text = firstNumber + " " + operation;
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            

            //result.Text = "";
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    result.Text = calc.Add(firstNumber, double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = calc.Subtract(firstNumber, double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = calc.Multiply(firstNumber, double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = calc.Divide(firstNumber, double.Parse(result.Text)).ToString();
                    break;
                case "x²":
                    result.Text = calc.Power(firstNumber, double.Parse(result.Text)).ToString();
                    break;
                case "sqrt":
                    result.Text = calc.SquareRoot(double.Parse(result.Text)).ToString();
                    break;
                case "sin":
                    result.Text = calc.sine(double.Parse(result.Text)).ToString();
                    break;
                case "cos":
                    result.Text = calc.Cosine(double.Parse(result.Text)).ToString();
                    break;
                case "tan":
                    result.Text = calc.Tangent(double.Parse(result.Text)).ToString();
                    break;
                case "log":
                    result.Text = calc.Logarithm(double.Parse(result.Text)).ToString();
                    break;
                case "!":
                    result.Text = calc.Factorial(double.Parse(result.Text)).ToString();
                    break;
                case "Mod":
                    result.Text = calc.Modulus(firstNumber, double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            } //end switch
            firstNumber = double.Parse(result.Text);
            operation = "";
            equals_pressed = true;
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch (e.KeyChar.ToString())
            //{
            //    case "0":
            //        zero.PerformClick();
            //        break;
            //    case "1":
            //        one.PerformClick();
            //        break;
            //    case "2":
            //        two.PerformClick();
            //        break;
            //    case "3":
            //        three.PerformClick();
            //        break;
            //    case "4":
            //        four.PerformClick();
            //        break;
            //    case "5":
            //        five.PerformClick();
            //        break;
            //    case "6":
            //        six.PerformClick();
            //        break;
            //    case "7":
            //        seven.PerformClick();
            //        break;
            //    case "8":
            //        eight.PerformClick();
            //        break;
            //    case "9":
            //        nine.PerformClick();
            //        break;
            //    case "+":
            //        add.PerformClick();
            //        break;
            //    case "-":
            //        subtract.PerformClick();
            //        break;
            //    case "*":
            //        multiply.PerformClick();
            //        break;
            //    case "/":
            //        divide.PerformClick();
            //        break;
            //    case ".":
            //        dec.PerformClick();
            //        break;
            //    case "=":
            //        equals.PerformClick();
            //        break;

            //    default:
            //        break;
            //}
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (result.Text.Length > 0)
            {
                result.Text = result.Text.Remove(result.Text.Length - 1, 1);
            }
            if (result.Text == "")
            {
                result.Text = "0";
            }
        }

        private void singleOp_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            equation.Text = "";
            //firstNumber = double.Parse(result.Text);
            operation = b.Text;
            equation.Text = firstNumber + " " + operation;
            equals.PerformClick();
        }

        private void Pi_Click(object sender, EventArgs e)
        {
            result.Text = (Math.PI).ToString();
        }
    }
}
 