using CannedFactoryContracts.ViewModels;
using System.Collections.Generic;

namespace CannedFactoryBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportCannedComponentViewModel> CannedComponents { get; set; }
    }
}
