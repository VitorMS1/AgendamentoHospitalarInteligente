namespace AgendamentoHospitalarInteligente.Desktop.Forms
{
    partial class MainForm
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

        #region Codigo gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnAgendas = new System.Windows.Forms.Button();
            this.btnGerarAgenda = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            //
            // panelMenu
            //
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.panelMenu.Controls.Add(this.btnPacientes);
            this.panelMenu.Controls.Add(this.btnMedicos);
            this.panelMenu.Controls.Add(this.btnAgendas);
            this.panelMenu.Controls.Add(this.btnGerarAgenda);
            this.panelMenu.Controls.Add(this.lblTitulo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(10);
            this.panelMenu.Size = new System.Drawing.Size(200, 661);
            this.panelMenu.TabIndex = 0;
            //
            // btnPacientes
            //
            this.btnPacientes.Visible = false;
            this.btnPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 50, 90);
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.Location = new System.Drawing.Point(10, 195);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(180, 45);
            this.btnPacientes.TabIndex = 4;
            this.btnPacientes.Text = "Pacientes";
            //
            // btnMedicos
            //
            this.btnMedicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedicos.FlatAppearance.BorderSize = 0;
            this.btnMedicos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 50, 90);
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMedicos.ForeColor = System.Drawing.Color.White;
            this.btnMedicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicos.Location = new System.Drawing.Point(10, 150);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(180, 45);
            this.btnMedicos.TabIndex = 3;
            this.btnMedicos.Text = "Medicos";
            //
            // btnAgendas
            //
            this.btnAgendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgendas.FlatAppearance.BorderSize = 0;
            this.btnAgendas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 50, 90);
            this.btnAgendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAgendas.ForeColor = System.Drawing.Color.White;
            this.btnAgendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgendas.Location = new System.Drawing.Point(10, 105);
            this.btnAgendas.Name = "btnAgendas";
            this.btnAgendas.Size = new System.Drawing.Size(180, 45);
            this.btnAgendas.TabIndex = 2;
            this.btnAgendas.Text = "Agendas";
            //
            // btnGerarAgenda
            //
            this.btnGerarAgenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGerarAgenda.FlatAppearance.BorderSize = 0;
            this.btnGerarAgenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 50, 90);
            this.btnGerarAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarAgenda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGerarAgenda.ForeColor = System.Drawing.Color.White;
            this.btnGerarAgenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarAgenda.Location = new System.Drawing.Point(10, 60);
            this.btnGerarAgenda.Name = "btnGerarAgenda";
            this.btnGerarAgenda.Size = new System.Drawing.Size(180, 45);
            this.btnGerarAgenda.TabIndex = 1;
            this.btnGerarAgenda.Text = "Gerar Agenda";
            //
            // lblTitulo
            //
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Menu";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelConteudo
            //
            this.panelConteudo.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.panelConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConteudo.Location = new System.Drawing.Point(200, 0);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Padding = new System.Windows.Forms.Padding(15);
            this.panelConteudo.Size = new System.Drawing.Size(884, 661);
            this.panelConteudo.TabIndex = 1;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agendamento Hospitalar Inteligente";
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelConteudo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnGerarAgenda;
        private System.Windows.Forms.Button btnAgendas;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnPacientes;
    }
}
