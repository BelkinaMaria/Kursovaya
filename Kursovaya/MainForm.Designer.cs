﻿namespace Kursovaya
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
            buttonInfo = new Button();
            groupBoxSelectOperation = new GroupBox();
            groupBoxProgramManagement = new GroupBox();
            buttonBack = new Button();
            buttonContinue = new Button();
            buttonStop = new Button();
            checkBoxStepByStep = new CheckBox();
            groupBoxDifferent = new GroupBox();
            pictureBoxCompare = new PictureBox();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            ToolStripMenuItemStates = new ToolStripMenuItem();
            ToolStripMenuItemBack = new ToolStripMenuItem();
            ToolStripMenuItemNext = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBT).BeginInit();
            groupBoxSelectOperation.SuspendLayout();
            groupBoxProgramManagement.SuspendLayout();
            groupBoxDifferent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompare).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxBT
            // 
            pictureBoxBT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxBT.Location = new Point(14, 43);
            pictureBoxBT.Name = "pictureBoxBT";
            pictureBoxBT.Size = new Size(1218, 702);
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
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(30, 99);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(348, 47);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить в файл";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonInfo
            // 
            buttonInfo.Location = new Point(30, 45);
            buttonInfo.Name = "buttonInfo";
            buttonInfo.Size = new Size(348, 47);
            buttonInfo.TabIndex = 1;
            buttonInfo.Text = "Информация";
            buttonInfo.UseVisualStyleBackColor = true;
            buttonInfo.Click += buttonInfo_Click;
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
            groupBoxProgramManagement.Controls.Add(buttonBack);
            groupBoxProgramManagement.Controls.Add(buttonContinue);
            groupBoxProgramManagement.Controls.Add(buttonStop);
            groupBoxProgramManagement.Controls.Add(checkBoxStepByStep);
            groupBoxProgramManagement.Location = new Point(1239, 232);
            groupBoxProgramManagement.Name = "groupBoxProgramManagement";
            groupBoxProgramManagement.Size = new Size(412, 222);
            groupBoxProgramManagement.TabIndex = 7;
            groupBoxProgramManagement.TabStop = false;
            groupBoxProgramManagement.Text = "Управление программой";
            // 
            // buttonBack
            // 
            buttonBack.Enabled = false;
            buttonBack.Location = new Point(208, 94);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(169, 47);
            buttonBack.TabIndex = 5;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonContinue
            // 
            buttonContinue.Enabled = false;
            buttonContinue.Location = new Point(31, 94);
            buttonContinue.Name = "buttonContinue";
            buttonContinue.Size = new Size(169, 47);
            buttonContinue.TabIndex = 5;
            buttonContinue.Text = "Далее";
            buttonContinue.UseVisualStyleBackColor = true;
            buttonContinue.Click += buttonContinue_Click;
            // 
            // buttonStop
            // 
            buttonStop.Enabled = false;
            buttonStop.Location = new Point(30, 158);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(348, 47);
            buttonStop.TabIndex = 5;
            buttonStop.Text = "Продолжить без остановок";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
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
            groupBoxDifferent.Controls.Add(buttonInfo);
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
            // saveFileDialog
            // 
            saveFileDialog.Filter = "txt file | *.txt";
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "txt file | *.txt";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemStates });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1665, 40);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemStates
            // 
            ToolStripMenuItemStates.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemBack, ToolStripMenuItemNext });
            ToolStripMenuItemStates.Name = "ToolStripMenuItemStates";
            ToolStripMenuItemStates.Size = new Size(288, 36);
            ToolStripMenuItemStates.Text = "Проход по состояниям";
            // 
            // ToolStripMenuItemBack
            // 
            ToolStripMenuItemBack.Name = "ToolStripMenuItemBack";
            ToolStripMenuItemBack.ShortcutKeys = Keys.Control | Keys.Z;
            ToolStripMenuItemBack.Size = new Size(359, 44);
            ToolStripMenuItemBack.Text = "Назад";
            ToolStripMenuItemBack.Click += ToolStripMenuItemBack_Click;
            // 
            // ToolStripMenuItemNext
            // 
            ToolStripMenuItemNext.Name = "ToolStripMenuItemNext";
            ToolStripMenuItemNext.ShortcutKeys = Keys.Control | Keys.Y;
            ToolStripMenuItemNext.Size = new Size(359, 44);
            ToolStripMenuItemNext.Text = "Вперёд";
            ToolStripMenuItemNext.Click += ToolStripMenuItemNext_Click;
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
            Controls.Add(menuStrip1);
            Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxBT).EndInit();
            groupBoxSelectOperation.ResumeLayout(false);
            groupBoxProgramManagement.ResumeLayout(false);
            groupBoxProgramManagement.PerformLayout();
            groupBoxDifferent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompare).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Button buttonInfo;
        private GroupBox groupBoxSelectOperation;
        private GroupBox groupBoxProgramManagement;
        private GroupBox groupBoxDifferent;
        private CheckBox checkBoxStepByStep;
        private Button buttonStop;
        private PictureBox pictureBoxCompare;
        private Button buttonContinue;
        private Button buttonBack;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItemStates;
        private ToolStripMenuItem ToolStripMenuItemBack;
        private ToolStripMenuItem ToolStripMenuItemNext;
    }
}