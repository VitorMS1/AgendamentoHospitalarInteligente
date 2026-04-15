using AgendamentoHospitalarInteligente.Desktop.Models;
using AgendamentoHospitalarInteligente.Desktop.Models.Enums;

namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    public partial class AgendaDetalhesControl : UserControl
    {
        private readonly MainForm _main;
        private readonly int _agendaId;
        private Control[] _controlesEncaixe = Array.Empty<Control>();
        private bool _encaixeVisivel;

        public AgendaDetalhesControl(MainForm main, int agendaId)
        {
            InitializeComponent();
            _main = main;
            _agendaId = agendaId;

            lblTitulo.Text = $"Detalhes da Agenda #{agendaId}";
            cmbPrioridade.Items.AddRange(Enum.GetNames<Prioridade>());
            cmbPrioridade.SelectedIndex = 0;

            _controlesEncaixe = new Control[] { lblPac, txtPacienteNome, lblDur, nudDuracao, lblPri, cmbPrioridade, btnEncaixar, chkRespeitarHoraAtualEncaixe };

            btnMostrarEncaixe.Click += (_, _) => DefinirVisibilidadeEncaixe(true);
            btnCancelarEncaixe.Click += (_, _) => DefinirVisibilidadeEncaixe(false);
            btnEncaixar.Click += BtnEncaixar_Click;

            Load += async (_, _) =>
            {
                DefinirVisibilidadeEncaixe(false);
                await CarregarAsync();
            };
        }

        private void DefinirVisibilidadeEncaixe(bool visivel)
        {
            _encaixeVisivel = visivel;
            panelPrincipal.SuspendLayout();
            foreach (var c in _controlesEncaixe)
                c.Visible = visivel;
            btnMostrarEncaixe.Visible = !visivel;
            btnCancelarEncaixe.Visible = visivel;
            panelPrincipal.ResumeLayout();
        }

        private async Task CarregarAsync()
        {
            try
            {
                var agenda = await Program.Api.ObterAgendaPorIdAsync(_agendaId);
                PreencherMedicos(agenda);
                PreencherConsultas(agenda);
                PreencherNaoAlocados(agenda);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar agenda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherMedicos(AgendaResponse agenda)
        {
            gridMedicos.Rows.Clear();
            foreach (var m in agenda.Medicos)
            {
                var horarios = string.Join(", ", m.HorariosDisponiveis.Select(h => $"{h.Inicio}-{h.Fim}"));
                gridMedicos.Rows.Add(m.Nome, horarios.Length > 0 ? horarios : "(sem horarios restantes)");
            }
        }

        private void PreencherConsultas(AgendaResponse agenda)
        {
            gridConsultas.Rows.Clear();
            foreach (var c in agenda.Consultas.OrderBy(x => x.HorarioInicio))
                gridConsultas.Rows.Add(c.Prioridade.ToString(), c.PacienteNome, c.MedicoNome, $"{c.HorarioInicio} - {c.HorarioFim}", c.DuracaoMinutos);
        }

        private void PreencherNaoAlocados(AgendaResponse agenda)
        {
            gridNaoAlocados.Rows.Clear();
            foreach (var p in agenda.PacientesNaoAlocados)
                gridNaoAlocados.Rows.Add(p.Nome, p.DuracaoMinutos, p.Prioridade.ToString());
        }

        private async void BtnEncaixar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPacienteNome.Text))
                {
                    MessageBox.Show("Informe o nome do paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var prioridade = Enum.Parse<Prioridade>(cmbPrioridade.SelectedItem!.ToString()!);
                var horaAtual = chkRespeitarHoraAtualEncaixe.Checked ? DateTime.Now.ToString("HH:mm") : (string?)null;
                var agenda = await Program.Api.EncaixarConsultaAsync(_agendaId, txtPacienteNome.Text.Trim(), (int)nudDuracao.Value, prioridade, horaAtual);

                PreencherMedicos(agenda);
                PreencherConsultas(agenda);
                PreencherNaoAlocados(agenda);

                txtPacienteNome.Clear();
                DefinirVisibilidadeEncaixe(false);

                MessageBox.Show("Consulta encaixada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao encaixar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
