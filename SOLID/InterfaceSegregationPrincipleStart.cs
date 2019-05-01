using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// In this code, we see that we are getting a UserModel, but we are getting more details than what we need.
    /// Also see the LSP for other examples such as the NotImplementedException.
    /// </summary>
    public class InterfaceSegregationPrincipleStart
    {
        private UserRepository _userRepo = new UserRepository();
        private Emailer _emailer = new Emailer();

        public void SendEmail(int userId)
        {
            var user = _userRepo.GetUser(1);
            _emailer.Email(user.EmailAddress);
        }
    }

    public class UserRepository
    {
        public UserModel GetUser(int id)
        {
            return new UserModel()
            {
                Id = 1,
                EmailAddress = "me@here.com",
                Name = "User Name",
                PhoneNumber = "555-369-8874"
            };
        }
    }

    public class Emailer
    {
        public void Email(string emailAddress)
        {
            Console.WriteLine("Emailed" + emailAddress);
        }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
