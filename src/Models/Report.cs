﻿namespace Models;

public class Report
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ReportType ReportType { get; set; }

    public IEnumerable<ReportField> Fields { get; set; }
}