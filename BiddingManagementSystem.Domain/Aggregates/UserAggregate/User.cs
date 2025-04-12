using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Aggregates.UserAggregate
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Bid> Bids { get; private set; }
        public ICollection<Tender> Tenders { get; private set; }
        public ICollection<Role> Roles { get; private set; }

        public User() 
        {
            Bids = new List<Bid>();
            Roles = new List<Role>();
            Tenders = new List<Tender>();
        }

        public User(string username, string email, string passwordHash, Address address)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Address = address;
            Bids = new List<Bid>();
            Roles = new List<Role>();
            Tenders = new List<Tender>();
        }

        public void UpdateEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }

        public void UpdateAddress(Address newAddress)
        {
            Address = newAddress;
        }

        public void AddBid(Bid bid)
        {
            Bids.Add(bid);
        }

        public void AddRole(Role role)
        {
            if(Roles == null)
            {
                Roles = new List<Role>();
            }

            if(!Roles.Any(r => r.Name == role.Name))
            {
                Roles.Add(role);
            }
        }
        
        public void AddRole(RoleType roleType)
        {
            // Check if the role collection is initialized
            if (Roles == null)
            {
                Roles = new List<Role>();
            }
            
            // Check if the role already exists
            if (!HasRole(roleType))
            {
                Roles.Add(new Role { Name = roleType.ToString() });
            }
        }
        
        public bool HasRole(RoleType roleType)
        {
            return Roles?.Any(r => r.Name == roleType.ToString()) ?? false;
        }

        public void AddTender(Tender tender)
        {
            if(Tenders == null)
            {
                Tenders = new List<Tender>();
            }
            Tenders.Add(tender);
        }
    }
}
