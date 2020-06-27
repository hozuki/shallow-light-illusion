namespace AchievementUnlocker.Forms
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAppId = new System.Windows.Forms.Label();
            this.lblAccountInfo = new System.Windows.Forms.Label();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iml = new System.Windows.Forms.ImageList(this.components);
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current AppID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current account:";
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(122, 23);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(51, 13);
            this.lblAppId.TabIndex = 2;
            this.lblAppId.Text = "$APP_ID";
            // 
            // lblAccountInfo
            // 
            this.lblAccountInfo.AutoSize = true;
            this.lblAccountInfo.Location = new System.Drawing.Point(122, 49);
            this.lblAccountInfo.Name = "lblAccountInfo";
            this.lblAccountInfo.Size = new System.Drawing.Size(65, 13);
            this.lblAccountInfo.TabIndex = 3;
            this.lblAccountInfo.Text = "$ACCOUNT";
            // 
            // lv
            // 
            this.lv.CheckBoxes = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(12, 75);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(701, 341);
            this.lv.SmallImageList = this.iml;
            this.lv.TabIndex = 4;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Display Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Achieved";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "API Name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Hidden";
            // 
            // iml
            // 
            this.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iml.ImageSize = new System.Drawing.Size(48, 48);
            this.iml.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnSelAll
            // 
            this.btnSelAll.Location = new System.Drawing.Point(509, 422);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(99, 29);
            this.btnSelAll.TabIndex = 5;
            this.btnSelAll.Text = "Select &All";
            this.btnSelAll.UseVisualStyleBackColor = true;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(614, 422);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(99, 29);
            this.btnUnlock.TabIndex = 6;
            this.btnUnlock.Text = "&Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(12, 430);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(48, 13);
            this.lblStats.TabIndex = 7;
            this.lblStats.Text = "$STATS";
            this.lblStats.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 459);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnSelAll);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.lblAccountInfo);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Achievements";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.Label lblAccountInfo;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ImageList iml;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Label lblStats;
    }
}