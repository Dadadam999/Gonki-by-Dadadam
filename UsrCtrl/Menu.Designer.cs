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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.MenuBar = new System.Windows.Forms.Panel();
            this.Car_Selected_Info = new System.Windows.Forms.Label();
            this.separator3 = new System.Windows.Forms.Panel();
            this.Menu_Exit = new System.Windows.Forms.Button();
            this.separator2 = new System.Windows.Forms.Panel();
            this.Menu_Garage = new System.Windows.Forms.Button();
            this.separator1 = new System.Windows.Forms.Panel();
            this.Menu_StartGame = new System.Windows.Forms.Button();
            this.Info_Ver = new System.Windows.Forms.Label();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.Color.Transparent;
            this.MenuBar.Controls.Add(this.Car_Selected_Info);
            this.MenuBar.Controls.Add(this.separator3);
            this.MenuBar.Controls.Add(this.Menu_Exit);
            this.MenuBar.Controls.Add(this.separator2);
            this.MenuBar.Controls.Add(this.Menu_Garage);
            this.MenuBar.Controls.Add(this.separator1);
            this.MenuBar.Controls.Add(this.Menu_StartGame);
            this.MenuBar.Location = new System.Drawing.Point(124, 101);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(310, 215);
            this.MenuBar.TabIndex = 1;
            // 
            // Car_Selected_Info
            // 
            this.Car_Selected_Info.AutoSize = true;
            this.Car_Selected_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Car_Selected_Info.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.Car_Selected_Info.ForeColor = System.Drawing.Color.DarkBlue;
            this.Car_Selected_Info.Location = new System.Drawing.Point(0, 159);
            this.Car_Selected_Info.Name = "Car_Selected_Info";
            this.Car_Selected_Info.Size = new System.Drawing.Size(207, 23);
            this.Car_Selected_Info.TabIndex = 3;
            this.Car_Selected_Info.Text = "Car not selected.";
            // 
            // separator3
            // 
            this.separator3.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator3.Location = new System.Drawing.Point(0, 149);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(310, 10);
            this.separator3.TabIndex = 4;
            // 
            // Menu_Exit
            // 
            this.Menu_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu_Exit.BackgroundImage")));
            this.Menu_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu_Exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Menu_Exit.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.Menu_Exit.ForeColor = System.Drawing.Color.SkyBlue;
            this.Menu_Exit.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Exit.Image")));
            this.Menu_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Menu_Exit.Location = new System.Drawing.Point(0, 103);
            this.Menu_Exit.Name = "Menu_Exit";
            this.Menu_Exit.Size = new System.Drawing.Size(310, 46);
            this.Menu_Exit.TabIndex = 2;
            this.Menu_Exit.Text = "Exit";
            this.Menu_Exit.UseVisualStyleBackColor = false;
            this.Menu_Exit.Click += new System.EventHandler(this.Menu_Exit_Click);
            // 
            // separator2
            // 
            this.separator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator2.Location = new System.Drawing.Point(0, 93);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(310, 10);
            this.separator2.TabIndex = 5;
            // 
            // Menu_Garage
            // 
            this.Menu_Garage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu_Garage.BackgroundImage")));
            this.Menu_Garage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu_Garage.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu_Garage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Menu_Garage.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.Menu_Garage.ForeColor = System.Drawing.Color.SkyBlue;
            this.Menu_Garage.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Garage.Image")));
            this.Menu_Garage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Menu_Garage.Location = new System.Drawing.Point(0, 50);
            this.Menu_Garage.Name = "Menu_Garage";
            this.Menu_Garage.Size = new System.Drawing.Size(310, 43);
            this.Menu_Garage.TabIndex = 1;
            this.Menu_Garage.Text = "Garage";
            this.Menu_Garage.UseVisualStyleBackColor = false;
            this.Menu_Garage.Click += new System.EventHandler(this.Menu_Garage_Click);
            // 
            // separator1
            // 
            this.separator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator1.Location = new System.Drawing.Point(0, 40);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(310, 10);
            this.separator1.TabIndex = 6;
            // 
            // Menu_StartGame
            // 
            this.Menu_StartGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu_StartGame.BackgroundImage")));
            this.Menu_StartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu_StartGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu_StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Menu_StartGame.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.Menu_StartGame.ForeColor = System.Drawing.Color.SkyBlue;
            this.Menu_StartGame.Image = ((System.Drawing.Image)(resources.GetObject("Menu_StartGame.Image")));
            this.Menu_StartGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Menu_StartGame.Location = new System.Drawing.Point(0, 0);
            this.Menu_StartGame.Name = "Menu_StartGame";
            this.Menu_StartGame.Size = new System.Drawing.Size(310, 40);
            this.Menu_StartGame.TabIndex = 0;
            this.Menu_StartGame.Text = "Start game";
            this.Menu_StartGame.UseVisualStyleBackColor = false;
            this.Menu_StartGame.Click += new System.EventHandler(this.Menu_StartGame_Click);
            // 
            // Info_Ver
            // 
            this.Info_Ver.AutoSize = true;
            this.Info_Ver.BackColor = System.Drawing.Color.Transparent;
            this.Info_Ver.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info_Ver.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.Info_Ver.ForeColor = System.Drawing.Color.MediumBlue;
            this.Info_Ver.Location = new System.Drawing.Point(0, 0);
            this.Info_Ver.Name = "Info_Ver";
            this.Info_Ver.Size = new System.Drawing.Size(82, 23);
            this.Info_Ver.TabIndex = 4;
            this.Info_Ver.Text = "Ver 1.0";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gonki_by_Dadadam.Properties.Resources.BackgroundMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Info_Ver);
            this.Controls.Add(this.MenuBar);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(558, 377);
            this.Resize += new System.EventHandler(this.Menu_Resize);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MenuBar;
        private System.Windows.Forms.Button Menu_Exit;
        private System.Windows.Forms.Button Menu_Garage;
        private System.Windows.Forms.Button Menu_StartGame;
        public System.Windows.Forms.Label Car_Selected_Info;
        public System.Windows.Forms.Label Info_Ver;
        private System.Windows.Forms.Panel separator3;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel separator1;
    }
}
