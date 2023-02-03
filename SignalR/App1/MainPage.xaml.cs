using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public String UserName { get; set; }
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8081/signalr";
        public HubConnection Connection { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            HubProxy.Invoke("Send", UserName, TextBoxMessage.Text);
            TextBoxMessage.Text = String.Empty;
            TextBoxMessage.Focus(FocusState.Programmatic);
        }
        /// <summary>
        /// Creates and connects the hub connection and hub proxy. This method
        /// is called asynchronously from SignInButton_Click.
        /// </summary>
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Error += Connection_Error;
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            HubProxy.On<string, string>("AddMessage", (name, message) =>
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Paragraph p = new Paragraph();
                    p.Inlines.Add(new Run { Text = $"{name}: {message}" });
                    RichTextBoxConsole.Blocks.Add(p);
                }
                )
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            );
            try
            {
                await Connection.Start(new WebSocketTransport());

                //await Connection.Start();
            }
            catch (HttpRequestException)
            {
                StatusText.Text = "Unable to connect to server: Start server before connecting clients.";
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Show chat UI; hide login UI
            SignInPanel.Visibility = Visibility.Collapsed;
            ChatPanel.Visibility = Visibility.Visible;
            ButtonSend.IsEnabled = true;
            TextBoxMessage.Focus(FocusState.Programmatic);

            Paragraph p2 = new Paragraph();
            p2.Inlines.Add(new Run { Text = $"Connected to server at {ServerURI}\r" });
            RichTextBoxConsole.Blocks.Add(p2);
        }

        private void Connection_Error(Exception obj)
        {
            var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ChatPanel.Visibility = Visibility.Visible;
                Paragraph p = new Paragraph();
                p.Inlines.Add(new Run { Text = $"Error: {obj}\r" });
                RichTextBoxConsole.Blocks.Add(p);
            });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        /// <summary>
        /// If the server is stopped, the connection will time out after 30 seconds (default), and the 
        /// Closed event will fire.
        /// </summary>
        void Connection_Closed()
        {
            //Hide chat UI; show login UI
            var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ChatPanel.Visibility = Visibility.Collapsed;
                ButtonSend.IsEnabled = false;
                StatusText.Text = "You have been disconnected.";
                SignInPanel.Visibility = Visibility.Visible;
            });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            UserName = UserNameTextBox.Text;
            //Connect to server (use async method to avoid blocking UI thread)
            if (!String.IsNullOrEmpty(UserName))
            {
                StatusText.Visibility = Visibility.Visible;
                StatusText.Text = "Connecting to server...";
                ConnectAsync();
            }

        }
    }
}
