using AgendamentoHospitalarInteligente.Desktop.Models;
using AgendamentoHospitalarInteligente.Desktop.Models.Enums;

namespace AgendamentoHospitalarInteligente.Desktop.Forms.UserControls
{
    public partial class CriarAgendaControl : UserControl
    {
        private readonly MainForm _main;
        private List<MedicoModeloResponse> _resultadosBusca = new();
        private readonly List<object> _medicosAdicionados = new();
        private readonly List<object> _solicitacoesAdicionadas = new();
        private readonly System.Windows.Forms.Timer _debounceTimer;
        private bool _selecionando;

        public CriarAgendaControl(MainForm main)
        {
            InitializeComponent();
            _main = main;

            cmbPrioridade.Items.AddRange(Enum.GetNames<Prioridade>());
            cmbPrioridade.SelectedIndex = 0;

            _debounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
            _debounceTimer.Tick += DebounceTimer_Tick;

            cmbMedicoExistente.TextChanged += CmbMedicoExistente_TextChanged;
            cmbMedicoExistente.SelectedIndexChanged += CmbMedicoExistente_SelectedIndexChanged;
            btnAddHorario.Click += (_, _) => gridHorariosTemp.Rows.Add(mtbHorarioInicio.Text, mtbHorarioFim.Text);
            btnAddMedico.Click += BtnAddMedico_Click;
            btnAddSolicitacao.Click += BtnAddSolicitacao_Click;
            btnGerarAgenda.Click += BtnGerarAgenda_Click;

            gridMedicos.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && gridMedicos.Columns[e.ColumnIndex].Name == "colMedicoRemover")
                {
                    _medicosAdicionados.RemoveAt(e.RowIndex);
                    gridMedicos.Rows.RemoveAt(e.RowIndex);
                    AtualizarBotaoGerar();
                }
            };

            gridSolicitacoes.CellClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && gridSolicitacoes.Columns[e.ColumnIndex].Name == "colSolicitacaoRemover")
                {
                    _solicitacoesAdicionadas.RemoveAt(e.RowIndex);
                    gridSolicitacoes.Rows.RemoveAt(e.RowIndex);
                    AtualizarBotaoGerar();
                }
            };
        }

        private void CmbMedicoExistente_TextChanged(object? sender, EventArgs e)
        {
            if (_selecionando) return;

            _debounceTimer.Stop();

            if (cmbMedicoExistente.Text.Length >= 2)
                _debounceTimer.Start();
        }

        private async void DebounceTimer_Tick(object? sender, EventArgs e)
        {
            _debounceTimer.Stop();
            var filtro = cmbMedicoExistente.Text;

            if (string.IsNullOrWhiteSpace(filtro) || filtro.Length < 2) return;

            try
            {
                _resultadosBusca = await Program.Api.BuscarMedicosAsync(filtro);

                _selecionando = true;
                var cursorPos = cmbMedicoExistente.SelectionStart;
                cmbMedicoExistente.Items.Clear();

                if (_resultadosBusca.Count > 0)
                {
                    foreach (var m in _resultadosBusca)
                        cmbMedicoExistente.Items.Add($"{m.Id} - {m.Nome}");
                }
                else
                {
                    cmbMedicoExistente.Items.Add("(Nenhum registro)");
                }

                cmbMedicoExistente.SelectionStart = cursorPos;
                cmbMedicoExistente.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                _selecionando = false;
            }
            catch
            {
                _selecionando = false;
            }
        }

        private void CmbMedicoExistente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_selecionando || cmbMedicoExistente.SelectedIndex < 0) return;
            if (_resultadosBusca.Count == 0 || cmbMedicoExistente.SelectedIndex >= _resultadosBusca.Count)
            {
                _selecionando = true;
                cmbMedicoExistente.SelectedIndex = -1;
                _selecionando = false;
                return;
            }

            var modelo = _resultadosBusca[cmbMedicoExistente.SelectedIndex];
            txtMedicoNome.Text = modelo.Nome;
            gridHorariosTemp.Rows.Clear();
            foreach (var h in modelo.HorariosDisponiveis)
                gridHorariosTemp.Rows.Add(h.Inicio, h.Fim);
        }

        private void BtnAddMedico_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicoNome.Text) || gridHorariosTemp.Rows.Count == 0)
            {
                MessageBox.Show("Informe o nome e pelo menos um horário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var horarios = new List<object>();
            foreach (DataGridViewRow row in gridHorariosTemp.Rows)
            {
                var inicio = row.Cells["colHorarioInicio"].Value!.ToString()!;
                var fim = row.Cells["colHorarioFim"].Value!.ToString()!;
                horarios.Add(new { inicio, fim });
            }

            _medicosAdicionados.Add(new { nome = txtMedicoNome.Text.Trim(), horariosDisponiveis = horarios });
            gridMedicos.Rows.Add(txtMedicoNome.Text.Trim(), "Remover");

            txtMedicoNome.Clear();
            gridHorariosTemp.Rows.Clear();
            _selecionando = true;
            cmbMedicoExistente.Text = "";
            cmbMedicoExistente.Items.Clear();
            _selecionando = false;
            AtualizarBotaoGerar();
        }

        private void BtnAddSolicitacao_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPacienteNome.Text))
            {
                MessageBox.Show("Informe o nome do paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var prioridade = cmbPrioridade.SelectedItem!.ToString()!;
            var duracao = (int)nudDuracao.Value;

            _solicitacoesAdicionadas.Add(new { pacienteNome = txtPacienteNome.Text.Trim(), duracaoMinutos = duracao, prioridade });
            gridSolicitacoes.Rows.Add(txtPacienteNome.Text.Trim(), duracao, prioridade, "Remover");
            txtPacienteNome.Clear();
            AtualizarBotaoGerar();
        }

        private void AtualizarBotaoGerar()
        {
            var habilitado = _medicosAdicionados.Count > 0 && _solicitacoesAdicionadas.Count > 0;
            btnGerarAgenda.Enabled = habilitado;
            btnGerarAgenda.BackColor = habilitado ? Color.FromArgb(30, 30, 60) : Color.LightGray;
        }

        private async void BtnGerarAgenda_Click(object? sender, EventArgs e)
        {
            try
            {
                btnGerarAgenda.Enabled = false;
                btnGerarAgenda.Text = "Gerando...";

                var horaAtual = chkRespeitarHoraAtual.Checked ? DateTime.Now.ToString("HH:mm") : (string?)null;
                var request = new { medicos = _medicosAdicionados, solicitacoes = _solicitacoesAdicionadas, horaAtual };
                var agenda = await Program.Api.CriarAgendaAsync(request);

                MessageBox.Show($"Agenda #{agenda.Id} gerada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _main.NavegarParaDetalhes(agenda.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar agenda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGerarAgenda.Enabled = true;
                btnGerarAgenda.Text = "Gerar Agenda";
            }
        }
    }
}
