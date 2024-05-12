
namespace OpmlEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtMain = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_InputSpeedMinute = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_InputSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Up = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Down = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddInner = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTxtTimer = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ToDo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_NextDo = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(355, 469);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.Validating += new System.ComponentModel.CancelEventHandler(this.treeView1_Validating);
            // 
            // txtMain
            // 
            this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMain.Location = new System.Drawing.Point(0, 0);
            this.txtMain.Margin = new System.Windows.Forms.Padding(4);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMain.Size = new System.Drawing.Size(708, 469);
            this.txtMain.TabIndex = 1;
            this.txtMain.ModifiedChanged += new System.EventHandler(this.txtMain_ModifiedChanged);
            this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_InputSpeedMinute,
            this.toolStripStatusLabel_InputSpeed});
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1067, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_InputSpeedMinute
            // 
            this.toolStripStatusLabel_InputSpeedMinute.Name = "toolStripStatusLabel_InputSpeedMinute";
            this.toolStripStatusLabel_InputSpeedMinute.Size = new System.Drawing.Size(55, 20);
            this.toolStripStatusLabel_InputSpeedMinute.Text = "minute";
            // 
            // toolStripStatusLabel_InputSpeed
            // 
            this.toolStripStatusLabel_InputSpeed.Name = "toolStripStatusLabel_InputSpeed";
            this.toolStripStatusLabel_InputSpeed.Size = new System.Drawing.Size(68, 20);
            this.toolStripStatusLabel_InputSpeed.Text = "char/min";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openOToolStripMenuItem,
            this.saveSToolStripMenuItem,
            this.saveAsAToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeXToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // openOToolStripMenuItem
            // 
            this.openOToolStripMenuItem.Name = "openOToolStripMenuItem";
            this.openOToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.openOToolStripMenuItem.Text = "Open(&O)";
            this.openOToolStripMenuItem.Click += new System.EventHandler(this.openOToolStripMenuItem_Click);
            // 
            // saveSToolStripMenuItem
            // 
            this.saveSToolStripMenuItem.Name = "saveSToolStripMenuItem";
            this.saveSToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.saveSToolStripMenuItem.Text = "Save(&S)";
            this.saveSToolStripMenuItem.Click += new System.EventHandler(this.saveSToolStripMenuItem_Click);
            // 
            // saveAsAToolStripMenuItem
            // 
            this.saveAsAToolStripMenuItem.Name = "saveAsAToolStripMenuItem";
            this.saveAsAToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.saveAsAToolStripMenuItem.Text = "Save as(&A)";
            this.saveAsAToolStripMenuItem.Click += new System.EventHandler(this.saveAsAToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // closeXToolStripMenuItem
            // 
            this.closeXToolStripMenuItem.Name = "closeXToolStripMenuItem";
            this.closeXToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.closeXToolStripMenuItem.Text = "Close(&X)";
            this.closeXToolStripMenuItem.Click += new System.EventHandler(this.closeXToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripSeparator5,
            this.toolStripButton_Up,
            this.toolStripButton_Down,
            this.toolStripSeparator4,
            this.toolStripButton_Add,
            this.toolStripButton_AddInner,
            this.toolStripButton_Delete,
            this.toolStripSeparator3,
            this.toolStripTxtTimer,
            this.toolStripSeparator2,
            this.toolStripButton_ToDo,
            this.toolStripButton_NextDo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1067, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Save.Image")));
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Save.Text = "Save";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_Up
            // 
            this.toolStripButton_Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Up.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Up.Image")));
            this.toolStripButton_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Up.Name = "toolStripButton_Up";
            this.toolStripButton_Up.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Up.Text = "node_up";
            this.toolStripButton_Up.Click += new System.EventHandler(this.toolStripButton_Up_Click);
            // 
            // toolStripButton_Down
            // 
            this.toolStripButton_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Down.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Down.Image")));
            this.toolStripButton_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Down.Name = "toolStripButton_Down";
            this.toolStripButton_Down.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Down.Text = "node_down";
            this.toolStripButton_Down.Click += new System.EventHandler(this.toolStripButton_Down_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Add.Image")));
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Add.Text = "Add";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_AddInner
            // 
            this.toolStripButton_AddInner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddInner.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddInner.Image")));
            this.toolStripButton_AddInner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddInner.Name = "toolStripButton_AddInner";
            this.toolStripButton_AddInner.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_AddInner.Text = "Add_Inner";
            this.toolStripButton_AddInner.Click += new System.EventHandler(this.toolStripButton_AddInner_Click);
            // 
            // toolStripButton_Delete
            // 
            this.toolStripButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Delete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Delete.Image")));
            this.toolStripButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Delete.Name = "toolStripButton_Delete";
            this.toolStripButton_Delete.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_Delete.Text = "Delete";
            this.toolStripButton_Delete.Click += new System.EventHandler(this.toolStripButton_Delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripTxtTimer
            // 
            this.toolStripTxtTimer.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.toolStripTxtTimer.Name = "toolStripTxtTimer";
            this.toolStripTxtTimer.ReadOnly = true;
            this.toolStripTxtTimer.Size = new System.Drawing.Size(160, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton_ToDo
            // 
            this.toolStripButton_ToDo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ToDo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ToDo.Image")));
            this.toolStripButton_ToDo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ToDo.Name = "toolStripButton_ToDo";
            this.toolStripButton_ToDo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_ToDo.Text = "ToDo";
            this.toolStripButton_ToDo.Click += new System.EventHandler(this.toolStripButton_ToDo_Click);
            // 
            // toolStripButton_NextDo
            // 
            this.toolStripButton_NextDo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_NextDo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_NextDo.Image")));
            this.toolStripButton_NextDo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_NextDo.Name = "toolStripButton_NextDo";
            this.toolStripButton_NextDo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_NextDo.Text = "NextDo";
            this.toolStripButton_NextDo.Click += new System.EventHandler(this.toolStripButton_NextDo_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtMain);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 469);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 6;
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "OpmlEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeXToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddInner;
        private System.Windows.Forms.ToolStripButton toolStripButton_Delete;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ToDo;
        private System.Windows.Forms.ToolStripButton toolStripButton_NextDo;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ToolStripMenuItem saveAsAToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_Up;
        private System.Windows.Forms.ToolStripButton toolStripButton_Down;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_InputSpeed;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_InputSpeedMinute;
    }
}

