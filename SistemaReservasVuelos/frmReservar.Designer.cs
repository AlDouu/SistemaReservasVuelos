using System.Windows.Forms;

namespace Clases_para_Proyecto
{
    partial class frmReservar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Configuración del DataGridView y columnas
            dgvVuelos = new DataGridView();
            colCodigoVuelo = new DataGridViewTextBoxColumn();
            colOrigen = new DataGridViewTextBoxColumn();
            colDestino = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colHora = new DataGridViewTextBoxColumn();
            colAsientosDisp = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            
            btnConfirmar = new Button();
            btnVolver = new Button();
            lblTitulo = new Label();
            
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).BeginInit();
            SuspendLayout();

            // 
            // dgvVuelos
            // 
            dgvVuelos.AllowUserToAddRows = false;
            dgvVuelos.AllowUserToDeleteRows = false;
            dgvVuelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVuelos.Columns.AddRange(new DataGridViewColumn[] {
                colCodigoVuelo,
                colOrigen,
                colDestino,
                colFecha,
                colHora,
                colAsientosDisp,
                colPrecio});
            dgvVuelos.Location = new Point(20, 50);
            dgvVuelos.Margin = new Padding(4, 5, 4, 5);
            dgvVuelos.MultiSelect = false;
            dgvVuelos.Name = "dgvVuelos";
            dgvVuelos.ReadOnly = true;
            dgvVuelos.RowHeadersWidth = 51;
            dgvVuelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVuelos.Size = new Size(800, 350);
            dgvVuelos.TabIndex = 0;
            dgvVuelos.SelectionChanged += dgvVuelos_SelectionChanged;

            // Configuración de columnas (ejemplo para una columna)
            colCodigoVuelo.HeaderText = "Código Vuelo";
            colCodigoVuelo.MinimumWidth = 6;
            colCodigoVuelo.Name = "colCodigoVuelo";
            colCodigoVuelo.ReadOnly = true;
            colCodigoVuelo.Width = 120;
            
            // ... (configuración similar para las otras columnas)

            // 
            // btnConfirmar
            // 
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new Point(20, 420);
            btnConfirmar.Margin = new Padding(4, 5, 4, 5);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(180, 50);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "CONFIRMAR RESERVA";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click_1;

            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(220, 420);
            btnVolver.Margin = new Padding(4, 5, 4, 5);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 50);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click_1;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 20);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "VUELOS DISPONIBLES";

            // 
            // frmReservar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 500);
            Controls.Add(lblTitulo);
            Controls.Add(btnVolver);
            Controls.Add(btnConfirmar);
            Controls.Add(dgvVuelos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReservar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Realizar Reserva de Vuelo";
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVuelos;
        private DataGridViewTextBoxColumn colCodigoVuelo;
        private DataGridViewTextBoxColumn colOrigen;
        private DataGridViewTextBoxColumn colDestino;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colAsientosDisp;
        private DataGridViewTextBoxColumn colPrecio;
        private Button btnConfirmar;
        private Button btnVolver;
        private Label lblTitulo;
    }
}