using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExample
{
    class User
    {
        public IChatRoom ChatRoom { get; set; }
        public string Username { get; set; }
        public void Send()
        {
            Console.Write("Enter Message : ");
            var message = Console.ReadLine();
            this.ChatRoom.BroadCast(this, message);
        }
        public void Recieve(string message, string from)
        {
            Console.Write("{0} have message from {1} :", this.Username, from);
            Console.WriteLine(message);
        }
    }

    interface IChatRoom
    {
        List<User> Users { get; set; }
        void BroadCast(User sender, string message);
    }

    class ChatRoom : IChatRoom
    {
        public List<User> Users { get; set; }
        public void BroadCast(User sender, string message)
        {
            Users.ForEach(
                u =>
                {
                    if (u.Username != sender.Username)
                    {
                        u.Recieve(message, sender.Username);
                    }
                }
                );
        }
    }



    
    class Program
    {
        static void Main(string[] args)
        {
            IChatRoom chatRoom = new ChatRoom();
            List<User> users = new List<User> {
            new User
            {
                Username="Iman",
                ChatRoom=chatRoom
            },
            new User
            {
                Username="Haci",
                ChatRoom=chatRoom
            },
            new User
            {
                Username="Rashid",
                ChatRoom=chatRoom
            },
            new User
            {
                Username="Zabil",
                ChatRoom=chatRoom
            },
            };
            chatRoom.Users = users;
            while (true)
            {
                Console.Write("Write your username : ");
                var username = Console.ReadLine();

                var user = users.FirstOrDefault(e => e.Username == username);
                if (user != null)
                {
                    user.Send();
                }
                Console.WriteLine();
            }

        }
    }
}
