﻿namespace hangfire_libs.Configurations;

public class DatabaseSettings
{
    public string DBProvider { get; set; }
    
    public string ConnectionString { get; set; }
    
    public string DatabaseName { get; set; }
}