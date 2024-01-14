namespace Condotec.Identity.IoC.Models
{
    public interface ISettings
    {
        public TracingSettings? TracingSettings { get; }
        public SqlServerSettings? SqlServerSettings { get; }
        public JwtOptionsSettings? JwtOptionsSettings { get; }
    }

    public class Settings : ISettings
    {
        public TracingSettings? TracingSettings { get; set; }

        public SqlServerSettings? SqlServerSettings { get; set; }

        public JwtOptionsSettings? JwtOptionsSettings { get; set; }
    }
}
