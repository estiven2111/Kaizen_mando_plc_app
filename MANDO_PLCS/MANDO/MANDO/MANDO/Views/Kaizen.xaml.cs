using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MANDO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kaizen : ContentPage
    {
        string ip = "172.25.214.11";
        int slot = 2;
        int rack = 0;
        int tam_byte = 32;
        int numDB = 250;
        int start_DB = 0;
        
        public Kaizen()
        {
            InitializeComponent();
        }

        private void PULSO_1_Clicked(object sender, EventArgs e)
        {

            mensaje.Text = ""; MenError.Text = "";Menadver.Text = "";
            MenError.TextColor = Color.Red;
            Menadver.TextColor = Color.DarkOrange;
            var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);
                    if (conect != 0)
                    {
                        //sal.Text = "porfavor verifica tu conexion";

                    }

            List<string> errores = new List<string>();
            errores.Add("patas no abren bien codigo error 000");
            errores.Add("grua disparada codigo error 001");
            errores.Add("traslacion bloqueada codigo error 002");
            errores.Add("codigo error 003");
            errores.Add("codigo error 004");
            errores.Add("codigo error 005");
            errores.Add("codigo error 006");
            errores.Add("codigo error 007");
            errores.Add("codigo error 008");


            //var buffer = new byte[tam_byte];
            var buffer = new byte[tam_byte];
            int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);
            //var codigo = Sharp7.S7.GetIntAt(buffer, 0);
           // var cod = Sharp7.S7.GetStringAt(buffer, 2);
            
           
            bool bit = false;
            int cont = 0;
             string [] error = { 
                "patas no abren bien codigo error 000", "grua disparada codigo error 001",
                "traslacion bloqueada codigo error 002", " codigo error 003", " codigo error 004",
                 " codigo error 005", " codigo error 006", " codigo error 007"
            };

            for (int i = 0; i <= buffer.Length-1; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                   
                    //if (error[cont++] != "") {
                        bit = Sharp7.S7.GetBitAt(buffer, i, j);
                        if (bit && (i <= 5))
                        {
                            MenError.Text = MenError.Text + i + "," + j + "--"+ error[i];
                            // MenError.Text = MenError.Text + error[i] + "\n\n\n";
                        }
                        else if (bit && (i > 5))
                        {
                            MenError.Text = MenError.Text + i + "," + j + "--";
                            //Menadver.Text = Menadver.Text + error[i] + "\n\n\n";
                        }
                        else
                        {
                            MenError.Text = MenError.Text + i + "," + j + "--";
                        }
                    //}
                }
                MenError.Text = MenError.Text + "\n\n";
            }

           
          Plugin.LocalNotifications.CrossLocalNotifications.Current.Show("title", "body", 101, DateTime.Now.AddSeconds(1));

            //if (codigo == 0)
            //{
            //    mensaje.Text = "NO HAY NINGUN ERROR PARA MOSTRAR TODO ESTA CORRECTO ";
            //    mensaje.TextColor = Color.Green;
            //}
            //else if (codigo == 1)
            //{
            //    mensaje.Text = "ERROR DE PATAS MAL CERRADAS VERIFIQUE PORFAVOR EL SENSOR DE LA PATA DERECHA YA " +
            //        "QUE ESTOY DETECTANDO QUE ESTA PATA NO TE ESTA DANDO LA SEÑAL COMO DEVERIA DE SER PORFAVOR " +
            //        "REVISA Y VALIDA NUEVAMENTE LOS ERRORES";
            //          mensaje.TextColor = Color.Red;
            //}
            //else if (codigo == 2)
            //{
            //    mensaje.Text = "ADVERTENCIA!!!!!! \n " +
            //        "POR FAVOR REVISAR COMUNICACION NO ES CONSTANTE Y PUEDE GENERAR UN PARO DE LINEA";
            //    mensaje.TextColor = Color.Yellow;
            //}


            //var escribirDB = new byte[tam_byte];


            //var pr2 = Sharp7.S7.GetByteAt(escribirDB, 0);
            //Sharp7.S7.SetIntAt( escribirDB, 0, 52);
            //Sharp7.S7.SetBitAt(ref escribirDB, 0, 0, true);
            //int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
            //int lectura =cliente.DBRead(numDB, start_DB, escribirDB.Length, escribirDB);Ç
            //mensaje.Text = lectura.ToString();
            cliente.Disconnect();
            
            

        }
        private void navegar_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://airtable.com/shrCmvcXBOsr7f4XG", BrowserLaunchMode.SystemPreferred);
        }
    }
}