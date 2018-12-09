using System;
using System.Windows;
using System.Windows.Forms;

namespace Calculator
{
    partial class frmCalculator
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

        private TextBox text_display;




        private Button cancle_all;
        private Button backspace;
        private Button cancle_last;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem ctrl_c;
        private ToolStripMenuItem ctrl_v;
        private MenuStrip menu;





        private ToolStripMenuItem 查看ToolStripMenuItem;
        private ToolStripMenuItem 帮助ToolStripMenuItem;
        private Button no_0;
        private Button dot;
        private Button equal;
        private Button operate_div;
        private Button operate_ride;
        private Button operate_dec;
        private Button operate_add;
        private FlowLayoutPanel flowLayoutPanel_numbers;
        private Button no_7;
        private Button no_8;
        private Button no_9;
        private Button no_4;
        private Button no_5;
        private Button no_6;
        private Button no_1;
        private Button no_2;
        private Button no_3;
        private Button minus;
        private Button sqrt;
        private Button reciprocal;
        private Button percent;
        private Button mc;
        private Button mr;
        private Button ms;
        private Button mAdd;
        private Label label_m;






        
    }
}

