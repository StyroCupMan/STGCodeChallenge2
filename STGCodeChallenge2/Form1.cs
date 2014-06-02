using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STGCodeChallenge2
{
    public partial class Form1 : Form
    {
        protected string RomanNum;
        protected int RomanValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            bool isNegative = false;
            int cindx = 0;
            RomanNum =  txtRoman.Text.ToUpper().Trim();
            RomanValue = 0;

            // Assumptions:
            // According to modern rules, only one subtraction number is allowed (IX is valid IIX is not)
            // For simplicity I am going to assume valid input for the most part and just ignore illegal chars (assign value 0)

            // Check for 0
            if (string.IsNullOrWhiteSpace(RomanNum))
            {
                txtValue.Text = "0";
                return;
            }

            // Check for negative
            if (getChar(0) == '-')
            {
                isNegative = true;
                cindx = 1;
            }

            while (cindx < RomanNum.Length)
            {
                int val = getValue(getChar(cindx));
                int nextVal = getValue(getChar(cindx+1));
                // If the value of the char after the current one is greater, then we subtract the current char)
                if (nextVal > val)
                    RomanValue -= val;
                else
                    RomanValue += val;
                cindx++;
            }

            // If the whole thing was preceded by a minus, it was a negative number
            if (isNegative)
                RomanValue *= -1;

            txtValue.Text = RomanValue.ToString();
        }

        private char getChar(int cindx)
        {
            // Returns ' ' if we go past the end of the string
            if (cindx >= RomanNum.Length)
                return ' ';
            else
                return RomanNum[cindx];
        }

        private int getValue(char c)
        {
            switch (c)
            {
                case 'M': return 1000;
                case 'D': return 500;
                case 'C': return 100;
                case 'L': return 50;
                case 'X': return 10;
                case 'V': return 5;
                case 'I': return 1;
                default:
                    return 0;
            }
        }
    }
}
