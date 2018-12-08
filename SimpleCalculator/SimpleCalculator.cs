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

        //铁律2:在每一个方法/变量 声明之时加注释, 说明用途
        double operandA = 0;    //操作数A
        double operandB = 0;    //操作数B

        //想要知道变量有什么用, 首先看在哪用了. Ctrl+F 呼出搜索/替换对话框
        bool blSomeFlag = false;    //首先, 其默认值是false, 也许,表示在初始化的时候,是某个东西的尚未操作的状态?
                                    //接下来考虑, 如果默认是false, 那么, 既然下面有判断它是true的情况下会如何如何的代码, 那么,他是在什么时候变成true的? 
                                    //搜索给它赋值的语句, 看哪个赋值语句让它变成true了.
                                    //这个时候你就知道变量名称有多重要了, 如果按照之前的, 变量名是c, 整篇代码下来有多少个c??? 那就是个灾难.
                                    //快捷键: Ctrl+K+D, 整理代码格式, 帮你对齐没对齐的括号大括号, 整理缩进
                                    //blSomeFlag = true   你用搜索功能搜索这个, (注意=左右的空格, 再区分一下"=="和"="的作用), 就会发现,  先别看下一行, 搜一下自己分析分析



            
        //只有在点击运算符号之后,才会变成true, 所以很显然, 这个东西的作用是判断是否已经点击了运算符




        string strOperator;     //字符串类型的变量, 代表操作符

        //课题1:上面这四个变量, 为什么要在这声明?提示:级别/作用范围



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
            string strNum = ((Button)sender).Text;  //好好想想这块是怎么回事?**极度重要**
                                                    //用类似的方法, 把运算符的写出来
            if (blSomeFlag == true)
            {
                txtDisplay.Text = "";
                blSomeFlag = false;
            }
            txtDisplay.Text += strNum;

            if (strOperator == "/" && strNum=="0")
            {
                txtDisplay.Clear();
                MessageBox.Show("除数不能为零", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #region 此标签用于手动折叠代码块
        ///// <summary>
        ///// 按钮1点击事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn1_Click(object sender, EventArgs e)  //课题2:搞明白这个object sender和EventArgs e是什么, 起什么作用. 提示:这几个单词什么意思?
        //                                                     //课题3:为什么点击了按钮1, 就会运行下面的代码?是如何绑定的?是如何触发的?还可以怎么写?提示:事件/事件处理
        //                                                     //课题4:如何知道点击之后的各个变量有什么变化?提示:"断点""调试""watch窗口"
        //{
        //    if (blSomeFlag == true)// 用注释写上这一段代码的逻辑是什么Start
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "1";// 用注释写上这一段代码的逻辑是什么End
        //}

        ///// <summary>
        ///// 试试删除这些灰色的注释, 再在方法的上一行连打三个///, 再在方法参数的个数名称不同的情况下试试
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn2_Click(object sender, EventArgs e)  //2
        //{
        //    if (blSomeFlag == true)

        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "2";
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn4_Click(object sender, EventArgs e)   //4
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "4";

        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn3_Click(object sender, EventArgs e)  //3
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "3";
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn5_Click(object sender, EventArgs e)  //5
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "5";
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn6_Click(object sender, EventArgs e)   //6
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "6";
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn7_Click(object sender, EventArgs e)  //7
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "7";
        //}



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn8_Click(object sender, EventArgs e)  //8
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "8";
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn9_Click(object sender, EventArgs e)  //9
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "9";
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btn0_Click(object sender, EventArgs e) // 0
        //{
        //    if (blSomeFlag == true)
        //    {
        //        txtDisplay.Text = "";
        //        blSomeFlag = false;
        //    }
        //    txtDisplay.Text += "0";

        //    if (strOperator == "/")
        //    {
        //        txtDisplay.Clear();
        //        MessageBox.Show("除数不能为零", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //}
        #endregion



        private void OperButton_Click(object sender, EventArgs e)
        {
            string strOper = ((Button)sender).Text;

            blSomeFlag = true;
            operandB = double.Parse(txtDisplay.Text);
            strOperator = strOper;
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEsc_Click(object sender, EventArgs e) // blSomeFlag
        {
            txtDisplay.Text = "";  
        }
        
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

        
        //if (e.KeyChar == '1')
        //    {
        //        button1.PerformClick();// 执行按钮“1”的操作
        //        e.Handled = true;
        //    }


        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void KeybordNumber_Load(object sender, KeyPressEventArgs e)
        {

        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
