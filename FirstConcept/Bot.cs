using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenMetaverse;


namespace FirstConcept
{
//This is the code that will communicate from the virtual world to the application

class Bot { //This contains all the funtions that are required for the bot to communicate with the second life grid. public static GridClient Client = new GridClient();
    public GridClient Client = new GridClient();
    //Login information for the grid
    private static string first_name;
    private static string last_name;
    private static string password;

    static void Main(string[] args)
    {
       //Prompts the user for their login information: First Name: Last Name: Password:
       //I'm not sure if we will need to make this more secure?
        Console.WriteLine("First Name: ");
        first_name = Console.ReadLine();
        Console.WriteLine("Last Name: ");
        last_name = Console.ReadLine();
        Console.WriteLine("Password: ");
        password = Console.ReadLine();

      //Logs into the VDC 1 at the home position located at the bottom of the holodome viewing room
        Client.Settings.LOGIN_SERVER = "http://virtualdiscoverycenter.net:8002/";

      //Creates a new event that processes all the login inormation
        Client.Network.LoginProgress += new EventHandler<LoginProgressEventArgs>(Network_LoginProgress);

      //if else test to check if the log in was successful. If login was unsuccessful then it tells the user why.
        if (Client.Network.Login(first_name, last_name, password, "My First Bot", "NAO Jeremy"))
        {
            Console.WriteLine("I logged into Second Life!");
        }
        else
        {
            Console.WriteLine("I couldn't log in, here is why: " + Client.Network.LoginMessage);
            Console.WriteLine("press enter to close...");
            Console.ReadLine();
        }

      //Creates an event for the bot to listen for messages in the Virtual World. 
        Client.Self.ChatFromSimulator += new EventHandler<ChatEventArgs>(Self_ChatFromSimulator);
    }

  //I dont know if this is necessary to the code. It's just pretty much a 'hellow world' code
    static void Network_LoginProgress(object sender, LoginProgressEventArgs e)
    {
        if (e.Status == LoginStatus.Success)
        {
            Console.WriteLine("I'm connected to the simulator, going to greet everyone around me");
            Client.Self.Chat("Hellow World!", 0, ChatType.Normal);
        }
    }

  //This listens for chat commands in the virtual world
    static void Self_ChatFromSimulator(object sender, ChatEventArgs e)
    {
      //Prints the messages from the virtual world.
        Console.WriteLine(e.Message);

      //If the message in the virtual world is exit, it logs the bot out of the VDC
        if (e.Message == "Exit")
        {
            Console.WriteLine("Now I am going to logout of SL.. Goodbye!");
            Client.Network.Logout();
            Console.WriteLine("I am Loged out please press enter to close...");
            Console.ReadLine();
            //Key id for the bot
            //a37a28ef-6ff1-4f77-8e14-6dfadeed8d4

        }
    }
}
}