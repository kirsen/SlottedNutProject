namespace SlottedNut
{
    partial class SlottedNutDataForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.outsideDiameterBox = new System.Windows.Forms.ComboBox();
            this.baseDiameterBox = new System.Windows.Forms.ComboBox();
            this.heightNutBox = new System.Windows.Forms.ComboBox();
            this.heightSlotBox = new System.Windows.Forms.ComboBox();
            this.widthSlotBox = new System.Windows.Forms.ComboBox();
            this.threadDiameterBox = new System.Windows.Forms.ComboBox();
            this.typeOfThreadBox = new System.Windows.Forms.ComboBox();
            this.stepOfThreadBox = new System.Windows.Forms.ComboBox();
            this.roundingDiameterBox = new System.Windows.Forms.ComboBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.countOfSlotBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.frontalViewPicture = new System.Windows.Forms.PictureBox();
            this.horizontalViewPicture = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frontalViewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalViewPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Построить деталь";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // outsideDiameterBox
            // 
            this.outsideDiameterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outsideDiameterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outsideDiameterBox.FormattingEnabled = true;
            this.outsideDiameterBox.Location = new System.Drawing.Point(167, 48);
            this.outsideDiameterBox.Name = "outsideDiameterBox";
            this.outsideDiameterBox.Size = new System.Drawing.Size(97, 21);
            this.outsideDiameterBox.TabIndex = 1;
            this.outsideDiameterBox.SelectedIndexChanged += new System.EventHandler(this.outsideDiameterBox_SelectedIndexChanged);
            this.outsideDiameterBox.Leave += new System.EventHandler(this.SetFrontalViewImage);
            // 
            // baseDiameterBox
            // 
            this.baseDiameterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baseDiameterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseDiameterBox.FormattingEnabled = true;
            this.baseDiameterBox.Location = new System.Drawing.Point(167, 75);
            this.baseDiameterBox.Name = "baseDiameterBox";
            this.baseDiameterBox.Size = new System.Drawing.Size(97, 21);
            this.baseDiameterBox.TabIndex = 2;
            this.baseDiameterBox.SelectedIndexChanged += new System.EventHandler(this.baseDiameterBox_SelectedIndexChanged);
            this.baseDiameterBox.Leave += new System.EventHandler(this.SetFrontalViewImage);
            // 
            // heightNutBox
            // 
            this.heightNutBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.heightNutBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heightNutBox.FormattingEnabled = true;
            this.heightNutBox.Location = new System.Drawing.Point(167, 102);
            this.heightNutBox.Name = "heightNutBox";
            this.heightNutBox.Size = new System.Drawing.Size(97, 21);
            this.heightNutBox.TabIndex = 3;
            this.heightNutBox.SelectedIndexChanged += new System.EventHandler(this.heightNutBox_SelectedIndexChanged);
            this.heightNutBox.Leave += new System.EventHandler(this.SetFrontalViewImage);
            // 
            // heightSlotBox
            // 
            this.heightSlotBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.heightSlotBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heightSlotBox.FormattingEnabled = true;
            this.heightSlotBox.Location = new System.Drawing.Point(167, 129);
            this.heightSlotBox.Name = "heightSlotBox";
            this.heightSlotBox.Size = new System.Drawing.Size(97, 21);
            this.heightSlotBox.TabIndex = 4;
            this.heightSlotBox.SelectedIndexChanged += new System.EventHandler(this.heightSlotBox_SelectedIndexChanged);
            this.heightSlotBox.Leave += new System.EventHandler(this.SetHorizontalViewImage);
            // 
            // widthSlotBox
            // 
            this.widthSlotBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.widthSlotBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.widthSlotBox.FormattingEnabled = true;
            this.widthSlotBox.Location = new System.Drawing.Point(167, 156);
            this.widthSlotBox.Name = "widthSlotBox";
            this.widthSlotBox.Size = new System.Drawing.Size(97, 21);
            this.widthSlotBox.TabIndex = 5;
            this.widthSlotBox.SelectedIndexChanged += new System.EventHandler(this.widthSlotBox_SelectedIndexChanged);
            this.widthSlotBox.Leave += new System.EventHandler(this.SetHorizontalViewImage);
            // 
            // threadDiameterBox
            // 
            this.threadDiameterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.threadDiameterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.threadDiameterBox.FormattingEnabled = true;
            this.threadDiameterBox.Location = new System.Drawing.Point(167, 183);
            this.threadDiameterBox.Name = "threadDiameterBox";
            this.threadDiameterBox.Size = new System.Drawing.Size(97, 21);
            this.threadDiameterBox.TabIndex = 6;
            this.threadDiameterBox.SelectedIndexChanged += new System.EventHandler(this.threadDiameterBox_SelectedIndexChanged);
            this.threadDiameterBox.Leave += new System.EventHandler(this.SetHorizontalViewImage);
            // 
            // typeOfThreadBox
            // 
            this.typeOfThreadBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeOfThreadBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeOfThreadBox.FormattingEnabled = true;
            this.typeOfThreadBox.Location = new System.Drawing.Point(167, 210);
            this.typeOfThreadBox.Name = "typeOfThreadBox";
            this.typeOfThreadBox.Size = new System.Drawing.Size(97, 21);
            this.typeOfThreadBox.TabIndex = 7;
            // 
            // stepOfThreadBox
            // 
            this.stepOfThreadBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stepOfThreadBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stepOfThreadBox.FormattingEnabled = true;
            this.stepOfThreadBox.Location = new System.Drawing.Point(167, 237);
            this.stepOfThreadBox.Name = "stepOfThreadBox";
            this.stepOfThreadBox.Size = new System.Drawing.Size(97, 21);
            this.stepOfThreadBox.TabIndex = 8;
            this.stepOfThreadBox.SelectedIndexChanged += new System.EventHandler(this.threadStepBox_SelectedIndexChanged);
            // 
            // roundingDiameterBox
            // 
            this.roundingDiameterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roundingDiameterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundingDiameterBox.FormattingEnabled = true;
            this.roundingDiameterBox.Location = new System.Drawing.Point(167, 264);
            this.roundingDiameterBox.Name = "roundingDiameterBox";
            this.roundingDiameterBox.Size = new System.Drawing.Size(97, 21);
            this.roundingDiameterBox.TabIndex = 9;
            this.roundingDiameterBox.SelectedIndexChanged += new System.EventHandler(this.roundingDiameterBox_SelectedIndexChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(30, 395);
            this.menuStrip2.TabIndex = 11;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Внешний диаметер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Диаметр основания";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Высота гайки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Высота шлица";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ширина шлица";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Диаметр резьбы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Тип резьбы";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Шаг резьбы";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Диаметр скругления";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.countOfSlotBox);
            this.groupBox1.Controls.Add(this.outsideDiameterBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.baseDiameterBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.heightNutBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.heightSlotBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.widthSlotBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.threadDiameterBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.typeOfThreadBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.stepOfThreadBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.roundingDiameterBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 301);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Число шлицев";
            // 
            // countOfSlotBox
            // 
            this.countOfSlotBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countOfSlotBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.countOfSlotBox.FormattingEnabled = true;
            this.countOfSlotBox.Location = new System.Drawing.Point(167, 21);
            this.countOfSlotBox.Name = "countOfSlotBox";
            this.countOfSlotBox.Size = new System.Drawing.Size(97, 21);
            this.countOfSlotBox.TabIndex = 22;
            this.countOfSlotBox.SelectedIndexChanged += new System.EventHandler(this.countOfSlotBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 66);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Управление";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Очистить все данные";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(334, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 373);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Проекционное представление";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Фронтальная проекция";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Горизонтальная проекция";
            // 
            // frontalViewPicture
            // 
            this.frontalViewPicture.Image = global::SlottedNut.Properties.Resources.front1;
            this.frontalViewPicture.Location = new System.Drawing.Point(406, 254);
            this.frontalViewPicture.Name = "frontalViewPicture";
            this.frontalViewPicture.Size = new System.Drawing.Size(153, 109);
            this.frontalViewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.frontalViewPicture.TabIndex = 27;
            this.frontalViewPicture.TabStop = false;
            // 
            // horizontalViewPicture
            // 
            this.horizontalViewPicture.Image = global::SlottedNut.Properties.Resources.sixslot;
            this.horizontalViewPicture.Location = new System.Drawing.Point(404, 56);
            this.horizontalViewPicture.Name = "horizontalViewPicture";
            this.horizontalViewPicture.Size = new System.Drawing.Size(196, 136);
            this.horizontalViewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.horizontalViewPicture.TabIndex = 26;
            this.horizontalViewPicture.TabStop = false;
            // 
            // SlottedNutDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 395);
            this.Controls.Add(this.frontalViewPicture);
            this.Controls.Add(this.horizontalViewPicture);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.groupBox3);
            this.Name = "SlottedNutDataForm";
            this.Text = "Шлицевая гайка";
            this.Load += new System.EventHandler(this.SlottedNutDataForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frontalViewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalViewPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox outsideDiameterBox;
        private System.Windows.Forms.ComboBox baseDiameterBox;
        private System.Windows.Forms.ComboBox heightNutBox;
        private System.Windows.Forms.ComboBox heightSlotBox;
        private System.Windows.Forms.ComboBox widthSlotBox;
        private System.Windows.Forms.ComboBox threadDiameterBox;
        private System.Windows.Forms.ComboBox typeOfThreadBox;
        private System.Windows.Forms.ComboBox stepOfThreadBox;
        private System.Windows.Forms.ComboBox roundingDiameterBox;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox countOfSlotBox;
        private System.Windows.Forms.PictureBox horizontalViewPicture;
        private System.Windows.Forms.PictureBox frontalViewPicture;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
    }
}

