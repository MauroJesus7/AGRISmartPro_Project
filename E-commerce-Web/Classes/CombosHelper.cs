using AGRISmartPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGRISmartPro.Classes
{
    public class CombosHelper : IDisposable
    {
        private static AppDbContext db = new AppDbContext();
        
        public static List<Crop> GetCrops()
        {
            var crops = db.Crops.ToList();
            crops.Add(new Crop
            {
                CropId = 0,
                Name = "[ Select a crop ]"
            });

            return crops = crops.OrderBy(c => c.Name).ToList();
        }

        public static List<Disease> GetDiseases()
        {
            var diseases = db.Diseases.ToList();
            //diseases.Add(new Disease
            //{
            //    DiseaseId = 0,
            //    Name = "[ Select a disease ]"
            //});

            return diseases = diseases.OrderBy(d => d.Name).ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}