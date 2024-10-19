namespace CoDex
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_OpenText = new System.Windows.Forms.TextBox();
            this.textBox_OpenTextHex = new System.Windows.Forms.TextBox();
            this.textBox_CloseTextHex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьОткрытыйТекстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сгенерироватьКлючToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зашифроватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зашифроватьXORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зашифроватьDECToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дешифроватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дешифроватьXORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дешифроватьDECToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_OpenText
            // 
            this.textBox_OpenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_OpenText.Location = new System.Drawing.Point(82, 115);
            this.textBox_OpenText.Multiline = true;
            this.textBox_OpenText.Name = "textBox_OpenText";
            this.textBox_OpenText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_OpenText.Size = new System.Drawing.Size(510, 295);
            this.textBox_OpenText.TabIndex = 0;
            // 
            // textBox_OpenTextHex
            // 
            this.textBox_OpenTextHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_OpenTextHex.Location = new System.Drawing.Point(82, 480);
            this.textBox_OpenTextHex.Multiline = true;
            this.textBox_OpenTextHex.Name = "textBox_OpenTextHex";
            this.textBox_OpenTextHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_OpenTextHex.Size = new System.Drawing.Size(510, 295);
            this.textBox_OpenTextHex.TabIndex = 4;
            // 
            // textBox_CloseTextHex
            // 
            this.textBox_CloseTextHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_CloseTextHex.Location = new System.Drawing.Point(776, 480);
            this.textBox_CloseTextHex.Multiline = true;
            this.textBox_CloseTextHex.Name = "textBox_CloseTextHex";
            this.textBox_CloseTextHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_CloseTextHex.Size = new System.Drawing.Size(510, 295);
            this.textBox_CloseTextHex.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(228, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Открытый текст ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(217, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Открытый текст HEX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(913, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Закрытый текст HEX";
            // 
            // textBox_Key
            // 
            this.textBox_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Key.Location = new System.Drawing.Point(776, 362);
            this.textBox_Key.Multiline = true;
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Key.Size = new System.Drawing.Size(510, 48);
            this.textBox_Key.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(973, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ключ HEX";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сгенерироватьКлючToolStripMenuItem,
            this.зашифроватьToolStripMenuItem,
            this.дешифроватьToolStripMenuItem,
            this.очиститьВсеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 36);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьОткрытыйТекстToolStripMenuItem,
            this.pToolStripMenuItem,
            this.hToolStripMenuItem});
            this.загрузитьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(116, 32);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            // 
            // загрузитьОткрытыйТекстToolStripMenuItem
            // 
            this.загрузитьОткрытыйТекстToolStripMenuItem.Name = "загрузитьОткрытыйТекстToolStripMenuItem";
            this.загрузитьОткрытыйТекстToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.загрузитьОткрытыйТекстToolStripMenuItem.Text = " Загрузить открытый текст";
            this.загрузитьОткрытыйТекстToolStripMenuItem.Click += new System.EventHandler(this.загрузитьОткрытыйТекстToolStripMenuItem_Click);
            // 
            // pToolStripMenuItem
            // 
            this.pToolStripMenuItem.Name = "pToolStripMenuItem";
            this.pToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.pToolStripMenuItem.Text = " Загрузить закрытый текст";
            this.pToolStripMenuItem.Click += new System.EventHandler(this.LoadCloseTextToolStripMenuItem_Click);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(338, 32);
            this.hToolStripMenuItem.Text = "Загрузить ключ";
            this.hToolStripMenuItem.Click += new System.EventHandler(this.hToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jToolStripMenuItem,
            this.gToolStripMenuItem,
            this.gToolStripMenuItem1});
            this.сохранитьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(123, 32);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // jToolStripMenuItem
            // 
            this.jToolStripMenuItem.Name = "jToolStripMenuItem";
            this.jToolStripMenuItem.Size = new System.Drawing.Size(340, 32);
            this.jToolStripMenuItem.Text = "Сохранить открытый текст";
            this.jToolStripMenuItem.Click += new System.EventHandler(this.SaveOpenTextToolStripMenuItem_Click);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(340, 32);
            this.gToolStripMenuItem.Text = "Сохранить закрытый текст";
            this.gToolStripMenuItem.Click += new System.EventHandler(this.SaveCloseTextToolStripMenuItem_Click);
            // 
            // gToolStripMenuItem1
            // 
            this.gToolStripMenuItem1.Name = "gToolStripMenuItem1";
            this.gToolStripMenuItem1.Size = new System.Drawing.Size(340, 32);
            this.gToolStripMenuItem1.Text = "Сохранить ключ";
            this.gToolStripMenuItem1.Click += new System.EventHandler(this.SaveKeyToolStripMenuItem1_Click);
            // 
            // сгенерироватьКлючToolStripMenuItem
            // 
            this.сгенерироватьКлючToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.сгенерироватьКлючToolStripMenuItem.Name = "сгенерироватьКлючToolStripMenuItem";
            this.сгенерироватьКлючToolStripMenuItem.Size = new System.Drawing.Size(223, 32);
            this.сгенерироватьКлючToolStripMenuItem.Text = "Сгенерировать ключ ";
            this.сгенерироватьКлючToolStripMenuItem.Click += new System.EventHandler(this.сгенерироватьКлючToolStripMenuItem_Click);
            // 
            // зашифроватьToolStripMenuItem
            // 
            this.зашифроватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зашифроватьXORToolStripMenuItem,
            this.зашифроватьDECToolStripMenuItem});
            this.зашифроватьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.зашифроватьToolStripMenuItem.Name = "зашифроватьToolStripMenuItem";
            this.зашифроватьToolStripMenuItem.Size = new System.Drawing.Size(152, 32);
            this.зашифроватьToolStripMenuItem.Text = "Зашифровать";
            // 
            // зашифроватьXORToolStripMenuItem
            // 
            this.зашифроватьXORToolStripMenuItem.Name = "зашифроватьXORToolStripMenuItem";
            this.зашифроватьXORToolStripMenuItem.Size = new System.Drawing.Size(268, 32);
            this.зашифроватьXORToolStripMenuItem.Text = "Зашифровать XOR";
            this.зашифроватьXORToolStripMenuItem.Click += new System.EventHandler(this.зашифроватьXORToolStripMenuItem_Click);
            // 
            // зашифроватьDECToolStripMenuItem
            // 
            this.зашифроватьDECToolStripMenuItem.Name = "зашифроватьDECToolStripMenuItem";
            this.зашифроватьDECToolStripMenuItem.Size = new System.Drawing.Size(268, 32);
            this.зашифроватьDECToolStripMenuItem.Text = "Зашифровать DEC";
            this.зашифроватьDECToolStripMenuItem.Click += new System.EventHandler(this.зашифроватьDECToolStripMenuItem_Click);
            // 
            // дешифроватьToolStripMenuItem
            // 
            this.дешифроватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дешифроватьXORToolStripMenuItem,
            this.дешифроватьDECToolStripMenuItem});
            this.дешифроватьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.дешифроватьToolStripMenuItem.Name = "дешифроватьToolStripMenuItem";
            this.дешифроватьToolStripMenuItem.Size = new System.Drawing.Size(155, 32);
            this.дешифроватьToolStripMenuItem.Text = "Дешифровать";
            // 
            // дешифроватьXORToolStripMenuItem
            // 
            this.дешифроватьXORToolStripMenuItem.Name = "дешифроватьXORToolStripMenuItem";
            this.дешифроватьXORToolStripMenuItem.Size = new System.Drawing.Size(271, 32);
            this.дешифроватьXORToolStripMenuItem.Text = "Дешифровать XOR";
            this.дешифроватьXORToolStripMenuItem.Click += new System.EventHandler(this.дешифроватьXORToolStripMenuItem_Click);
            // 
            // дешифроватьDECToolStripMenuItem
            // 
            this.дешифроватьDECToolStripMenuItem.Name = "дешифроватьDECToolStripMenuItem";
            this.дешифроватьDECToolStripMenuItem.Size = new System.Drawing.Size(271, 32);
            this.дешифроватьDECToolStripMenuItem.Text = "Дешифровать DEC";
            this.дешифроватьDECToolStripMenuItem.Click += new System.EventHandler(this.дешифроватьDECToolStripMenuItem_Click);
            // 
            // очиститьВсеToolStripMenuItem
            // 
            this.очиститьВсеToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.очиститьВсеToolStripMenuItem.Name = "очиститьВсеToolStripMenuItem";
            this.очиститьВсеToolStripMenuItem.Size = new System.Drawing.Size(146, 32);
            this.очиститьВсеToolStripMenuItem.Text = "Очистить все";
            this.очиститьВсеToolStripMenuItem.Click += new System.EventHandler(this.очиститьВсеToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Key);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_CloseTextHex);
            this.Controls.Add(this.textBox_OpenTextHex);
            this.Controls.Add(this.textBox_OpenText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_OpenText;
        private System.Windows.Forms.TextBox textBox_OpenTextHex;
        private System.Windows.Forms.TextBox textBox_CloseTextHex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьОткрытыйТекстToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сгенерироватьКлючToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зашифроватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дешифроватьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem очиститьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зашифроватьXORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зашифроватьDECToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дешифроватьXORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дешифроватьDECToolStripMenuItem;
    }
}

