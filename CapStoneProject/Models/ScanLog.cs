using System.ComponentModel.DataAnnotations;

namespace CapStoneProject.Models
{
    public class ScanLog
    {
        [Key]
        public int LogID { get; set; }

        [Required]
        public string TargetIPAddress { get; set; }

        public DateTime ScanTimestamp { get; set; } = DateTime.Now;

        public string OpenPortsDetected { get; set; }

        public int ScanDurationMs { get; set; }
    }
}