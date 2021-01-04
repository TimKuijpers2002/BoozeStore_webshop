using DAL_factory.Factories;
using DTO_layer.DTO_s;
using LOGIC_layer.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOGIC_layer.Collections
{
    public class CustomerCollection
    {
        private CartItemCollection cartColl;

        public CustomerCollection()
        {
            cartColl = new CartItemCollection();
        }
        public void Create(CustomerModel customer, ShoppingCartModel shoppingCartModel, List<CartItemModel> cartItemModel)
        {
            var ID = customer.GeneratedID();

            var _dto = new DTOCustomer()
            {
                CustomerID = ID,
                Name = customer.Name,
                Adress = customer.Adress,
                Email = customer.Email
            };

            customer.CreateCart(shoppingCartModel, ID);

            foreach (var item in cartItemModel)
            {
                var model = new CartItemModel(item.CartID, item.DrinkID, item.Quantity);
                cartColl.Create(model, ID);
            }

            CustomerFactory.customerConnectionHandler.CreateCustomer(_dto);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            var result = CustomerFactory.customerConnectionHandler.GetCustomers();
            var customers = new List<CustomerModel>();
            foreach (var dto in result)
            {
                customers.Add(new CustomerModel(dto.CustomerID, dto.Name, dto.Adress, dto.Email));
            }
            return customers;
        }

        public List<CustomerModel> GetByCustomerID(string ID)
        {
            var result = GetAllCustomers();
            var customer = result.Where(r => r.CustomerID.Contains(ID)).ToList();
            return customer;
        }

        public void SendEmail(string email, string name)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BoozeStore Order", "timkuijpers2002@outlook.com"));
            message.To.Add(new MailboxAddress(name, email));
            message.Subject = "Your recent order";
            message.Body = new TextPart("plain")
            {
                Text = "Change your password using this link: https://localhost:44341/Account/inputpassword"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);
                client.Authenticate("timkuijpers2002@outlook.com", "TimK2002");
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
