namespace PosSystem
{
    partial class StartUpForm
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
            this._tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._exitButton = new System.Windows.Forms.Button();
            this._startCustomerProgramButton = new System.Windows.Forms.Button();
            this._startRestaurantProgramButton = new System.Windows.Forms.Button();
            this._tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayout
            // 
            this._tableLayout.ColumnCount = 1;
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayout.Controls.Add(this._exitButton, 0, 2);
            this._tableLayout.Controls.Add(this._startCustomerProgramButton, 0, 0);
            this._tableLayout.Controls.Add(this._startRestaurantProgramButton, 0, 1);
            this._tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayout.Location = new System.Drawing.Point(0, 0);
            this._tableLayout.Name = "_tableLayout";
            this._tableLayout.RowCount = 3;
            this._tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this._tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this._tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this._tableLayout.Size = new System.Drawing.Size(611, 296);
            this._tableLayout.TabIndex = 0;
            // 
            // _exitButton
            // 
            this._exitButton.AccessibleName = "ExitButton";
            this._exitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._exitButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._exitButton.Location = new System.Drawing.Point(429, 203);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(179, 90);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ClickExitButton);
            // 
            // _startCustomerProgramButton
            // 
            this._startCustomerProgramButton.AccessibleName = "StartCustomerProgramButton";
            this._startCustomerProgramButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._startCustomerProgramButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._startCustomerProgramButton.Location = new System.Drawing.Point(3, 3);
            this._startCustomerProgramButton.Name = "_startCustomerProgramButton";
            this._startCustomerProgramButton.Size = new System.Drawing.Size(605, 94);
            this._startCustomerProgramButton.TabIndex = 0;
            this._startCustomerProgramButton.Text = "Start the Customer Program (Frontend)";
            this._startCustomerProgramButton.UseVisualStyleBackColor = true;
            this._startCustomerProgramButton.Click += new System.EventHandler(this.StartCustomerProgram);
            // 
            // _startRestaurantProgramButton
            // 
            this._startRestaurantProgramButton.AccessibleName = "StartRestaurantProgramButton";
            this._startRestaurantProgramButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._startRestaurantProgramButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._startRestaurantProgramButton.Location = new System.Drawing.Point(3, 103);
            this._startRestaurantProgramButton.Name = "_startRestaurantProgramButton";
            this._startRestaurantProgramButton.Size = new System.Drawing.Size(605, 94);
            this._startRestaurantProgramButton.TabIndex = 1;
            this._startRestaurantProgramButton.Text = "Start the Restaurant Program (Backend)";
            this._startRestaurantProgramButton.UseVisualStyleBackColor = true;
            this._startRestaurantProgramButton.Click += new System.EventHandler(this.StartRestaurantProgram);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 296);
            this.Controls.Add(this._tableLayout);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this._tableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayout;
        private System.Windows.Forms.Button _startCustomerProgramButton;
        private System.Windows.Forms.Button _startRestaurantProgramButton;
        private System.Windows.Forms.Button _exitButton;
    }
}