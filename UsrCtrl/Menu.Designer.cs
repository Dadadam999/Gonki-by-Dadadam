namespace Gonki_by_Dadadam
{
    partial class Menu
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
            this.MenuBar = new System.Windows.Forms.Panel();
            this.Car_Selected_Info = new System.Windows.Forms.Label();
            this.Menu_Exit = new System.Windows.Forms.Button();
            this.Menu_Garage = new System.Windows.Forms.Button();
            this.Menu_StartGame = new System.Windows.Forms.Button();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Controls.Add(this.Car_Selected_Info);
            this.MenuBar.Controls.Add(this.Menu_Exit);
            this.MenuBar.Controls.Add(this.Menu_Garage);
            this.MenuBar.Controls.Add(this.Menu_StartGame);
            this.MenuBar.Location = new System.Drawing.Point(124, 146);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(310, 102);
            this.MenuBar.TabIndex = 1;
            // 
            // Car_Selected_Info
            // 
            this.Car_Selected_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Car_Selected_Info.Location = new System.Drawing.Point(0, 69);
            this.Car_Selected_Info.Name = "Car_Selected_Info";
            this.Car_Selected_Info.Size = new System.Drawing.Size(310, 13);
            this.Car_Selected_Info.TabIndex = 3;
            this.Car_Selected_Info.Text = "Car not selected.";
            // 
            // Menu_Exit
            // 
            this.Menu_Exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu_Exit.Location = new System.Drawing.Point(0, 46);
            this.Menu_Exit.Name = "Menu_Exit";
            this.Menu_Exit.Size = new System.Drawing.Size(310, 23);
            this.Menu_Exit.TabIndex = 2;
            this.Menu_Exit.Text = "Exit";
            this.Menu_Exit.UseVisualStyleBackColor = false;
            this.Menu_Exit.Click += new System.EventHandler(this.Menu_Exit_Click);
            // 
            // Menu_Garage
            // 
            this.Menu_Garage.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu_Garage.Location = new System.Drawing.Point(0, 23);
            this.Menu_Garage.Name = "Menu_Garage";
            this.Menu_Garage.Size = new System.Drawing.Size(310, 23);
            this.Menu_Garage.TabIndex = 1;
            this.Menu_Garage.Text = "Garage";
            this.Menu_Garage.UseVisualStyleBackColor = false;
            this.Menu_Garage.Click += new System.EventHandler(this.Menu_Garage_Click);
            // 
            // Menu_StartGame
            // 
            this.Menu_StartGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu_StartGame.Location = new System.Drawing.Point(0, 0);
            this.Menu_StartGame.Name = "Menu_StartGame";
            this.Menu_StartGame.Size = new System.Drawing.Size(310, 23);
            this.Menu_StartGame.TabIndex = 0;
            this.Menu_StartGame.Text = "Start game";
            this.Menu_StartGame.UseVisualStyleBackColor = false;
            this.Menu_StartGame.Click += new System.EventHandler(this.Menu_StartGame_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MenuBar);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(558, 377);
            this.Resize += new System.EventHandler(this.Menu_Resize);
            this.MenuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuBar;
        private System.Windows.Forms.Button Menu_Exit;
        private System.Windows.Forms.Button Menu_Garage;
        private System.Windows.Forms.Button Menu_StartGame;
        public System.Windows.Forms.Label Car_Selected_Info;
    }
}
