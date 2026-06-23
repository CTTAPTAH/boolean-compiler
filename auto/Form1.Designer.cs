namespace auto
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewTable = new System.Windows.Forms.ListView();
            this.columnToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonProcess = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCode = new System.Windows.Forms.TabPage();
            this.richTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.tabPageList = new System.Windows.Forms.TabPage();
            this.treeViewSyntax = new System.Windows.Forms.TreeView();
            this.tabPageAsm = new System.Windows.Forms.TabPage();
            this.richTextBoxAsmCode = new System.Windows.Forms.RichTextBox();
            this.buttonWindowCode = new System.Windows.Forms.Button();
            this.richTextBoxAsmCodeMain = new System.Windows.Forms.RichTextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelCodeAsm = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageCode.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            this.tabPageList.SuspendLayout();
            this.tabPageAsm.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTable
            // 
            this.listViewTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnToken,
            this.columnType,
            this.columnString});
            this.listViewTable.FullRowSelect = true;
            this.listViewTable.GridLines = true;
            this.listViewTable.HideSelection = false;
            this.listViewTable.Location = new System.Drawing.Point(17, 15);
            this.listViewTable.Margin = new System.Windows.Forms.Padding(2);
            this.listViewTable.Name = "listViewTable";
            this.listViewTable.Size = new System.Drawing.Size(559, 308);
            this.listViewTable.TabIndex = 1;
            this.listViewTable.UseCompatibleStateImageBehavior = false;
            this.listViewTable.View = System.Windows.Forms.View.Details;
            // 
            // columnToken
            // 
            this.columnToken.Text = "Лексема";
            this.columnToken.Width = 100;
            // 
            // columnType
            // 
            this.columnType.Text = "Тип";
            this.columnType.Width = 100;
            // 
            // columnString
            // 
            this.columnString.Text = "Строка";
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(8, 295);
            this.buttonProcess.Margin = new System.Windows.Forms.Padding(2);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(104, 26);
            this.buttonProcess.TabIndex = 2;
            this.buttonProcess.Text = "Преобразовать";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCode);
            this.tabControl1.Controls.Add(this.tabPageTable);
            this.tabControl1.Controls.Add(this.tabPageList);
            this.tabControl1.Controls.Add(this.tabPageAsm);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 366);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageCode
            // 
            this.tabPageCode.Controls.Add(this.labelCodeAsm);
            this.tabPageCode.Controls.Add(this.labelCode);
            this.tabPageCode.Controls.Add(this.richTextBoxAsmCodeMain);
            this.tabPageCode.Controls.Add(this.buttonWindowCode);
            this.tabPageCode.Controls.Add(this.richTextBoxCode);
            this.tabPageCode.Controls.Add(this.buttonProcess);
            this.tabPageCode.Location = new System.Drawing.Point(4, 22);
            this.tabPageCode.Name = "tabPageCode";
            this.tabPageCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCode.Size = new System.Drawing.Size(592, 340);
            this.tabPageCode.TabIndex = 0;
            this.tabPageCode.Text = "Код";
            this.tabPageCode.UseVisualStyleBackColor = true;
            // 
            // richTextBoxCode
            // 
            this.richTextBoxCode.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCode.Location = new System.Drawing.Point(8, 24);
            this.richTextBoxCode.Name = "richTextBoxCode";
            this.richTextBoxCode.Size = new System.Drawing.Size(281, 266);
            this.richTextBoxCode.TabIndex = 3;
            this.richTextBoxCode.Text = "";
            this.richTextBoxCode.WordWrap = false;
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.listViewTable);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(592, 340);
            this.tabPageTable.TabIndex = 1;
            this.tabPageTable.Text = "Таблица";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // tabPageList
            // 
            this.tabPageList.Controls.Add(this.treeViewSyntax);
            this.tabPageList.Location = new System.Drawing.Point(4, 22);
            this.tabPageList.Name = "tabPageList";
            this.tabPageList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageList.Size = new System.Drawing.Size(592, 340);
            this.tabPageList.TabIndex = 2;
            this.tabPageList.Text = "Дерево";
            this.tabPageList.UseVisualStyleBackColor = true;
            // 
            // treeViewSyntax
            // 
            this.treeViewSyntax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSyntax.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewSyntax.HideSelection = false;
            this.treeViewSyntax.Location = new System.Drawing.Point(3, 3);
            this.treeViewSyntax.Name = "treeViewSyntax";
            this.treeViewSyntax.Size = new System.Drawing.Size(586, 334);
            this.treeViewSyntax.TabIndex = 0;
            // 
            // tabPageAsm
            // 
            this.tabPageAsm.Controls.Add(this.richTextBoxAsmCode);
            this.tabPageAsm.Location = new System.Drawing.Point(4, 22);
            this.tabPageAsm.Name = "tabPageAsm";
            this.tabPageAsm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAsm.Size = new System.Drawing.Size(592, 340);
            this.tabPageAsm.TabIndex = 3;
            this.tabPageAsm.Text = "Ассемблер";
            this.tabPageAsm.UseVisualStyleBackColor = true;
            // 
            // richTextBoxAsmCode
            // 
            this.richTextBoxAsmCode.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxAsmCode.Location = new System.Drawing.Point(8, 6);
            this.richTextBoxAsmCode.Name = "richTextBoxAsmCode";
            this.richTextBoxAsmCode.Size = new System.Drawing.Size(576, 326);
            this.richTextBoxAsmCode.TabIndex = 0;
            this.richTextBoxAsmCode.Text = "";
            // 
            // buttonWindowCode
            // 
            this.buttonWindowCode.Location = new System.Drawing.Point(128, 295);
            this.buttonWindowCode.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWindowCode.Name = "buttonWindowCode";
            this.buttonWindowCode.Size = new System.Drawing.Size(143, 26);
            this.buttonWindowCode.TabIndex = 4;
            this.buttonWindowCode.Text = "Открыть в другой форме";
            this.buttonWindowCode.UseVisualStyleBackColor = true;
            this.buttonWindowCode.Click += new System.EventHandler(this.buttonWindowCode_Click);
            // 
            // richTextBoxAsmCodeMain
            // 
            this.richTextBoxAsmCodeMain.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxAsmCodeMain.Location = new System.Drawing.Point(303, 24);
            this.richTextBoxAsmCodeMain.Name = "richTextBoxAsmCodeMain";
            this.richTextBoxAsmCodeMain.Size = new System.Drawing.Size(281, 266);
            this.richTextBoxAsmCodeMain.TabIndex = 5;
            this.richTextBoxAsmCodeMain.Text = "";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCode.Location = new System.Drawing.Point(8, 3);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(32, 18);
            this.labelCode.TabIndex = 6;
            this.labelCode.Text = "Код";
            // 
            // labelCodeAsm
            // 
            this.labelCodeAsm.AutoSize = true;
            this.labelCodeAsm.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCodeAsm.Location = new System.Drawing.Point(300, 3);
            this.labelCodeAsm.Name = "labelCodeAsm";
            this.labelCodeAsm.Size = new System.Drawing.Size(80, 18);
            this.labelCodeAsm.TabIndex = 7;
            this.labelCodeAsm.Text = "Ассемблер";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Логический компилятор";
            this.tabControl1.ResumeLayout(false);
            this.tabPageCode.ResumeLayout(false);
            this.tabPageCode.PerformLayout();
            this.tabPageTable.ResumeLayout(false);
            this.tabPageList.ResumeLayout(false);
            this.tabPageAsm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listViewTable;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.ColumnHeader columnToken;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnString;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCode;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.RichTextBox richTextBoxCode;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.TreeView treeViewSyntax;
        private System.Windows.Forms.TabPage tabPageAsm;
        private System.Windows.Forms.RichTextBox richTextBoxAsmCode;
        private System.Windows.Forms.Button buttonWindowCode;
        private System.Windows.Forms.RichTextBox richTextBoxAsmCodeMain;
        private System.Windows.Forms.Label labelCodeAsm;
        private System.Windows.Forms.Label labelCode;
    }
}

