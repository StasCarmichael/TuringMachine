
namespace TuringMachineWinForms
{
    partial class bootForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bootForm));
            this.richTextBoxforUser = new System.Windows.Forms.RichTextBox();
            this.buttonDonwload = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxforUser
            // 
            this.richTextBoxforUser.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxforUser.Location = new System.Drawing.Point(6, 7);
            this.richTextBoxforUser.Name = "richTextBoxforUser";
            this.richTextBoxforUser.Size = new System.Drawing.Size(786, 410);
            this.richTextBoxforUser.TabIndex = 0;
            this.richTextBoxforUser.Text = "";
            // 
            // buttonDonwload
            // 
            this.buttonDonwload.BackColor = System.Drawing.Color.Lime;
            this.buttonDonwload.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDonwload.Location = new System.Drawing.Point(180, 427);
            this.buttonDonwload.Name = "buttonDonwload";
            this.buttonDonwload.Size = new System.Drawing.Size(182, 61);
            this.buttonDonwload.TabIndex = 1;
            this.buttonDonwload.Text = "Завантажити дані";
            this.buttonDonwload.UseVisualStyleBackColor = false;
            this.buttonDonwload.Click += new System.EventHandler(this.buttonDonwload_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(478, 427);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(182, 61);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Вийти";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // bootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDonwload);
            this.Controls.Add(this.richTextBoxforUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "bootForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bootForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bootForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bootForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxforUser;
        private System.Windows.Forms.Button buttonDonwload;
        private System.Windows.Forms.Button buttonExit;
    }
}