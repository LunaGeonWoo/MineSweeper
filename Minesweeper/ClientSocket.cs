using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    internal class ClientSocket
    {
        Socket socket;

        ~ClientSocket()
        {
            socket.Close();
        }

        public bool ServerConnect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);

            try
            {
                socket.Connect(ep);

                Thread Recv = new Thread(new ThreadStart(Receive));
                Recv.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Receive()
        {
            byte[] buffer = new byte[1024];

            MainApp cf = Application.OpenForms["MainApp"] as MainApp;
            if (cf == null) return;

            while (true)
            {
                try
                {
                    int n = socket.Receive(buffer);

                    string data = Encoding.UTF8.GetString(buffer, 0, n);

                    cf.sendtomainThreadParsing(data);
                }
                catch
                {
                    break;
                }
            }
        }

        public void Send(string data)
        {
            byte[] buffer = new byte[1024];
            buffer = Encoding.UTF8.GetBytes(data);
            socket.Send(buffer, SocketFlags.None);
        }

        public void Close()
        {
            socket.Close();
        }
    }
}
