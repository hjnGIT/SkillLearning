namespace SimpleCalculator
{
    partial class SimpleCalculator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btnOperAdd = new System.Windows.Forms.Button();
            this.btnOperSubtract = new System.Windows.Forms.Button();
            this.btnOperMultiply = new System.Windows.Forms.Button();
            this.btnOperDevide = new System.Windows.Forms.Button();
            this.btnEsc = new System.Windows.Forms.Button();
            this.btnOperSqr = new System.Windows.Forms.Button();
            this.btnOperSqrRoot = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(24, 191);
            this.btn1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 50);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.NumberButton_Click);
            this.btn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btn1_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(51, 66);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(300, 25);
            this.txtDisplay.TabIndex = 2;
            this.txtDisplay.TextChanged += new System.EventHandler(this.txtDisplay_TextChanged);
            this.txtDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(155, 191);
            this.btn2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 50);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(24, 264);
            this.btn4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(100, 50);
            this.btn4.TabIndex = 5;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btnOperAdd
            // 
            this.btnOperAdd.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOperAdd.Location = new System.Drawing.Point(445, 191);
            this.btnOperAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperAdd.Name = "btnOperAdd";
            this.btnOperAdd.Size = new System.Drawing.Size(100, 50);
            this.btnOperAdd.TabIndex = 12;
            this.btnOperAdd.Text = "+";
            this.btnOperAdd.UseVisualStyleBackColor = false;
            this.btnOperAdd.Click += new System.EventHandler(this.OperButton_Click);
            // 
            // btnOperSubtract
            // 
            this.btnOperSubtract.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOperSubtract.Location = new System.Drawing.Point(445, 248);
            this.btnOperSubtract.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperSubtract.Name = "btnOperSubtract";
            this.btnOperSubtract.Size = new System.Drawing.Size(100, 50);
            this.btnOperSubtract.TabIndex = 13;
            this.btnOperSubtract.Text = "-";
            this.btnOperSubtract.UseVisualStyleBackColor = false;
            this.btnOperSubtract.Click += new System.EventHandler(this.OperButton_Click);
            // 
            // btnOperMultiply
            // 
            this.btnOperMultiply.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOperMultiply.Location = new System.Drawing.Point(445, 302);
            this.btnOperMultiply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperMultiply.Name = "btnOperMultiply";
            this.btnOperMultiply.Size = new System.Drawing.Size(100, 50);
            this.btnOperMultiply.TabIndex = 14;
            this.btnOperMultiply.Text = "*";
            this.btnOperMultiply.UseVisualStyleBackColor = false;
            this.btnOperMultiply.Click += new System.EventHandler(this.OperButton_Click);
            // 
            // btnOperDevide
            // 
            this.btnOperDevide.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOperDevide.Location = new System.Drawing.Point(445, 359);
            this.btnOperDevide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperDevide.Name = "btnOperDevide";
            this.btnOperDevide.Size = new System.Drawing.Size(100, 50);
            this.btnOperDevide.TabIndex = 15;
            this.btnOperDevide.Text = "/";
            this.btnOperDevide.UseVisualStyleBackColor = false;
            this.btnOperDevide.Click += new System.EventHandler(this.OperButton_Click);
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEsc.Location = new System.Drawing.Point(573, 191);
            this.btnEsc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(100, 50);
            this.btnEsc.TabIndex = 16;
            this.btnEsc.Text = "C";
            this.btnEsc.UseVisualStyleBackColor = false;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btnOperSqr
            // 
            this.btnOperSqr.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOperSqr.Location = new System.Drawing.Point(573, 248);
            this.btnOperSqr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperSqr.Name = "btnOperSqr";
            this.btnOperSqr.Size = new System.Drawing.Size(100, 50);
            this.btnOperSqr.TabIndex = 17;
            this.btnOperSqr.Text = "square";
            this.btnOperSqr.UseVisualStyleBackColor = false;
            this.btnOperSqr.Click += new System.EventHandler(this.OperButton_Click);
            // 
            // btnOperSqrRoot
            // 
            this.btnOperSqrRoot.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOperSqrRoot.Location = new System.Drawing.Point(573, 302);
            this.btnOperSqrRoot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperSqrRoot.Name = "btnOperSqrRoot";
            this.btnOperSqrRoot.Size = new System.Drawing.Size(100, 50);
            this.btnOperSqrRoot.TabIndex = 18;
            this.btnOperSqrRoot.Text = "sqrt";
            this.btnOperSqrRoot.UseVisualStyleBackColor = false;
            this.btnOperSqrRoot.Click += new System.EventHandler(this.OperButton_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCalculate.Location = new System.Drawing.Point(688, 191);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 50);
            this.btnCalculate.TabIndex = 19;
            this.btnCalculate.Text = "=";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(285, 191);
            this.btn3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(100, 50);
            this.btn3.TabIndex = 4;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(155, 398);
            this.btn0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(100, 50);
            this.btn0.TabIndex = 11;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(285, 264);
            this.btn6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(100, 50);
            this.btn6.TabIndex = 7;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(24, 332);
            this.btn7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(100, 50);
            this.btn7.TabIndex = 8;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(155, 332);
            this.btn8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(100, 50);
            this.btn8.TabIndex = 9;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(285, 332);
            this.btn9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(100, 50);
            this.btn9.TabIndex = 10;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(155, 264);
            this.btn5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(100, 50);
            this.btn5.TabIndex = 6;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // SimpleCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnOperSqrRoot);
            this.Controls.Add(this.btnOperSqr);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnOperDevide);
            this.Controls.Add(this.btnOperMultiply);
            this.Controls.Add(this.btnOperSubtract);
            this.Controls.Add(this.btnOperAdd);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btn1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SimpleCalculator";
            this.Text = "SimpleCalculator";
            this.Load += new System.EventHandler(this.SimpleCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //铁律1:为每一个使用到的控件(窗体,按钮, 文本框,以及所有),起一个一目了然的简易易懂的名字,使用名词.
        //一旦发现有更好的名字,立刻替换.

        //Designer中的代码, 是自动生成的,只关注你可控的部分.
        //不认识的,暂时不用理会.
        //Designer中的代码, 原则上说不应该手动修改.
        //设计器中的代码是根据前台画面自动生成的，告诉后台这个界面长什么样，告诉计算机把这个画面画成什么样

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        //数字0
        private System.Windows.Forms.Button btn0;

        //数字1
        private System.Windows.Forms.Button btn1;

        //数字2
        private System.Windows.Forms.Button btn2;

        //数字3
        private System.Windows.Forms.Button btn3;

        //数字4
        private System.Windows.Forms.Button btn4;

        //数字5
        private System.Windows.Forms.Button btn5;
        
        //数字6
        private System.Windows.Forms.Button btn6;

        //数字7
        private System.Windows.Forms.Button btn7;

        //数字8
        private System.Windows.Forms.Button btn8;

        //数字9
        private System.Windows.Forms.Button btn9;

        //用来显示输入及结果的文本框
        private System.Windows.Forms.TextBox txtDisplay;
        
        //操作符+
        private System.Windows.Forms.Button btnOperAdd;

        //操作符-
        private System.Windows.Forms.Button btnOperSubtract;

        //操作符*
        private System.Windows.Forms.Button btnOperMultiply;


        //操作符/
        private System.Windows.Forms.Button btnOperDevide;

        //清空按钮
        private System.Windows.Forms.Button btnEsc;


        //操作符平方
        private System.Windows.Forms.Button btnOperSqr;


        //操作符开方
        private System.Windows.Forms.Button btnOperSqrRoot;

        //计算结果
        private System.Windows.Forms.Button btnCalculate;
    }
}

