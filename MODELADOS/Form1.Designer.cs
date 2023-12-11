namespace MODELADOS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChartDesplazamiento = new LiveCharts.WinForms.CartesianChart();
            this.label3 = new System.Windows.Forms.Label();
            this.ChartAceleracion = new LiveCharts.WinForms.CartesianChart();
            this.ChartVelocidad = new LiveCharts.WinForms.CartesianChart();
            this.SPpuertos = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChartDesplazamiento
            // 
            this.ChartDesplazamiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChartDesplazamiento.BackColor = System.Drawing.Color.Transparent;
            this.ChartDesplazamiento.ForeColor = System.Drawing.Color.Black;
            this.ChartDesplazamiento.Location = new System.Drawing.Point(31, 86);
            this.ChartDesplazamiento.Name = "ChartDesplazamiento";
            this.ChartDesplazamiento.Size = new System.Drawing.Size(435, 290);
            this.ChartDesplazamiento.TabIndex = 0;
            this.ChartDesplazamiento.Text = "Desplazamiento";
            this.ChartDesplazamiento.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.Desplazamiento_ChildChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(185, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Desplazamiento";
            // 
            // ChartAceleracion
            // 
            this.ChartAceleracion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChartAceleracion.BackColor = System.Drawing.Color.Transparent;
            this.ChartAceleracion.ForeColor = System.Drawing.Color.Black;
            this.ChartAceleracion.Location = new System.Drawing.Point(536, 90);
            this.ChartAceleracion.Name = "ChartAceleracion";
            this.ChartAceleracion.Size = new System.Drawing.Size(409, 273);
            this.ChartAceleracion.TabIndex = 4;
            this.ChartAceleracion.Text = "Aceleracion";
            // 
            // ChartVelocidad
            // 
            this.ChartVelocidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChartVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.ChartVelocidad.Location = new System.Drawing.Point(324, 379);
            this.ChartVelocidad.Name = "ChartVelocidad";
            this.ChartVelocidad.Size = new System.Drawing.Size(349, 283);
            this.ChartVelocidad.TabIndex = 5;
            this.ChartVelocidad.Text = "Velocidad";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(671, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Velocidad";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(444, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Aceleracion";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(975, 674);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChartVelocidad);
            this.Controls.Add(this.ChartAceleracion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChartDesplazamiento);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Graficas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart ChartDesplazamiento;
        private System.Windows.Forms.Label label3;
        private LiveCharts.WinForms.CartesianChart ChartAceleracion;
        private LiveCharts.WinForms.CartesianChart ChartVelocidad;
        private System.IO.Ports.SerialPort SPpuertos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

