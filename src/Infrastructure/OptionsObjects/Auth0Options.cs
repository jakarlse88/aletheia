namespace Aletheia.Infrastructure.OptionsObjects
{
    internal class Auth0Options
    {
        internal static string Auth0 => "Auth0";

        internal string Authority { get; set; }
        internal string ApiIdentifier { get; set; }
    }
}
