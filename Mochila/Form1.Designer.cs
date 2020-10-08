namespace Mochila
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Iniciar = new System.Windows.Forms.Button();
            this.nud_Objetos = new System.Windows.Forms.NumericUpDown();
            this.lbl_Objetos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Peso = new System.Windows.Forms.NumericUpDown();
            this.pnl_PainelPrincipal = new System.Windows.Forms.Panel();
            this.pnl_Mochila = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Objetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Peso)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Iniciar
            // 
            this.btn_Iniciar.Location = new System.Drawing.Point(795, 12);
            this.btn_Iniciar.Name = "btn_Iniciar";
            this.btn_Iniciar.Size = new System.Drawing.Size(75, 31);
            this.btn_Iniciar.TabIndex = 0;
            this.btn_Iniciar.Text = "Iniciar";
            this.btn_Iniciar.UseVisualStyleBackColor = true;
            this.btn_Iniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // nud_Objetos
            // 
            this.nud_Objetos.Location = new System.Drawing.Point(795, 96);
            this.nud_Objetos.Maximum = new decimal(new int[] {
            54,
            0,
            0,
            0});
            this.nud_Objetos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Objetos.Name = "nud_Objetos";
            this.nud_Objetos.Size = new System.Drawing.Size(40, 20);
            this.nud_Objetos.TabIndex = 2;
            this.nud_Objetos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Objetos
            // 
            this.lbl_Objetos.AutoSize = true;
            this.lbl_Objetos.Location = new System.Drawing.Point(792, 80);
            this.lbl_Objetos.Name = "lbl_Objetos";
            this.lbl_Objetos.Size = new System.Drawing.Size(43, 13);
            this.lbl_Objetos.TabIndex = 3;
            this.lbl_Objetos.Text = "Objetos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(863, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Peso Limite";
            // 
            // nud_Peso
            // 
            this.nud_Peso.Location = new System.Drawing.Point(866, 96);
            this.nud_Peso.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Peso.Name = "nud_Peso";
            this.nud_Peso.Size = new System.Drawing.Size(58, 20);
            this.nud_Peso.TabIndex = 4;
            this.nud_Peso.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnl_PainelPrincipal
            // 
            this.pnl_PainelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_PainelPrincipal.Location = new System.Drawing.Point(12, 12);
            this.pnl_PainelPrincipal.Name = "pnl_PainelPrincipal";
            this.pnl_PainelPrincipal.Size = new System.Drawing.Size(775, 362);
            this.pnl_PainelPrincipal.TabIndex = 6;
            // 
            // pnl_Mochila
            // 
            this.pnl_Mochila.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Mochila.Location = new System.Drawing.Point(12, 409);
            this.pnl_Mochila.Name = "pnl_Mochila";
            this.pnl_Mochila.Size = new System.Drawing.Size(775, 255);
            this.pnl_Mochila.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mochila";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 673);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl_Mochila);
            this.Controls.Add(this.pnl_PainelPrincipal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_Peso);
            this.Controls.Add(this.lbl_Objetos);
            this.Controls.Add(this.nud_Objetos);
            this.Controls.Add(this.btn_Iniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Objetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Peso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Iniciar;
        private System.Windows.Forms.NumericUpDown nud_Objetos;
        private System.Windows.Forms.Label lbl_Objetos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Peso;
        private System.Windows.Forms.Panel pnl_PainelPrincipal;
        private System.Windows.Forms.Panel pnl_Mochila;
        private System.Windows.Forms.Label label2;
    }
}

