﻿namespace MiddlewareAndRoutes.Models;

public class Result
{
    public string Controller {  get; set; }
    public string  Action { get; set; }
    public IDictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
}