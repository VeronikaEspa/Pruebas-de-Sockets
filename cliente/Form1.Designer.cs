namespace cliente
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            reservaAccion = new Button();
            inputHoraDeReserva = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // reservaAccion
            // 
            reservaAccion.Location = new Point(308, 318);
            reservaAccion.Name = "reservaAccion";
            reservaAccion.Size = new Size(112, 34);
            reservaAccion.TabIndex = 0;
            reservaAccion.Text = "Reservar ticket";
            reservaAccion.UseVisualStyleBackColor = true;
            reservaAccion.Click += reservaAccion_Click;
            // 
            // inputHoraDeReserva
            // 
            inputHoraDeReserva.Location = new Point(292, 248);
            inputHoraDeReserva.Name = "inputHoraDeReserva";
            inputHoraDeReserva.Size = new Size(150, 31);
            inputHoraDeReserva.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 251);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 2;
            label1.Text = "Indique la opción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(150, 132);
            label2.Name = "label2";
            label2.Size = new Size(436, 25);
            label2.TabIndex = 3;
            label2.Text = "1. 9am       2. 10am      3. 11am      4. 12pm     5. 1pm";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(inputHoraDeReserva);
            Controls.Add(reservaAccion);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button reservaAccion;
        private TextBox inputHoraDeReserva;
        private Label label1;
        private Label label2;
    }
}
