﻿namespace Persistence.Common.Configurations;

public class ConnectionStringsOptions
{
    public const string ConnectionStrings = nameof(ConnectionStrings);
    public string DefaultConnection { get; set; }
}