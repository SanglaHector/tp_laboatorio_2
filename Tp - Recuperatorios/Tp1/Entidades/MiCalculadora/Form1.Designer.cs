namespace MiCalculadora
{
    partial class FormCalculadora
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
            this.textBoxNum1 = new System.Windows.Forms.TextBox();
            this.textBoxNum2 = new System.Windows.Forms.TextBox();
            this.comboBoxOperacion = new System.Windows.Forms.ComboBox();
            this.labelResultado = new System.Windows.Forms.Label();
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnConverToBin = new System.Windows.Forms.Button();
            this.btnConverToDec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNum1
            // 
            this.textBoxNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNum1.Location = new System.Drawing.Point(12, 70);
            this.textBoxNum1.Name = "textBoxNum1";
            this.textBoxNum1.Size = new System.Drawing.Size(175, 47);
            this.textBoxNum1.TabIndex = 1;
            // 
            // textBoxNum2
            // 
            this.textBoxNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNum2.Location = new System.Drawing.Point(439, 70);
            this.textBoxNum2.Name = "textBoxNum2";
            this.textBoxNum2.Size = new System.Drawing.Size(175, 47);
            this.textBoxNum2.TabIndex = 3;
            // 
            // comboBoxOperacion
            // 
            this.comboBoxOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOperacion.FormattingEnabled = true;
            this.comboBoxOperacion.Items.AddRange(new object[] {
            "+",
            "-",
            "/",
            "*"});
            this.comboBoxOperacion.Location = new System.Drawing.Point(215, 70);
            this.comboBoxOperacion.Name = "comboBoxOperacion";
            this.comboBoxOperacion.Size = new System.Drawing.Size(195, 47);
            this.comboBoxOperacion.TabIndex = 2;
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultado.Location = new System.Drawing.Point(354, 19);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(260, 39);
            this.labelResultado.TabIndex = 3;
            this.labelResultado.Text = "                           ";
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(12, 140);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(175, 47);
            this.btnOperar.TabIndex = 4;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(224, 140);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(175, 47);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(439, 140);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(175, 47);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click_1);
            // 
            // btnConverToBin
            // 
            this.btnConverToBin.Location = new System.Drawing.Point(12, 218);
            this.btnConverToBin.Name = "btnConverToBin";
            this.btnConverToBin.Size = new System.Drawing.Size(289, 40);
            this.btnConverToBin.TabIndex = 7;
            this.btnConverToBin.Text = "Convertir a binario";
            this.btnConverToBin.UseVisualStyleBackColor = true;
            this.btnConverToBin.Click += new System.EventHandler(this.BtnConverToBin_Click);
            // 
            // btnConverToDec
            // 
            this.btnConverToDec.Location = new System.Drawing.Point(325, 218);
            this.btnConverToDec.Name = "btnConverToDec";
            this.btnConverToDec.Size = new System.Drawing.Size(289, 40);
            this.btnConverToDec.TabIndex = 8;
            this.btnConverToDec.Text = "Convertir a decimal";
            this.btnConverToDec.UseVisualStyleBackColor = true;
            this.btnConverToDec.Click += new System.EventHandler(this.BtnConverToDec_Click);
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 281);
            this.Controls.Add(this.btnConverToDec);
            this.Controls.Add(this.btnConverToBin);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.comboBoxOperacion);
            this.Controls.Add(this.textBoxNum2);
            this.Controls.Add(this.textBoxNum1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Héctor Sangla curso 2 D";
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNum1;
        private System.Windows.Forms.TextBox textBoxNum2;
        private System.Windows.Forms.ComboBox comboBoxOperacion;
        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnConverToBin;
        private System.Windows.Forms.Button btnConverToDec;
    }
}

