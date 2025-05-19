
namespace ControlAccesoEdificio.Forms
{
    partial class RegistroAcceso
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
            this.dgvAccesos = new System.Windows.Forms.DataGridView();
            this.txtZonaAcceso = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAccesos
            // 
            this.dgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccesos.Location = new System.Drawing.Point(12, 221);
            this.dgvAccesos.Name = "dgvAccesos";
            this.dgvAccesos.Size = new System.Drawing.Size(554, 217);
            this.dgvAccesos.TabIndex = 0;
            // 
            // txtZonaAcceso
            // 
            this.txtZonaAcceso.Location = new System.Drawing.Point(58, 52);
            this.txtZonaAcceso.Name = "txtZonaAcceso";
            this.txtZonaAcceso.Size = new System.Drawing.Size(100, 20);
            this.txtZonaAcceso.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(71, 102);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(111, 73);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "button1";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(221, 102);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 73);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "button2";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtpSalida
            // 
            this.dtpSalida.Location = new System.Drawing.Point(198, 52);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(200, 20);
            this.dtpSalida.TabIndex = 4;
            // 
            // RegistroAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 448);
            this.Controls.Add(this.dtpSalida);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtZonaAcceso);
            this.Controls.Add(this.dgvAccesos);
            this.Name = "RegistroAcceso";
            this.Text = "RegistroAcceso";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccesos;
        private System.Windows.Forms.TextBox txtZonaAcceso;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DateTimePicker dtpSalida;
    }
}