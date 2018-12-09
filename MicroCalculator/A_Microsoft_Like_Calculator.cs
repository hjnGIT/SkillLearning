/*
 
 author: TLSLT
 Data: 2007.10.21
 Company: 大连IT产业国际交流协会  
 
 */
#region using System
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;                                               //使用栈所必需的集合类
using System.Text.RegularExpressions;                                   //字符串所需的操作,比如某字符串中是否有某子串,及其个数;正则表达式亦要使用
//using System.Web;
//using System.Web.UI;                                                  //设置焦点所用命名空间
#endregion

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        public Stack numStack = new Stack();                            //声明数字栈
        public Stack operStack = new Stack();                           //声明符号栈
        public Stack mStack = new Stack();                              //声明寄存器栈

        bool operFlag = false;                                          //声明运算符的Flag,用来判断是否已点击运算符
        bool dotFlag = false;                                           //声明小数点的Flag,用来判断是否已点击小数点
        bool enterFlag = false;                                         //声明=（Enter）的Flag


        public frmCalculator()
        {
            InitializeComponent();
  
            operStack.Push("0"); 
            /*
             * 不能在方法外进行入栈操作
             * 且不能在operate_Click事件里入栈
             * （会每次点击符号的时候都加一个"0"进去，
             * 后续操作中会无法提取运算符运算，在初始化接口的时候会因找不到"0"所对应的方法而报错，因为只有+-* /的。
             * 故在此将"0"入符号栈内,并在之后比较运算符优先级时将其优先级设为最低
            */


        }


        #region 初始化组件
        private void InitializeComponent()
        {
            this.cancle_all = new System.Windows.Forms.Button();
            this.backspace = new System.Windows.Forms.Button();
            this.cancle_last = new System.Windows.Forms.Button();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_c = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_v = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.text_display = new System.Windows.Forms.TextBox();
            this.no_0 = new System.Windows.Forms.Button();
            this.dot = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.Button();
            this.operate_div = new System.Windows.Forms.Button();
            this.operate_ride = new System.Windows.Forms.Button();
            this.operate_dec = new System.Windows.Forms.Button();
            this.operate_add = new System.Windows.Forms.Button();
            this.flowLayoutPanel_numbers = new System.Windows.Forms.FlowLayoutPanel();
            this.no_7 = new System.Windows.Forms.Button();
            this.no_8 = new System.Windows.Forms.Button();
            this.no_9 = new System.Windows.Forms.Button();
            this.no_4 = new System.Windows.Forms.Button();
            this.no_5 = new System.Windows.Forms.Button();
            this.no_6 = new System.Windows.Forms.Button();
            this.no_1 = new System.Windows.Forms.Button();
            this.no_2 = new System.Windows.Forms.Button();
            this.no_3 = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.sqrt = new System.Windows.Forms.Button();
            this.reciprocal = new System.Windows.Forms.Button();
            this.percent = new System.Windows.Forms.Button();
            this.mc = new System.Windows.Forms.Button();
            this.mr = new System.Windows.Forms.Button();
            this.ms = new System.Windows.Forms.Button();
            this.mAdd = new System.Windows.Forms.Button();
            this.label_m = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.flowLayoutPanel_numbers.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancle_all
            // 
            this.cancle_all.BackColor = System.Drawing.Color.White;
            this.cancle_all.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancle_all.ForeColor = System.Drawing.Color.Red;
            this.cancle_all.Location = new System.Drawing.Point(206, 63);
            this.cancle_all.Name = "cancle_all";
            this.cancle_all.Size = new System.Drawing.Size(67, 32);
            this.cancle_all.TabIndex = 0;
            this.cancle_all.TabStop = false;
            this.cancle_all.Text = "C";
            this.cancle_all.UseVisualStyleBackColor = false;
            this.cancle_all.Click += new System.EventHandler(this.c_Click);
            this.cancle_all.GotFocus += new System.EventHandler(this.button_GotFocus);

            // 
            // backspace
            // 
            this.backspace.BackColor = System.Drawing.Color.White;
            this.backspace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backspace.ForeColor = System.Drawing.Color.Red;
            this.backspace.Location = new System.Drawing.Point(55, 63);
            this.backspace.Name = "backspace";
            this.backspace.Size = new System.Drawing.Size(73, 32);
            this.backspace.TabIndex = 0;
            this.backspace.TabStop = false;
            this.backspace.Text = "Backspace";
            this.backspace.UseVisualStyleBackColor = false;
            this.backspace.Click += new System.EventHandler(this.backspace_Click);
            this.backspace.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // cancle_last
            // 
            this.cancle_last.BackColor = System.Drawing.Color.White;
            this.cancle_last.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancle_last.ForeColor = System.Drawing.Color.Red;
            this.cancle_last.Location = new System.Drawing.Point(135, 63);
            this.cancle_last.Name = "cancle_last";
            this.cancle_last.Size = new System.Drawing.Size(65, 32);
            this.cancle_last.TabIndex = 0;
            this.cancle_last.TabStop = false;
            this.cancle_last.Text = "CE";
            this.cancle_last.UseVisualStyleBackColor = false;
            this.cancle_last.Click += new System.EventHandler(this.ce_Click);
            this.cancle_last.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrl_c,
            this.ctrl_v});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.文件ToolStripMenuItem.Text = "编辑(&E)";
            // 
            // ctrl_c
            // 
            this.ctrl_c.Name = "ctrl_c";
            this.ctrl_c.Size = new System.Drawing.Size(154, 22);
            this.ctrl_c.Text = "复制(&C) Ctrl+C";
            this.ctrl_c.Click += new System.EventHandler(this.ctrl_c_Click);
            // 
            // ctrl_v
            // 
            this.ctrl_v.Name = "ctrl_v";
            this.ctrl_v.Size = new System.Drawing.Size(154, 22);
            this.ctrl_v.Text = "粘贴(&P) Ctrl+V";
            this.ctrl_v.Click += new System.EventHandler(this.ctrl_v_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.ShowItemToolTips = true;
            this.menu.Size = new System.Drawing.Size(279, 24);
            this.menu.TabIndex = 15;
            this.menu.Text = "文件";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.查看ToolStripMenuItem.Text = "查看(&V)";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // text_display
            // 
            this.text_display.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.text_display.BackColor = System.Drawing.SystemColors.Window;
            this.text_display.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_display.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_display.ForeColor = System.Drawing.Color.Black;
            this.text_display.Location = new System.Drawing.Point(6, 28);
            this.text_display.Name = "text_display";
            this.text_display.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.text_display.Size = new System.Drawing.Size(267, 26);
            this.text_display.TabIndex = 0;
            this.text_display.TabStop = false;
            this.text_display.Text = "0.";
            this.text_display.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_display.GotFocus += new System.EventHandler(this.text_display_GotFocus);
            // 
            // no_0
            // 
            this.no_0.BackColor = System.Drawing.Color.White;
            this.no_0.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_0.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_0.Location = new System.Drawing.Point(55, 209);
            this.no_0.Name = "no_0";
            this.no_0.Size = new System.Drawing.Size(40, 30);
            this.no_0.TabIndex = 0;
            this.no_0.TabStop = false;
            this.no_0.Tag = "0";
            this.no_0.Text = "0";
            this.no_0.UseVisualStyleBackColor = false;
            this.no_0.Click += new System.EventHandler(this.num_Click);
            this.no_0.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // dot
            // 
            this.dot.BackColor = System.Drawing.Color.White;
            this.dot.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dot.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dot.Location = new System.Drawing.Point(147, 209);
            this.dot.Name = "dot";
            this.dot.Size = new System.Drawing.Size(40, 30);
            this.dot.TabIndex = 0;
            this.dot.TabStop = false;
            this.dot.Tag = "dot";
            this.dot.Text = ".";
            this.dot.UseVisualStyleBackColor = false;
            this.dot.Click += new System.EventHandler(this.dot_Click);
            this.dot.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // equal
            // 
            this.equal.BackColor = System.Drawing.Color.White;
            this.equal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.equal.ForeColor = System.Drawing.Color.Red;
            this.equal.Location = new System.Drawing.Point(234, 209);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(40, 30);
            this.equal.TabIndex = 0;
            this.equal.TabStop = false;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = false;
            this.equal.Click += new System.EventHandler(this.equal_Click);
            this.equal.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_div
            // 
            this.operate_div.BackColor = System.Drawing.Color.White;
            this.operate_div.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_div.ForeColor = System.Drawing.Color.Red;
            this.operate_div.Location = new System.Drawing.Point(193, 101);
            this.operate_div.Name = "operate_div";
            this.operate_div.Size = new System.Drawing.Size(40, 30);
            this.operate_div.TabIndex = 0;
            this.operate_div.TabStop = false;
            this.operate_div.Tag = "";
            this.operate_div.Text = "/";
            this.operate_div.UseVisualStyleBackColor = false;
            this.operate_div.Click += new System.EventHandler(this.operator_Click);
            this.operate_div.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_ride
            // 
            this.operate_ride.BackColor = System.Drawing.Color.White;
            this.operate_ride.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_ride.ForeColor = System.Drawing.Color.Red;
            this.operate_ride.Location = new System.Drawing.Point(193, 137);
            this.operate_ride.Name = "operate_ride";
            this.operate_ride.Size = new System.Drawing.Size(40, 30);
            this.operate_ride.TabIndex = 0;
            this.operate_ride.TabStop = false;
            this.operate_ride.Tag = "";
            this.operate_ride.Text = "*";
            this.operate_ride.UseVisualStyleBackColor = false;
            this.operate_ride.Click += new System.EventHandler(this.operator_Click);
            this.operate_ride.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_dec
            // 
            this.operate_dec.BackColor = System.Drawing.Color.White;
            this.operate_dec.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_dec.ForeColor = System.Drawing.Color.Red;
            this.operate_dec.Location = new System.Drawing.Point(193, 173);
            this.operate_dec.Name = "operate_dec";
            this.operate_dec.Size = new System.Drawing.Size(40, 30);
            this.operate_dec.TabIndex = 0;
            this.operate_dec.TabStop = false;
            this.operate_dec.Tag = "";
            this.operate_dec.Text = "-";
            this.operate_dec.UseVisualStyleBackColor = false;
            this.operate_dec.Click += new System.EventHandler(this.operator_Click);
            this.operate_dec.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // operate_add
            // 
            this.operate_add.BackColor = System.Drawing.Color.White;
            this.operate_add.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operate_add.ForeColor = System.Drawing.Color.Red;
            this.operate_add.Location = new System.Drawing.Point(193, 209);
            this.operate_add.Name = "operate_add";
            this.operate_add.Size = new System.Drawing.Size(40, 30);
            this.operate_add.TabIndex = 0;
            this.operate_add.TabStop = false;
            this.operate_add.Tag = "";
            this.operate_add.Text = "+";
            this.operate_add.UseVisualStyleBackColor = false;
            this.operate_add.Click += new System.EventHandler(this.operator_Click);
            this.operate_add.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // flowLayoutPanel_numbers
            // 
            this.flowLayoutPanel_numbers.BackColor = System.Drawing.SystemColors.MenuBar;
            this.flowLayoutPanel_numbers.Controls.Add(this.no_7);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_8);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_9);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_4);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_5);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_6);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_1);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_2);
            this.flowLayoutPanel_numbers.Controls.Add(this.no_3);
            this.flowLayoutPanel_numbers.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flowLayoutPanel_numbers.Location = new System.Drawing.Point(52, 98);
            this.flowLayoutPanel_numbers.Name = "flowLayoutPanel_numbers";
            this.flowLayoutPanel_numbers.Size = new System.Drawing.Size(140, 110);
            this.flowLayoutPanel_numbers.TabIndex = 1;
            // 
            // no_7
            // 
            this.no_7.BackColor = System.Drawing.Color.White;
            this.no_7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_7.Location = new System.Drawing.Point(3, 3);
            this.no_7.Name = "no_7";
            this.no_7.Size = new System.Drawing.Size(40, 30);
            this.no_7.TabIndex = 0;
            this.no_7.TabStop = false;
            this.no_7.Tag = "7";
            this.no_7.Text = "7";
            this.no_7.UseVisualStyleBackColor = false;
            this.no_7.Click += new System.EventHandler(this.num_Click);
            this.no_7.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_8
            // 
            this.no_8.BackColor = System.Drawing.Color.White;
            this.no_8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_8.Location = new System.Drawing.Point(49, 3);
            this.no_8.Name = "no_8";
            this.no_8.Size = new System.Drawing.Size(40, 30);
            this.no_8.TabIndex = 0;
            this.no_8.TabStop = false;
            this.no_8.Tag = "8";
            this.no_8.Text = "8";
            this.no_8.UseVisualStyleBackColor = false;
            this.no_8.Click += new System.EventHandler(this.num_Click);
            this.no_8.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_9
            // 
            this.no_9.BackColor = System.Drawing.Color.White;
            this.no_9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_9.Location = new System.Drawing.Point(95, 3);
            this.no_9.Name = "no_9";
            this.no_9.Size = new System.Drawing.Size(40, 30);
            this.no_9.TabIndex = 0;
            this.no_9.TabStop = false;
            this.no_9.Tag = "9";
            this.no_9.Text = "9";
            this.no_9.UseVisualStyleBackColor = false;
            this.no_9.Click += new System.EventHandler(this.num_Click);
            this.no_9.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_4
            // 
            this.no_4.BackColor = System.Drawing.Color.White;
            this.no_4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_4.Location = new System.Drawing.Point(3, 39);
            this.no_4.Name = "no_4";
            this.no_4.Size = new System.Drawing.Size(40, 30);
            this.no_4.TabIndex = 0;
            this.no_4.TabStop = false;
            this.no_4.Tag = "4";
            this.no_4.Text = "4";
            this.no_4.UseVisualStyleBackColor = false;
            this.no_4.Click += new System.EventHandler(this.num_Click);
            this.no_4.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_5
            // 
            this.no_5.BackColor = System.Drawing.Color.White;
            this.no_5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_5.Location = new System.Drawing.Point(49, 39);
            this.no_5.Name = "no_5";
            this.no_5.Size = new System.Drawing.Size(40, 30);
            this.no_5.TabIndex = 0;
            this.no_5.TabStop = false;
            this.no_5.Tag = "5";
            this.no_5.Text = "5";
            this.no_5.UseVisualStyleBackColor = false;
            this.no_5.Click += new System.EventHandler(this.num_Click);
            this.no_5.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_6
            // 
            this.no_6.BackColor = System.Drawing.Color.White;
            this.no_6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_6.Location = new System.Drawing.Point(95, 39);
            this.no_6.Name = "no_6";
            this.no_6.Size = new System.Drawing.Size(40, 30);
            this.no_6.TabIndex = 0;
            this.no_6.TabStop = false;
            this.no_6.Tag = "6";
            this.no_6.Text = "6";
            this.no_6.UseVisualStyleBackColor = false;
            this.no_6.Click += new System.EventHandler(this.num_Click);
            this.no_6.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_1
            // 
            this.no_1.BackColor = System.Drawing.Color.White;
            this.no_1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_1.Location = new System.Drawing.Point(3, 75);
            this.no_1.Name = "no_1";
            this.no_1.Size = new System.Drawing.Size(40, 30);
            this.no_1.TabIndex = 0;
            this.no_1.TabStop = false;
            this.no_1.Tag = "1";
            this.no_1.Text = "1";
            this.no_1.UseVisualStyleBackColor = false;
            this.no_1.Click += new System.EventHandler(this.num_Click);
            this.no_1.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_2
            // 
            this.no_2.BackColor = System.Drawing.Color.White;
            this.no_2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_2.Location = new System.Drawing.Point(49, 75);
            this.no_2.Name = "no_2";
            this.no_2.Size = new System.Drawing.Size(40, 30);
            this.no_2.TabIndex = 0;
            this.no_2.TabStop = false;
            this.no_2.Tag = "2";
            this.no_2.Text = "2";
            this.no_2.UseVisualStyleBackColor = false;
            this.no_2.Click += new System.EventHandler(this.num_Click);
            this.no_2.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // no_3
            // 
            this.no_3.BackColor = System.Drawing.Color.White;
            this.no_3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.no_3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.no_3.Location = new System.Drawing.Point(95, 75);
            this.no_3.Name = "no_3";
            this.no_3.Size = new System.Drawing.Size(40, 30);
            this.no_3.TabIndex = 0;
            this.no_3.TabStop = false;
            this.no_3.Tag = "3";
            this.no_3.Text = "3";
            this.no_3.UseVisualStyleBackColor = false;
            this.no_3.Click += new System.EventHandler(this.num_Click);
            this.no_3.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.Color.White;
            this.minus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.minus.Location = new System.Drawing.Point(101, 209);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(40, 30);
            this.minus.TabIndex = 0;
            this.minus.TabStop = false;
            this.minus.Text = "+/-";
            this.minus.UseVisualStyleBackColor = false;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            this.minus.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // sqrt
            // 
            this.sqrt.BackColor = System.Drawing.Color.White;
            this.sqrt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sqrt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.sqrt.Location = new System.Drawing.Point(234, 101);
            this.sqrt.Name = "sqrt";
            this.sqrt.Size = new System.Drawing.Size(40, 30);
            this.sqrt.TabIndex = 0;
            this.sqrt.TabStop = false;
            this.sqrt.Text = "sqrt";
            this.sqrt.UseVisualStyleBackColor = false;
            this.sqrt.Click += new System.EventHandler(this.sqrt_Click);
            this.sqrt.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // reciprocal
            // 
            this.reciprocal.BackColor = System.Drawing.Color.White;
            this.reciprocal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reciprocal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.reciprocal.Location = new System.Drawing.Point(234, 173);
            this.reciprocal.Name = "reciprocal";
            this.reciprocal.Size = new System.Drawing.Size(40, 30);
            this.reciprocal.TabIndex = 0;
            this.reciprocal.TabStop = false;
            this.reciprocal.Text = "1/x";
            this.reciprocal.UseVisualStyleBackColor = false;
            this.reciprocal.Click += new System.EventHandler(this.reciprocal_Click);
            this.reciprocal.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // percent
            // 
            this.percent.BackColor = System.Drawing.Color.White;
            this.percent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.percent.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.percent.Location = new System.Drawing.Point(234, 137);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(40, 30);
            this.percent.TabIndex = 0;
            this.percent.TabStop = false;
            this.percent.Text = "%";
            this.percent.UseVisualStyleBackColor = false;
            this.percent.Click += new System.EventHandler(this.percent_Click);
            this.percent.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // mc
            // 
            this.mc.BackColor = System.Drawing.Color.White;
            this.mc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mc.ForeColor = System.Drawing.Color.Red;
            this.mc.Location = new System.Drawing.Point(6, 101);
            this.mc.Name = "mc";
            this.mc.Size = new System.Drawing.Size(40, 30);
            this.mc.TabIndex = 0;
            this.mc.TabStop = false;
            this.mc.Text = "MC";
            this.mc.UseVisualStyleBackColor = false;
            this.mc.Click += new System.EventHandler(this.mc_Click);
            this.mc.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // mr
            // 
            this.mr.BackColor = System.Drawing.Color.White;
            this.mr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mr.ForeColor = System.Drawing.Color.Red;
            this.mr.Location = new System.Drawing.Point(6, 137);
            this.mr.Name = "mr";
            this.mr.Size = new System.Drawing.Size(40, 30);
            this.mr.TabIndex = 0;
            this.mr.TabStop = false;
            this.mr.Text = "MR";
            this.mr.UseVisualStyleBackColor = false;
            this.mr.Click += new System.EventHandler(this.mr_Click);
            this.mr.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // ms
            // 
            this.ms.BackColor = System.Drawing.Color.White;
            this.ms.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ms.ForeColor = System.Drawing.Color.Red;
            this.ms.Location = new System.Drawing.Point(6, 173);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(40, 30);
            this.ms.TabIndex = 0;
            this.ms.TabStop = false;
            this.ms.Text = "MS";
            this.ms.UseVisualStyleBackColor = false;
            this.ms.Click += new System.EventHandler(this.ms_Click);
            this.ms.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // mAdd
            // 
            this.mAdd.BackColor = System.Drawing.Color.White;
            this.mAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mAdd.ForeColor = System.Drawing.Color.Red;
            this.mAdd.Location = new System.Drawing.Point(6, 209);
            this.mAdd.Name = "mAdd";
            this.mAdd.Size = new System.Drawing.Size(40, 30);
            this.mAdd.TabIndex = 0;
            this.mAdd.TabStop = false;
            this.mAdd.Text = "M+";
            this.mAdd.UseVisualStyleBackColor = false;
            this.mAdd.Click += new System.EventHandler(this.mAdd_Click);
            this.mAdd.GotFocus += new System.EventHandler(this.button_GotFocus);
            // 
            // label_m
            // 
            this.label_m.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label_m.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_m.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_m.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_m.Location = new System.Drawing.Point(6, 63);
            this.label_m.Name = "label_m";
            this.label_m.Size = new System.Drawing.Size(40, 32);
            this.label_m.TabIndex = 1;
            this.label_m.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCalculator
            // 
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(279, 244);
            this.Controls.Add(this.label_m);
            this.Controls.Add(this.mAdd);
            this.Controls.Add(this.ms);
            this.Controls.Add(this.mr);
            this.Controls.Add(this.cancle_all);
            this.Controls.Add(this.mc);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.reciprocal);
            this.Controls.Add(this.sqrt);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.text_display);
            this.Controls.Add(this.flowLayoutPanel_numbers);
            this.Controls.Add(this.backspace);
            this.Controls.Add(this.cancle_last);
            this.Controls.Add(this.operate_add);
            this.Controls.Add(this.operate_dec);
            this.Controls.Add(this.operate_ride);
            this.Controls.Add(this.operate_div);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.dot);
            this.Controls.Add(this.no_0);
            this.Controls.Add(this.menu);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "frmCalculator";
            this.Text = "C#计算器";
            
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            this.KeyPreview = true;
            /*
             * 加上这两句之后才会使键盘好使。 
             * this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
             * 这句话把整个窗体（包括其所有控件）的KeyUp事件都委托给keyUp()方法处理。
             * 
             * 这句话的意思是把KeyUp事件交与一个委托（KeyEventHandler）来执行，这个委托把KeyUp事件交给（其实是做出一个指向）keyUp()方法来做。
             * 
             * 这里的委托只是狭义的委托，而广义上我们可以自己定义委托来使用。
             * 
             * 而KeyPreview属性是与焦点有关的。
             * 
             */



            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.flowLayoutPanel_numbers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        #region widget_loseFocus
        private void text_display_GotFocus(object sender, EventArgs e)                      
        {   /*
             * 文本框的“获取焦点”事件发生时执行的方法。每次获得焦点时，就会执行此方法，使之马上失去焦点。
             * 
             * 当某控件的Enable属性变为False的时候，它的焦点将转移到TabIndex属性值比它大1的控件上。
             * 这时，如果有多个控件的TabIndex属性值同时比它大1，鼠标点击按钮或敲击键盘时候会发出“咚”的一声。
             * 故在本程序中，将label_m控件的TabIndex设为1，其它的全部设为0，因此所有的控件在不可用时焦点都会转移到label_m上，
             * 因为label_m没有Click和KeyUp事件，所以不会出错。
             * 这样就实现了全局无焦点的功能。
             * 
             */
            text_display.Enabled = false;                                                   //先使文本框不可用，这时焦点转移到TabIndex比文本框大的下一个控件上
            text_display.Enabled = true;                                                    //再使文本框可用，这时焦点不会返回。
        }

        private void button_GotFocus(object sender, EventArgs e)                            //所有的按钮控件都用此方法失去焦点
        {
            Button btnTmp = (Button)sender;
            btnTmp.Enabled = false;
            btnTmp.Enabled = true;
        }

        #endregion Ends_widget_loseFocus






        #region num_Click
        private void num_Click(object sender, EventArgs e)              //数字的Click事件；object改为Button，表示当前点击的按钮
        {
            Button num = (Button)sender;                                // object 可以声明任何类型的变量 ,现在的object sender 是一个按钮,所以将其转化为按钮对象

            if (operFlag)                                               //若已点击过运算符
            {
                if (!dotFlag)                                           //若已点击过运算符,且没点击小数点,若点击的数字是0，则将文本框改为"0."；否则将文本框换为点击的数字,并将运算符改为未点击状态
                {
                    if (num.Text.Equals("0"))
                    {
                        text_display.Text = "0";
                        operFlag = false;
                        dotFlag = false;                                 //此句可有可无，因为现在的状态是“0.”，再点击小数点的时候，就会按照文本框是“0.”的情况进行，亦不会添加小数点

                    }
                    else
                    {
                        text_display.Text = num.Text.ToString();        //此句包含文本框中为“除数不能为0。”的情况。
                        operFlag = false;
                        dotFlag = false;

                    }
                }
                else                                                    //若运算符和小数点都已点击,则直接在后面添加点击的数字,并将运算符或等号改为未点击状态
                {
                    text_display.Text = text_display.Text + num.Text.ToString();
                    operFlag = false;

                }
            }
            else                                                                                            //若未点击运算符
            {
                if (!dotFlag && (text_display.Text.Equals("0.") || text_display.Text.Equals("0")))          //若未点击运算符,且未点击小数点,且文本框里为"0."或"0"
                {
                    text_display.Text = num.Text.ToString();

                }
                else 
                {
                    text_display.Text = text_display.Text + num.Text.ToString();                            //其它情况一律直接添加。

                }

            }
            enterFlag = false;                                          //在Enter是true之后，无论执行了什么操作，都把它改为False


            label_m.Focus();                                            //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }

        #endregion Ends_num_Click

        #region dot_Click
        private void dot_Click(object sender, EventArgs e)
        {
            if (!dotFlag)                                                   //没点击的情况下
            {
                if (operFlag)                                               //如果点击了运算符,就将文本换为"0.",并将小数点设为已点击
                {
                    text_display.Text = "0.";
                    dotFlag = true;
                }
                else if (text_display.Text.Equals("0."))                    //如果没有点击运算符,切当前文本是"0.",便保持现状但将小数点设为已点击
                {
                    dotFlag = true;
                }
                else if (text_display.Text.Equals("0") || text_display.Text.Equals(""))  
                {
                    text_display.Text = "0.";
                    dotFlag = true;
                }
                else                                                        //其他情况直接添加并将小数点设为已点击
                {
                    text_display.Text = text_display.Text + ".";
                    dotFlag = true;
                }
            }
            else                                                            //如果已点击则什么也不做
            {

            }
            enterFlag = false;


            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion



        #region operator_Click
        private void operator_Click(object sender, EventArgs e)         //运算符的Click事件
        {
            Button oper = (Button)sender;

            if (enterFlag)                                              //如果Enter已经点击，再点击运算符的时候就执行计算器运行初始状态时的第一次数和符号入栈操作（此时符号站应该为"0"。数字栈为空）
            {
                numStack.Push(text_display.Text.ToString());
                operStack.Push(oper.Text.ToString());
                operFlag = true;
                dotFlag = false;                                        //可有可无。因为点击等号之后已将其改为False
            
            }

            if (operFlag)                                               //若点击运算符时，运算符状态为已点击，则取出当前符号栈栈顶元素，把当前点击的运算符入栈
            {
                operStack.Pop();
                operStack.Push(oper.Text);
            }
            else
            {
                if (operStack.Count == 1 || priorityCompare(oper.Text.ToString(), operStack.Peek().ToString()))
                {   
                    /*
                     * 当符号栈为初始化状态（只有一个"0"时）
                     * 且栈外运算符优先级 > 栈顶的优先级时
                     * （"0"的优先级为最低，是-1），
                     * 文本框数字入数字栈，符号入符号栈，
                     * 并将符号设为已点击状态,把小数点设为未点击状态
                    */
                    numStack.Push(text_display.Text);
                    operStack.Push(oper.Text);
                    operFlag = true;
                    dotFlag = false;
                }
                else                                                    //当栈外运算符优先级 <= 栈顶运算符优先级时
                {
                    object result = new object();
                    numStack.Push(text_display.Text);                   //先将数字入数字栈      
               
                    string num1 = numStack.Peek().ToString();           //取得数字栈顶元素
                    string num2;
                    string operTmp = operStack.Peek().ToString();       //取得符号栈顶元素

                    if (num1.Equals("0.") && operTmp.Equals("/"))       
                    {
                        /*
                         * 判断是否为除数为零的情况，若是，则显示错误提示，并且删除数字栈顶的零，
                         * 将运算符或等号设为点击状态，将小数点设为未点击状态，等待新数输入，
                         * 当前点击的运算符不作任何处理
                        */
                        text_display.Text = "除数不能为0。";
                        numStack.Pop();
                        operFlag = true;
                        dotFlag = false;
                    }
                    else
                    {
                        while (!priorityCompare(oper.Text.ToString(), operStack.Peek().ToString()))     //每当栈外运算符优先级 <= 栈顶运算符优先级时,都执行while里面的语句，直到栈外运算符优先级 > 栈顶运算符优先级时才继续执行while后面的语句
                        {
                            num1 = numStack.Pop().ToString();
                            num2 = numStack.Pop().ToString();
                            operTmp = operStack.Pop().ToString();
                            OperateFactory operFac = new OperateFactory();                              //声明工厂对象，并用其调用CreateOperate()方法来传递取得的运算符，以选择用哪一种方法来实例化operInterface接口
                            OperateInterface operInterface = operFac.CreateOperate(operTmp);
                            result = operInterface.Operate(num1, num2);                                 //用实例化好的接口调用实例化它的方法的Operate()方法来计算
                            numStack.Push(result.ToString());                                           //将结果入数字栈，参与下一次循环的运算                         
                            text_display.Text = numStack.Peek().ToString();                             //这一句将每次运算获得的中间结果显示在文本框上，使用Peek()，不改变站内元素。再次输入数字的时候会自动清空，不影响下一步操作。
                        }
                        operStack.Push(oper.Text);                                                      //此时栈外运算符优先级 > 栈顶运算符优先级，故将最后点击的运算符入栈
                        operFlag = true;                                                                //运算符设为点击，小数点设为未点击
                        dotFlag = false;
                    }
                }

            }
            enterFlag = false; 


            label_m.Focus();                                                                            //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_operator_Click
        
        #region equal_Click
        private void equal_Click(object sender, EventArgs e)
        {   
            numStack.Push(text_display.Text);                                                           //先将文本框内数字入站       
            object result = new object();
            string num1 = numStack.Peek().ToString();
            string num2;
            string operTmp = operStack.Peek().ToString();


            if(num1.Equals("0.") && operTmp.Equals("/"))
            {
                text_display.Text = "除数不能为0。";
                operFlag = true;
                dotFlag = false;

            }           
             
            else
            {             
                while ( operStack.Count > 1)                                                            //当符号栈内元素 > 1 时，执行运算并将结果入数字栈
                {
                    num1 = numStack.Pop().ToString();
                    num2 = numStack.Pop().ToString();
                    operTmp = operStack.Pop().ToString();
                    OperateFactory operFac = new OperateFactory();
                    OperateInterface operInterface = operFac.CreateOperate(operTmp);
                    result = operInterface.Operate( num1, num2);
                    numStack.Push(result.ToString());
                }
                text_display.Text = numStack.Pop().ToString();                                          //显示结果
                numStack.Clear();                                                                       //清空数字栈
                operStack.Clear();                                                                  
                operStack.Push("0");
                operFlag = true;                                                                        //只有true，在按等号算出结果之后，输入数字才会按照运算符为true的情况清空文本框再输入新数，否则会在上一次的结果之后添加输入的数字
                dotFlag = false;                                                                        //小数点设为未点击

            }
            enterFlag = true;
            
            
            label_m.Focus();                                                                            //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion



        #region c_Click
        private void c_Click(object sender, EventArgs e)                    //将所有都设为初始化状态
        {
            text_display.Text = "0.";
            numStack.Clear();
            operStack.Clear();
            operStack.Push("0");
            operFlag = false;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion

        #region ce_Click
        private void ce_Click(object sender, EventArgs e)                   //允许用户清除输入的错误数字，并等待输入新数。
        {
            if (operFlag)
            {
                text_display.Text = "操作已执行，不能取消，请继续或归零。";
            }
            else
            {
                text_display.Text = "0.";
                operFlag = true;
                dotFlag = false;
                enterFlag = false;
            }
            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }        
        #endregion

        #region backspace_Click
        private void backspace_Click(object sender, EventArgs e)
        {
            if (operFlag) 
            {
            }
            else if (text_display.Text.Length > 0 )
            {
                text_display.Text = text_display.Text.Substring(0, text_display.Text.Length - 1);

                if (text_display.Text.Equals("0") || text_display.Text.Equals("0.") || text_display.Text.Equals(""))
                {
                    text_display.Text = "0.";                               //这时候相当于执行一个了CE的过程
                    operFlag = true;
                    dotFlag = false;
                }

            }

            int dotNum = text_display.Text.IndexOf(".");                  //声明整型变量来计算当前文本中"."的个数,若为-1即为不存在
            if (dotNum == -1 && !text_display.Text.Equals("0."))
            {
                dotFlag = false;                                          //若不存在小数点了（已被删除），则把dotFlag设为false，等待用户输入。
            }
            else                                                          //若存在小数点，即设为true。
            {
                dotFlag = true;
            }

            enterFlag = false;
            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion



        #region Priority

        private int getPriority(string oper)                                                        //取得优先级的方法
        {   
            if(oper.Equals("+"))                                                                    // * /优先级为1,+-为0 ,符号栈内默认的"0"的优先级是-1
            {
                return 0;
            }
            else if (oper.Equals("-"))
        	{
                return 0;
        	}
            else if(oper.Equals("*"))
        	{
                return 1;
        	}
            else if(oper.Equals("/"))
        	{
                return 1;
        	}
            else if (oper.Equals("0"))
            {
                return -1;
            }
            return 0;
        }

        private bool priorityCompare(string oper1, string oper2)                                    //比较优先级的方法
        {
            int pri1 = getPriority(oper1);                                                          //取得栈外运算符优先级
            int pri2 = getPriority(oper2);                                                          //取得栈顶运算符优先级
  
            if(pri1 > pri2)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
       
        #endregion



        #region minus_Click
        private void minus_Click(object sender, EventArgs e)
        {
            int minusNum = text_display.Text.IndexOf("-");                  //声明整型变量来计算当前文本中-的个数,若为-1即为不存在
            if (minusNum == -1 && !text_display.Text.Equals("0."))
            {
                text_display.Text = "-" + text_display.Text;
            }
            else 
            {
                text_display.Text = text_display.Text.Replace("-","");      //在某字符串中找出第一个参数的字符，并用第二个参数的字符替换
            }
            /*
             * 此处就不需要更改任何Flag的状态。
             * 因为只是等同于改变一下文本框内数字的正负，相当于输入一个新数
             * 而在数字点击之后就已经会对各Flag做出正确的操作。
             */

            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。
        }
        #endregion

        #region recip_Click
        private void reciprocal_Click(object sender, EventArgs e)
        {
            object result = new object();
            Button recip = (Button)sender;
            string Num = text_display.Text.ToString();

            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");                     //一个正则表达式（验证输入的为数字）

            if (reg.IsMatch(text_display.Text.ToString()))                  //若匹配这个正则表达式
            {
                if ((text_display.Text.Equals("0.") || text_display.Text.Equals("0")))
                {
                    text_display.Text = "除数不能为零。";
                    operFlag = true;
                    dotFlag = false;
                }
                else
                {
                    OperateFactory operFac = new OperateFactory();
                    OperateInterface operInterface = operFac.CreateOperate(recip.Name.ToString());
                    result = operInterface.Operate(text_display.Text.ToString(), "1");
                    text_display.Text = result.ToString();
                    operFlag = true;
                    dotFlag = false;
                }
            }

            else 
            {
                text_display.Text = "请输入数字。";
                operFlag = true;
                dotFlag = false;
            }
            enterFlag = false;



            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_recip_Click

        #region sqrt_Click
        private void sqrt_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");

            if (reg.IsMatch(text_display.Text.ToString()))
            {
                if (double.Parse(text_display.Text) >= 0)
                {
                    text_display.Text = Math.Sqrt(double.Parse(text_display.Text.ToString())).ToString();
                    operFlag = true;
                    dotFlag = false;
                }
                else
                {
                    text_display.Text = "负数不能开方，请重新输入。";
                    operFlag = true;
                    dotFlag = false;
                }
            }
            else
            {
                text_display.Text = "请输入数字。";
                operFlag = true;
                dotFlag = false;
            }
            enterFlag = false;


            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_sqrt_Click

        #region percent_Click
        private void percent_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            if (reg.IsMatch(text_display.Text.ToString())) 
            {
                double Num = double.Parse(text_display.Text.ToString()) / 100;
                text_display.Text = Num.ToString();
                operFlag = true;
                dotFlag = false;
            }
            else
            {
                text_display.Text = "请输入数字。";
                operFlag = true;
                dotFlag = false;
            }
            enterFlag = false;


            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_percent_Click

        #region m

        #region mADD_Click
        private void mAdd_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            if (reg.IsMatch(text_display.Text.ToString()))
            {
                if (mStack.Count == 0)
                {
                    mStack.Push(text_display.Text.ToString());
                    label_m.Text = "M";
                }
                else if (mStack.Count > 0)
                {
                    decimal num1 = decimal.Parse(text_display.Text.ToString());
                    decimal num2 = decimal.Parse(mStack.Pop().ToString());
                    decimal numTmp = num1 + num2;
                    mStack.Push(numTmp.ToString());
                    label_m.Text = "M";
                }
            }
            else
            {
                text_display.Text = "请输入数字。";
            }
            operFlag = true;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_mAdd_Click

        #region ms_Click
        private void ms_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            if (reg.IsMatch(text_display.Text.ToString()))
            {
                mStack.Clear();
                mStack.Push(text_display.Text.ToString());
                label_m.Text = "M";
            }
            else
            {
                text_display.Text = "请输入数字。";
            }
            operFlag = true;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_ms_Click

        #region mr_Click
        private void mr_Click(object sender, EventArgs e)
        {
            if (mStack.Count > 0)                                           //当寄存器栈不为空时
            {
                text_display.Text = mStack.Pop().ToString();
                label_m.Text = "";
            }
            else
            {
                text_display.Text = "寄存器为空";
                label_m.Text = "";

            }
            operFlag = true;
            dotFlag = false;
            enterFlag = false;

            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_mr_Click
        
        #region mc_Click
        private void mc_Click(object sender, EventArgs e)
        {
            mStack.Clear();
            label_m.Text = "";
            operFlag = true;
            dotFlag = false;
            enterFlag = false;
            label_m.Focus();                                                //键盘按键之后焦点由下面的各个_GotFocus()方法控制；鼠标点击之后的焦点有这条语句控制，同样使焦点转移到label_m上。

        }
        #endregion Ends_mc_Click

        #endregion Ends_m


        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        #region keyUp
        private void keyUp(object sender, KeyEventArgs e)   
        {   /* 
             * 这是KeyUp事件对应的方法，在窗体的属性中的KeyUp中选中此keyUp方法，则可实现在按钮抬起时（KeyUp）执行此方法
             */

            if (e.KeyCode == Keys.Escape)           //这是KeyEventArg的对象所具有的类方法
            {
                c_Click(cancle_all,e);
        
            }
            else if (e.KeyCode == Keys.Back)
            {
                backspace_Click(backspace,e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                equal_Click(equal,e);
            }

            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                operator_Click(operate_add, e);
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                operator_Click(operate_dec, e);
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                operator_Click(operate_ride, e);
            }
            else if (e.KeyCode == Keys.Divide)
            {
                operator_Click(operate_div, e);
            }
            else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {
                num_Click(no_0, e);

            }
            else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {
                /* 当窗体的某个控件触发了其本身的KeyUp事件之后，
                 * 将会调用keyUp()方法，并判断是哪个按键
                 * 如果是大键盘或者是小键盘的1时，便调用num_Click()方法。
                 * 参数是no_1和e。
                 * 在这里的no_1指的是按钮no_1，e是KeyUp事件
                 * no_1是按钮，参数格式正确；而e是KeyUp事件，也是事件的一种。KeyEventHandler当然也是EventHandler的一部分。
                 * 所以调用了之num_Click()后一切按照no_1按钮事件的操作执行
                 * 所以no_1按钮的这一句
                 * this.no_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.num_Click);    
                 * 可以不写
                 */
                num_Click(no_1, e);

            }
            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {
                num_Click(no_2, e);

            }
            else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {
                num_Click(no_3, e);

            }
            else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {
                num_Click(no_4, e);

            }
            else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {
                num_Click(no_5, e);

            }
            else if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {
                num_Click(no_6, e);

            }
            else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {
                num_Click(no_7, e);

            }
            else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {
                num_Click(no_8, e);

            }
            else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {
                num_Click(no_9, e);

            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.OemPeriod || e.KeyValue == 110 || e.KeyValue == 46)              //小键盘上的小数点的KeyValue是110，大键盘上是46
            {
                dot_Click(dot,e);
            }
        }
        #endregion Ends_keyUp


        #region Copy_Paste
        private void ctrl_c_Click(object sender, EventArgs e)
        {
            
            Clipboard.SetDataObject(text_display.Text);
            enterFlag = false;
        }

        private void ctrl_v_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[-]?\d+[.]?\d*$");
            IDataObject iData = Clipboard.GetDataObject();
            /*
             * 声明一个IDataObject来保存从剪贴板取回的数据.
             * 取回剪贴板数据.Determines(确定)是否是你可使用的数据格式.
             */
            if (iData.GetDataPresent(DataFormats.Text)||iData.GetDataPresent(DataFormats.OemText))
            {
                text_display.Text = (String)iData.GetData(DataFormats.Text); 
                if (!reg.IsMatch(text_display.Text.ToString()))
                {
                    text_display.Text = "输入的不是数字";
                    //MessageBox.Show("输入的不是数字", "计算器");
                    operFlag = true;
                    dotFlag = false;

                }
                else
                {

                }
                enterFlag = false;
            }
        }
        #endregion


    }
    
}


