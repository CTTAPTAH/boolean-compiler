namespace auto
{
    partial class FormCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxCode2 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCodeAsm2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxCode2
            // 
            this.richTextBoxCode2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCode2.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxCode2.Name = "richTextBoxCode2";
            this.richTextBoxCode2.Size = new System.Drawing.Size(270, 337);
            this.richTextBoxCode2.TabIndex = 4;
            this.richTextBoxCode2.Text = "";
            this.richTextBoxCode2.WordWrap = false;
            // 
            // richTextBoxCodeAsm2
            // 
            this.richTextBoxCodeAsm2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCodeAsm2.Location = new System.Drawing.Point(299, 12);
            this.richTextBoxCodeAsm2.Name = "richTextBoxCodeAsm2";
            this.richTextBoxCodeAsm2.Size = new System.Drawing.Size(273, 337);
            this.richTextBoxCodeAsm2.TabIndex = 5;
            this.richTextBoxCodeAsm2.Text = "";
            this.richTextBoxCodeAsm2.WordWrap = false;
            // 
            // FormCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.richTextBoxCodeAsm2);
            this.Controls.Add(this.richTextBoxCode2);
            this.Name = "FormCode";
            this.Text = "Код";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCode2;
        private System.Windows.Forms.RichTextBox richTextBoxCodeAsm2;
    }
}