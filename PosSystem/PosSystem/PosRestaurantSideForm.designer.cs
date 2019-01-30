namespace PosSystem
{
    partial class PosRestaurantSideForm
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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._mealManagerPage = new System.Windows.Forms.TabPage();
            this._addMealButton = new System.Windows.Forms.Button();
            this._editMealGroupBox = new System.Windows.Forms.GroupBox();
            this._currencyLabel = new System.Windows.Forms.Label();
            this._mealCategoryLabel = new System.Windows.Forms.Label();
            this._saveMealButton = new System.Windows.Forms.Button();
            this._mealDescriptionTextBox = new System.Windows.Forms.TextBox();
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._browseFileButton = new System.Windows.Forms.Button();
            this._mealImagePathTextBox = new System.Windows.Forms.TextBox();
            this._mealPriceTextBox = new System.Windows.Forms.TextBox();
            this._mealNameTextBox = new System.Windows.Forms.TextBox();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._pathLabel = new System.Windows.Forms.Label();
            this._mealPriceLabel = new System.Windows.Forms.Label();
            this._mealNameLabel = new System.Windows.Forms.Label();
            this._deleteMealButton = new System.Windows.Forms.Button();
            this._mealListBox = new System.Windows.Forms.ListBox();
            this._categoryManagerPage = new System.Windows.Forms.TabPage();
            this._categoryListBox = new System.Windows.Forms.ListBox();
            this._deleteCategoryButton = new System.Windows.Forms.Button();
            this._addCategoryButton = new System.Windows.Forms.Button();
            this._editCategoryGroupBox = new System.Windows.Forms.GroupBox();
            this._mealsOfSelectedCategoryListBox = new System.Windows.Forms.ListBox();
            this._saveCategoryButton = new System.Windows.Forms.Button();
            this._mealsOfCategoryLabel = new System.Windows.Forms.Label();
            this._categoryNameTextBox = new System.Windows.Forms.TextBox();
            this._categoryNameLabel = new System.Windows.Forms.Label();
            this._tabControl.SuspendLayout();
            this._mealManagerPage.SuspendLayout();
            this._editMealGroupBox.SuspendLayout();
            this._categoryManagerPage.SuspendLayout();
            this._editCategoryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tabControl.Controls.Add(this._mealManagerPage);
            this._tabControl.Controls.Add(this._categoryManagerPage);
            this._tabControl.Location = new System.Drawing.Point(12, 16);
            this._tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1110, 573);
            this._tabControl.TabIndex = 0;
            this._tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.SelectTabControl);
            // 
            // _mealManagerPage
            // 
            this._mealManagerPage.Controls.Add(this._addMealButton);
            this._mealManagerPage.Controls.Add(this._editMealGroupBox);
            this._mealManagerPage.Controls.Add(this._deleteMealButton);
            this._mealManagerPage.Controls.Add(this._mealListBox);
            this._mealManagerPage.Location = new System.Drawing.Point(4, 25);
            this._mealManagerPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._mealManagerPage.Name = "_mealManagerPage";
            this._mealManagerPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._mealManagerPage.Size = new System.Drawing.Size(1102, 544);
            this._mealManagerPage.TabIndex = 0;
            this._mealManagerPage.Text = "Meal Manager";
            this._mealManagerPage.UseVisualStyleBackColor = true;
            // 
            // _addMealButton
            // 
            this._addMealButton.AccessibleName = "AddMealButton";
            this._addMealButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._addMealButton.Location = new System.Drawing.Point(6, 506);
            this._addMealButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._addMealButton.Name = "_addMealButton";
            this._addMealButton.Size = new System.Drawing.Size(160, 28);
            this._addMealButton.TabIndex = 5;
            this._addMealButton.Text = "Add New Meal";
            this._addMealButton.UseVisualStyleBackColor = true;
            this._addMealButton.Click += new System.EventHandler(this.ClickAddMealButton);
            // 
            // _editMealGroupBox
            // 
            this._editMealGroupBox.Controls.Add(this._currencyLabel);
            this._editMealGroupBox.Controls.Add(this._mealCategoryLabel);
            this._editMealGroupBox.Controls.Add(this._saveMealButton);
            this._editMealGroupBox.Controls.Add(this._mealDescriptionTextBox);
            this._editMealGroupBox.Controls.Add(this._categoryComboBox);
            this._editMealGroupBox.Controls.Add(this._browseFileButton);
            this._editMealGroupBox.Controls.Add(this._mealImagePathTextBox);
            this._editMealGroupBox.Controls.Add(this._mealPriceTextBox);
            this._editMealGroupBox.Controls.Add(this._mealNameTextBox);
            this._editMealGroupBox.Controls.Add(this._descriptionLabel);
            this._editMealGroupBox.Controls.Add(this._pathLabel);
            this._editMealGroupBox.Controls.Add(this._mealPriceLabel);
            this._editMealGroupBox.Controls.Add(this._mealNameLabel);
            this._editMealGroupBox.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._editMealGroupBox.Location = new System.Drawing.Point(388, 10);
            this._editMealGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this._editMealGroupBox.Name = "_editMealGroupBox";
            this._editMealGroupBox.Size = new System.Drawing.Size(705, 524);
            this._editMealGroupBox.TabIndex = 3;
            this._editMealGroupBox.TabStop = false;
            this._editMealGroupBox.Text = "Edit Meal";
            // 
            // _currencyLabel
            // 
            this._currencyLabel.AutoSize = true;
            this._currencyLabel.Location = new System.Drawing.Point(322, 110);
            this._currencyLabel.Name = "_currencyLabel";
            this._currencyLabel.Size = new System.Drawing.Size(35, 17);
            this._currencyLabel.TabIndex = 14;
            this._currencyLabel.Text = "NTD";
            // 
            // _mealCategoryLabel
            // 
            this._mealCategoryLabel.AutoSize = true;
            this._mealCategoryLabel.Location = new System.Drawing.Point(363, 110);
            this._mealCategoryLabel.Name = "_mealCategoryLabel";
            this._mealCategoryLabel.Size = new System.Drawing.Size(114, 17);
            this._mealCategoryLabel.TabIndex = 13;
            this._mealCategoryLabel.Text = "Meal Category (*)";
            // 
            // _saveMealButton
            // 
            this._saveMealButton.AccessibleName = "SaveMealButton";
            this._saveMealButton.Location = new System.Drawing.Point(546, 490);
            this._saveMealButton.Name = "_saveMealButton";
            this._saveMealButton.Size = new System.Drawing.Size(150, 28);
            this._saveMealButton.TabIndex = 12;
            this._saveMealButton.Text = "Save";
            this._saveMealButton.UseVisualStyleBackColor = true;
            this._saveMealButton.Click += new System.EventHandler(this.ClickSaveMealButton);
            // 
            // _mealDescriptionTextBox
            // 
            this._mealDescriptionTextBox.AccessibleName = "MealDescriptionTextBox";
            this._mealDescriptionTextBox.Location = new System.Drawing.Point(9, 269);
            this._mealDescriptionTextBox.Margin = new System.Windows.Forms.Padding(6);
            this._mealDescriptionTextBox.Multiline = true;
            this._mealDescriptionTextBox.Name = "_mealDescriptionTextBox";
            this._mealDescriptionTextBox.Size = new System.Drawing.Size(687, 212);
            this._mealDescriptionTextBox.TabIndex = 11;
            this._mealDescriptionTextBox.TextChanged += new System.EventHandler(this.ChangeMealDescriptionTextBox);
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.AccessibleName = "CategoryComboBox";
            this._categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(486, 107);
            this._categoryComboBox.Margin = new System.Windows.Forms.Padding(6);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(210, 25);
            this._categoryComboBox.TabIndex = 10;
            this._categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectCategoryComboBoxIndex);
            // 
            // _browseFileButton
            // 
            this._browseFileButton.AccessibleName = "BrowseFileButton";
            this._browseFileButton.Location = new System.Drawing.Point(600, 172);
            this._browseFileButton.Name = "_browseFileButton";
            this._browseFileButton.Size = new System.Drawing.Size(96, 25);
            this._browseFileButton.TabIndex = 9;
            this._browseFileButton.Text = "browse...";
            this._browseFileButton.UseVisualStyleBackColor = true;
            this._browseFileButton.Click += new System.EventHandler(this.ClickBrowseFileButton);
            // 
            // _mealImagePathTextBox
            // 
            this._mealImagePathTextBox.AccessibleName = "MealImagePathTextBox";
            this._mealImagePathTextBox.Location = new System.Drawing.Point(204, 172);
            this._mealImagePathTextBox.Margin = new System.Windows.Forms.Padding(6);
            this._mealImagePathTextBox.Name = "_mealImagePathTextBox";
            this._mealImagePathTextBox.ReadOnly = true;
            this._mealImagePathTextBox.Size = new System.Drawing.Size(387, 25);
            this._mealImagePathTextBox.TabIndex = 8;
            // 
            // _mealPriceTextBox
            // 
            this._mealPriceTextBox.AccessibleName = "MealPriceTextBox";
            this._mealPriceTextBox.Location = new System.Drawing.Point(121, 107);
            this._mealPriceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this._mealPriceTextBox.Name = "_mealPriceTextBox";
            this._mealPriceTextBox.Size = new System.Drawing.Size(192, 25);
            this._mealPriceTextBox.TabIndex = 5;
            this._mealPriceTextBox.TextChanged += new System.EventHandler(this.ChangeMealPriceText);
            // 
            // _mealNameTextBox
            // 
            this._mealNameTextBox.AccessibleName = "MealNameTextBox";
            this._mealNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._mealNameTextBox.Location = new System.Drawing.Point(121, 42);
            this._mealNameTextBox.Margin = new System.Windows.Forms.Padding(6);
            this._mealNameTextBox.Name = "_mealNameTextBox";
            this._mealNameTextBox.Size = new System.Drawing.Size(575, 25);
            this._mealNameTextBox.TabIndex = 4;
            this._mealNameTextBox.TextChanged += new System.EventHandler(this.ChangeMealNameTextBox);
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(12, 240);
            this._descriptionLabel.Margin = new System.Windows.Forms.Padding(9, 24, 9, 6);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(110, 17);
            this._descriptionLabel.TabIndex = 3;
            this._descriptionLabel.Text = "Meal Description";
            // 
            // _pathLabel
            // 
            this._pathLabel.AutoSize = true;
            this._pathLabel.Location = new System.Drawing.Point(12, 175);
            this._pathLabel.Margin = new System.Windows.Forms.Padding(9, 24, 9, 24);
            this._pathLabel.Name = "_pathLabel";
            this._pathLabel.Size = new System.Drawing.Size(177, 17);
            this._pathLabel.TabIndex = 2;
            this._pathLabel.Text = "Meal Image Relative Path (*)";
            // 
            // _mealPriceLabel
            // 
            this._mealPriceLabel.AutoSize = true;
            this._mealPriceLabel.Location = new System.Drawing.Point(12, 110);
            this._mealPriceLabel.Margin = new System.Windows.Forms.Padding(9, 24, 9, 24);
            this._mealPriceLabel.Name = "_mealPriceLabel";
            this._mealPriceLabel.Size = new System.Drawing.Size(87, 17);
            this._mealPriceLabel.TabIndex = 1;
            this._mealPriceLabel.Text = "Meal Price (*)";
            // 
            // _mealNameLabel
            // 
            this._mealNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mealNameLabel.AutoSize = true;
            this._mealNameLabel.Location = new System.Drawing.Point(12, 45);
            this._mealNameLabel.Margin = new System.Windows.Forms.Padding(9, 24, 9, 24);
            this._mealNameLabel.Name = "_mealNameLabel";
            this._mealNameLabel.Size = new System.Drawing.Size(94, 17);
            this._mealNameLabel.TabIndex = 0;
            this._mealNameLabel.Text = "Meal Name (*)";
            // 
            // _deleteMealButton
            // 
            this._deleteMealButton.AccessibleName = "DeleteMealButton";
            this._deleteMealButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._deleteMealButton.Location = new System.Drawing.Point(219, 506);
            this._deleteMealButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._deleteMealButton.Name = "_deleteMealButton";
            this._deleteMealButton.Size = new System.Drawing.Size(160, 28);
            this._deleteMealButton.TabIndex = 2;
            this._deleteMealButton.Text = "Delete Selected Meal";
            this._deleteMealButton.UseVisualStyleBackColor = true;
            this._deleteMealButton.Click += new System.EventHandler(this.ClickDeleteMealButton);
            // 
            // _mealListBox
            // 
            this._mealListBox.AccessibleName = "MealListBox";
            this._mealListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mealListBox.FormattingEnabled = true;
            this._mealListBox.ItemHeight = 16;
            this._mealListBox.Location = new System.Drawing.Point(6, 7);
            this._mealListBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this._mealListBox.Name = "_mealListBox";
            this._mealListBox.Size = new System.Drawing.Size(373, 484);
            this._mealListBox.TabIndex = 0;
            this._mealListBox.SelectedIndexChanged += new System.EventHandler(this.SelectMealListBoxIndex);
            // 
            // _categoryManagerPage
            // 
            this._categoryManagerPage.Controls.Add(this._categoryListBox);
            this._categoryManagerPage.Controls.Add(this._deleteCategoryButton);
            this._categoryManagerPage.Controls.Add(this._addCategoryButton);
            this._categoryManagerPage.Controls.Add(this._editCategoryGroupBox);
            this._categoryManagerPage.Location = new System.Drawing.Point(4, 25);
            this._categoryManagerPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._categoryManagerPage.Name = "_categoryManagerPage";
            this._categoryManagerPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._categoryManagerPage.Size = new System.Drawing.Size(1102, 544);
            this._categoryManagerPage.TabIndex = 1;
            this._categoryManagerPage.Text = "Category Manager";
            this._categoryManagerPage.UseVisualStyleBackColor = true;
            // 
            // _categoryListBox
            // 
            this._categoryListBox.AccessibleName = "CategoryListBox";
            this._categoryListBox.FormattingEnabled = true;
            this._categoryListBox.ItemHeight = 16;
            this._categoryListBox.Location = new System.Drawing.Point(6, 7);
            this._categoryListBox.Name = "_categoryListBox";
            this._categoryListBox.Size = new System.Drawing.Size(373, 484);
            this._categoryListBox.TabIndex = 8;
            this._categoryListBox.SelectedIndexChanged += new System.EventHandler(this.SelectCategoryListBoxIndex);
            // 
            // _deleteCategoryButton
            // 
            this._deleteCategoryButton.AccessibleName = "DeleteCategoryButton";
            this._deleteCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._deleteCategoryButton.Location = new System.Drawing.Point(219, 506);
            this._deleteCategoryButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._deleteCategoryButton.Name = "_deleteCategoryButton";
            this._deleteCategoryButton.Size = new System.Drawing.Size(160, 28);
            this._deleteCategoryButton.TabIndex = 7;
            this._deleteCategoryButton.Text = "Delete Selected Category";
            this._deleteCategoryButton.UseVisualStyleBackColor = true;
            this._deleteCategoryButton.Click += new System.EventHandler(this.ClickDeleteCategoryButton);
            // 
            // _addCategoryButton
            // 
            this._addCategoryButton.AccessibleName = "AddCategoryButton";
            this._addCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._addCategoryButton.Location = new System.Drawing.Point(6, 506);
            this._addCategoryButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this._addCategoryButton.Name = "_addCategoryButton";
            this._addCategoryButton.Size = new System.Drawing.Size(160, 28);
            this._addCategoryButton.TabIndex = 6;
            this._addCategoryButton.Text = "Add Category";
            this._addCategoryButton.UseVisualStyleBackColor = true;
            this._addCategoryButton.Click += new System.EventHandler(this.ClickAddCategoryButton);
            // 
            // _editCategoryGroupBox
            // 
            this._editCategoryGroupBox.Controls.Add(this._mealsOfSelectedCategoryListBox);
            this._editCategoryGroupBox.Controls.Add(this._saveCategoryButton);
            this._editCategoryGroupBox.Controls.Add(this._mealsOfCategoryLabel);
            this._editCategoryGroupBox.Controls.Add(this._categoryNameTextBox);
            this._editCategoryGroupBox.Controls.Add(this._categoryNameLabel);
            this._editCategoryGroupBox.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._editCategoryGroupBox.Location = new System.Drawing.Point(388, 10);
            this._editCategoryGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this._editCategoryGroupBox.Name = "_editCategoryGroupBox";
            this._editCategoryGroupBox.Size = new System.Drawing.Size(705, 524);
            this._editCategoryGroupBox.TabIndex = 2;
            this._editCategoryGroupBox.TabStop = false;
            this._editCategoryGroupBox.Text = "Edit Category";
            // 
            // _mealsOfSelectedCategoryListBox
            // 
            this._mealsOfSelectedCategoryListBox.AccessibleName = "MealsOfSelectedCategoryListBox";
            this._mealsOfSelectedCategoryListBox.FormattingEnabled = true;
            this._mealsOfSelectedCategoryListBox.ItemHeight = 17;
            this._mealsOfSelectedCategoryListBox.Location = new System.Drawing.Point(15, 130);
            this._mealsOfSelectedCategoryListBox.Name = "_mealsOfSelectedCategoryListBox";
            this._mealsOfSelectedCategoryListBox.Size = new System.Drawing.Size(681, 344);
            this._mealsOfSelectedCategoryListBox.TabIndex = 14;
            // 
            // _saveCategoryButton
            // 
            this._saveCategoryButton.AccessibleName = "SaveCategoryButton";
            this._saveCategoryButton.Location = new System.Drawing.Point(546, 487);
            this._saveCategoryButton.Margin = new System.Windows.Forms.Padding(6);
            this._saveCategoryButton.Name = "_saveCategoryButton";
            this._saveCategoryButton.Size = new System.Drawing.Size(150, 28);
            this._saveCategoryButton.TabIndex = 13;
            this._saveCategoryButton.Text = "Save";
            this._saveCategoryButton.UseVisualStyleBackColor = true;
            this._saveCategoryButton.Click += new System.EventHandler(this.ClickSaveCategoryButton);
            // 
            // _mealsOfCategoryLabel
            // 
            this._mealsOfCategoryLabel.AutoSize = true;
            this._mealsOfCategoryLabel.Location = new System.Drawing.Point(12, 110);
            this._mealsOfCategoryLabel.Margin = new System.Windows.Forms.Padding(9, 24, 9, 6);
            this._mealsOfCategoryLabel.Name = "_mealsOfCategoryLabel";
            this._mealsOfCategoryLabel.Size = new System.Drawing.Size(177, 17);
            this._mealsOfCategoryLabel.TabIndex = 6;
            this._mealsOfCategoryLabel.Text = "Meal(s) Using this Category:";
            // 
            // _categoryNameTextBox
            // 
            this._categoryNameTextBox.AccessibleName = "CategoryNameTextBox";
            this._categoryNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._categoryNameTextBox.Location = new System.Drawing.Point(147, 42);
            this._categoryNameTextBox.Margin = new System.Windows.Forms.Padding(6);
            this._categoryNameTextBox.Name = "_categoryNameTextBox";
            this._categoryNameTextBox.Size = new System.Drawing.Size(549, 25);
            this._categoryNameTextBox.TabIndex = 5;
            this._categoryNameTextBox.TextChanged += new System.EventHandler(this.ChangeCategoryNameText);
            // 
            // _categoryNameLabel
            // 
            this._categoryNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._categoryNameLabel.AutoSize = true;
            this._categoryNameLabel.Location = new System.Drawing.Point(12, 45);
            this._categoryNameLabel.Margin = new System.Windows.Forms.Padding(9, 24, 9, 24);
            this._categoryNameLabel.Name = "_categoryNameLabel";
            this._categoryNameLabel.Size = new System.Drawing.Size(120, 17);
            this._categoryNameLabel.TabIndex = 1;
            this._categoryNameLabel.Text = "Category Name (*)";
            // 
            // PosRestaurantSideForm
            // 
            this.AccessibleName = "PosRestaurantSideForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 601);
            this.Controls.Add(this._tabControl);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PosRestaurantSideForm";
            this.Text = "PosRestaurantSideForm";
            this._tabControl.ResumeLayout(false);
            this._mealManagerPage.ResumeLayout(false);
            this._editMealGroupBox.ResumeLayout(false);
            this._editMealGroupBox.PerformLayout();
            this._categoryManagerPage.ResumeLayout(false);
            this._editCategoryGroupBox.ResumeLayout(false);
            this._editCategoryGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _mealManagerPage;
        private System.Windows.Forms.TabPage _categoryManagerPage;
        private System.Windows.Forms.GroupBox _editMealGroupBox;
        private System.Windows.Forms.Label _mealNameLabel;
        private System.Windows.Forms.Button _deleteMealButton;
        private System.Windows.Forms.ListBox _mealListBox;
        private System.Windows.Forms.Button _addMealButton;
        private System.Windows.Forms.TextBox _mealNameTextBox;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.Label _pathLabel;
        private System.Windows.Forms.Label _mealPriceLabel;
        private System.Windows.Forms.Button _browseFileButton;
        private System.Windows.Forms.TextBox _mealImagePathTextBox;
        private System.Windows.Forms.TextBox _mealPriceTextBox;
        private System.Windows.Forms.TextBox _mealDescriptionTextBox;
        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.Button _saveMealButton;
        private System.Windows.Forms.Button _deleteCategoryButton;
        private System.Windows.Forms.Button _addCategoryButton;
        private System.Windows.Forms.GroupBox _editCategoryGroupBox;
        private System.Windows.Forms.Button _saveCategoryButton;
        private System.Windows.Forms.Label _mealsOfCategoryLabel;
        private System.Windows.Forms.TextBox _categoryNameTextBox;
        private System.Windows.Forms.Label _categoryNameLabel;
        private System.Windows.Forms.Label _currencyLabel;
        private System.Windows.Forms.Label _mealCategoryLabel;
        private System.Windows.Forms.ListBox _mealsOfSelectedCategoryListBox;
        private System.Windows.Forms.ListBox _categoryListBox;
    }
}