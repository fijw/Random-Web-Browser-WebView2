using something;
using System.Windows.Forms;

namespace something
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.newTabBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshPageBtn = new something.RefreshButton();
            this.closePageBtn = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.RichTextBox();
            this.pageForwardBtn = new System.Windows.Forms.Button();
            this.pageBackBtn = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.RichTextBox();
            this.tabListPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabListPanel
            // 
            this.tabListPanel.BackColor = System.Drawing.Color.Khaki;
            this.tabListPanel.Controls.Add(this.newTabBtn);
            this.tabListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabListPanel.Location = new System.Drawing.Point(0, 0);
            this.tabListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tabListPanel.Name = "tabListPanel";
            this.tabListPanel.Size = new System.Drawing.Size(1284, 25);
            this.tabListPanel.TabIndex = 0;
            // 
            // newTabBtn
            // 
            this.newTabBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(224)))), ((int)(((byte)(225)))));
            this.newTabBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(224)))), ((int)(((byte)(225)))));
            this.newTabBtn.FlatAppearance.BorderSize = 0;
            this.newTabBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(224)))), ((int)(((byte)(225)))));
            this.newTabBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(224)))), ((int)(((byte)(225)))));
            this.newTabBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newTabBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTabBtn.Location = new System.Drawing.Point(2, 1);
            this.newTabBtn.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.newTabBtn.Name = "newTabBtn";
            this.newTabBtn.Size = new System.Drawing.Size(23, 23);
            this.newTabBtn.TabIndex = 1;
            this.newTabBtn.Text = "+";
            this.newTabBtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.refreshPageBtn);
            this.panel1.Controls.Add(this.closePageBtn);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Controls.Add(this.pageForwardBtn);
            this.panel1.Controls.Add(this.pageBackBtn);
            this.panel1.Controls.Add(this.urlTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 35);
            this.panel1.TabIndex = 2;
            // 
            // refreshPageBtn
            // 
            this.refreshPageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshPageBtn.BackColor = System.Drawing.Color.White;
            this.refreshPageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshPageBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.refreshPageBtn.FlatAppearance.BorderSize = 0;
            this.refreshPageBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.refreshPageBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.refreshPageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.refreshPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshPageBtn.Location = new System.Drawing.Point(864, 3);
            this.refreshPageBtn.Name = "refreshPageBtn";
            this.refreshPageBtn.Size = new System.Drawing.Size(28, 28);
            this.refreshPageBtn.TabIndex = 3;
            this.refreshPageBtn.Text = "↩️  ↪️";
            this.refreshPageBtn.UseVisualStyleBackColor = false;
            // 
            // closePageBtn
            // 
            this.closePageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closePageBtn.BackColor = System.Drawing.Color.White;
            this.closePageBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closePageBtn.FlatAppearance.BorderSize = 0;
            this.closePageBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.closePageBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.closePageBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.closePageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closePageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closePageBtn.Location = new System.Drawing.Point(892, 3);
            this.closePageBtn.Name = "closePageBtn";
            this.closePageBtn.Size = new System.Drawing.Size(28, 28);
            this.closePageBtn.TabIndex = 2;
            this.closePageBtn.Text = "X";
            this.closePageBtn.UseVisualStyleBackColor = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BackColor = System.Drawing.Color.White;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.DetectUrls = false;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(926, 3);
            this.searchTextBox.Multiline = false;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(355, 28);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.Text = "Google Search";
            // 
            // pageForwardBtn
            // 
            this.pageForwardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageForwardBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageForwardBtn.FlatAppearance.BorderSize = 0;
            this.pageForwardBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageForwardBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageForwardBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageForwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageForwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageForwardBtn.Location = new System.Drawing.Point(43, 4);
            this.pageForwardBtn.Name = "pageForwardBtn";
            this.pageForwardBtn.Size = new System.Drawing.Size(25, 25);
            this.pageForwardBtn.TabIndex = 1;
            this.pageForwardBtn.Text = "↪️";
            this.pageForwardBtn.UseVisualStyleBackColor = false;
            // 
            // pageBackBtn
            // 
            this.pageBackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageBackBtn.FlatAppearance.BorderSize = 0;
            this.pageBackBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(234)))), ((int)(((byte)(235)))));
            this.pageBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageBackBtn.Location = new System.Drawing.Point(12, 4);
            this.pageBackBtn.Name = "pageBackBtn";
            this.pageBackBtn.Size = new System.Drawing.Size(25, 25);
            this.pageBackBtn.TabIndex = 0;
            this.pageBackBtn.Text = "↩️";
            this.pageBackBtn.UseVisualStyleBackColor = false;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.BackColor = System.Drawing.Color.White;
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlTextBox.DetectUrls = false;
            this.urlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlTextBox.Location = new System.Drawing.Point(74, 3);
            this.urlTextBox.Multiline = false;
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(790, 28);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Text = "Enter URL Here";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 812);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabListPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1300, 850);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browser";
            this.TransparencyKey = System.Drawing.Color.Khaki;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabListPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel tabListPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox urlTextBox;
        private System.Windows.Forms.RichTextBox searchTextBox;
        private System.Windows.Forms.Button pageForwardBtn;
        private System.Windows.Forms.Button pageBackBtn;
        private System.Windows.Forms.Button closePageBtn;
        private something.RefreshButton refreshPageBtn;
        private Button newTabBtn;
    }
}

