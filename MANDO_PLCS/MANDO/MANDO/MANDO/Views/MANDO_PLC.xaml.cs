using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MANDO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MANDO_PLC : ContentPage
    {
        string ip = "172.25.214.11";
        int slot = 2;
        int rack = 0;
        int tam_byte = 1;
        int numDB = 250;
        int start_DB = 0;
        public MANDO_PLC()
        {
            InitializeComponent();
            SUBIR_ON.BackgroundColor = Color.Green;
            BAJAR_ON.BackgroundColor = Color.Green;
            ADELANTE_ON.BackgroundColor = Color.Green;
            ATRAS_ON.BackgroundColor = Color.Green;
            ABRIR_ON.BackgroundColor = Color.Green;
            CERRAR_ON.BackgroundColor = Color.Green;


        }


        private void PULSO_1_Clicked(object sender, EventArgs e)
        {

            var boton = sender as Button;

            if (boton != null)
            {
                string text = boton.Text;
                if (text == "SUBIR_ON")
                {
                    BAJAR_ON.BackgroundColor = Color.Green;
                    BAJAR_ON.Text = "BAJAR_ON";
                    ADELANTE_ON.BackgroundColor = Color.Green;
                    ADELANTE_ON.Text = "ADELANTE_ON";
                    ATRAS_ON.BackgroundColor = Color.Green;
                    ATRAS_ON.Text = "ATRAS_ON";
                    ABRIR_ON.BackgroundColor = Color.Green;
                    ABRIR_ON.Text = "ABRIR_ON";
                    CERRAR_ON.BackgroundColor = Color.Green;
                    CERRAR_ON.Text = "CERRAR_ON";

                    ATRAS_ON.Text = "ATRAS_ON";
                    boton.BackgroundColor = Color.Red;
                    boton.Text = "SUBIR_OFF";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip,rack,slot);
                    if (conect != 0)
                    {
                        //sal.Text = "porfavor verifica tu conexion";

                    }


                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 0, true);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();

                }
                else
                {


                    boton.BackgroundColor = Color.Green;
                    boton.Text = "SUBIR_ON";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);
                    if (conect != 0)
                    {
                        //sal.Text = "porfavor verifica tu conexion";
                    }
                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 0, false);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();

                }

            }

        }

        private void PULSO_2_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;


            if (boton != null)
            {
                string text = boton.Text;
                if (text == "BAJAR_ON")
                {
                    SUBIR_ON.BackgroundColor = Color.Green;
                    SUBIR_ON.Text = "SUBIR_ON";
                    BAJAR_ON.BackgroundColor = Color.Green;
                    ADELANTE_ON.BackgroundColor = Color.Green;
                    ADELANTE_ON.Text = "ADELANTE_ON";
                    ATRAS_ON.BackgroundColor = Color.Green;
                    ATRAS_ON.Text = "ATRAS_ON";
                    ABRIR_ON.BackgroundColor = Color.Green;
                    ABRIR_ON.Text = "ABRIR_ON";
                    CERRAR_ON.BackgroundColor = Color.Green;
                    CERRAR_ON.Text = "CERRAR_ON";

                    boton.BackgroundColor = Color.Red;
                    boton.Text = "BAJAR_OFF";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 1, true);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);

                    cliente.Disconnect();

                    
                }
                else
                {


                    boton.BackgroundColor = Color.Green;
                    boton.Text = "BAJAR_ON";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 1, false);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();

                }

            }


        }

        private void PULSO_3_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;

            if (boton != null)
            {
                string text = boton.Text;
                if (text == "ADELANTE_ON")
                {
                    SUBIR_ON.BackgroundColor = Color.Green;
                    SUBIR_ON.Text = "SUBIR_ON";
                    BAJAR_ON.BackgroundColor = Color.Green;
                    BAJAR_ON.Text = "BAJAR_ON";
                    ATRAS_ON.BackgroundColor = Color.Green;
                    ATRAS_ON.Text = "ATRAS_ON";
                    ABRIR_ON.BackgroundColor = Color.Green;
                    ABRIR_ON.Text = "ABRIR_ON";
                    CERRAR_ON.BackgroundColor = Color.Green;
                    CERRAR_ON.Text = "CERRAR_ON";

                    boton.BackgroundColor = Color.Red;
                    boton.Text = "ADELANTE_OFF";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 2, true);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();

                }
                else
                {

                    boton.BackgroundColor = Color.Green;
                    boton.Text = "ADELANTE_ON";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 2, false);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();
                }

            }
        }


        private void PULSO_4_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;

            if (boton != null)
            {
                string text = boton.Text;
                if (text == "ATRAS_ON")
                {
                    SUBIR_ON.BackgroundColor = Color.Green;
                    SUBIR_ON.Text = "SUBIR_ON";
                    BAJAR_ON.BackgroundColor = Color.Green;
                    BAJAR_ON.Text = "BAJAR_ON";
                    ADELANTE_ON.BackgroundColor = Color.Green;
                    ADELANTE_ON.Text = "ADELANTE_ON";
                    ABRIR_ON.BackgroundColor = Color.Green;
                    ABRIR_ON.Text = "ABRIR_ON";
                    CERRAR_ON.BackgroundColor = Color.Green;
                    CERRAR_ON.Text = "CERRAR_ON";

                    boton.BackgroundColor = Color.Red;
                    boton.Text = "ATRAS_OFF";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 3, true);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();

                }
                else
                {

                    boton.BackgroundColor = Color.Green;
                    boton.Text = "ATRAS_ON";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 3, false);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();
                }

            }
        }


        private void PULSO_5_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;

            if (boton != null)
            {
                string text = boton.Text;
                if (text == "ABRIR_ON")
                {
                    SUBIR_ON.BackgroundColor = Color.Green;
                    SUBIR_ON.Text = "SUBIR_ON";
                    BAJAR_ON.BackgroundColor = Color.Green;
                    BAJAR_ON.Text = "BAJAR_ON";
                    ADELANTE_ON.BackgroundColor = Color.Green;
                    ADELANTE_ON.Text = "ADELANTE_ON";
                    ATRAS_ON.BackgroundColor = Color.Green;
                    ATRAS_ON.Text = "ATRAS_ON";
                    CERRAR_ON.BackgroundColor = Color.Green;
                    CERRAR_ON.Text = "CERRAR_ON";

                    boton.BackgroundColor = Color.Red;
                    boton.Text = "ABRIR_OFF";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 4, true);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();

                }
                else
                {

                    boton.BackgroundColor = Color.Green;
                    boton.Text = "ABRIR_ON";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 4, false);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();
                }

            }
        }

        private void PULSO_6_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;

            if (boton != null)
            {
                string text = boton.Text;
                if (text == "CERRAR_ON")
                {
                    SUBIR_ON.BackgroundColor = Color.Green;
                    SUBIR_ON.Text = "SUBIR_ON";
                    BAJAR_ON.BackgroundColor = Color.Green;
                    BAJAR_ON.Text = "BAJAR_ON";
                    ADELANTE_ON.BackgroundColor = Color.Green;
                    ADELANTE_ON.Text = "ADELANTE_ON";
                    ATRAS_ON.BackgroundColor = Color.Green;
                    ATRAS_ON.Text = "ATRAS_ON";
                    ABRIR_ON.BackgroundColor = Color.Green;
                    ABRIR_ON.Text = "ABRIR_ON";

                    boton.BackgroundColor = Color.Red;
                    boton.Text = "CERRAR_OFF";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 5, true);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();

                }
                else
                {

                    boton.BackgroundColor = Color.Green;
                    boton.Text = "CERRAR_ON";
                    var cliente = new Sharp7.S7Client();
                    int conect = cliente.ConnectTo(ip, rack, slot);

                    var buffer = new byte[tam_byte];
                    int leerDB = cliente.DBRead(numDB, start_DB, buffer.Length, buffer);

                    var escribirDB = new byte[tam_byte];
                    Sharp7.S7.SetBitAt(ref escribirDB, 0, 5, false);
                    int resultadoescritura = cliente.DBWrite(numDB, start_DB, escribirDB.Length, escribirDB);
                    cliente.Disconnect();
                }

            }

        }
        private void PRU_Clicked(object sender, EventArgs e)
        {

        }
    }
}