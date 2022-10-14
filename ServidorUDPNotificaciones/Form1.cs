using System.Net.Sockets;
using System.Net;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ServidorUDPNotificaciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Notificacion noti;

        private void Form1_Load(object sender, EventArgs e)
        {



            UdpClient cliente = new UdpClient(2022);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 2022);
            cliente.EnableBroadcast = true;


            while (true)
            {
                byte[] buffer = cliente.Receive(ref ep);
                string mensaje = System.Text.Encoding.UTF8.GetString(buffer);
                var json = JsonConvert.DeserializeObject<Notificacion>(mensaje);
                if (json != null)
                {
                    noti = new Notificacion()
                    {
                        Titulo = json.Titulo,
                        Mensaje = json.Mensaje
                    };
                    new ToastContentBuilder()
                        .AddAppLogoOverride(new Uri("ms-appdata:///local/Andrew.jpg"), ToastGenericAppLogoCrop.Circle)
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                       .AddText(noti.Titulo)
                       .AddText(noti.Mensaje)
                       .Show();
                }

            }

















        }


    }
}