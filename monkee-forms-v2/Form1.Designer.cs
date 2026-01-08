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
            panel1 = new Panel();
            label2 = new Label();
            tabControl1 = new TabControl();
            tab1 = new TabPage();
            perUserGrid = new DataGridView();
            tab2 = new TabPage();
            perTextGrid = new DataGridView();
            tab3 = new TabPage();
            overallGrid = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            userIdTxt = new Label();
            label8 = new Label();
            CreationTimeTxt = new Label();
            AvgAccTxt = new Label();
            label5 = new Label();
            label7 = new Label();
            label4 = new Label();
            label6 = new Label();
            label1 = new Label();
            RacesDoneTxt = new Label();
            BestWPMTxt = new Label();
            AvgWPMTxt = new Label();
            textIdInput = new TextBox();
            userSelect = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            wpmTxt = new Label();
            accTxt = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            typeTxt = new Label();
            titleTxt = new Label();
            rootPanel.SuspendLayout();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)perUserGrid).BeginInit();
            tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)perTextGrid).BeginInit();
            tab3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)overallGrid).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
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
            rootPanel.Controls.Add(panel1, 1, 0);
            rootPanel.Controls.Add(tableLayoutPanel2, 0, 1);
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
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tabControl1);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(textIdInput);
            panel1.Controls.Add(userSelect);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(872, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(227, 523);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 283);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 5;
            label2.Text = "Top 5 scores";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tab1);
            tabControl1.Controls.Add(tab2);
            tabControl1.Controls.Add(tab3);
            tabControl1.ItemSize = new Size(55, 20);
            tabControl1.Location = new Point(6, 299);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(218, 192);
            tabControl1.TabIndex = 4;
            // 
            // tab1
            // 
            tab1.Controls.Add(perUserGrid);
            tab1.Location = new Point(4, 24);
            tab1.Name = "tab1";
            tab1.Padding = new Padding(3);
            tab1.Size = new Size(210, 164);
            tab1.TabIndex = 0;
            tab1.Text = "Per User";
            tab1.UseVisualStyleBackColor = true;
            // 
            // perUserGrid
            // 
            perUserGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            perUserGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            perUserGrid.Location = new Point(0, 0);
            perUserGrid.Name = "perUserGrid";
            perUserGrid.RowHeadersVisible = false;
            perUserGrid.Size = new Size(210, 164);
            perUserGrid.TabIndex = 0;
            // 
            // tab2
            // 
            tab2.Controls.Add(perTextGrid);
            tab2.Location = new Point(4, 24);
            tab2.Name = "tab2";
            tab2.Padding = new Padding(3);
            tab2.Size = new Size(210, 164);
            tab2.TabIndex = 1;
            tab2.Text = "Per Text";
            tab2.UseVisualStyleBackColor = true;
            // 
            // perTextGrid
            // 
            perTextGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            perTextGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            perTextGrid.Location = new Point(0, 0);
            perTextGrid.Name = "perTextGrid";
            perTextGrid.RowHeadersVisible = false;
            perTextGrid.Size = new Size(210, 164);
            perTextGrid.TabIndex = 1;
            // 
            // tab3
            // 
            tab3.Controls.Add(overallGrid);
            tab3.Location = new Point(4, 24);
            tab3.Name = "tab3";
            tab3.Size = new Size(210, 164);
            tab3.TabIndex = 2;
            tab3.Text = "Overall";
            tab3.UseVisualStyleBackColor = true;
            // 
            // overallGrid
            // 
            overallGrid.AllowUserToAddRows = false;
            overallGrid.AllowUserToDeleteRows = false;
            overallGrid.AllowUserToResizeColumns = false;
            overallGrid.AllowUserToResizeRows = false;
            overallGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            overallGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            overallGrid.Location = new Point(0, 0);
            overallGrid.Name = "overallGrid";
            overallGrid.RowHeadersVisible = false;
            overallGrid.Size = new Size(210, 164);
            overallGrid.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.8914032F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.1085968F));
            tableLayoutPanel1.Controls.Add(userIdTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(label8, 0, 1);
            tableLayoutPanel1.Controls.Add(CreationTimeTxt, 1, 1);
            tableLayoutPanel1.Controls.Add(AvgAccTxt, 1, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 0);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(label4, 0, 5);
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 3);
            tableLayoutPanel1.Controls.Add(RacesDoneTxt, 1, 6);
            tableLayoutPanel1.Controls.Add(BestWPMTxt, 1, 3);
            tableLayoutPanel1.Controls.Add(AvgWPMTxt, 1, 5);
            tableLayoutPanel1.Location = new Point(3, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.4834118F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 3.686636F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9052124F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.Size = new Size(221, 211);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // userIdTxt
            // 
            userIdTxt.Dock = DockStyle.Left;
            userIdTxt.Location = new Point(100, 0);
            userIdTxt.Name = "userIdTxt";
            userIdTxt.Size = new Size(118, 30);
            userIdTxt.TabIndex = 7;
            userIdTxt.Text = "label3";
            userIdTxt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Left;
            label8.Location = new Point(3, 30);
            label8.Name = "label8";
            label8.Size = new Size(79, 39);
            label8.TabIndex = 11;
            label8.Text = "User creation time:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CreationTimeTxt
            // 
            CreationTimeTxt.Dock = DockStyle.Left;
            CreationTimeTxt.Location = new Point(100, 30);
            CreationTimeTxt.Name = "CreationTimeTxt";
            CreationTimeTxt.Size = new Size(118, 39);
            CreationTimeTxt.TabIndex = 12;
            CreationTimeTxt.Text = "label2";
            CreationTimeTxt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AvgAccTxt
            // 
            AvgAccTxt.Dock = DockStyle.Fill;
            AvgAccTxt.Location = new Point(100, 118);
            AvgAccTxt.Name = "AvgAccTxt";
            AvgAccTxt.Size = new Size(118, 30);
            AvgAccTxt.TabIndex = 15;
            AvgAccTxt.Text = "label12";
            AvgAccTxt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 30);
            label5.TabIndex = 9;
            label5.Text = "User ID:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 178);
            label7.Name = "label7";
            label7.Size = new Size(91, 33);
            label7.TabIndex = 10;
            label7.Text = "Races completed:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 148);
            label4.Name = "label4";
            label4.Size = new Size(91, 30);
            label4.TabIndex = 6;
            label4.Text = "Average WPM (last 10 races):";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 118);
            label6.Name = "label6";
            label6.Size = new Size(91, 30);
            label6.TabIndex = 8;
            label6.Text = "Average Acc (last 10 races):";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 76);
            label1.Name = "label1";
            label1.Size = new Size(91, 42);
            label1.TabIndex = 4;
            label1.Text = "Best WPM:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RacesDoneTxt
            // 
            RacesDoneTxt.Dock = DockStyle.Fill;
            RacesDoneTxt.Location = new Point(100, 178);
            RacesDoneTxt.Name = "RacesDoneTxt";
            RacesDoneTxt.Size = new Size(118, 33);
            RacesDoneTxt.TabIndex = 16;
            RacesDoneTxt.Text = "label11";
            RacesDoneTxt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BestWPMTxt
            // 
            BestWPMTxt.Dock = DockStyle.Fill;
            BestWPMTxt.Location = new Point(100, 76);
            BestWPMTxt.Name = "BestWPMTxt";
            BestWPMTxt.Size = new Size(118, 42);
            BestWPMTxt.TabIndex = 13;
            BestWPMTxt.Text = "label10";
            BestWPMTxt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AvgWPMTxt
            // 
            AvgWPMTxt.Dock = DockStyle.Fill;
            AvgWPMTxt.Location = new Point(100, 148);
            AvgWPMTxt.Name = "AvgWPMTxt";
            AvgWPMTxt.Size = new Size(118, 30);
            AvgWPMTxt.TabIndex = 14;
            AvgWPMTxt.Text = "label9";
            AvgWPMTxt.TextAlign = ContentAlignment.MiddleRight;
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
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.23059F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.01274633F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.874855F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5225964F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.7068367F));
            tableLayoutPanel2.Controls.Add(wpmTxt, 4, 0);
            tableLayoutPanel2.Controls.Add(accTxt, 3, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 532);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(863, 63);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // wpmTxt
            // 
            wpmTxt.AutoSize = true;
            wpmTxt.Dock = DockStyle.Fill;
            wpmTxt.Font = new Font("Segoe UI", 26F);
            wpmTxt.Location = new Point(600, 0);
            wpmTxt.Name = "wpmTxt";
            wpmTxt.Size = new Size(260, 63);
            wpmTxt.TabIndex = 0;
            wpmTxt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accTxt
            // 
            accTxt.AutoSize = true;
            accTxt.Dock = DockStyle.Fill;
            accTxt.Font = new Font("Segoe UI", 26F);
            accTxt.Location = new Point(398, 0);
            accTxt.Name = "accTxt";
            accTxt.Size = new Size(196, 63);
            accTxt.TabIndex = 1;
            accTxt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(typeTxt, 0, 0);
            tableLayoutPanel3.Controls.Add(titleTxt, 0, 1);
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 45.6140366F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 54.3859634F));
            tableLayoutPanel3.Size = new Size(200, 57);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // typeTxt
            // 
            typeTxt.AutoSize = true;
            typeTxt.Dock = DockStyle.Fill;
            typeTxt.Location = new Point(3, 0);
            typeTxt.Name = "typeTxt";
            typeTxt.Size = new Size(194, 26);
            typeTxt.TabIndex = 3;
            // 
            // titleTxt
            // 
            titleTxt.AutoSize = true;
            titleTxt.Dock = DockStyle.Fill;
            titleTxt.Location = new Point(3, 26);
            titleTxt.Name = "titleTxt";
            titleTxt.Size = new Size(194, 31);
            titleTxt.TabIndex = 0;
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
            tabControl1.ResumeLayout(false);
            tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)perUserGrid).EndInit();
            tab2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)perTextGrid).EndInit();
            tab3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)overallGrid).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel rootPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel mainPanel;
        private Panel panel1;
        private ComboBox userSelect;
        private TextBox textIdInput;
        private Label label5;
        private Label label6;
        private Label userIdTxt;
        private Label label4;
        private Label label1;
        private Label label7;
        private Label label8;
        private Label RacesDoneTxt;
        private Label AvgAccTxt;
        private Label AvgWPMTxt;
        private Label BestWPMTxt;
        private Label CreationTimeTxt;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label wpmTxt;
        private Label accTxt;
        private TableLayoutPanel tableLayoutPanel3;
        private Label titleTxt;
        private Label typeTxt;
        private TabControl tabControl1;
        private TabPage tab1;
        private TabPage tab2;
        private TabPage tab3;
        private DataGridView perUserGrid;
        private Label label2;
        private DataGridView perTextGrid;
        private DataGridView overallGrid;
    }
}

