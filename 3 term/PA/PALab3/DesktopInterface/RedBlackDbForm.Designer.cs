namespace DesktopInterface
{
    partial class RedBlackDbForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.InsertInput = new System.Windows.Forms.TextBox();
            this.InsertButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.FindInput = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DeleteInput = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.UpdateInput = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FindResultLabel = new System.Windows.Forms.Label();
            this.DeleteResultLabel = new System.Windows.Forms.Label();
            this.UpdateResultLabel = new System.Windows.Forms.Label();
            this.InsertResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // InsertInput
            // 
            this.InsertInput.Location = new System.Drawing.Point(82, 81);
            this.InsertInput.Name = "InsertInput";
            this.InsertInput.Size = new System.Drawing.Size(166, 23);
            this.InsertInput.TabIndex = 1;
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(316, 81);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 2;
            this.InsertButton.Text = "Insert value";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(316, 128);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(75, 23);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find key";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FindInput
            // 
            this.FindInput.Location = new System.Drawing.Point(82, 128);
            this.FindInput.Name = "FindInput";
            this.FindInput.Size = new System.Drawing.Size(166, 23);
            this.FindInput.TabIndex = 3;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(316, 190);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete key";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DeleteInput
            // 
            this.DeleteInput.Location = new System.Drawing.Point(82, 190);
            this.DeleteInput.Name = "DeleteInput";
            this.DeleteInput.Size = new System.Drawing.Size(166, 23);
            this.DeleteInput.TabIndex = 5;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(316, 279);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 8;
            this.UpdateButton.Text = "Update key";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // UpdateInput
            // 
            this.UpdateInput.Location = new System.Drawing.Point(82, 279);
            this.UpdateInput.Name = "UpdateInput";
            this.UpdateInput.Size = new System.Drawing.Size(166, 23);
            this.UpdateInput.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(272, 358);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(119, 49);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save changes";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(82, 358);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(119, 49);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(151, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "Red black db";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "To update, insert data in format \"key, new value\"";
            // 
            // FindResultLabel
            // 
            this.FindResultLabel.AutoSize = true;
            this.FindResultLabel.Location = new System.Drawing.Point(82, 163);
            this.FindResultLabel.Name = "FindResultLabel";
            this.FindResultLabel.Size = new System.Drawing.Size(0, 15);
            this.FindResultLabel.TabIndex = 13;
            // 
            // DeleteResultLabel
            // 
            this.DeleteResultLabel.AutoSize = true;
            this.DeleteResultLabel.Location = new System.Drawing.Point(92, 216);
            this.DeleteResultLabel.Name = "DeleteResultLabel";
            this.DeleteResultLabel.Size = new System.Drawing.Size(0, 15);
            this.DeleteResultLabel.TabIndex = 14;
            // 
            // UpdateResultLabel
            // 
            this.UpdateResultLabel.AutoSize = true;
            this.UpdateResultLabel.Location = new System.Drawing.Point(92, 316);
            this.UpdateResultLabel.Name = "UpdateResultLabel";
            this.UpdateResultLabel.Size = new System.Drawing.Size(0, 15);
            this.UpdateResultLabel.TabIndex = 15;
            // 
            // InsertResultLabel
            // 
            this.InsertResultLabel.AutoSize = true;
            this.InsertResultLabel.Location = new System.Drawing.Point(92, 107);
            this.InsertResultLabel.Name = "InsertResultLabel";
            this.InsertResultLabel.Size = new System.Drawing.Size(0, 15);
            this.InsertResultLabel.TabIndex = 16;
            // 
            // RedBlackDbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 450);
            this.Controls.Add(this.InsertResultLabel);
            this.Controls.Add(this.UpdateResultLabel);
            this.Controls.Add(this.DeleteResultLabel);
            this.Controls.Add(this.FindResultLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.UpdateInput);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DeleteInput);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.FindInput);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.InsertInput);
            this.Controls.Add(this.label1);
            this.Name = "RedBlackDbForm";
            this.Text = "RedBlackDb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox InsertInput;
        private Button InsertButton;
        private Button FindButton;
        private TextBox FindInput;
        private Button DeleteButton;
        private TextBox DeleteInput;
        private Button UpdateButton;
        private TextBox UpdateInput;
        private Button SaveButton;
        private Button CancelButton;
        private Label label2;
        private Label label3;
        private Label FindResultLabel;
        private Label DeleteResultLabel;
        private Label UpdateResultLabel;
        private Label InsertResultLabel;
    }
}