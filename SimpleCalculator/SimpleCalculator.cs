using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class SimpleCalculator : Form
    {

        double operandA = 0;    //操作数A
        double operandB = 0;    //操作数B
        bool blSomeFlag = false;    //判断是否已经点击了运算符
        string strOperator;     //字符串类型的变量, 代表操作符

        public SimpleCalculator()           //这是干啥用的?在哪用了?
        {
            InitializeComponent();
        }


        /// <summary>
        /// 数字按钮点击事件
        /// </summary>
        /// <param name="sender">调用此事件的对象,此时是0-9,10个数字</param>
        /// <param name="e">发生的是什么事件</param>
        private void NumberButton_Click(object sender, EventArgs e)
        {
            NumberButton_ClickOrPress(((Button)sender).Text);
        }



        /// <summary>
        /// 数字按钮点击事件
        /// </summary>
        /// <param name="sender">调用此事件的对象,此时是0-9,10个数字</param>
        /// <param name="e">发生的是什么事件</param>
        private void NumberButton_ClickOrPress(string strNum)
        {
            if (blSomeFlag == true)
            {
                txtDisplay.Text = "";
                blSomeFlag = false;
            }
            txtDisplay.Text += strNum;

            if (strOperator == "/" && strNum == "0")
            {
                txtDisplay.Clear();
                MessageBox.Show("除数不能为零", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }







        /// <summary>
        /// 运算符点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperButton_Click(object sender, EventArgs e)
        {
            string strOper = ((Button)sender).Text;

            blSomeFlag = true;
            operandB = double.Parse(txtDisplay.Text);
            strOperator = strOper;
        }


        /// <summary>
        /// Esc按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEsc_Click(object sender, EventArgs e) // blSomeFlag
        {
            txtDisplay.Text = "";
        }


        /// <summary>
        /// 窗体加载时的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleCalculator_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e) //=
        {
            switch (strOperator)
            {
                case "/":
                    operandA = operandB / double.Parse(txtDisplay.Text);
                    break;//感受一下两种格式的不同, 你觉得哪一种看起来更清爽?

                case "+":
                    operandA = operandB + double.Parse(txtDisplay.Text);
                    break;

                case "*":
                    operandA = operandB * double.Parse(txtDisplay.Text);
                    break;

                case "-":
                    operandA = operandB - double.Parse(txtDisplay.Text);
                    break;

                case "square":
                    operandA = operandB * double.Parse(txtDisplay.Text);
                    break;

                case "sqrt":
                    operandA = Math.Sqrt(operandB);
                    break;

            }
            txtDisplay.Text = operandA + "";
            blSomeFlag = true;
        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case '1':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '2':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '3':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '4':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '5':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '6':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '7':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '8':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '9':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '0':
                    NumberButton_ClickOrPress(e.KeyChar.ToString());
                    break;
                case '+':
                    btnOperAdd.PerformClick();
                    break;
                case '-':
                    btnOperSubtract.PerformClick();
                    break;
                case '*':
                    btnOperMultiply.PerformClick();
                    break;
                case '/':
                    btnOperDevide.PerformClick();
                    break;
                case 'C':
                    btnEsc.PerformClick();
                    break;
                case '=':
                    btnCalculate.PerformClick();
                    break;
                    //square sqrt 没能实现，因为单引号里只能容纳1个字符，sqrt已经4个了
                    // 要是把按钮名改为一个字，也不现实，开方也不能只写个‘开’吧
                    //没来得及实现全局监控，光标点进去输入栏才能输入，应该是keypress局限性
                    //涉及到开方平方只能手动计算了，现在这么写很笨，明天实现一下重写

            }
            e.Handled = true;
        }

    }
}
