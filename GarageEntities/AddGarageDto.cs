using System;

namespace GarageEntities
{
    public class AddGarageDto
    {
        // מחלקה זו מייצגת Data Transfer Object (DTO) עבור מוסך
        // כלומר, מבנה נתונים שמטרתו לשמש להעברת מידע בין ה-Frontend ל-Backend
//נניח פה שדה ה ID לא מוצג כי לא רוצים להציג למשתמש וזה קוד שיוצר גמישות בקוד 
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
