namespace PosSystem
{
    partial class PosCustomerSideForm
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
            this._totalLabel = new System.Windows.Forms.Label();
            this._orderDataGridView = new System.Windows.Forms.DataGridView();
            this._mealsGroupBox = new System.Windows.Forms.GroupBox();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tabPage = new System.Windows.Forms.TabPage();
            this._mealButtonsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._mealButton8 = new System.Windows.Forms.Button();
            this._mealButton7 = new System.Windows.Forms.Button();
            this._mealButton6 = new System.Windows.Forms.Button();
            this._mealButton5 = new System.Windows.Forms.Button();
            this._mealButton4 = new System.Windows.Forms.Button();
            this._mealButton3 = new System.Windows.Forms.Button();
            this._mealButton2 = new System.Windows.Forms.Button();
            this._mealButton1 = new System.Windows.Forms.Button();
            this._mealButton0 = new System.Windows.Forms.Button();
            this._mealDescribeTextBox = new System.Windows.Forms.RichTextBox();
            this._pageLabel = new System.Windows.Forms.Label();
            this._nextPageButton = new System.Windows.Forms.Button();
            this._previousPageButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._orderItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this._nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._quantityDataGridViewTextBoxColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._subtotalDollarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._orderDataGridView)).BeginInit();
            this._mealsGroupBox.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._tabPage.SuspendLayout();
            this._mealButtonsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._orderItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _totalLabel
            // 
            this._totalLabel.AccessibleName = "TotalLabel";
            this._totalLabel.AutoSize = true;
            this._totalLabel.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._totalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this._totalLabel.Location = new System.Drawing.Point(769, 543);
            this._totalLabel.Name = "_totalLabel";
            this._totalLabel.Size = new System.Drawing.Size(129, 47);
            this._totalLabel.TabIndex = 8;
            this._totalLabel.Text = "Total :";
            // 
            // _orderDataGridView
            // 
            this._orderDataGridView.AccessibleName = "OrderDataGridView";
            this._orderDataGridView.AllowUserToAddRows = false;
            this._orderDataGridView.AutoGenerateColumns = false;
            this._orderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._orderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._orderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteButton,
            this._nameDataGridViewTextBoxColumn,
            this._categoryNameDataGridViewTextBoxColumn,
            this._unitPriceDataGridViewTextBoxColumn,
            this._quantityDataGridViewTextBoxColumn,
            this._subtotalDollarDataGridViewTextBoxColumn});
            this._orderDataGridView.DataSource = this._orderItemBindingSource;
            this._orderDataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._orderDataGridView.Location = new System.Drawing.Point(532, 10);
            this._orderDataGridView.Name = "_orderDataGridView";
            this._orderDataGridView.RowHeadersVisible = false;
            this._orderDataGridView.RowTemplate.Height = 24;
            this._orderDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._orderDataGridView.Size = new System.Drawing.Size(590, 512);
            this._orderDataGridView.TabIndex = 7;
            this._orderDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridViewCell);
            this._orderDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeDataGridViewCellValue);
            // 
            // _mealsGroupBox
            // 
            this._mealsGroupBox.Controls.Add(this._tabControl);
            this._mealsGroupBox.Controls.Add(this._mealDescribeTextBox);
            this._mealsGroupBox.Controls.Add(this._pageLabel);
            this._mealsGroupBox.Controls.Add(this._nextPageButton);
            this._mealsGroupBox.Controls.Add(this._previousPageButton);
            this._mealsGroupBox.Controls.Add(this._addButton);
            this._mealsGroupBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._mealsGroupBox.Location = new System.Drawing.Point(12, 10);
            this._mealsGroupBox.Name = "_mealsGroupBox";
            this._mealsGroupBox.Size = new System.Drawing.Size(490, 577);
            this._mealsGroupBox.TabIndex = 6;
            this._mealsGroupBox.TabStop = false;
            this._mealsGroupBox.Text = "Meals";
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabPage);
            this._tabControl.Location = new System.Drawing.Point(6, 21);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(478, 399);
            this._tabControl.TabIndex = 5;
            this._tabControl.SelectedIndexChanged += new System.EventHandler(this.SelectTabControl);
            // 
            // _tabPage
            // 
            this._tabPage.Controls.Add(this._mealButtonsTableLayout);
            this._tabPage.Location = new System.Drawing.Point(4, 25);
            this._tabPage.Name = "_tabPage";
            this._tabPage.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage.Size = new System.Drawing.Size(470, 370);
            this._tabPage.TabIndex = 0;
            this._tabPage.UseVisualStyleBackColor = true;
            // 
            // _mealButtonsTableLayout
            // 
            this._mealButtonsTableLayout.ColumnCount = 3;
            this._mealButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._mealButtonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._mealButtonsTableLayout.Controls.Add(this._mealButton8, 2, 2);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton7, 1, 2);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton6, 0, 2);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton5, 2, 1);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton4, 1, 1);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton3, 0, 1);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton2, 2, 0);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton1, 1, 0);
            this._mealButtonsTableLayout.Controls.Add(this._mealButton0, 0, 0);
            this._mealButtonsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButtonsTableLayout.Location = new System.Drawing.Point(3, 3);
            this._mealButtonsTableLayout.Name = "_mealButtonsTableLayout";
            this._mealButtonsTableLayout.RowCount = 3;
            this._mealButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealButtonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._mealButtonsTableLayout.Size = new System.Drawing.Size(464, 364);
            this._mealButtonsTableLayout.TabIndex = 0;
            // 
            // _mealButton8
            // 
            this._mealButton8.AccessibleName = "MealButton8";
            this._mealButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton8.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton8.ForeColor = System.Drawing.Color.White;
            this._mealButton8.Location = new System.Drawing.Point(311, 245);
            this._mealButton8.Name = "_mealButton8";
            this._mealButton8.Size = new System.Drawing.Size(150, 116);
            this._mealButton8.TabIndex = 8;
            this._mealButton8.Tag = "8";
            this._mealButton8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton8.UseVisualStyleBackColor = true;
            this._mealButton8.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton7
            // 
            this._mealButton7.AccessibleName = "MealButton7";
            this._mealButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton7.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton7.ForeColor = System.Drawing.Color.White;
            this._mealButton7.Location = new System.Drawing.Point(157, 245);
            this._mealButton7.Name = "_mealButton7";
            this._mealButton7.Size = new System.Drawing.Size(148, 116);
            this._mealButton7.TabIndex = 7;
            this._mealButton7.Tag = "7";
            this._mealButton7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton7.UseVisualStyleBackColor = true;
            this._mealButton7.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton6
            // 
            this._mealButton6.AccessibleName = "MealButton6";
            this._mealButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton6.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton6.ForeColor = System.Drawing.Color.White;
            this._mealButton6.Location = new System.Drawing.Point(3, 245);
            this._mealButton6.Name = "_mealButton6";
            this._mealButton6.Size = new System.Drawing.Size(148, 116);
            this._mealButton6.TabIndex = 6;
            this._mealButton6.Tag = "6";
            this._mealButton6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton6.UseVisualStyleBackColor = true;
            this._mealButton6.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton5
            // 
            this._mealButton5.AccessibleName = "MealButton5";
            this._mealButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton5.ForeColor = System.Drawing.Color.White;
            this._mealButton5.Location = new System.Drawing.Point(311, 124);
            this._mealButton5.Name = "_mealButton5";
            this._mealButton5.Size = new System.Drawing.Size(150, 115);
            this._mealButton5.TabIndex = 5;
            this._mealButton5.Tag = "5";
            this._mealButton5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton5.UseVisualStyleBackColor = true;
            this._mealButton5.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton4
            // 
            this._mealButton4.AccessibleName = "MealButton4";
            this._mealButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton4.ForeColor = System.Drawing.Color.White;
            this._mealButton4.Location = new System.Drawing.Point(157, 124);
            this._mealButton4.Name = "_mealButton4";
            this._mealButton4.Size = new System.Drawing.Size(148, 115);
            this._mealButton4.TabIndex = 4;
            this._mealButton4.Tag = "4";
            this._mealButton4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton4.UseVisualStyleBackColor = true;
            this._mealButton4.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton3
            // 
            this._mealButton3.AccessibleName = "MealButton3";
            this._mealButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton3.ForeColor = System.Drawing.Color.White;
            this._mealButton3.Location = new System.Drawing.Point(3, 124);
            this._mealButton3.Name = "_mealButton3";
            this._mealButton3.Size = new System.Drawing.Size(148, 115);
            this._mealButton3.TabIndex = 3;
            this._mealButton3.Tag = "3";
            this._mealButton3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton3.UseVisualStyleBackColor = true;
            this._mealButton3.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton2
            // 
            this._mealButton2.AccessibleName = "MealButton2";
            this._mealButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton2.ForeColor = System.Drawing.Color.White;
            this._mealButton2.Location = new System.Drawing.Point(311, 3);
            this._mealButton2.Name = "_mealButton2";
            this._mealButton2.Size = new System.Drawing.Size(150, 115);
            this._mealButton2.TabIndex = 2;
            this._mealButton2.Tag = "2";
            this._mealButton2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton2.UseVisualStyleBackColor = true;
            this._mealButton2.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton1
            // 
            this._mealButton1.AccessibleName = "MealButton1";
            this._mealButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton1.ForeColor = System.Drawing.Color.White;
            this._mealButton1.Location = new System.Drawing.Point(157, 3);
            this._mealButton1.Name = "_mealButton1";
            this._mealButton1.Size = new System.Drawing.Size(148, 115);
            this._mealButton1.TabIndex = 1;
            this._mealButton1.Tag = "1";
            this._mealButton1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton1.UseVisualStyleBackColor = true;
            this._mealButton1.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealButton0
            // 
            this._mealButton0.AccessibleName = "MealButton0";
            this._mealButton0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._mealButton0.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mealButton0.ForeColor = System.Drawing.Color.White;
            this._mealButton0.Location = new System.Drawing.Point(3, 3);
            this._mealButton0.Name = "_mealButton0";
            this._mealButton0.Size = new System.Drawing.Size(148, 115);
            this._mealButton0.TabIndex = 0;
            this._mealButton0.Tag = "0";
            this._mealButton0.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._mealButton0.UseVisualStyleBackColor = true;
            this._mealButton0.Click += new System.EventHandler(this.ClickMealButton);
            // 
            // _mealDescribeTextBox
            // 
            this._mealDescribeTextBox.AccessibleName = "MealDescribeTextBox";
            this._mealDescribeTextBox.Location = new System.Drawing.Point(6, 426);
            this._mealDescribeTextBox.Name = "_mealDescribeTextBox";
            this._mealDescribeTextBox.ReadOnly = true;
            this._mealDescribeTextBox.Size = new System.Drawing.Size(474, 87);
            this._mealDescribeTextBox.TabIndex = 4;
            this._mealDescribeTextBox.Text = "";
            // 
            // _pageLabel
            // 
            this._pageLabel.AccessibleName = "PageLabel";
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._pageLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._pageLabel.Location = new System.Drawing.Point(0, 543);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(63, 24);
            this._pageLabel.TabIndex = 3;
            this._pageLabel.Text = "Page :";
            // 
            // _nextPageButton
            // 
            this._nextPageButton.AccessibleName = "NextPageButton";
            this._nextPageButton.Location = new System.Drawing.Point(357, 548);
            this._nextPageButton.Name = "_nextPageButton";
            this._nextPageButton.Size = new System.Drawing.Size(123, 23);
            this._nextPageButton.TabIndex = 0;
            this._nextPageButton.Text = "Next Page";
            this._nextPageButton.Click += new System.EventHandler(this.ClickNextPageButton);
            // 
            // _previousPageButton
            // 
            this._previousPageButton.AccessibleName = "PreviousPageButton";
            this._previousPageButton.Enabled = false;
            this._previousPageButton.Location = new System.Drawing.Point(228, 548);
            this._previousPageButton.Name = "_previousPageButton";
            this._previousPageButton.Size = new System.Drawing.Size(123, 23);
            this._previousPageButton.TabIndex = 2;
            this._previousPageButton.Text = "Previous Page";
            this._previousPageButton.UseVisualStyleBackColor = true;
            this._previousPageButton.Click += new System.EventHandler(this.ClickPreviousPageButton);
            // 
            // _addButton
            // 
            this._addButton.AccessibleName = "AddButton";
            this._addButton.Enabled = false;
            this._addButton.Location = new System.Drawing.Point(357, 519);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(123, 23);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.ClickAddButton);
            // 
            // _orderItemBindingSource
            // 
            this._orderItemBindingSource.DataSource = typeof(PosSystem.OrderItem);
            // 
            // _deleteButton
            // 
            this._deleteButton.HeaderText = "Delete";
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.ReadOnly = true;
            this._deleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteButton.Text = "X";
            this._deleteButton.UseColumnTextForButtonValue = true;
            // 
            // _nameDataGridViewTextBoxColumn
            // 
            this._nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this._nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this._nameDataGridViewTextBoxColumn.Name = "_nameDataGridViewTextBoxColumn";
            this._nameDataGridViewTextBoxColumn.ReadOnly = true;
            this._nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _categoryNameDataGridViewTextBoxColumn
            // 
            this._categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            this._categoryNameDataGridViewTextBoxColumn.HeaderText = "Category";
            this._categoryNameDataGridViewTextBoxColumn.Name = "_categoryNameDataGridViewTextBoxColumn";
            this._categoryNameDataGridViewTextBoxColumn.ReadOnly = true;
            this._categoryNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _unitPriceDataGridViewTextBoxColumn
            // 
            this._unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            this._unitPriceDataGridViewTextBoxColumn.HeaderText = "Unit Price";
            this._unitPriceDataGridViewTextBoxColumn.Name = "_unitPriceDataGridViewTextBoxColumn";
            this._unitPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this._unitPriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _quantityDataGridViewTextBoxColumn
            // 
            this._quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this._quantityDataGridViewTextBoxColumn.HeaderText = "Qty";
            this._quantityDataGridViewTextBoxColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._quantityDataGridViewTextBoxColumn.Name = "_quantityDataGridViewTextBoxColumn";
            this._quantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // _subtotalDollarDataGridViewTextBoxColumn
            // 
            this._subtotalDollarDataGridViewTextBoxColumn.DataPropertyName = "SubtotalDollar";
            this._subtotalDollarDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this._subtotalDollarDataGridViewTextBoxColumn.Name = "_subtotalDollarDataGridViewTextBoxColumn";
            this._subtotalDollarDataGridViewTextBoxColumn.ReadOnly = true;
            this._subtotalDollarDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PosCustomerSideForm
            // 
            this.AccessibleName = "PosCustomerSideForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 601);
            this.Controls.Add(this._totalLabel);
            this.Controls.Add(this._orderDataGridView);
            this.Controls.Add(this._mealsGroupBox);
            this.Name = "PosCustomerSideForm";
            this.Text = "PosCustomerSideForm";
            ((System.ComponentModel.ISupportInitialize)(this._orderDataGridView)).EndInit();
            this._mealsGroupBox.ResumeLayout(false);
            this._mealsGroupBox.PerformLayout();
            this._tabControl.ResumeLayout(false);
            this._tabPage.ResumeLayout(false);
            this._mealButtonsTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._orderItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _totalLabel;
        private System.Windows.Forms.DataGridView _orderDataGridView;
        private System.Windows.Forms.GroupBox _mealsGroupBox;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _tabPage;
        private System.Windows.Forms.TableLayoutPanel _mealButtonsTableLayout;
        private System.Windows.Forms.RichTextBox _mealDescribeTextBox;
        private System.Windows.Forms.Label _pageLabel;
        private System.Windows.Forms.Button _nextPageButton;
        private System.Windows.Forms.Button _previousPageButton;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _mealButton8;
        private System.Windows.Forms.Button _mealButton7;
        private System.Windows.Forms.Button _mealButton6;
        private System.Windows.Forms.Button _mealButton5;
        private System.Windows.Forms.Button _mealButton4;
        private System.Windows.Forms.Button _mealButton3;
        private System.Windows.Forms.Button _mealButton2;
        private System.Windows.Forms.Button _mealButton1;
        private System.Windows.Forms.Button _mealButton0;
        private System.Windows.Forms.BindingSource _orderItemBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _categoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unitPriceDataGridViewTextBoxColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _subtotalDollarDataGridViewTextBoxColumn;
    }
}