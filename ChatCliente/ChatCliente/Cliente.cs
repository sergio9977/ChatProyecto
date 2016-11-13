using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatCliente
{
    public class Cliente
    {
         public string Conectar(string dato)
         {
             Socket CrearChat = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
             IPEndPoint Direccion = new IPEndPoint(IPAddress.Parse("198.0.0.1"), 1234);
             CrearChat.Connect(Direccion);
             Socket Escuchar = CrearChat.Accept();

             Console.WriteLine("Conectado con exito");


             byte[] ByRec = new byte[255];

             int a = Escuchar.Receive(ByRec, 0, ByRec.Length, 0);

             Array.Resize(ref ByRec, a);

             
             dato= Console.ReadLine();

             byte[] infoEnviar = Encoding.Default.GetBytes(dato);

             CrearChat.Send(infoEnviar, 0, infoEnviar.Length, 0);
             //Console.WriteLine("User1 dice: " + Encoding.Default.GetString(ByRec)); //mostramos lo recibido

             return Encoding.Default.GetString(ByRec);
         }
       
    }
}
