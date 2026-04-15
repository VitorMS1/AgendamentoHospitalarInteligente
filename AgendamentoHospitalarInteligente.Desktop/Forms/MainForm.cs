using AgendamentoHospitalarInteligente.Desktop.Forms.UserControls;

namespace AgendamentoHospitalarInteligente.Desktop.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            btnGerarAgenda.Click += (_, _) => NavegarPara(new CriarAgendaControl(this));
            btnAgendas.Click += (_, _) => NavegarPara(new AgendasListControl(this));
            btnMedicos.Click += (_, _) => NavegarPara(new MedicosListControl());

            Load += (_, _) => NavegarPara(new AgendasListControl(this));
        }

        public void NavegarPara(UserControl control)
        {
            panelConteudo.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(control);
        }

        public void NavegarParaDetalhes(int agendaId)
        {
            NavegarPara(new AgendaDetalhesControl(this, agendaId));
        }
    }
}
