namespace Kursovaya
{
    partial class MainForm
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
            BinarySearchTree = new PictureBox();
            buttonRemove = new Button();
            buttonSearch = new Button();
            buttonInsert = new Button();
            buttonContinue = new Button();
            buttonNext = new Button();
            buttonLoad = new Button();
            buttonSave = new Button();
            button1 = new Button();
            groupBoxSelectOperation = new GroupBox();
            groupBoxProgramManagement = new GroupBox();
            groupBoxDifferent = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)BinarySearchTree).BeginInit();
            groupBoxSelectOperation.SuspendLayout();
            groupBoxProgramManagement.SuspendLayout();
            groupBoxDifferent.SuspendLayout();
            SuspendLayout();
            // 
            // BinarySearchTree
            // 
            BinarySearchTree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BinarySearchTree.Location = new Point(14, 12);
            BinarySearchTree.Name = "BinarySearchTree";
            BinarySearchTree.Size = new Size(752, 615);
            BinarySearchTree.TabIndex = 0;
            BinarySearchTree.TabStop = false;
            // 
            // buttonRemove
            // 
            buttonRemove.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonRemove.Location = new Point(30, 153);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(348, 47);
            buttonRemove.TabIndex = 3;
            buttonRemove.Text = "Удалить элемент";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonSearch.Location = new Point(30, 99);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(348, 47);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Найти элемент";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonInsert
            // 
            buttonInsert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonInsert.Location = new Point(30, 45);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(348, 47);
            buttonInsert.TabIndex = 1;
            buttonInsert.Text = "Вставить элемент";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // buttonContinue
            // 
            buttonContinue.Location = new Point(178, 45);
            buttonContinue.Name = "buttonContinue";
            buttonContinue.Size = new Size(201, 111);
            buttonContinue.TabIndex = 5;
            buttonContinue.Text = "Продолжить без остановок";
            buttonContinue.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(30, 45);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(129, 111);
            buttonNext.TabIndex = 4;
            buttonNext.Text = "Далее";
            buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(30, 153);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(348, 47);
            buttonLoad.TabIndex = 3;
            buttonLoad.Text = "Загрузить из файла";
            buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(30, 99);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(348, 47);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить в файл";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(30, 45);
            button1.Name = "button1";
            button1.Size = new Size(348, 47);
            button1.TabIndex = 1;
            button1.Text = "Информация";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBoxSelectOperation
            // 
            groupBoxSelectOperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxSelectOperation.Controls.Add(buttonRemove);
            groupBoxSelectOperation.Controls.Add(buttonInsert);
            groupBoxSelectOperation.Controls.Add(buttonSearch);
            groupBoxSelectOperation.Location = new Point(773, 12);
            groupBoxSelectOperation.Name = "groupBoxSelectOperation";
            groupBoxSelectOperation.Size = new Size(412, 213);
            groupBoxSelectOperation.TabIndex = 6;
            groupBoxSelectOperation.TabStop = false;
            groupBoxSelectOperation.Text = "Выберите операцию";
            // 
            // groupBoxProgramManagement
            // 
            groupBoxProgramManagement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxProgramManagement.Controls.Add(buttonContinue);
            groupBoxProgramManagement.Controls.Add(buttonNext);
            groupBoxProgramManagement.Location = new Point(773, 232);
            groupBoxProgramManagement.Name = "groupBoxProgramManagement";
            groupBoxProgramManagement.Size = new Size(412, 173);
            groupBoxProgramManagement.TabIndex = 7;
            groupBoxProgramManagement.TabStop = false;
            groupBoxProgramManagement.Text = "Управление программой";
            // 
            // groupBoxDifferent
            // 
            groupBoxDifferent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxDifferent.Controls.Add(buttonLoad);
            groupBoxDifferent.Controls.Add(button1);
            groupBoxDifferent.Controls.Add(buttonSave);
            groupBoxDifferent.Location = new Point(773, 411);
            groupBoxDifferent.Name = "groupBoxDifferent";
            groupBoxDifferent.Size = new Size(412, 216);
            groupBoxDifferent.TabIndex = 8;
            groupBoxDifferent.TabStop = false;
            groupBoxDifferent.Text = "Другое";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(15F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 639);
            Controls.Add(groupBoxDifferent);
            Controls.Add(groupBoxProgramManagement);
            Controls.Add(groupBoxSelectOperation);
            Controls.Add(BinarySearchTree);
            Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)BinarySearchTree).EndInit();
            groupBoxSelectOperation.ResumeLayout(false);
            groupBoxProgramManagement.ResumeLayout(false);
            groupBoxDifferent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox BinarySearchTree;
        private Button buttonSearch;
        private Button buttonInsert;
        private Button buttonRemove;
        private Button buttonContinue;
        private Button buttonNext;
        private Panel panel2;
        private Label labelDifferent;
        private Button buttonLoad;
        private Button buttonSave;
        private Button button1;
        private GroupBox groupBoxSelectOperation;
        private GroupBox groupBoxProgramManagement;
        private GroupBox groupBoxDifferent;
    }
}