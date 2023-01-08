using ApplicationServices.Interfaces;

namespace ApplicatonServices.Implementation
{
    public class SecurityService : ISecurityService
    {
        public bool ISCurrentUserISAdmin => throw new NotImplementedException();

        public string[] CurrentUserPermissons => throw new NotImplementedException();
    }
}