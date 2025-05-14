using System.Windows.Forms;
namespace Clases_para_Proyecto
{
    partial class frmMostrar
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnRealizarReserva = new System.Windows.Forms.Button();
            this.btnGestionarReservas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(50, 30);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(200, 20);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido, [Nombre]";
            // 
            // btnRealizarReserva
            // 
            this.btnRealizarReserva.Click += new System.EventHandler(this.btnRealizarReserva_Click);
            this.btnRealizarReserva.Location = new System.Drawing.Point(100, 80);
            this.btnRealizarReserva.Name = "btnRealizarReserva";
            this.btnRealizarReserva.Size = new System.Drawing.Size(150, 40);
            this.btnRealizarReserva.TabIndex = 1;
            this.btnRealizarReserva.Text = "REALIZAR RESERVA";
            this.btnRealizarReserva.UseVisualStyleBackColor = true;
            // 
            // btnGestionarReservas
            // 
            this.btnGestionarReservas.Click += new System.EventHandler(this.btnGestionarReservas_Click);
            this.btnGestionarReservas.Location = new System.Drawing.Point(100, 140);
            this.btnGestionarReservas.Name = "btnGestionarReservas";
            this.btnGestionarReservas.Size = new System.Drawing.Size(150, 40);
            this.btnGestionarReservas.TabIndex = 2;
            this.btnGestionarReservas.Text = "GESTIONAR RESERVAS";
            this.btnGestionarReservas.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.Location = new System.Drawing.Point(100, 200);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGestionarReservas);
            this.Controls.Add(this.btnRealizarReserva);
            this.Controls.Add(this.lblBienvenida);
            this.Name = "frmMostrar";
            this.Text = "Opciones de Reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnRealizarReserva;
        private System.Windows.Forms.Button btnGestionarReservas;
        private System.Windows.Forms.Button btnSalir;
    }
}