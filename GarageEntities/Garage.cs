using System.ComponentModel.DataAnnotations;

namespace GarageEntities
{
    public class Garage
    {
        [Key] // _id הוא המפתח הראשי
        public int _id { get; set; }

        public int mispar_mosah { get; set; }

        public string shem_mosah { get; set; }

        public int cod_sug_mosah { get; set; }

        public string sug_mosah { get; set; }

        public string ktovet { get; set; }

        public string yishuv { get; set; }

        public string telephone { get; set; }

        public int mikud { get; set; }

        public int cod_miktzoa { get; set; }

        public string miktzoa { get; set; }

        public string menahel_miktzoa { get; set; }

        public long rasham_havarot { get; set; }

        public string TESTIME { get; set; }

    }
}
