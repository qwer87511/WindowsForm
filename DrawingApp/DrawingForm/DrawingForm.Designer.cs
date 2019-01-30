namespace DrawingForm
{
    partial class DrawingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._diamondButton = new System.Windows.Forms.Button();
            this._lineButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._ellipseButton = new System.Windows.Forms.Button();
            this._undoButton = new System.Windows.Forms.Button();
            this._redoButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _diamondButton
            // 
            this._diamondButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._diamondButton.Location = new System.Drawing.Point(876, 12);
            this._diamondButton.Name = "_diamondButton";
            this._diamondButton.Size = new System.Drawing.Size(150, 50);
            this._diamondButton.TabIndex = 4;
            this._diamondButton.Text = "Diamond";
            this._diamondButton.UseVisualStyleBackColor = true;
            // 
            // _lineButton
            // 
            this._lineButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._lineButton.Location = new System.Drawing.Point(720, 12);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(150, 50);
            this._lineButton.TabIndex = 3;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            // 
            // _clearButton
            // 
            this._clearButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._clearButton.Location = new System.Drawing.Point(1188, 12);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(150, 50);
            this._clearButton.TabIndex = 6;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            // 
            // _ellipseButton
            // 
            this._ellipseButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._ellipseButton.Location = new System.Drawing.Point(1032, 12);
            this._ellipseButton.Name = "_ellipseButton";
            this._ellipseButton.Size = new System.Drawing.Size(150, 50);
            this._ellipseButton.TabIndex = 5;
            this._ellipseButton.Text = "Ellipse";
            this._ellipseButton.UseVisualStyleBackColor = true;
            this._ellipseButton.Click += new System.EventHandler(this.HandleEllipseButtonClick);
            // 
            // _undoButton
            // 
            this._undoButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._undoButton.Location = new System.Drawing.Point(12, 12);
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(150, 50);
            this._undoButton.TabIndex = 7;
            this._undoButton.Text = "Undo";
            this._undoButton.UseVisualStyleBackColor = true;
            this._undoButton.Click += new System.EventHandler(this.HandleUndoButtonClick);
            // 
            // _redoButton
            // 
            this._redoButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._redoButton.Location = new System.Drawing.Point(168, 12);
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(150, 50);
            this._redoButton.TabIndex = 8;
            this._redoButton.Text = "Redo";
            this._redoButton.UseVisualStyleBackColor = true;
            this._redoButton.Click += new System.EventHandler(this.HandleRedoButtonClick);
            // 
            // _saveButton
            // 
            this._saveButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._saveButton.Location = new System.Drawing.Point(324, 12);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(150, 50);
            this._saveButton.TabIndex = 1;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.HandleSaveButtonClick);
            // 
            // _loadButton
            // 
            this._loadButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._loadButton.Location = new System.Drawing.Point(480, 12);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(150, 50);
            this._loadButton.TabIndex = 2;
            this._loadButton.Text = "Load";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this.HandleLoadButtonClick);
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this._loadButton);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._redoButton);
            this.Controls.Add(this._undoButton);
            this.Controls.Add(this._ellipseButton);
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this._lineButton);
            this.Controls.Add(this._diamondButton);
            this.Name = "DrawingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _diamondButton;
        private System.Windows.Forms.Button _lineButton;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _ellipseButton;
        private System.Windows.Forms.Button _undoButton;
        private System.Windows.Forms.Button _redoButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _loadButton;
    }
}

