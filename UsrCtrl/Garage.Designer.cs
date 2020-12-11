namespace Gonki_by_Dadadam
{
    partial class Garage
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
            this.Garage_Back = new System.Windows.Forms.Button();
            this.Garage_List_Car = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Garage_Back
            // 
            this.Garage_Back.BackColor = System.Drawing.Color.Transparent;
            this.Garage_Back.BackgroundImage = global::Gonki_by_Dadadam.Properties.Resources.ButtonMenu;
            this.Garage_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Garage_Back.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Garage_Back.FlatAppearance.BorderSize = 0;
            this.Garage_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Garage_Back.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.Garage_Back.ForeColor = System.Drawing.Color.SkyBlue;
            this.Garage_Back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Garage_Back.Location = new System.Drawing.Point(0, 408);
            this.Garage_Back.Name = "Garage_Back";
            this.Garage_Back.Size = new System.Drawing.Size(685, 34);
            this.Garage_Back.TabIndex = 0;
            this.Garage_Back.Text = "Back";
            this.Garage_Back.UseVisualStyleBackColor = false;
            this.Garage_Back.Click += new System.EventHandler(this.Garage_Back_Click);
            // 
            // Garage_List_Car
            // 
            this.Garage_List_Car.AutoScroll = true;
            this.Garage_List_Car.BackColor = System.Drawing.Color.Transparent;
            this.Garage_List_Car.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Garage_List_Car.Location = new System.Drawing.Point(0, 0);
            this.Garage_List_Car.Name = "Garage_List_Car";
            this.Garage_List_Car.Size = new System.Drawing.Size(685, 408);
            this.Garage_List_Car.TabIndex = 4;
            // 
            // Garage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gonki_by_Dadadam.Properties.Resources.BackgroundMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Garage_List_Car);
            this.Controls.Add(this.Garage_Back);
            this.Name = "Garage";
            this.Size = new System.Drawing.Size(685, 442);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Garage_Back;
        private System.Windows.Forms.FlowLayoutPanel Garage_List_Car;
    }
}
