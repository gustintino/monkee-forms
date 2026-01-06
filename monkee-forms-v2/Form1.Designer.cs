namespace monkee_forms_v2
{
    partial class Form1
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
            rootPanel = new TableLayoutPanel();
            button1 = new Button();
            mainPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            textIdInput = new TextBox();
            userSelect = new ComboBox();
            rootPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.AutoSize = true;
            rootPanel.ColumnCount = 2;
            rootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 233F));
            rootPanel.Controls.Add(button1, 1, 1);
            rootPanel.Controls.Add(mainPanel, 0, 0);
            rootPanel.Controls.Add(flowLayoutPanel1, 0, 1);
            rootPanel.Controls.Add(panel1, 1, 0);
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.Location = new Point(0, 0);
            rootPanel.Margin = new Padding(4, 3, 4, 3);
            rootPanel.Name = "rootPanel";
            rootPanel.RowCount = 2;
            rootPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            rootPanel.Size = new Size(1102, 598);
            rootPanel.TabIndex = 1;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(873, 532);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(225, 63);
            button1.TabIndex = 1;
            button1.Text = "Generate New Text";
            button1.UseVisualStyleBackColor = true;
            button1.Click += StartNewRound;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(4, 3);
            mainPanel.Margin = new Padding(4, 3, 4, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(861, 523);
            mainPanel.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 532);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(863, 63);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(textIdInput);
            panel1.Controls.Add(userSelect);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(872, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(227, 523);
            panel1.TabIndex = 4;
            // 
            // textIdInput
            // 
            textIdInput.ForeColor = SystemColors.ControlText;
            textIdInput.Location = new Point(3, 497);
            textIdInput.Name = "textIdInput";
            textIdInput.PlaceholderText = "Enter custom text ID here...";
            textIdInput.Size = new Size(221, 23);
            textIdInput.TabIndex = 3;
            // 
            // userSelect
            // 
            userSelect.AllowDrop = true;
            userSelect.Dock = DockStyle.Top;
            userSelect.FormattingEnabled = true;
            userSelect.Location = new Point(0, 0);
            userSelect.Name = "userSelect";
            userSelect.Size = new Size(227, 23);
            userSelect.TabIndex = 1;
            userSelect.SelectedIndexChanged += userSelect_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 598);
            Controls.Add(rootPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "test";
            rootPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel rootPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel mainPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private ComboBox userSelect;
        private TextBox textIdInput;
    }
}

