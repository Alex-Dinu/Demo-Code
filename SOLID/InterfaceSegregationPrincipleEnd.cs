using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// Here, we are splitting up the large userDetails class into smaller ones and inherit from the individual interfaces when we need the whole user data object.
    /// </summary>
    class InterfaceSegregationPrincipleEnd
    {
        private UserRepository1 _userRepo = new UserRepository1();
        private Emailer _emailer = new Emailer();

        public void SendEmail(int userId)
        {
            var userEmailData = _userRepo.GetUserEmail(1);
            _emailer.Email(userEmailData.EmailAddress);
        }
    }


    public class UserRepository1
    {
        public TheWholeUser GetUser(int id)
        {
            return new TheWholeUser()
            {
                Id = 1,
                EmailAddress = "me@here.com",
                Name = "User Name",
                PhoneNumber = "555-369-8874"
            };
        }

        public UserEmailDetails GetUserEmail(int id)
        {
            var user = new TheWholeUser()
            {
                Id = 1,
                EmailAddress = "me@here.com",
                Name = "User Name",
                PhoneNumber = "555-369-8874"
            };

            UserEmailDetails emailData = new UserEmailDetails()
            {
                EmailAddress = user.EmailAddress
            };

            return emailData;
        }
    }


    public class TheWholeUser : IUserEmailDetails, IUserModel1
    {
        public string EmailAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
    public interface IUserModel1
    {
        int Id { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
    }
    public class UserModel1 : IUserModel1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }


    public interface IUserEmailDetails
    {
        string EmailAddress { get; set; }
    }
    public class UserEmailDetails: IUserEmailDetails
    {
        public string EmailAddress { get; set; }

    }
}
