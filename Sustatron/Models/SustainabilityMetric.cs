using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models;

public class SustainabilityMetric
{
    [Key]
    public int Id { get; set; }
    public string metricName { get; set; }
    public string description { get; set; }
    public string unit { get; set; }
}