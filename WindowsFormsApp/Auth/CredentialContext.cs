using System;

namespace WindowsFormsApp.Auth
{
    class CredentialContext : ICredentialContext
    {
        public string MySQL_Password { get; set; } =
            Environment.GetEnvironmentVariable("Project_WindowsFormsApp.MySQL_Password", EnvironmentVariableTarget.User);
    }
}
