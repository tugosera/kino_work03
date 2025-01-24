namespace kino_work03
{
    partial class User_buy_tickets
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
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(85, 271);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(139, 119);
            this.button17.TabIndex = 16;
            this.button17.Text = "Buy";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(12, 12);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(101, 35);
            this.button18.TabIndex = 17;
            this.button18.Text = "Back";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // User_buy_tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Name = "User_buy_tickets";
            this.Text = "User_buy_tickets";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
    }
}