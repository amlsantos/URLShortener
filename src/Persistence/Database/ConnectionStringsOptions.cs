﻿namespace Persistence.Database;

public class ConnectionStringsOptions
{
    public static string ConnectionStrings = nameof(ConnectionStrings);
    public string DefaultConnection { get; set; }
}