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
            pictureBoxBT = new PictureBox();
            buttonRemove = new Button();
            buttonSearch = new Button();
            buttonInsert = new Button();
            buttonLoad = new Button();
            buttonSave = new Button();
            button1 = new Button();
            groupBoxSelectOperation = new GroupBox();
            groupBoxProgramManagement = new GroupBox();
            buttonContinueStepByStep = new Button();
            buttonContinueWithoutStops = new Button();
            checkBoxStepByStep = new CheckBox();
            groupBoxDifferent = new GroupBox();
            pictureBoxCompare = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBT).BeginInit();
            groupBoxSelectOperation.SuspendLayout();
            groupBoxProgramManagement.SuspendLayout();
            groupBoxDifferent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompare).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBT
            // 
            pictureBoxBT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxBT.Location = new Point(14, 12);
            pictureBoxBT.Name = "pictureBoxBT";
            pictureBoxBT.Size = new Size(1218, 733);
            pictureBoxBT.TabIndex = 0;
            pictureBoxBT.TabStop = false;
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
            buttonRemove.Click += buttonRemove_Click;
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
            buttonSearch.Click += buttonSearch_Click;
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
            groupBoxSelectOperation.Location = new Point(1239, 12);
            groupBoxSelectOperation.Name = "groupBoxSelectOperation";
            groupBoxSelectOperation.Size = new Size(412, 213);
            groupBoxSelectOperation.TabIndex = 6;
            groupBoxSelectOperation.TabStop = false;
            groupBoxSelectOperation.Text = "Выберите операцию";
            // 
            // groupBoxProgramManagement
            // 
            groupBoxProgramManagement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxProgramManagement.Controls.Add(buttonContinueStepByStep);
            groupBoxProgramManagement.Controls.Add(buttonContinueWithoutStops);
            groupBoxProgramManagement.Controls.Add(checkBoxStepByStep);
            groupBoxProgramManagement.Location = new Point(1239, 232);
            groupBoxProgramManagement.Name = "groupBoxProgramManagement";
            groupBoxProgramManagement.Size = new Size(412, 222);
            groupBoxProgramManagement.TabIndex = 7;
            groupBoxProgramManagement.TabStop = false;
            groupBoxProgramManagement.Text = "Управление программой";
            // 
            // buttonContinueStepByStep
            // 
            buttonContinueStepByStep.Enabled = false;
            buttonContinueStepByStep.Location = new Point(32, 94);
            buttonContinueStepByStep.Name = "buttonContinueStepByStep";
            buttonContinueStepByStep.Size = new Size(348, 47);
            buttonContinueStepByStep.TabIndex = 5;
            buttonContinueStepByStep.Text = "Далее";
            buttonContinueStepByStep.UseVisualStyleBackColor = true;
            buttonContinueStepByStep.Click += buttonContinueStepByStep_Click;
            // 
            // buttonContinueWithoutStops
            // 
            buttonContinueWithoutStops.Enabled = false;
            buttonContinueWithoutStops.Location = new Point(30, 158);
            buttonContinueWithoutStops.Name = "buttonContinueWithoutStops";
            buttonContinueWithoutStops.Size = new Size(348, 47);
            buttonContinueWithoutStops.TabIndex = 5;
            buttonContinueWithoutStops.Text = "Продолжить без остановок";
            buttonContinueWithoutStops.UseVisualStyleBackColor = true;
            buttonContinueWithoutStops.Click += buttonContinueWithoutStops_Click;
            // 
            // checkBoxStepByStep
            // 
            checkBoxStepByStep.AutoSize = true;
            checkBoxStepByStep.Location = new Point(42, 40);
            checkBoxStepByStep.Name = "checkBoxStepByStep";
            checkBoxStepByStep.Size = new Size(297, 37);
            checkBoxStepByStep.TabIndex = 6;
            checkBoxStepByStep.Text = "Выполнить пошагово";
            checkBoxStepByStep.UseVisualStyleBackColor = true;
            // 
            // groupBoxDifferent
            // 
            groupBoxDifferent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBoxDifferent.Controls.Add(buttonLoad);
            groupBoxDifferent.Controls.Add(button1);
            groupBoxDifferent.Controls.Add(buttonSave);
            groupBoxDifferent.Location = new Point(1241, 460);
            groupBoxDifferent.Name = "groupBoxDifferent";
            groupBoxDifferent.Size = new Size(412, 214);
            groupBoxDifferent.TabIndex = 8;
            groupBoxDifferent.TabStop = false;
            groupBoxDifferent.Text = "Другое";
            // 
            // pictureBoxCompare
            // 
            pictureBoxCompare.Location = new Point(1241, 680);
            pictureBoxCompare.Name = "pictureBoxCompare";
            pictureBoxCompare.Size = new Size(410, 65);
            pictureBoxCompare.TabIndex = 9;
            pictureBoxCompare.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(15F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1665, 757);
            Controls.Add(pictureBoxCompare);
            Controls.Add(groupBoxDifferent);
            Controls.Add(groupBoxProgramManagement);
            Controls.Add(groupBoxSelectOperation);
            Controls.Add(pictureBoxBT);
            Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxBT).EndInit();
            groupBoxSelectOperation.ResumeLayout(false);
            groupBoxProgramManagement.ResumeLayout(false);
            groupBoxProgramManagement.PerformLayout();
            groupBoxDifferent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompare).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxBT;
        private Button buttonSearch;
        private Button buttonInsert;
        private Button buttonRemove;
        private Panel panel2;
        private Label labelDifferent;
        private Button buttonLoad;
        private Button buttonSave;
        private Button button1;
        private GroupBox groupBoxSelectOperation;
        private GroupBox groupBoxProgramManagement;
        private GroupBox groupBoxDifferent;
        private CheckBox checkBoxStepByStep;
        private Button buttonContinueWithoutStops;
        private PictureBox pictureBoxCompare;
        private Button buttonContinueStepByStep;
        private Button button2;
    }
}