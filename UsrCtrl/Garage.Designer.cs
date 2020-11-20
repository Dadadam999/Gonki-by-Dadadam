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
            this.Garage_Bar = new System.Windows.Forms.Panel();
            this.Garage_List_Car = new System.Windows.Forms.FlowLayoutPanel();
            this.Garage_Bar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Garage_Back
            // 
            this.Garage_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Garage_Back.Location = new System.Drawing.Point(0, 0);
            this.Garage_Back.Name = "Garage_Back";
            this.Garage_Back.Size = new System.Drawing.Size(685, 25);
            this.Garage_Back.TabIndex = 0;
            this.Garage_Back.Text = "Back";
            this.Garage_Back.UseVisualStyleBackColor = true;
            this.Garage_Back.Click += new System.EventHandler(this.Garage_Back_Click);
            // 
            // Garage_Bar
            // 
            this.Garage_Bar.Controls.Add(this.Garage_Back);
            this.Garage_Bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Garage_Bar.Location = new System.Drawing.Point(0, 417);
            this.Garage_Bar.Name = "Garage_Bar";
            this.Garage_Bar.Size = new System.Drawing.Size(685, 25);
            this.Garage_Bar.TabIndex = 3;
            // 
            // Garage_List_Car
            // 
            this.Garage_List_Car.AutoScroll = true;
            this.Garage_List_Car.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Garage_List_Car.Location = new System.Drawing.Point(0, 0);
            this.Garage_List_Car.Name = "Garage_List_Car";
            this.Garage_List_Car.Size = new System.Drawing.Size(685, 417);
            this.Garage_List_Car.TabIndex = 4;
            // 
            // Garage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Garage_List_Car);
            this.Controls.Add(this.Garage_Bar);
            this.Name = "Garage";
            this.Size = new System.Drawing.Size(685, 442);
            this.Garage_Bar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Garage_Back;
        private System.Windows.Forms.Panel Garage_Bar;
        private System.Windows.Forms.FlowLayoutPanel Garage_List_Car;
    }
}
