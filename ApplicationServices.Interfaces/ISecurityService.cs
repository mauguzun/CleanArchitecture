namespace ApplicationServices.Interfaces
{
    public interface ISecurityService
    {
        bool ISCurrentUserISAdmin { get; }

        string[] CurrentUserPermissons { get; }
    }
}