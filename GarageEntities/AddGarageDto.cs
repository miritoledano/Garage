using System;

namespace GarageEntities
{
    public class AddGarageDto
    {
        public int MisparMosah { get; set; }
        public string ShemMosah { get; set; } = string.Empty;
        public int CodSugMosah { get; set; }
        public string SugMosah { get; set; } = string.Empty;
        public string? Ktovet { get; set; }
        public string? Yishuv { get; set; }
        public string? Telephone { get; set; }
        public int? Mikud { get; set; }
        public int? CodMiktzoa { get; set; }
        public string? Miktzoa { get; set; }
        public string? MenahelMiktzoa { get; set; }
        public long? RashamHavarot { get; set; }
        public string? Testime { get; set; }
    }
}
