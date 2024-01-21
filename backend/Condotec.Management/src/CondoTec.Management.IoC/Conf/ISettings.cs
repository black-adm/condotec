namespace CondoTec.Management.IoC.Conf
{
    public interface ISettings
    {
        public string? TokenAuth { get; }
        public MongoSettings? MongoSettings { get; }
    }
}
