using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto
{
    public partial class FormCode : Form
    {
        public FormCode()
        {
            InitializeComponent();
        }
        public void SetCode(string code, string code_asm)
        {
            richTextBoxCode2.Text = code;
            richTextBoxCodeAsm2.Text = code_asm;
        }
    }
}
