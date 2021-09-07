
namespace b7.XabboExamples.WinForms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInjectClient = new System.Windows.Forms.Button();
            this.checkBoxManipulate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxBlock = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonInjectServer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonInjectClient
            // 
            this.buttonInjectClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInjectClient.Location = new System.Drawing.Point(3, 477);
            this.buttonInjectClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonInjectClient.Name = "buttonInjectClient";
            this.buttonInjectClient.Size = new System.Drawing.Size(258, 29);
            this.buttonInjectClient.TabIndex = 0;
            this.buttonInjectClient.Text = "Send to client";
            this.buttonInjectClient.UseVisualStyleBackColor = true;
            this.buttonInjectClient.Click += new System.EventHandler(this.ButtonInjectClient_Click);
            // 
            // checkBoxManipulate
            // 
            this.checkBoxManipulate.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxManipulate, 2);
            this.checkBoxManipulate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBoxManipulate.Location = new System.Drawing.Point(3, 342);
            this.checkBoxManipulate.Name = "checkBoxManipulate";
            this.checkBoxManipulate.Size = new System.Drawing.Size(169, 23);
            this.checkBoxManipulate.TabIndex = 1;
            this.checkBoxManipulate.Text = "Packet manipulation";
            this.checkBoxManipulate.UseVisualStyleBackColor = true;
            this.checkBoxManipulate.CheckedChanged += new System.EventHandler(this.CheckBoxManipulate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Changes incoming chat packets to upper case.";
            // 
            // checkBoxBlock
            // 
            this.checkBoxBlock.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxBlock, 2);
            this.checkBoxBlock.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBoxBlock.Location = new System.Drawing.Point(3, 390);
            this.checkBoxBlock.Name = "checkBoxBlock";
            this.checkBoxBlock.Size = new System.Drawing.Size(136, 23);
            this.checkBoxBlock.TabIndex = 1;
            this.checkBoxBlock.Text = "Packet blocking";
            this.checkBoxBlock.UseVisualStyleBackColor = true;
            this.checkBoxBlock.CheckedChanged += new System.EventHandler(this.checkBoxBlock_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Location = new System.Drawing.Point(3, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(463, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Blocks outgoing move packets and displays the coordinates in the log.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonInjectClient, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonInjectServer, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxBlock, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxManipulate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLog, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(529, 510);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // buttonInjectServer
            // 
            this.buttonInjectServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInjectServer.Location = new System.Drawing.Point(267, 477);
            this.buttonInjectServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonInjectServer.Name = "buttonInjectServer";
            this.buttonInjectServer.Size = new System.Drawing.Size(259, 29);
            this.buttonInjectServer.TabIndex = 0;
            this.buttonInjectServer.Text = "Send to server";
            this.buttonInjectServer.UseVisualStyleBackColor = true;
            this.buttonInjectServer.Click += new System.EventHandler(this.ButtonInjectServer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Location = new System.Drawing.Point(3, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sends a chat packet to the client / server.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Packet injection";
            // 
            // textBoxLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxLog, 2);
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLog.Location = new System.Drawing.Point(3, 3);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(523, 333);
            this.textBoxLog.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 518);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Xabbo.GEarth WinForms example";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInjectClient;
        private System.Windows.Forms.CheckBox checkBoxManipulate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonInjectServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxBlock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLog;
    }
}

