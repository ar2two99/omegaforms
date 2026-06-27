namespace omegaforms
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
            lblTitulo = new Label();
            prgVida = new ProgressBar();
            lblVida = new Label();
            lblEnergia = new Label();
            prgEnergia = new ProgressBar();
            label1 = new Label();
            lstInventario = new CheckedListBox();
            txtNarrativa = new RichTextBox();
            label2 = new Label();
            btnOpcion1 = new Button();
            btnOpcion2 = new Button();
            btnOpcion3 = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(12, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(162, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Mision omega hito 5 unifranz";
            // 
            // prgVida
            // 
            prgVida.Location = new Point(26, 78);
            prgVida.Name = "prgVida";
            prgVida.Size = new Size(100, 23);
            prgVida.TabIndex = 1;
            prgVida.Value = 100;
            // 
            // lblVida
            // 
            lblVida.AutoSize = true;
            lblVida.Location = new Point(26, 60);
            lblVida.Name = "lblVida";
            lblVida.Size = new Size(30, 15);
            lblVida.TabIndex = 2;
            lblVida.Text = "Vida";
            // 
            // lblEnergia
            // 
            lblEnergia.AutoSize = true;
            lblEnergia.Location = new Point(322, 60);
            lblEnergia.Name = "lblEnergia";
            lblEnergia.Size = new Size(46, 15);
            lblEnergia.TabIndex = 3;
            lblEnergia.Text = "Energia";
            // 
            // prgEnergia
            // 
            prgEnergia.BackColor = SystemColors.Control;
            prgEnergia.Location = new Point(322, 78);
            prgEnergia.Name = "prgEnergia";
            prgEnergia.Size = new Size(100, 23);
            prgEnergia.TabIndex = 4;
            prgEnergia.Value = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(593, 133);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 5;
            label1.Text = "Inventario";
            // 
            // lstInventario
            // 
            lstInventario.FormattingEnabled = true;
            lstInventario.Location = new Point(593, 151);
            lstInventario.Name = "lstInventario";
            lstInventario.Size = new Size(159, 112);
            lstInventario.TabIndex = 6;
            // 
            // txtNarrativa
            // 
            txtNarrativa.BackColor = SystemColors.ActiveCaptionText;
            txtNarrativa.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtNarrativa.ForeColor = Color.Lime;
            txtNarrativa.Location = new Point(26, 136);
            txtNarrativa.Name = "txtNarrativa";
            txtNarrativa.ReadOnly = true;
            txtNarrativa.Size = new Size(541, 152);
            txtNarrativa.TabIndex = 7;
            txtNarrativa.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 118);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 8;
            label2.Text = "HISTORIA";
            // 
            // btnOpcion1
            // 
            btnOpcion1.Location = new Point(26, 294);
            btnOpcion1.Name = "btnOpcion1";
            btnOpcion1.Size = new Size(117, 47);
            btnOpcion1.TabIndex = 9;
            btnOpcion1.Text = "button1";
            btnOpcion1.UseVisualStyleBackColor = true;
            btnOpcion1.Click += btnOpcion1_Click;
            // 
            // btnOpcion2
            // 
            btnOpcion2.Location = new Point(252, 294);
            btnOpcion2.Name = "btnOpcion2";
            btnOpcion2.Size = new Size(116, 47);
            btnOpcion2.TabIndex = 10;
            btnOpcion2.Text = "button2";
            btnOpcion2.UseVisualStyleBackColor = true;
            btnOpcion2.Click += btnOpcion2_Click;
            // 
            // btnOpcion3
            // 
            btnOpcion3.Location = new Point(451, 294);
            btnOpcion3.Name = "btnOpcion3";
            btnOpcion3.Size = new Size(116, 47);
            btnOpcion3.TabIndex = 11;
            btnOpcion3.Text = "button3";
            btnOpcion3.UseVisualStyleBackColor = true;
            btnOpcion3.Click += btnOpcion3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOpcion3);
            Controls.Add(btnOpcion2);
            Controls.Add(btnOpcion1);
            Controls.Add(label2);
            Controls.Add(txtNarrativa);
            Controls.Add(lstInventario);
            Controls.Add(label1);
            Controls.Add(prgEnergia);
            Controls.Add(lblEnergia);
            Controls.Add(lblVida);
            Controls.Add(prgVida);
            Controls.Add(lblTitulo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private ProgressBar prgVida;
        private Label lblVida;
        private Label lblEnergia;
        private ProgressBar prgEnergia;
        private Label label1;
        private CheckedListBox lstInventario;
        private RichTextBox txtNarrativa;
        private Label label2;
        private Button btnOpcion1;
        private Button btnOpcion2;
        private Button btnOpcion3;
    }
}
