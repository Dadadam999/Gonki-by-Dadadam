namespace Gonki_by_Dadadam
{
    partial class Garage_Car
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Car_Sprite = new System.Windows.Forms.PictureBox();
            this.Car_Info = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.Car_Sprite)).BeginInit();
            this.SuspendLayout();
            // 
            // Car_Sprite
            // 
            this.Car_Sprite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Car_Sprite.Location = new System.Drawing.Point(0, 0);
            this.Car_Sprite.Name = "Car_Sprite";
            this.Car_Sprite.Size = new System.Drawing.Size(198, 148);
            this.Car_Sprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Car_Sprite.TabIndex = 0;
            this.Car_Sprite.TabStop = false;
            this.Car_Sprite.Click += new System.EventHandler(this.Car_Sprite_Click);
            // 
            // Car_Info
            // 
            this.Car_Info.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Car_Info.Location = new System.Drawing.Point(0, 93);
            this.Car_Info.Name = "Car_Info";
            this.Car_Info.Size = new System.Drawing.Size(198, 55);
            this.Car_Info.TabIndex = 1;
            this.Car_Info.Text = "label1";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 90);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(198, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // Garage_Car
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Car_Info);
            this.Controls.Add(this.Car_Sprite);
            this.Name = "Garage_Car";
            this.Size = new System.Drawing.Size(198, 148);
            ((System.ComponentModel.ISupportInitialize)(this.Car_Sprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Car_Sprite;
        private System.Windows.Forms.Label Car_Info;
        private System.Windows.Forms.Splitter splitter1;
    }
}
