namespace Gonki_by_Dadadam
{
    partial class MainSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSpace));
            this.PreLoad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // PreLoad
            // 
            this.PreLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreLoad.Image = global::Gonki_by_Dadadam.Properties.Resources.Load;
            this.PreLoad.Location = new System.Drawing.Point(0, 0);
            this.PreLoad.Name = "PreLoad";
            this.PreLoad.Size = new System.Drawing.Size(784, 561);
            this.PreLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreLoad.TabIndex = 1;
            this.PreLoad.TabStop = false;
            // 
            // MainSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.PreLoad);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainSpace";
            this.Text = "Gonki by Dadadam";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainSpace_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainSpace_KeyUp);
            this.Resize += new System.EventHandler(this.MainSpace_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PreLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PreLoad;
    }
}

