using DAL_factory.Factories;
using DTO_layer.DTO_s;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;

namespace LOGIC_layer.Models
{
    public class CustomerModel
    {
        public string CustomerID { get; }
        public string Name { get; }
        public string Adress { get; }
        public string Email { get; }

        public CustomerModel(string customerID, string name, string adress, string email)
        {
            CustomerID = customerID;
            Name = name;
            Adress = adress;
            Email = email;
        }

        public void Delete(string customerID)
        {
            CustomerFactory.customerConnectionHandler.DeleteCustomer(customerID);
        }

        public string GeneratedID()
        {
            string id = Guid.NewGuid().ToString();
            return id;
        }

        public void CreateCart(ShoppingCartModel cart, string customerID, string cartID)
        {
            var _dto = new DTOShoppingCart()
            {
                CartID = cartID,
                CustomerID = customerID,
                TotalPrice = cart.TotalPrice,
                CreationTime = cart.CreationTime,
            };

            ShoppingCartFactory.shoppingCartConnectionHandler.CreateShoppingCart(_dto);
        }

        public void SendEmail(string sender, string email, string name)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your GP", sender));
            message.To.Add(new MailboxAddress(name, email));
            message.Subject = "Register password";
            message.Body = new TextPart("plain")
            {
                Text = "Change your password using this link: https://localhost:44341/Account/inputpassword"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);
                client.Authenticate(sender, "TimK2002");
                var options = FormatOptions.Default.Clone();
                if (client.Capabilities.HasFlag(SmtpCapabilities.UTF8))
                {
                    options.International = true;
                }
                client.Send(options, message);
                client.Disconnect(true);
            };
        }
    }
}
