using BLL;

namespace PoddarGrupp20
{
    public partial class Form1 : Form
    {
        private Poddkontrollerare poddkontroll;

        public Form1()
        {
            InitializeComponent();
            poddkontroll = new Poddkontrollerare();
        }

        private void btnS�k_Click(object sender, EventArgs e)
        {
            string rss = txtbRSS.Text;
            poddkontroll.H�mtaPoddarRSS(rss);
        }
    }
}
