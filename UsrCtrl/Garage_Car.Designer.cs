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
            this.Car_Info = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Car_Sprite = new System.Windows.Forms.PictureBox();
            this.PicInfo = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Car_Sprite)).BeginInit();
            this.PicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Car_Info
            // 
            this.Car_Info.BackColor = System.Drawing.Color.Transparent;
            this.Car_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Car_Info.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Car_Info.ForeColor = System.Drawing.Color.SkyBlue;
            this.Car_Info.Location = new System.Drawing.Point(0, 0);
            this.Car_Info.Name = "Car_Info";
            this.Car_Info.Size = new System.Drawing.Size(239, 86);
            this.Car_Info.TabIndex = 1;
            this.Car_Info.Text = "label1";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Red;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 102);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(239, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // Car_Sprite
            // 
            this.Car_Sprite.BackColor = System.Drawing.Color.Transparent;
            this.Car_Sprite.BackgroundImage = global::Gonki_by_Dadadam.Properties.Resources.GarageCarSprite;
            this.Car_Sprite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Car_Sprite.Location = new System.Drawing.Point(0, 0);
            this.Car_Sprite.Name = "Car_Sprite";
            this.Car_Sprite.Size = new System.Drawing.Size(239, 102);
            this.Car_Sprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Car_Sprite.TabIndex = 0;
            this.Car_Sprite.TabStop = false;
            this.Car_Sprite.Click += new System.EventHandler(this.Car_Sprite_Click);
            // 
            // PicInfo
            // 
            this.PicInfo.BackColor = System.Drawing.Color.Transparent;
            this.PicInfo.BackgroundImage = global::Gonki_by_Dadadam.Properties.Resources.GarageCarInfo;
            this.PicInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicInfo.Controls.Add(this.Car_Info);
            this.PicInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PicInfo.Location = new System.Drawing.Point(0, 105);
            this.PicInfo.Name = "PicInfo";
            this.PicInfo.Size = new System.Drawing.Size(239, 86);
            this.PicInfo.TabIndex = 3;
            // 
            // Garage_Car
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Car_Sprite);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.PicInfo);
            this.Name = "Garage_Car";
            this.Size = new System.Drawing.Size(239, 191);
            ((System.ComponentModel.ISupportInitialize)(this.Car_Sprite)).EndInit();
            this.PicInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Car_Sprite;
        private System.Windows.Forms.Label Car_Info;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel PicInfo;
    }
}
