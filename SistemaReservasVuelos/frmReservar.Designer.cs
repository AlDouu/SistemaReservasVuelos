using System.Windows.Forms;
namespace Clases_para_Proyecto
{
    partial class frmReservar
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

            this.dgvVuelos = new System.Windows.Forms.DataGridView();
            this.cmbAsientos = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVuelos
            // 
            this.dgvVuelos.Columns.Add("Codigo", "Código Vuelo");
            this.dgvVuelos.Columns.Add("Origen", "Origen");
            this.dgvVuelos.Columns.Add("Destino", "Destino");
            this.dgvVuelos.Columns.Add("Fecha", "Fecha");
            this.dgvVuelos.Columns.Add("Hora", "Hora");
            this.dgvVuelos.Columns.Add("Asientos", "Asientos Disp.");
            this.dgvVuelos.Columns.Add("Precio", "Precio");
            this.dgvVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuelos.Location = new System.Drawing.Point(20, 30);
            this.dgvVuelos.Name = "dgvVuelos";
            this.dgvVuelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVuelos.Size = new System.Drawing.Size(600, 200);
            this.dgvVuelos.TabIndex = 0;
            // 
            // cmbAsientos
            // 
            this.cmbAsientos.FormattingEnabled = true;
            this.cmbAsientos.Location = new System.Drawing.Point(120, 250);
            this.cmbAsientos.Name = "cmbAsientos";
            this.cmbAsientos.Size = new System.Drawing.Size(100, 21);
            this.cmbAsientos.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(250, 250);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(120, 30);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(400, 250);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(120, 30);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Asiento disponible:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "VUELOS DISPONIBLES";
            // 
            // frmReservar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 300);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cmbAsientos);
            this.Controls.Add(this.dgvVuelos);
            this.Name = "frmReservar";
            this.Text = "Realizar Reserva";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVuelos;
        private System.Windows.Forms.ComboBox cmbAsientos;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}