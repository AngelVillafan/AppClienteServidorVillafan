using ClienteUDPNotificaciones.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ClienteUDPNotificaciones.ViewModels
{
    public class MensajeViewModel : INotifyPropertyChanged
    {

        public Notificacion Noti { get; set; }
        public string Error { get; set; } = "";
        public ICommand EnviarCommand { get; set; }

        public MensajeViewModel()
        {
            EnviarCommand = new RelayCommand<Notificacion>(Enviar);

            Noti = new Notificacion();
        }

        public void Enviar(Notificacion n)
        {
            Error = "";
            Actualizar();
            if (Noti != null)
                n = Noti;

            if (string.IsNullOrWhiteSpace(n.Titulo))
            {
                Error = "Indique el título de la notificación";
                Actualizar();
            }
            if (string.IsNullOrWhiteSpace(n.Mensaje))
            {
                Error = "¿Cual es el cuerpo del mensaje?";
                Actualizar();
            }
            else
            {
                var json = JsonConvert.SerializeObject(n);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(json);
                UdpClient cliente = new UdpClient();
                cliente.EnableBroadcast = true;
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 2022);
                cliente.Send(buffer, buffer.Length, endPoint);
            }
        }

        public void Actualizar(string? propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
