using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Model;

namespace ecommerce.Data
{
    public class ProductDetails
    {
        [Key]
        public int ProductDetailId { get; set; }
        public string Name { get; set; }
        public string ImgUrl1 { get; set; }
        public string ImgUrl2 { get; set; }
        public string ImgUrl3 { get; set; }
        public string OperatingSystem { get; set; }
        public string Manufacturer { get; set; }
        public string Cpu { get; set; }
        public string CpuSpeed { get; set; }
        public string NumCores { get; set; }
        public string CacheType { get; set; }
        public string CacheSize { get; set; }
        public string ChipsetType { get; set; }
        public string Features { get; set; }
        public string RamType { get; set; }
        public string RamSpeed { get; set; }
        public string RamSize { get; set; }
        public string DisplayTech { get; set; }
        public string DisplayResolution { get; set; }
        public string DisplaySize { get; set; }
        public string DisplayType { get; set; }
        public string GraphicName { get; set; }
        public string GraphicSize { get; set; }
        public string Webcam { get; set; }
        public string Sound { get; set; }
        public string AudioCodec { get; set; }
        public string HardDriveType { get; set; }
        public string HardDriveSize { get; set; }
        public string InputType { get; set; }
        public string WirelessProtocol { get; set; }
        public string WirelessController { get; set; }
        public string Bluetooth { get; set; }
        public string CardReaderType { get; set; }
        public string CardReaderSupport { get; set; }
        public string BatterySize { get; set; }
        public string BaterryCells { get; set; }
        public string Dimensions { get; set; }
        public string Mainboard { get; set; }
        public string Weight { get; set; }
        public string Backlight { get; set; }

    }
}
