﻿namespace CondoTec.Management.IoC.Conf
{
    public record Settings : ISettings
    {
        public string? TokenAuth { get; set; }

        public MongoSettings? MongoSettings { get; set; }
    }
}
