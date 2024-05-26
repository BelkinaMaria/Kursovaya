namespace Kursovaya
{
    partial class NewNumberForm
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
            maskedTextBoxNmber = new MaskedTextBox();
            labelEnterNumber = new Label();
            buttonOk = new Button();
            SuspendLayout();
            // 
            // maskedTextBoxNmber
            // 
            maskedTextBoxNmber.Location = new Point(249, 29);
            maskedTextBoxNmber.Mask = "000";
            maskedTextBoxNmber.Name = "maskedTextBoxNmber";
            maskedTextBoxNmber.Size = new Size(152, 41);
            maskedTextBoxNmber.TabIndex = 0;
            maskedTextBoxNmber.ValidatingType = typeof(int);
            // 
            // labelEnterNumber
            // 
            labelEnterNumber.AutoSize = true;
            labelEnterNumber.Location = new Point(31, 29);
            labelEnterNumber.Name = "labelEnterNumber";
            labelEnterNumber.Size = new Size(199, 33);
            labelEnterNumber.TabIndex = 1;
            labelEnterNumber.Text = "Введите число: ";
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(156, 89);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(150, 46);
            buttonOk.TabIndex = 2;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // NewNumberForm
            // 
            AutoScaleDimensions = new SizeF(15F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 158);
            Controls.Add(buttonOk);
            Controls.Add(labelEnterNumber);
            Controls.Add(maskedTextBoxNmber);
            Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "NewNumberForm";
            Text = "Новая операция";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedTextBoxNmber;
        private Label labelEnterNumber;
        private Button buttonOk;
    }
}