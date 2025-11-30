using System;
using System.Collections.Generic;

namespace GarageDb.EF.Models;

public partial class Garage
{
    public int Id { get; set; }

    public int MisparMosah { get; set; }

    public string ShemMosah { get; set; } = null!;

    public int CodSugMosah { get; set; }

    public string SugMosah { get; set; } = null!;

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
