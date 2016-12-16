namespace TankGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.doneButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listaDeIPs = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(456, 86);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(216, 60);
            this.doneButton.TabIndex = 7;
            this.doneButton.Text = "Iniciar Partida";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(456, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 60);
            this.button1.TabIndex = 8;
            this.button1.Text = "Criar Partida";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listaDeIPs
            // 
            this.listaDeIPs.FormattingEnabled = true;
            this.listaDeIPs.Location = new System.Drawing.Point(12, 12);
            this.listaDeIPs.Name = "listaDeIPs";
            this.listaDeIPs.Size = new System.Drawing.Size(216, 134);
            this.listaDeIPs.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(234, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(216, 60);
            this.button2.TabIndex = 9;
            this.button2.Text = "Refresh Hosts";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(234, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(216, 60);
            this.button3.TabIndex = 11;
            this.button3.Text = "Conectar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 162);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listaDeIPs);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.doneButton);
            this.Name = "Form1";
            this.Text = "Tanks 0.1 Alpha";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listaDeIPs;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

