namespace FLP.DashboardEagle.Application.Dto
{
    public class EagleResponseDto
    {
        public string MachineName { get; set; }
        public int ProductKey { get; set; }
        public string ProductName { get; set; }
        public int ObjectKey { get; set; }
        public string Barcode { get; set; }
        public int Bankidx { get; set; }
        public DateTime Time { get; set; }
        public double Value { get; set; }
        public double AuxValue { get; set; }
    }
}
