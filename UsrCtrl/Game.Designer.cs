namespace Gonki_by_Dadadam
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.Game_Loop = new System.Windows.Forms.Timer(this.components);
            this.Instruction = new System.Windows.Forms.Label();
            this.Pause_Label = new System.Windows.Forms.Label();
            this.Speed_Info = new System.Windows.Forms.Label();
            this.Breaking_Text = new System.Windows.Forms.Label();
            this.EndGame_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Game_Loop
            // 
            this.Game_Loop.Interval = 16;
            this.Game_Loop.Tick += new System.EventHandler(this.Game_Loop_Tick);
            // 
            // Instruction
            // 
            this.Instruction.AutoSize = true;
            this.Instruction.BackColor = System.Drawing.Color.Transparent;
            this.Instruction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Instruction.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Instruction.ForeColor = System.Drawing.Color.DarkBlue;
            this.Instruction.Location = new System.Drawing.Point(0, 0);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(181, 92);
            this.Instruction.TabIndex = 6;
            this.Instruction.Text = "Управление\r\nWASD - движение\r\nShift - нитро\r\nEsc - выход";
            this.Instruction.Visible = false;
            // 
            // Pause_Label
            // 
            this.Pause_Label.BackColor = System.Drawing.Color.Transparent;
            this.Pause_Label.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Pause_Label.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause_Label.ForeColor = System.Drawing.Color.DarkBlue;
            this.Pause_Label.Location = new System.Drawing.Point(78, 339);
            this.Pause_Label.Name = "Pause_Label";
            this.Pause_Label.Size = new System.Drawing.Size(473, 51);
            this.Pause_Label.TabIndex = 4;
            this.Pause_Label.Text = "Нажмите R чтобы играть";
            // 
            // Speed_Info
            // 
            this.Speed_Info.AutoSize = true;
            this.Speed_Info.BackColor = System.Drawing.Color.Transparent;
            this.Speed_Info.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Speed_Info.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed_Info.ForeColor = System.Drawing.Color.Lime;
            this.Speed_Info.Location = new System.Drawing.Point(191, 0);
            this.Speed_Info.Name = "Speed_Info";
            this.Speed_Info.Size = new System.Drawing.Size(110, 46);
            this.Speed_Info.TabIndex = 7;
            this.Speed_Info.Text = "Скорость: \r\nНитро:";
            // 
            // Breaking_Text
            // 
            this.Breaking_Text.AutoSize = true;
            this.Breaking_Text.BackColor = System.Drawing.Color.Transparent;
            this.Breaking_Text.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Breaking_Text.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Breaking_Text.ForeColor = System.Drawing.Color.DarkBlue;
            this.Breaking_Text.Location = new System.Drawing.Point(488, 0);
            this.Breaking_Text.Name = "Breaking_Text";
            this.Breaking_Text.Size = new System.Drawing.Size(0, 23);
            this.Breaking_Text.TabIndex = 8;
            // 
            // EndGame_Label
            // 
            this.EndGame_Label.BackColor = System.Drawing.Color.Transparent;
            this.EndGame_Label.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndGame_Label.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndGame_Label.ForeColor = System.Drawing.Color.Red;
            this.EndGame_Label.Location = new System.Drawing.Point(78, 339);
            this.EndGame_Label.Name = "EndGame_Label";
            this.EndGame_Label.Size = new System.Drawing.Size(575, 51);
            this.EndGame_Label.TabIndex = 9;
            this.EndGame_Label.Text = "Нажмите Escape чтобы выйти";
            this.EndGame_Label.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.EndGame_Label);
            this.Controls.Add(this.Breaking_Text);
            this.Controls.Add(this.Speed_Info);
            this.Controls.Add(this.Pause_Label);
            this.Controls.Add(this.Instruction);
            this.DoubleBuffered = true;
            this.Name = "Game";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Game_Loop;
        private System.Windows.Forms.Label Instruction;
        private System.Windows.Forms.Label Pause_Label;
        private System.Windows.Forms.Label Speed_Info;
        private System.Windows.Forms.Label Breaking_Text;
        private System.Windows.Forms.Label EndGame_Label;
    }
}
